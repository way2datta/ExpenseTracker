import { Component, OnInit, Input } from '@angular/core';
import { Expense } from '../expense';
@Component({
  selector: 'app-expense-details',
  templateUrl: './expense-details.component.html',
  styleUrls: ['./expense-details.component.css']
})
export class ExpenseDetailsComponent implements OnInit {
  @Input() expense: Expense;
  constructor() { }

  ngOnInit() {
  }

}
