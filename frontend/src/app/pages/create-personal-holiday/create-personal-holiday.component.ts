import { Component, OnInit } from '@angular/core';
import { Calendar } from 'src/app/models/calendar.model';
import { Calendarcolor } from 'src/app/models/calendarcolor.model';
import { Emoji } from 'src/app/models/emoji.model';
import { UserAvailabilityDto } from 'src/app/models/user-availability-dto.model';
import { User } from 'src/app/models/user.model';
import { CalendartaskService } from 'src/app/services/calenartask.service';
import { CalendarService } from 'src/app/services/calendar.service';
import { CalendarcolorService } from 'src/app/services/calendarcolor.service';
import { EmojiService } from 'src/app/services/emoji.service';
import { UserService } from 'src/app/services/user.service';
import { UtilitiesService } from 'src/app/services/utilities.service';

@Component({
  selector: 'app-create-personal-holiday',
  templateUrl: './create-personal-holiday.component.html',
  styleUrls: ['./create-personal-holiday.component.css']
})
export class CreatePersonalHolidayComponent implements OnInit {


  pickedCalednarColorId: number = 0;
  title: string = "";
  description: string = "";

  taskDate: Date = new Date();
  isTaskTimeSet: boolean = false;

  calendarColors: Calendarcolor[] = [];

  allUsers: User[] = [];
  selectedUsersIds: number[] = [];

  creatorId: number = 0;

  emojis: Emoji[] = [];
  pickedEmojiId: number = 0;

  numberOfDays: number = 1;

  startTime: Date = new Date();
  endTime: Date = new Date();


  constructor(private calendarColorsService: CalendarcolorService, private userService: UserService,
     private calendartaskService: CalendartaskService, private emojiService: EmojiService,
      private utilitiesService: UtilitiesService) { }

  ngOnInit(): void {
    this.loadColors();
    this.loadEmojis();
    this.getUsers();
  }

  loadColors(){
    this.calendarColorsService.getAll().subscribe(data => {
      this.calendarColors = data;
    });
  }

  loadEmojis(){
    this.emojiService.getAll().subscribe(data => {
      this.emojis = data;
    });
  }

  allFieldsCheck(): boolean{
    if(this.numberOfDays<1 || this.numberOfDays > 21){
      alert("Holiday length must be in range 1-21 days!");
      return false;
    }
    if(!this.title){
      alert("You must enter task\'s title!");
      return false;
    }

    if(!this.description){
      alert("You must enter task\'s description!");
      return false;
    }

    if(this.pickedCalednarColorId < 1){
      alert("You must enter task\'s color!");
      return false;
    }
    if(this.selectedUsersIds.length <= 0){
      alert("You must select at least 1 participant!");
      return false;
    }
    return true;
  }

  setUpStartEndTimes(){
    this.startTime = new Date(this.taskDate);
    this.endTime = new Date(this.taskDate);
    this.startTime.setHours(0);
    this.startTime.setMinutes(1);
    this.endTime.setHours(23);
    this.endTime.setMinutes(59);
  }

  setCreatorId(){
    var creator = this.userService.getCurUser();
    if(creator){
      this.creatorId = creator.id ?? -1;
    }
  }

  resetSelectedUsers(){
    this.selectedUsersIds = [];
  }

  getUsers(){
    this.userService.getAll().subscribe(data => {
      this.allUsers = data;
    });
  }

  addTask(){
    if(!this.allFieldsCheck()){
      return;
    }
    this.setUpStartEndTimes();
    this.setCreatorId();
    this.startTime.setDate(this.startTime.getDate() - 1);
    this.endTime.setDate(this.endTime.getDate() - 1);
    for(let i=0; i<this.numberOfDays; i++){
      this.startTime.setDate(this.startTime.getDate()+1);
      this.endTime.setDate(this.endTime.getDate()+1);
      this.calendartaskService.addNewCalendarTask(this.title, this.description,
        this.startTime, this.endTime, this.utilitiesService.PersonalHolidayCalendarId, this.creatorId,
        this.pickedCalednarColorId, this.pickedEmojiId, this.selectedUsersIds,
        true, true, undefined, undefined)
        .subscribe( data => {
            alert("Personal holiday's day successfully created!");
        });
    }
  }

}
