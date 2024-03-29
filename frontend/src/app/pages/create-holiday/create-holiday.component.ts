import { Component, OnInit } from '@angular/core';
import { Calendar } from 'src/app/models/calendar.model';
import { Calendarcolor } from 'src/app/models/calendarcolor.model';
import { Emoji } from 'src/app/models/emoji.model';
import { CalendarHolidayService } from 'src/app/services/calendar-holiday.service';
import { CalendarService } from 'src/app/services/calendar.service';
import { CalendarcolorService } from 'src/app/services/calendarcolor.service';
import { EmojiService } from 'src/app/services/emoji.service';

@Component({
  selector: 'app-create-holiday',
  templateUrl: './create-holiday.component.html',
  styleUrls: ['./create-holiday.component.css']
})
export class CreateHolidayComponent implements OnInit {


  title: string = "";
  description: string = "";

  pickedDay: number = 0;
  pickedMonth: number = 0;
  pickedYear?: number;

  isRepeatedYearly: boolean = true;

  startTime: Date = new Date();
  endTime: Date = new Date();

  calendarColors: Calendarcolor[] = [];
  pickedCalednarColorId: number = 0;

  calendars: Calendar[] = [];
  pickedCalendarId: number = 0;

  emojis: Emoji[] = [];
  pickedEmojiId: number = 0;



  constructor(private calendarColorsService: CalendarcolorService, private calendarHolidayService: CalendarHolidayService,
     private calendarService: CalendarService, private emojiService: EmojiService) { }

  ngOnInit(): void {
    this.loadColors();
    this.loadCalendars();
    this.loadEmojis();
  }

  printValue(){
    console.log(this.isRepeatedYearly);
  }

  loadColors(){
    this.calendarColorsService.getAll().subscribe(data => {
      this.calendarColors = data;
    });
  }

  loadCalendars(){
    this.calendarService.getAllForHoliday().subscribe(data => {
      this.calendars = data;
    });
  }

  loadEmojis(){
    this.emojiService.getAll().subscribe(data => {
      this.emojis = data;
    });
  }

  public getNumberOfDaysForSelectedMonth(month: number, year: number): number{
    switch(month) {
      case 2:
        if(year % 4 == 0){
          return 29;
        } else {
          return 28;
        }
      case 4:
      case 6:
      case 9:
      case 11:
        return 30;
      default:
        return 31;
    }
  }

  allFieldsCheck(): boolean{
    if(!this.isRepeatedYearly && (!this.pickedYear || this.pickedYear < 1 || this.pickedYear > 3000)){
      alert("Year must be in range 1-3000 if repeated yearly option is not selected!");
      return false;
    }
    if(!this.pickedMonth || this.pickedMonth < 1 || this.pickedMonth > 12){
      alert("Month must be in range 1-12");
      return false;
    }
    var dayUpperLimit = this.getNumberOfDaysForSelectedMonth(this.pickedMonth, this.pickedYear ?? 1);
    if(!this.pickedDay || this.pickedDay < 1 || this.pickedDay > dayUpperLimit){
      alert("Day must be in range 1-"+ dayUpperLimit);
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
    return true;
  }

  addHoliday(){
    if(!this.allFieldsCheck()){
      return;
    }

    this.calendarHolidayService.addNewCalendarHoliday(this.title, this.description,
       this.pickedCalendarId, this.pickedCalednarColorId, this.pickedEmojiId,
       this.isRepeatedYearly, this.pickedDay, this.pickedMonth, this.pickedYear)
      .subscribe( data => {
        alert("Holiday successfully created!");
    });
  }

}
