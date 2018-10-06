import { ExpenseCategory } from './entities/ExpenseCategory';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

const categoriesUrl = 'http://localhost:61415/api/ExpenseCategories';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ExpensesCategoryService {
  constructor(private http: HttpClient) { }

  getExpenseCategories(): Observable<ExpenseCategory[]> {
    return this.http.get<ExpenseCategory[]>(categoriesUrl)
  }

  getExpenseCategory(id: number): Observable<ExpenseCategory> {
    return this.http.get<ExpenseCategory>(categoriesUrl+"/"+id)
  }

  addExpenseCategory (expenseCategory: ExpenseCategory): Observable<ExpenseCategory> {
      return this.http.post<ExpenseCategory>(categoriesUrl, expenseCategory, httpOptions);
  }

  deleteExpenseCategory (id: number): Observable<ExpenseCategory> {
      return this.http.delete<ExpenseCategory>(categoriesUrl+'/' + id);
  }
}
