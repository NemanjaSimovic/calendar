import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalHolidayComponent } from './cal-holiday.component';

describe('CalHolidayComponent', () => {
  let component: CalHolidayComponent;
  let fixture: ComponentFixture<CalHolidayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CalHolidayComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CalHolidayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
