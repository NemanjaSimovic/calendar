import { Component, Input, OnInit, Output, EventEmitter} from '@angular/core';
import { CalendarHolidayDto } from 'src/app/models/calendar-holiday-dto.model';
import { Calendartaskextended } from 'src/app/models/calendartaskextended.model';

@Component({
  selector: 'app-calendar-day',
  templateUrl: './calendar-day.component.html',
  styleUrls: ['./calendar-day.component.css']
})
export class CalendarDayComponent implements OnInit {

  @Input()
  public day: number = 0;
  @Input()
  public taskList: Calendartaskextended[] = [];
  @Input()
  public holidayDtoList: CalendarHolidayDto[] = [];

  @Output()
  public currentlySelectedDay = new EventEmitter<number>();


  constructor() { }

  ngOnInit(): void {
  }

  public printTasks() {
    console.log(this.day);
  }

  public signalCurrentDay() {
    this.currentlySelectedDay.emit(this.day);
  }

}
