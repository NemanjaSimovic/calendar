import { TestBed } from '@angular/core/testing';

import { CalendarcolorService } from './calendarcolor.service';

describe('UrgencycolorsService', () => {
  let service: CalendarcolorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CalendarcolorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
