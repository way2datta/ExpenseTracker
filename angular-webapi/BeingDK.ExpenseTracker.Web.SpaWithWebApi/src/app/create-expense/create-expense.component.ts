import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Expense } from '../entities/Expense';
import { ExpenseService } from '../expense.service';
import { Router } from '@angular/router';
import { ExpensesCategoryService } from '../expenses-category.service';
import { ExpenseCategory } from '../entities/ExpenseCategory';

@Component({
  selector: 'app-create-expense',
  templateUrl: './create-expense.component.html',
  styleUrls: ['./create-expense.component.css']
})
export class CreateExpenseComponent implements OnInit {
  createExpenseForm = new FormGroup({
    amount: new FormControl(''),
    categoryId: new FormControl(''),
    description: new FormControl(''),
    incurredAt: new FormControl('')
  });
  categories: ExpenseCategory[];

  constructor(private expenseService: ExpenseService, private expenseCategoryService: ExpensesCategoryService, private router: Router) { }

  ngOnInit() {
    this.expenseCategoryService
      .getExpenseCategories()
      .subscribe(x => this.categories = x);
  }

  onSubmit() {
    this.addExpense(this.createExpenseForm.value);
  }

  addExpense(expense: Expense): void {
    this.expenseService.addExpense(expense)
      .subscribe(e => {
        this.router.navigate(['/expenses']);
      });
  }

}
