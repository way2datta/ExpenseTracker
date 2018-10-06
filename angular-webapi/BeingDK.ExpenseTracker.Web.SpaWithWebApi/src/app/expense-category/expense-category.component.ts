import { Component, OnInit } from '@angular/core';
import { ExpenseCategory } from '../entities/ExpenseCategory';
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

  getExpenseCategories(): void {
    this.expensesCategoryService.getExpenseCategories()
        .subscribe(categories => this.categories = categories);
  }

  ngOnInit() {
    this.getExpenseCategories();
  }

  deleteExpenseCategory(id: number): void {
    if (confirm('Are you sure to delete this record ?') == true) {
      this.expensesCategoryService.deleteExpenseCategory(id)
      .subscribe(x => {
        this.getExpenseCategories();
      })
    }
  }
}
