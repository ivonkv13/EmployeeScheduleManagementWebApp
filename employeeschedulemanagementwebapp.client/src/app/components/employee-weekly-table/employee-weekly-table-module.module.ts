import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeWeeklyTableComponent } from './employee-weekly-table.component';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner'
import { AddShiftComponent } from '../add-shift/add-shift.component';
import { EmployeeWeeklyTableRoutingModule } from './employee-weekly-table-routing.module';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [EmployeeWeeklyTableComponent, AddShiftComponent],
  imports: [
    CommonModule,
    MatTableModule,
    MatIconModule,
    MatProgressSpinnerModule,
    EmployeeWeeklyTableRoutingModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatSelectModule,
    MatButtonModule,
    MatDatepickerModule
  ],
  exports: [EmployeeWeeklyTableComponent, AddShiftComponent]
})
export class EmployeeWeeklyTableModuleModule { }
