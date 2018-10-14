import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Expense } from './entities/Expense';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const categoriesUrl = 'http://localhost:61415/api/Expenses';
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
    return this.http.get<Expense[]>(categoriesUrl, httpOptions);
  }

  getExpense(id: number): Observable<Expense> {
    return this.http.get<Expense>(categoriesUrl +"/"+id, httpOptions);
  }

}
