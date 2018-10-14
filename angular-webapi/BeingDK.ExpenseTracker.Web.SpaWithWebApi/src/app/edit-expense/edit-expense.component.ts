import { Component, OnInit } from '@angular/core';
import { Expense } from '../entities/Expense';
import { ExpenseService } from '../expense.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ExpenseCategory } from '../entities/ExpenseCategory';

@Component({
  selector: 'app-edit-expense',
  templateUrl: './edit-expense.component.html',
  styleUrls: ['./edit-expense.component.css']
})
export class EditExpenseComponent implements OnInit {
  expense: Expense = new Expense();
  categories: ExpenseCategory[];

  constructor(private expenseService: ExpenseService,
    private route:ActivatedRoute,
    private router: Router) {

  }

  ngOnInit() {
      let expenseId= 0;
      this.route.params.subscribe(
        x=> expenseId =x.id
      );

      this.expenseService.getExpense(expenseId)
      .subscribe(x=>this.expense = x);
  }

  updateExpense(expense)
  {
    debugger;
    console.log(expense);
    this.expenseService.updateExpense(expense)
    .subscribe(c => {
      this.router.navigate(['/expenses/']);
    });
  }
}
