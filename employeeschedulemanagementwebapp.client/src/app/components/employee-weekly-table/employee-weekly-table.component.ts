import { OnInit, Component, OnDestroy } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ShiftService } from '../../../services/shift.service';
import { Employee } from '../../models/employee.model';
import { Shift } from '../../models/employeeShift.model';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employee-weekly-table',
  templateUrl: './employee-weekly-table.component.html',
  styleUrl: './employee-weekly-table.component.css'
})
export class EmployeeWeeklyTableComponent implements OnInit, OnDestroy {

  private subscription: Subscription | null = null;

  employees: MatTableDataSource<Employee> = new MatTableDataSource<Employee>();
  displayedColumns: string[] = ['employee'];
  daysOfWeek: string[] = [];
  currentWeekNumber: number;
  currentYear: number;

  isLoading = true;

  constructor(private shiftService: ShiftService, private router: Router) {
    const today = new Date();
    this.currentWeekNumber = this.getWeekNumber(today);
    this.currentYear = today.getFullYear();
    this.daysOfWeek = this.getDatesForWeek(this.currentWeekNumber, this.currentYear);
  }

  ngOnInit(): void {
    this.loadShifts();
  }

  loadShifts(): void {
    this.isLoading = true;
    this.subscription = this.shiftService.GetWeeklyShifts(this.daysOfWeek).subscribe({
    next: (data) => {
      console.log(data)
      this.employees = new MatTableDataSource<Employee>(data); // Update the dataSource
    },
    error: (err) => {
      console.error('Error fetching data:', err);
    },
    complete: () => {
      this.isLoading = false; 
    },
  });
  }

  changeWeek(delta: number): void {
    this.currentWeekNumber += delta;

    if (this.currentWeekNumber < 1) {
      this.currentYear -= 1;
      this.currentWeekNumber = this.getWeeksInYear(this.currentYear);
    } else if (this.currentWeekNumber > this.getWeeksInYear(this.currentYear)) {
      this.currentYear += 1;
      this.currentWeekNumber = 1;
    }

    this.daysOfWeek = this.getDatesForWeek(this.currentWeekNumber, this.currentYear);
    this.displayedColumns = ['employee', ...this.daysOfWeek];
    this.loadShifts();
  }

  getWeekNumber(date: Date): number {
    const firstDayOfYear = new Date(date.getFullYear(), 0, 1);
    const dayOfYear = Math.floor((date.getTime() - firstDayOfYear.getTime()) / (24 * 60 * 60 * 1000)) + 1;
    return Math.ceil((dayOfYear + firstDayOfYear.getDay()) / 7);
  }

  getWeeksInYear(year: number): number {
    const lastDayOfYear = new Date(year, 11, 31);
    const firstDayOfYear = new Date(year, 0, 1);
    const daysInYear = Math.floor((lastDayOfYear.getTime() - firstDayOfYear.getTime()) / (24 * 60 * 60 * 1000)) + 1;
    return Math.ceil((daysInYear + firstDayOfYear.getDay()) / 7);
  }

  getDatesForWeek(weekNumber: number, year: number): string[] {
    const firstDayOfYear = new Date(year, 0, 1);
    const daysOffset = (weekNumber - 1) * 7;
    const firstDayOfWeek = new Date(firstDayOfYear.setDate(firstDayOfYear.getDate() - firstDayOfYear.getDay() + 1 + daysOffset));

    return Array.from({ length: 7 }, (_, i) => {
      const currentDate = new Date(firstDayOfWeek);
      currentDate.setDate(firstDayOfWeek.getDate() + i);
      return currentDate.toISOString().split('T')[0];
    });
  }

  getShiftsForDay(employee: Employee, day: string): Shift[] {
    return employee?.shifts?.filter((shift) => shift.shiftDate.split('T')[0] === day) || [];
  }

  navigateToAddShift(employeeId: number, date: string): void {
    this.router.navigate(['/add-shift', employeeId, date]).then((navigated) => {
      if (navigated) {
        console.log('Navigation successful!');
      } else {
        console.error('Navigation failed!');
      }
    });
  }

  navigateToEditShift(shiftId: number): void {
    this.router.navigate(['/edit-shift', shiftId]).then((navigated) => {
      if (navigated) {
        console.log('Navigation successful!');
      } else {
        console.error('Navigation failed!');
      }
    });
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
