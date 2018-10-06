import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditExpensesCategoryComponent } from './edit-expenses-category.component';

describe('EditExpensesCategoryComponent', () => {
  let component: EditExpensesCategoryComponent;
  let fixture: ComponentFixture<EditExpensesCategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditExpensesCategoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditExpensesCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
