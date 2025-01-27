import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeWeeklyTableComponent } from './employee-weekly-table.component';

describe('EmployeeWeeklyTableComponent', () => {
  let component: EmployeeWeeklyTableComponent;
  let fixture: ComponentFixture<EmployeeWeeklyTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EmployeeWeeklyTableComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeeWeeklyTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
