import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../app/models/employee.model';

@Injectable({
  providedIn: 'root'
})
export class ShiftService {
  private baseUrl = "https://localhost:44346/api/Shifts";

  constructor(private http: HttpClient) {}

  GetWeeklyShifts(daysOfTheWeek: string[]): Observable<Employee[]> {
    return this.http.post<Employee[]>(`${this.baseUrl}/GetWeeklyShifts`, daysOfTheWeek);
  }
}
