import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Calendartaskextended } from '../models/calendartaskextended.model';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class CalendartaskService {

  constructor(private http: HttpClient, private router: Router, private userService: UserService) { }


  getMilisecOffset(date: Date){
    var offset = new Date(date).getTimezoneOffset();
    return offset*60*1000;
  }

  GMTtoLocalTimeForSingleDate(date: Date): Date{
    var offset = this.getMilisecOffset(date);
    var updatedDate: Date = new Date(date);
    updatedDate.setTime(updatedDate.getTime() - offset);
    return updatedDate;
  }

  GMTtoLocalTimeForExtendedTaskArray(tasks: Calendartaskextended[]): Calendartaskextended[]{
    tasks.forEach(calenarTask => {
      if(calenarTask.startTime){
        calenarTask.startTime = this.GMTtoLocalTimeForSingleDate(calenarTask.startTime);
      }
      if(calenarTask.endTime){
        calenarTask.endTime = this.GMTtoLocalTimeForSingleDate(calenarTask.endTime);
      }
    });
    return tasks;
  }

  uri = 'http://localhost:5188/api/CalendarTask';

  getCaltasksByMonth(month: Date){
    const params = new HttpParams().append('minStartTime', month.toJSON());
    return this.http.get<Calendartaskextended[]>(`${this.uri}/extended/bymonth`, {params: params});
  }

  getCaltasksByIdAndMonth(month: Date){
    var id = this.userService.getCurUser()?.id;
    var params;
    if(id != null){
      params = new HttpParams().append('minStartTime', month.toJSON()).append('userId', id);
    }else{
      params = new HttpParams().append('minStartTime', month.toJSON()).append('userId', 0);
    }
    return this.http.get<Calendartaskextended[]>(`${this.uri}/extended/foruser/bymonth`, {params: params});
  }

  addNewCalendarTask(title: string, description: string,
    startTime: Date, endTime: Date, calendarId: number,
    creatorId: number, calendarColorId: number, emojiId: number,
    participantIds: number[], isNotWorkingHoliday: boolean, knownForEveryone: boolean,
    captionForEveryone?: string, descriptionForEveryone?: string
    ){


    var body = {
      title: title,
      description: description,
      startTime: startTime,
      endTime: endTime,
      calendarId: calendarId,
      creatorId: creatorId,
      calendarColorId: calendarColorId,
      emojiId: emojiId,
      isNotWorkingHoliday: isNotWorkingHoliday,
      knownForEveryone: knownForEveryone,
      captionForEveryone: captionForEveryone ?? "",
      descriptionForEveryone: descriptionForEveryone ?? "",
      participantIds: participantIds,
    }


    return this.http.post(`${this.uri}`, body);
  }

}
