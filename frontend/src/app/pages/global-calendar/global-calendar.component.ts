import { Platform } from '@angular/cdk/platform';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { DateAdapter, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { Calendar } from 'src/app/models/calendar.model';
import { Calendartaskextended } from 'src/app/models/calendartaskextended.model';
import { CalendartaskService } from 'src/app/services/calenartask.service';
import { CalendarService } from 'src/app/services/calendar.service';
import { MonthpickerDateAdapter } from './monthpicker-date-adapter';


@Component({
  selector: 'app-global-calendar',
  templateUrl: './global-calendar.component.html',
  styleUrls: ['./global-calendar.component.css'],
  providers: [
    {
      provide: DateAdapter,
      useClass: MonthpickerDateAdapter,
      deps: [MAT_DATE_LOCALE, Platform],
    },
  ],
})
export class GlobalCalendarComponent implements OnInit {


  constructor(private taskService: CalendartaskService, private calendarService: CalendarService) { }
  //dummy for looping ngfor
  numSequence(n: number): Array<number> {
    return Array(n);
  }

  @Input()
  public clickedCell: number = 0;

  public dummyCells: number[] = [];

  public weekDays: string[] = ["Mon", "Tue", "Wed", "Thr", "Fri", "Sat", "Sun"];

  public maxDaysOfTheMonth = 30;
  public dt: Date = new Date();
  public dayOfTheWeek: number = 1;
  public unfixedTasks: Calendartaskextended[] = [];
  public tasks: Calendartaskextended[] = [];
  public filteredTasksByCalendarIds: Calendartaskextended[] = [];
  public daysOfTheMonth: Calendartaskextended[][] = new Array(31);

  public selectedDay: number = 0;

  @Input()
  public monthAndYear: Date = new Date();

  @Output()
  public monthAndYearChange = new EventEmitter<Date | null>();

  public allCalendars: Calendar[] = [];
  public selectedCalendarIds: number[] = [];

  public getAllCalendars(){
    this.calendarService.getAllForTask().subscribe(data => {
      this.allCalendars = data;
      if(this.allCalendars){
        this.allCalendars.forEach(element => {
          this.selectedCalendarIds.push(element.id!);
        });
      }
    });
  }

  public emitDateChange(event: MatDatepickerInputEvent<Date | null, unknown>): void {
    this.monthAndYearChange.emit(event.value);
  }

  public monthChanged(value: any, widget: any): void {
    this.monthAndYear = value;
    if(this.monthAndYear)
      this.dt = new Date(this.monthAndYear.getFullYear(), this.monthAndYear.getMonth(), 1);
    this.chooseMonth();
    widget.close();
  }

  public setPickedMonthToTodays(){
    this.monthAndYear = new Date();
    this.dt = new Date(this.monthAndYear.getFullYear(), this.monthAndYear.getMonth(), 1);
    this.chooseMonth();
  }


  ngOnInit(): void {
    this.getAllCalendars();
    this.emptymatrix();
    this.setPickedMonthToTodays();
  }

  public emptymatrix(){
    for(var i=0; i<=31; i++){
      this.daysOfTheMonth[i] = [];
    }
  }

  public assignTasksByDay(){
    this.filteredTasksByCalendarIds.forEach(element => {
      var taskDate = new Date(element.startTime).getDate();
      this.daysOfTheMonth[taskDate].push(element);
    });
  }

  public printMatrix(){
    for(var i=1; i<= this.maxDaysOfTheMonth; i++){
      console.log("Tasks for " + (i).toString() + ". are: ");
      this.daysOfTheMonth[i].forEach(element => {
        console.log(element);
      });
    }
  }

  public setNumberOfDaysForSelectedMonth(){
    var month = this.dt.getMonth() + 1;

    switch(month) {
      case 2:
        this.maxDaysOfTheMonth = 28;
        break;
      case 4:
      case 6:
      case 9:
      case 11:
        this.maxDaysOfTheMonth = 30;
        break;
      default:
        this.maxDaysOfTheMonth = 31;
    }
  }

  public setWeekDayOfFirstOfTheMonth(){
    this.dt.setDate(1);
    this.dayOfTheWeek = this.dt.getDay();
    if(this.dayOfTheWeek <= 0){
      this.dummyCells = this.numSequence(6);
    }else if(this.dayOfTheWeek == 1){
      this.dummyCells = [];
    }else{
      this.dummyCells = this.numSequence(this.dayOfTheWeek-1);
    }
  }

  public setCurrentlySelectedDay(currentlySelectedDay: number) {
    this.selectedDay = currentlySelectedDay;
  }


  public filterTasksByCalendarId(){
    this.filteredTasksByCalendarIds = this.tasks.filter(t => this.selectedCalendarIds.includes(t.calendarId));
  }

  public onCalendarsChange(){
    this.filterTasksByCalendarId();
    this.emptymatrix();
    this.assignTasksByDay();
  }

  public chooseMonth(){
    this.taskService.getCaltasksByMonth(this.dt).subscribe((data) => {
      // resets selected day
      this.selectedDay = 0;
      this.setWeekDayOfFirstOfTheMonth();
      this.setNumberOfDaysForSelectedMonth();

      this.tasks = this.taskService.GMTtoLocalTimeForExtendedTaskArray(data);
      this.filterTasksByCalendarId();

      this.emptymatrix();
      this.assignTasksByDay();
    });
  }
}
