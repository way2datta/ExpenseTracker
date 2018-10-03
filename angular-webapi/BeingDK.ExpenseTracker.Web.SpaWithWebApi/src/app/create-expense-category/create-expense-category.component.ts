import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-expense-category',
  templateUrl: './create-expense-category.component.html',
  styleUrls: ['./create-expense-category.component.css']
})
export class CreateExpenseCategoryComponent implements OnInit {
  createExpenseCategoryForm = new FormGroup({
    name: new FormControl('')
  });

  constructor() { }

  ngOnInit() {
  }

  onSubmit() {
    // TODO: Use EventEmitter with form value
    console.warn(this.createExpenseCategoryForm.value);
  }
}
