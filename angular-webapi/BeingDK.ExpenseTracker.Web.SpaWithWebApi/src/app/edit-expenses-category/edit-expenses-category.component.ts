import { Component, OnInit } from '@angular/core';
import { ExpensesCategoryService } from '../expenses-category.service';
import { ExpenseCategory } from '../entities/ExpenseCategory';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-expenses-category',
  templateUrl: './edit-expenses-category.component.html',
  styleUrls: ['./edit-expenses-category.component.css']
})
export class EditExpensesCategoryComponent implements OnInit {
  category: ExpenseCategory= {id: 0, name: ''};

  constructor(private expensesCategoryService: ExpensesCategoryService,
    private route: ActivatedRoute, private router: Router) {
  }

  ngOnInit() {
    let categoryId = 0;
    this.route.params.subscribe(
      x=> categoryId = x.id
    );
    this.expensesCategoryService.getExpenseCategory(categoryId)
    .subscribe(c => this.category = c);
  }

  updateExpenseCategory(category) {
    console.log(category);
    this.expensesCategoryService.updateExpenseCategory(category)
    .subscribe(c => {
      this.router.navigate(['/expense-categories/']);
    });
  }
}
