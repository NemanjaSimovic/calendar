import { Platform } from '@angular/cdk/platform';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { DateAdapter, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { CalendarHolidayDto } from 'src/app/models/calendar-holiday-dto.model';
import { Calendar } from 'src/app/models/calendar.model';
import { Calendartaskextended } from 'src/app/models/calendartaskextended.model';
import { CalendartaskService } from 'src/app/services/calenartask.service';
import { CalendarHolidayService } from 'src/app/services/calendar-holiday.service';
import { CalendarService } from 'src/app/services/calendar.service';
import { UtilitiesService } from 'src/app/services/utilities.service';
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


  constructor(private taskService: CalendartaskService, private calendarService: CalendarService,
     private utilitiesService: UtilitiesService, private calendarHolidayService: CalendarHolidayService) { }
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

  public holidays: CalendarHolidayDto[] = [];
  public filteredHolidaysByCalendarIds: CalendarHolidayDto[] = [];

  public daysOfTheMonth: Calendartaskextended[][] = new Array(31);
  public holidaysOfTheMonth: CalendarHolidayDto[][] = new Array(31);

  public selectedDay: number = 0;

  @Input()
  public monthAndYear: Date = new Date();

  @Output()
  public monthAndYearChange = new EventEmitter<Date | null>();

  public allCalendars: Calendar[] = [];
  public selectedCalendarIds: number[] = [];

  public getAllCalendars(){
    this.calendarService.getAll().subscribe(data => {
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
    this.emptyTaskMatrix();
    this.emptyHolidaymatrix();
    this.setPickedMonthToTodays();
  }

  public emptyTaskMatrix(){
    for(var i=0; i<=31; i++){
      this.daysOfTheMonth[i] = [];
    }
  }

  public emptyHolidaymatrix(){
    for(var i=0; i<=31; i++){
      this.holidaysOfTheMonth[i] = [];
    }
  }

  public assignTasksByDay(){
    this.filteredTasksByCalendarIds.forEach(element => {
      var taskDate = new Date(element.startTime).getDate();
      this.daysOfTheMonth[taskDate].push(element);
    });
  }

  public assignHolidaysByDay(){
    this.filteredHolidaysByCalendarIds.forEach(element => {
      var holidayDate = new Date(new Date().getFullYear(), element.month-1, element.day).getDate();
      this.holidaysOfTheMonth[holidayDate].push(element);
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

  public filterHolidaysByCalendarId(){
    this.filteredHolidaysByCalendarIds = this.holidays.filter(t => this.selectedCalendarIds.includes(t.calendarId));
  }

  public onCalendarsChange(){
    this.filterTasksByCalendarId();
    this.filterHolidaysByCalendarId();
    this.emptyTaskMatrix();
    this.emptyHolidaymatrix();
    this.assignTasksByDay();
    this.assignHolidaysByDay();
  }

  proccessTaskData(data: Calendartaskextended[]){
    // resets selected day
    this.selectedDay = 0;
    this.setWeekDayOfFirstOfTheMonth();
    this.setNumberOfDaysForSelectedMonth();

    this.tasks = this.taskService.GMTtoLocalTimeForExtendedTaskArray(data);
    this.filterTasksByCalendarId();
    this.filterHolidaysByCalendarId();
    this.emptyTaskMatrix();
    this.assignTasksByDay();
  }

  proccessHolidayData(data: CalendarHolidayDto[]){
    this.holidays = data;
    this.filterHolidaysByCalendarId();

    this.emptyHolidaymatrix();
    this.assignHolidaysByDay();
  }

  getLastUrlDirectory(): string{
    var path = location.pathname;
    var directories = path.split("/");
    return directories[(directories.length - 1)];
  }

  public chooseMonth(){
    var lastDirecotry = this.getLastUrlDirectory();
    if(lastDirecotry == this.utilitiesService.globalCalendarLastDirectory){
      this.taskService.getCaltasksByMonth(this.dt).subscribe((data) => {
        this.proccessTaskData(data);
      });
    }else{
      this.taskService.getCaltasksByIdAndMonth(this.dt).subscribe((data) => {
        this.proccessTaskData(data);
      });
    }

    this.calendarHolidayService.getCaltaskDtosByMonth(this.dt.getMonth()+1, this.dt.getFullYear()).subscribe((data => {
      this.proccessHolidayData(data);
    }));
  }
}
