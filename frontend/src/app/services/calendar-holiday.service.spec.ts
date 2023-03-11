import { TestBed } from '@angular/core/testing';

import { CalendarHolidayService } from './calendar-holiday.service';

describe('CalendarHolidayService', () => {
  let service: CalendarHolidayService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CalendarHolidayService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
