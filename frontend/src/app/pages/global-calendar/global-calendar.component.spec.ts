import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GlobalCalendarComponent } from './global-calendar.component';

describe('GlobalCalendarComponent', () => {
  let component: GlobalCalendarComponent;
  let fixture: ComponentFixture<GlobalCalendarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GlobalCalendarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GlobalCalendarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
