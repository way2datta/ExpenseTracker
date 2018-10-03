import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ExpenseCategory } from '../entities/ExpenseCategory';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ExpensesCategoryService } from '../expenses-category.service';

const categoriesUrl = 'http://localhost:61415/api/ExpenseCategories';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Component({
  selector: 'app-create-expense-category',
  templateUrl: './create-expense-category.component.html',
  styleUrls: ['./create-expense-category.component.css']
})
export class CreateExpenseCategoryComponent implements OnInit {
  createExpenseCategoryForm = new FormGroup({
    name: new FormControl('')
  });

  constructor(private expensesCategoryService: ExpensesCategoryService) {
  }


  ngOnInit() {
  }

  onSubmit() {
    this.addExpenseCategory(this.createExpenseCategoryForm.value);
  }

  addExpenseCategory(expenseCategory: ExpenseCategory): void {
    this.expensesCategoryService.addExpenseCategory(expenseCategory)
      .subscribe(hero => {
        console.log("This is it: "+hero);

      });
  }
}

