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

  uri = 'http://localhost:5188';

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

  addNewCaltask(title: string, description: string, color: string,
     startTime: Date, endTime: Date, participantIds: number[],
  participantFullNames: string[], creatorId: number, creatorFullName: string){

    //we did not use this but can be useful for other cases, so let it be there.
    let startEpoch = startTime.getTime();
    let endEpoch = endTime.getTime();


    var body = {
      title: title,
      description: description,
      color: color,
      participantIds: participantIds,
      participantFullNames: participantFullNames,
      creatorId: creatorId,
      creatorFullName: creatorFullName,
      startTime: startTime,
      endTime: endTime
    }

    const params = new HttpParams().append('startEpoch', startEpoch).append('endEpoch', endEpoch);

    return this.http.post(`${this.uri}/task/add`, body, {params: params});
  }

}
