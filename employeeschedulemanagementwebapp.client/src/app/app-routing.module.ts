import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddShiftComponent } from './components/add-shift/add-shift.component';
import { EditShiftComponent } from './components/edit-shift/edit-shift.component';

const routes: Routes = [
  { path: '', 
    loadChildren: () => import('./components/employee-weekly-table/employee-weekly-table-module.module').then(m => m.EmployeeWeeklyTableModuleModule) },
  { path: 'add-shift/:employeeId/:date', component: AddShiftComponent },
  { path: 'edit-shift/:shiftId', component: EditShiftComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
