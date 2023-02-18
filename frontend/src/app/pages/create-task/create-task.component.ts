import { ListKeyManager } from '@angular/cdk/a11y';
import { Time } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Calendartaskextended } from 'src/app/models/calendartaskextended.model';
import { User } from 'src/app/models/user.model';
import { Calendarcolor } from 'src/app/models/calendarcolor.model';
import { CalendartaskService } from 'src/app/services/calenartask.service';
import { CalendarcolorService } from 'src/app/services/calendarcolor.service';
import { UserService } from 'src/app/services/user.service';
import { Calendar } from 'src/app/models/calendar.model';
import { CalendarService } from 'src/app/services/calendar.service';

@Component({
  selector: 'app-create-task',
  templateUrl: './create-task.component.html',
  styleUrls: ['./create-task.component.css']
})
export class CreateTaskComponent implements OnInit {

  pickedCalednarColorId: number = 0;
  title: string = "";
  description: string = "";
  taskDate: Date = new Date();

  startHM: string = "";
  endHM: string = "";

  startHours: number = 0;
  startMinutes: number = 0;
  endHours: number = 0;
  endMinutes: number = 0;

  startTime: Date = new Date();
  endTime: Date = new Date();

  calendarColors: Calendarcolor[] = [];

  allUsers: User[] = [];
  selectedUsersIds: number[] = [];

  creatorId: number = 0;

  Calendars: Calendar[] = [];
  pickedCalendarId: number = 0;

  constructor(private calendarColorsService: CalendarcolorService, private userService: UserService,
     private calendartaskService: CalendartaskService, private calendarService: CalendarService) { }

  ngOnInit(): void {
    this.loadColors();
    this.loadCalendars();
    this.getAllUsers();
  }

  loadColors(){
    this.calendarColorsService.getAll().subscribe(data => {
      this.calendarColors = data;
    });
  }

  loadCalendars(){
    this.calendarService.getAllForTask().subscribe(data => {
      this.Calendars = data;
      console.log(data);
    });
  }

  allFieldsCheck(): boolean{
    if(!this.endHM || !this.startHM){
      console.log("You must enter starting and ending time!");
      return false;
    }

    if(!this.title){
      console.log("You must enter task\'s title!");
      return false;
    }

    if(!this.description){
      console.log("You must enter task\'s description!");
      return false;
    }

    if(this.pickedCalednarColorId < 1){
      console.log("You must enter task\'s color!");
      return false;
    }
    if(this.selectedUsersIds.length <= 0){
      console.log("You must select at least 1 participant!");
      return false;
    }
    return true;
  }

//sets hours and minutes for both start and end time
  startLesserThanEndHM(): boolean{
    this.startHours = parseInt(this.startHM.slice(0,2), 10);
    this.startMinutes = parseInt(this.startHM.slice(3), 10);
    this.endHours = parseInt(this.endHM.slice(0,2), 10);
    this.endMinutes = parseInt(this.endHM.slice(3), 10);

    let startTotal: number = this.startHours * 60 + this.startMinutes;
    let endTotal: number = this.endHours * 60 + this.endMinutes;

    if(startTotal > endTotal){
      return false;
    }
    return true;
  }

  setUpStartEndTimes(){
    this.startTime = new Date(this.taskDate);
    if(this.startLesserThanEndHM()){
      this.endTime = new Date(this.taskDate);
    }else{
      this.endTime = new Date(this.taskDate);
      this.endTime.setDate(this.endTime.getDate() + 1);
    }

    this.startTime.setHours(this.startHours);
    this.startTime.setMinutes(this.startMinutes);
    this.endTime.setHours(this.endHours);
    this.endTime.setMinutes(this.endMinutes);
  }

  getAllUsers(){
    this.userService.getAll().subscribe(data => {
      this.allUsers = data;
    });
  }

  setCreatorId(){
    var creator = this.userService.getCurUser();
    if(!creator){
      this.creatorId = this.userService.getCurUser()?.Id ?? -1;
    }
  }

  addTask(){
    if(!this.allFieldsCheck()){
      alert("Empty field exists!");
      return;
    }
    this.setUpStartEndTimes();
    this.setCreatorId();

    this.calendartaskService.addNewCaltask(this.title, this.description,
      this.startTime, this.endTime, this.creatorId,
      this.pickedCalednarColorId, this.selectedUsersIds)
      .subscribe( data => {
            console.log(data);
    });
  }

}
