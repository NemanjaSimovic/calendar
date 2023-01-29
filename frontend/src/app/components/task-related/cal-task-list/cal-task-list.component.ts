import { Component, OnInit, Input } from '@angular/core';
import { Calendartaskextended } from 'src/app/models/calendartaskextended.model';

@Component({
  selector: 'app-cal-task-list',
  templateUrl: './cal-task-list.component.html',
  styleUrls: ['./cal-task-list.component.css']
})
export class CalTaskListComponent implements OnInit {

  @Input()
  tasks: Calendartaskextended[] | undefined;

  constructor() { }

  ngOnInit(): void {
  }

}
