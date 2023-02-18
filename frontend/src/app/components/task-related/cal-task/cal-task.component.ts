import { Component, OnInit, Input } from '@angular/core';
import { Calendartaskextended } from 'src/app/models/calendartaskextended.model';

@Component({
  selector: 'app-cal-task',
  templateUrl: './cal-task.component.html',
  styleUrls: ['./cal-task.component.css']
})
export class CalTaskComponent implements OnInit {

  @Input()
  task: Calendartaskextended = new Calendartaskextended();


  constructor() { }

  ngOnInit(): void {
  }

  startTimeString(): string{
    let startTime = this.task.StartTime;
    if(startTime){
      let h = startTime.getHours();
    }
    let hours = this.task.StartTime.getHours();
    let hoursString: string = "";
    let minutes = this.task.StartTime.getMinutes();
    let minutesString: string = "";
    let res: string = "";
    if(hours != null){
      if(hours == 0){
        hoursString = "00";
      }else if(0 < hours && hours < 10){
        hoursString = "0" + hours
      }else{
        hoursString = "" + hours;
      }
    }
    if(minutes != null){
      if(minutes == 0){
        minutesString = "00";
      }else if(0 < minutes && minutes < 10){
        minutesString = "0" + minutes
      }else{
        minutesString = "" + minutes;
      }
    }
    res = hoursString + ":" + minutesString;
    return res;
  }

  endTimeString(): string{
    let endTime = this.task.EndTime;
    if(endTime){
      let h = endTime.getHours();
    }
    let hours = this.task.EndTime.getHours();
    let hoursString: string = "";
    let minutes = this.task.EndTime.getMinutes();
    let minutesString: string = "";
    let res: string = "";
    if(hours != null){
      if(hours == 0){
        hoursString = "00";
      }else if(0 < hours && hours < 10){
        hoursString = "0" + hours
      }else{
        hoursString = "" + hours;
      }
    }
    if(minutes != null){
      if(minutes == 0){
        minutesString = "00";
      }else if(0 < minutes && minutes < 10){
        minutesString = "0" + minutes
      }else{
        minutesString = "" + minutes;
      }
    }
    res = hoursString + ":" + minutesString;
    return res;
  }

}
