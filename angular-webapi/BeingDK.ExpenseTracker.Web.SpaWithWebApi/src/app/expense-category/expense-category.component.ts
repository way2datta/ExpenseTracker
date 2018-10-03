import { Component, OnInit } from '@angular/core';
import { ExpenseCategory } from '../entities/ExpenseCategory';
import { EXPENSE_CATEGORIES } from '../mock-expense-categories';
import { ExpensesCategoryService } from '../expenses-category.service';


@Component({
  selector: 'app-expense-category',
  templateUrl: './expense-category.component.html',
  styleUrls: ['./expense-category.component.css']
})
export class ExpenseCategoryComponent implements OnInit {
  categories: ExpenseCategory[];

  constructor(private expensesCategoryService: ExpensesCategoryService) {
  }

  getHeroes(): void {
    this.categories = this.expensesCategoryService.getExpenseCategories();
  }

  ngOnInit() {
    this.getHeroes();
  }
}
