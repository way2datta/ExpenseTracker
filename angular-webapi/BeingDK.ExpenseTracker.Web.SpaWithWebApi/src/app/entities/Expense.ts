import { ExpenseCategory } from "./ExpenseCategory";

export class Expense
{
    id: number;
    name: string;
    amount: number;
    description: string;
    incurredAt: Date;
    categoryId: number;
    expenseCategory: ExpenseCategory
}
