import { Injectable } from '@angular/core';
import { EXPENSE_CATEGORIES } from "./mock-expense-categories";
import { ExpenseCategory } from './entities/ExpenseCategory';

@Injectable({
  providedIn: 'root'
})
export class ExpensesCategoryService {
  constructor() { }

  getExpenseCategories(): ExpenseCategory[] {
    return EXPENSE_CATEGORIES;
  }
}
