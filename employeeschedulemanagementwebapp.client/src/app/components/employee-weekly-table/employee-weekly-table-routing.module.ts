import { NgModule } from '@angular/core';
import { EmployeeWeeklyTableComponent } from './employee-weekly-table.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', component: EmployeeWeeklyTableComponent }, // Default route for this module
]

@NgModule({
  imports: [RouterModule.forChild(routes)], 
  exports: [RouterModule], 
})
export class EmployeeWeeklyTableRoutingModule { }
