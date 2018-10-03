import { EXPENSE_CATEGORIES } from "./mock-expense-categories";
import { ExpenseCategory } from './entities/ExpenseCategory';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';

//http://localhost:61415/api/ExpenseCategories
const endpoint = 'http://localhost:61415/api/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ExpensesCategoryService {
  constructor(private http: HttpClient) { }

  getExpenseCategories(): Observable<ExpenseCategory[]> {
    return of(EXPENSE_CATEGORIES);
  }
}
