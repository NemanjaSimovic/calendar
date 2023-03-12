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

  addNewCalendarHoliday(title: string, description: string,
    calendarId: number, calendarColorId: number, emojiId: number,
    isRepeatedYearly: boolean, day: number, month: number, year?: number
  ){
    var body = {
      title: title,
      description: description,
      calendarId: calendarId,
      calendarColorId: calendarColorId,
      emojiId: emojiId,
      isRepeatedYearly: isRepeatedYearly,
      day: day,
      month: month,
      year: isRepeatedYearly ? null: year
    }

    return this.http.post(`${this.uri}`, body);
  }
}
