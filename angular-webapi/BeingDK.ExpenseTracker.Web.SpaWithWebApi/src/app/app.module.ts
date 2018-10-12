import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HomeComponent } from './home.component';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { ExpensesComponent } from '../app/expenses/expenses.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ExpenseCategoryComponent } from './expense-category/expense-category.component';
import { CreateExpenseCategoryComponent } from './create-expense-category/create-expense-category.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { EditExpensesCategoryComponent } from './edit-expenses-category/edit-expenses-category.component';
import { APP_ROTES } from './app-routes';

@NgModule({
  declarations: [
    AppComponent,
    ExpensesComponent,
    DashboardComponent,
    HomeComponent,
    ExpenseCategoryComponent,
    CreateExpenseCategoryComponent,
    EditExpensesCategoryComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot(
      APP_ROTES,
      { enableTracing: true } // <-- debugging purposes only
    )
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
