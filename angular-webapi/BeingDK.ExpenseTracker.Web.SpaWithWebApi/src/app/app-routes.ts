import { ExpensesComponent } from "./expenses/expenses.component";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { ExpenseCategoryComponent } from "./expense-category/expense-category.component";
import { CreateExpenseCategoryComponent } from "./create-expense-category/create-expense-category.component";
import { EditExpensesCategoryComponent } from "./edit-expenses-category/edit-expenses-category.component";
import { HomeComponent } from "./home.component";
import { Routes } from "@angular/router";
import { EditExpenseComponent } from "./edit-expense/edit-expense.component";

export const APP_ROTES: Routes = [
  {
    path: 'expenses',
    component: ExpensesComponent,
    data: { title: 'Expenses' }
  },
  {
    path: 'expenses/:id',
    component: EditExpenseComponent,
    data: { title: 'Edit Expense' }
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
    data: { title: 'Dashboard' }
  },
  {
    path: 'expense-categories',
    component: ExpenseCategoryComponent,
    data: { title: 'Expense Categories' }
  },
  {
    path: 'expense-categories/create',
    component: CreateExpenseCategoryComponent,
    data: { title: 'Expense Categories' }
  },
  {
    path: 'expense-categories/:id',
    component: EditExpensesCategoryComponent,
    data: { title: 'Expense Categories' }
  },
  {
    path: '',
    component: HomeComponent,
    data: { title: 'Home' }
  }
];
