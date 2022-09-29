import { TestBed } from '@angular/core/testing';

import { UrgencycolorsService } from './urgencycolors.service';

describe('UrgencycolorsService', () => {
  let service: UrgencycolorsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UrgencycolorsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
