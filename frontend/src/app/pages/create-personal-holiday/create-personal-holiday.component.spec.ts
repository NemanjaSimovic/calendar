import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatePersonalHolidayComponent } from './create-personal-holiday.component';

describe('CreatePersonalHolidayComponent', () => {
  let component: CreatePersonalHolidayComponent;
  let fixture: ComponentFixture<CreatePersonalHolidayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreatePersonalHolidayComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatePersonalHolidayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
