import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HomeComponent } from './home.component';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { ExpensesComponent } from '../app/expenses/expenses.component';
import { DashboardComponent } from './dashboard/dashboard.component';

const appRoutes: Routes = [
  {
    path: 'expenses',
    component: ExpensesComponent,
    data: { title: 'Expenses' }
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
    data: { title: 'Dashboard' }
  },
  {
    path: '',
    component: HomeComponent,
    data: { title: 'Home' }
  }
];

@NgModule({
  declarations: [
    AppComponent,
    ExpensesComponent,
    DashboardComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    )
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
