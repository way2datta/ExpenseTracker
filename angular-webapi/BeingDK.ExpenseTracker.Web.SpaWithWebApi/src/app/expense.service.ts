import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Expense } from './entities/Expense';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const expenseUrl = 'http://localhost:61415/api/Expenses';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {

  constructor(private http: HttpClient) { }

  getExpenses(): Observable<Expense[]> {
    return this.http.get<Expense[]>(expenseUrl, httpOptions);
  }

  getExpense(id: number): Observable<Expense> {
    return this.http.get<Expense>(expenseUrl +"/"+id, httpOptions);
  }

  updateExpense(expense: Expense): Observable<Expense> {
    return this.http.put<Expense>(expenseUrl+"/"+expense.id, expense, httpOptions);
  }
}
