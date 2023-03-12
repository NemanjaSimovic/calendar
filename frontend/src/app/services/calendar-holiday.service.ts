import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { CalendarHolidayDto } from '../models/calendar-holiday-dto.model';
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

  getCaltaskDtosByMonth(month: number){
    const params = new HttpParams().append('month', month);
    return this.http.get<CalendarHolidayDto[]>(`${this.uri}/dto/bymonth`, {params: params});
  }

  addNewCalendarHoliday(title: string, description: string, day: number, month: number,
    calendarId: number, calendarColorId: number, emojiId: number
  ){
    var body = {
      title: title,
      description: description,
      day: day,
      month: month,
      calendarId: calendarId,
      calendarColorId: calendarColorId,
      emojiId: emojiId
    }

    return this.http.post(`${this.uri}`, body);
  }
}
