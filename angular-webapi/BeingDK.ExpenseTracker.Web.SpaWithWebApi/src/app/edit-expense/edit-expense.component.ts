import { Component, OnInit } from '@angular/core';
import { Expense } from '../entities/Expense';
import { ExpenseService } from '../expense.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-expense',
  templateUrl: './edit-expense.component.html',
  styleUrls: ['./edit-expense.component.css']
})
export class EditExpenseComponent implements OnInit {
  expense: Expense;

  constructor(private expenseService: ExpenseService,
    private route:ActivatedRoute) {


  }

  ngOnInit() {
      let expenseId= 0;
      this.route.params.subscribe(
        x=> expenseId =x.id
      );

      this.expenseService.getExpense(expenseId)
      .subscribe(x=>this.expense = x);
  }

}
