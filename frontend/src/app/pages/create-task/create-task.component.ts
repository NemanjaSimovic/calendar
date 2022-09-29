import { ListKeyManager } from '@angular/cdk/a11y';
import { Time } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Caltask } from 'src/app/models/caltask.model';
import { Caluser } from 'src/app/models/caluser.model';
import { Urgencycolor } from 'src/app/models/urgencycolor.model';
import { CtasksService } from 'src/app/services/ctasks.service';
import { UrgencycolorsService } from 'src/app/services/urgencycolors.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-create-task',
  templateUrl: './create-task.component.html',
  styleUrls: ['./create-task.component.css']
})
export class CreateTaskComponent implements OnInit {

  color: string= "";
  title: string= "";
  description: string= "";
  taskDate: Date = new Date();
  
  startHM: string = "";
  endHM: string = "";
  
  startHours: number = 0;
  startMinutes: number = 0;
  endHours: number = 0;
  endMinutes: number = 0;

  startTime: Date = new Date();
  endTime: Date = new Date();

  urgColors: Urgencycolor[] = [];

  allUsers: Caluser[] = [];
  selectedUsers: Caluser[] = [];

  selectedUsersFullNames: string[] = []; 
  selectedUsersIds: string[] = [];

  creator: Caluser | null = null;
  creatorFullName: string = "";
  creatorId: string = "";

  constructor(private urgencyColorsService: UrgencycolorsService, private usersService: UsersService, private ctasksService: CtasksService) { }

  ngOnInit(): void {
    this.loadColors();
    this.getAllUsers();
  }

  loadColors(){
    this.urgencyColorsService.getAllUrgencyColors().subscribe(data => {
      this.urgColors = data;
    });
  }

  allFieldsCheck(): boolean{
    if(this.endHM == null || this.endHM == "" ||
    this.startHM == null || this.startHM == ""){
      console.log("You must enter starting and ending time!");
      return false;
    }

    if(this.title == null || this.title == ""){
      console.log("You must enter task\'s title!");
      return false;
    }

    if(this.description == null || this.description == ""){
      console.log("You must enter task\'s description!");
      return false;
    }

    if(this.color == null || this.color == ""){
      console.log("You must enter task\'s color/urgency!");
      return false;
    }
    if(this.selectedUsers.length <= 0){
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
    this.usersService.getAllUsers().subscribe(data => {
      this.allUsers = data;
    });
  }

  setParticipantsAndCreator(){
    for(let i=0; i<this.selectedUsers.length; i++){

      this.selectedUsersFullNames[i] = this.selectedUsers[i].name + " " + this.selectedUsers[i].surname;

      // Since id can be undefined we nedd to check its value before assigning it, therfor new array value
      // will be assigned to an empty string if the value of an id is undefined. 
      this.selectedUsersIds[i] = this.selectedUsers[i].id !== undefined ? this.selectedUsers[i].id! : '';
    }

    this.creator = this.usersService.getCurUser();
    if(this.creator != null){
      this.creatorFullName = this.creator.name + " " + this.creator.surname;
      this.creatorId = this.creator.id !== undefined ? this.creator.id : "";
    }
  }

  addTask(){
    if(!this.allFieldsCheck()){
      console.log("Empty field exists!");
      return;
    }
    this.setUpStartEndTimes();
    this.setParticipantsAndCreator();
    
    

    this.ctasksService.addNewCaltask(this.title, this.description,
        this.color, this.startTime, this.endTime, this.selectedUsersIds,
        this.selectedUsersFullNames, this.creatorId, this.creatorFullName)
    .subscribe( data => {
            console.log(data);
    });
    

    


    //ostaje da se testira sve zajedno!
  }

}
