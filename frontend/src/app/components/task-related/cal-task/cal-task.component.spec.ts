import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalTaskComponent } from './cal-task.component';

describe('CalTaskComponent', () => {
  let component: CalTaskComponent;
  let fixture: ComponentFixture<CalTaskComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CalTaskComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CalTaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
