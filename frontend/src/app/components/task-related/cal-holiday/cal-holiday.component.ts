import { Component, OnInit, Input } from '@angular/core';
import { CalendarHoliday } from 'src/app/models/calendar-holiday.model';


@Component({
  selector: 'app-cal-holiday',
  templateUrl: './cal-holiday.component.html',
  styleUrls: ['./cal-holiday.component.css']
})
export class CalHolidayComponent implements OnInit {
  @Input()
  holiday: CalendarHoliday = new CalendarHoliday();


  constructor() { }

  ngOnInit(): void {
  }

}
