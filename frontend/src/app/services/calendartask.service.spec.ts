import { TestBed } from '@angular/core/testing';

import { CalendartaskService } from './calenartask.service';

describe('CtasksService', () => {
  let service: CalendartaskService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CalendartaskService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
