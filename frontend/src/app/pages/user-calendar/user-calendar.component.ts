import { Platform } from '@angular/cdk/platform';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { DateAdapter, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { Caltask } from 'src/app/models/caltask.model';
import { CtasksService } from 'src/app/services/ctasks.service';
import { MonthpickerDateAdapter } from '../global-calendar/monthpicker-date-adapter';

@Component({
  selector: 'app-user-calendar',
  templateUrl: './user-calendar.component.html',
  styleUrls: ['./user-calendar.component.css'],
  providers: [
    {
      provide: DateAdapter,
      useClass: MonthpickerDateAdapter,
      deps: [MAT_DATE_LOCALE, Platform],
    },
  ],
})
export class UserCalendarComponent implements OnInit {
  
  //dummy for looping ngfor
  numSequence(n: number): Array<number> {
    return Array(n);
  }

  @Input()
  public clickedCell: number = 0;

  public dummyCells: number[] = [];

  public weekDays: string[] = ["Mon", "Tue", "Wed", "Thr", "Fri", "Sat", "Sun"];

  public maxDaysOfTheMonth = 30;
  public dt: Date = new Date(2022, 8, 9);
  public dayOfTheWeek: number = 1;
  public unfixedTasks: Caltask[] = [];
  public tasks: Caltask[] = [];
  public daysOfTheMonth: Caltask[][] = new Array(31);

  public selectedDay: number = 0;
  
  @Input()
  public monthAndYear: Date = new Date(2022, 8);

  @Output()
  public monthAndYearChange = new EventEmitter<Date | null>();

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

  constructor(private taskService: CtasksService) { }

  ngOnInit(): void {
    this.emptymatrix();
    this.dt = new Date(2022, 8, 9);
    this.chooseMonth();
  }

  public emptymatrix(){
    for(var i=0; i<=31; i++){
      this.daysOfTheMonth[i] = [];
    }
  }

  public assignTasksByDay(){
    this.tasks.forEach(element => {
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
      case 1:
      case 3:
      case 5:
      case 7:
      case 8:
      case 10:
      case 12:
        this.maxDaysOfTheMonth = 31
        break;
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

  public setWeekDayOfFirstOdTheMonth(){
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

  public changeStringsToDates(){
    let startFixed;
    let endFixed;
    this.unfixedTasks.forEach(task => {
      startFixed = new Date(task.startTime);
      task.startTime = startFixed;

      endFixed= new Date(task.endTime);
      task.endTime = endFixed;
    });
  }


  public chooseMonth(){
    this.taskService.getCaltasksByIdAndMonth(this.dt).subscribe((data) => {
      // resets selected day
      this.selectedDay = 0;
      this.setWeekDayOfFirstOdTheMonth();
      this.setNumberOfDaysForSelectedMonth();

      this.unfixedTasks = data;
      this.changeStringsToDates();
      this.tasks = this.unfixedTasks;

      this.emptymatrix();
      this.assignTasksByDay();
    });
  }
}
