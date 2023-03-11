import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { CalendarHoliday } from '../models/calendar-holiday.model';

@Injectable({
  providedIn: 'root'
})
export class CalendarHolidayService {

  uri = 'http://localhost:5188/api/CalendarHoliday';

  constructor(private http: HttpClient, private router: Router) { }

  getCaltasksByMonth(month: number){
    const params = new HttpParams().append('month', month);
    return this.http.get<CalendarHoliday[]>(`${this.uri}/bymonth`, {params: params});
  }
}
