import { Component, OnInit, Input } from '@angular/core';
import { CalendarHolidayDto } from 'src/app/models/calendar-holiday-dto.model';


@Component({
  selector: 'app-cal-holiday',
  templateUrl: './cal-holiday.component.html',
  styleUrls: ['./cal-holiday.component.css']
})
export class CalHolidayComponent implements OnInit {
  @Input()
  holiday: CalendarHolidayDto = new CalendarHolidayDto();


  constructor() { }

  ngOnInit(): void {
  }

}
