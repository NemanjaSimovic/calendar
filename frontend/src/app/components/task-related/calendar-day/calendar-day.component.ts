import { Component, Input, OnInit, Output, EventEmitter} from '@angular/core';
import { Calendartaskextended } from 'src/app/models/calendartaskextended.model';

@Component({
  selector: 'app-calendar-day',
  templateUrl: './calendar-day.component.html',
  styleUrls: ['./calendar-day.component.css']
})
export class CalendarDayComponent implements OnInit {

  @Input()
  public taskList: Calendartaskextended[] = [];
  @Input()
  public day: number = 0;

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
