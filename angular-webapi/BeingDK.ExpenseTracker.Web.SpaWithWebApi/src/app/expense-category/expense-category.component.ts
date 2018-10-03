import { Component, OnInit } from '@angular/core';
import { ExpenseCategory } from '../entities/ExpenseCategory';

const EXPENSE_CATEGORIES = [
  new ExpenseCategory(1, 'Bills'),
  new ExpenseCategory(2, 'Grocery'),
  new ExpenseCategory(3, 'Food')
];

@Component({
  selector: 'app-expense-category',
  templateUrl: './expense-category.component.html',
  styleUrls: ['./expense-category.component.css']
})
export class ExpenseCategoryComponent implements OnInit {
  categories: ExpenseCategory[];

  constructor() {
    this.categories = EXPENSE_CATEGORIES;
  }

  ngOnInit() {
  }

}
