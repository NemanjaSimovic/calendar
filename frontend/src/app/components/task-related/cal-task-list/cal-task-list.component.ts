import { Component, OnInit, Input } from '@angular/core';
import { Caltask } from 'src/app/models/caltask.model';

@Component({
  selector: 'app-cal-task-list',
  templateUrl: './cal-task-list.component.html',
  styleUrls: ['./cal-task-list.component.css']
})
export class CalTaskListComponent implements OnInit {

  @Input()
  tasks: Caltask[] | undefined;

  constructor() { }

  ngOnInit(): void {
  }

}
