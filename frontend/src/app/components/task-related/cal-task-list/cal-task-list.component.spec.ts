import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalTaskListComponent } from './cal-task-list.component';

describe('CalTaskListComponent', () => {
  let component: CalTaskListComponent;
  let fixture: ComponentFixture<CalTaskListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CalTaskListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CalTaskListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
