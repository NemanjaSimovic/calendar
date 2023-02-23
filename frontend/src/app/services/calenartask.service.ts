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

  uri = 'http://localhost:5188/api/CalendarTask';

  getCaltasksByMonth(month: Date){
    var mnt = month.getMonth() + 1;
    var mStr;
    if(mnt > 9){
       mStr = mnt.toString();
    }else{
      mStr = "0" + mnt.toString();
    }
    var monthStr =  month.getFullYear().toString() + "/" + mStr + "/01";

    const params = new HttpParams().append('month', monthStr);
    return this.http.get<Calendartaskextended[]>(`${this.uri}/task/get/bymonth`, {params: params});
  }

  getCaltasksByIdAndMonth(month: Date){
    var id = this.userService.getCurUser()?.id;
    var mnt = month.getMonth() + 1;
    var mStr;
    if(mnt > 9){
      mStr = mnt.toString();
    }else{
      mStr = "0" + mnt.toString();
    }
    var monthStr =  month.getFullYear().toString() + "/" + mStr + "/01";
    var params;
    if(id != null){
      params = new HttpParams().append('month', monthStr).append('id', id);
    }else{
      params = new HttpParams().append('month', monthStr).append('id', " ");
    }
    return this.http.get<Calendartaskextended[]>(`${this.uri}/task/get/byidandmonth`, {params: params});
  }

  addNewCalendarTask(title: string, description: string,
    startTime: Date, endTime: Date, calendarId: number,
    creatorId: number, calendarColorId: number, emojiId: number,
    participantIds: number[], knownForEveryone: boolean,
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
      knownForEveryone: knownForEveryone,
      captionForEveryone: captionForEveryone ?? "",
      descriptionForEveryone: descriptionForEveryone ?? "",
      participantIds: participantIds,
    }


    return this.http.post(`${this.uri}`, body);
  }

}
