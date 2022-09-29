import { TestBed } from '@angular/core/testing';

import { CtasksService } from './ctasks.service';

describe('CtasksService', () => {
  let service: CtasksService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CtasksService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
