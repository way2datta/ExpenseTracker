import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ExpenseCategory } from '../entities/ExpenseCategory';
import { ExpensesCategoryService } from '../expenses-category.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-expense-category',
  templateUrl: './create-expense-category.component.html',
  styleUrls: ['./create-expense-category.component.css']
})
export class CreateExpenseCategoryComponent implements OnInit {
  createExpenseCategoryForm = new FormGroup({
    name: new FormControl('')
  });

  constructor(private expensesCategoryService: ExpensesCategoryService, private router: Router) {
  }

  ngOnInit() {
  }

  onSubmit() {
    this.addExpenseCategory(this.createExpenseCategoryForm.value);
  }

  addExpenseCategory(expenseCategory: ExpenseCategory): void {
    this.expensesCategoryService.addExpenseCategory(expenseCategory)
      .subscribe(category => {
        this.router.navigate(['/expense-categories']);
      });
  }
}

