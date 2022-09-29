import { Component, Input, OnInit, Output, EventEmitter} from '@angular/core';
import { Caltask } from 'src/app/models/caltask.model';

@Component({
  selector: 'app-calendar-day',
  templateUrl: './calendar-day.component.html',
  styleUrls: ['./calendar-day.component.css']
})
export class CalendarDayComponent implements OnInit {

  @Input()
  public taskList: Caltask[] = [];
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
