import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeWeeklyTableModuleModule } from './components/employee-weekly-table/employee-weekly-table-module.module';
import { EditShiftComponent } from './components/edit-shift/edit-shift.component';

@NgModule({
  declarations: [
    AppComponent,
    EditShiftComponent, // Root component
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule, // Routing configuration
    EmployeeWeeklyTableModuleModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
