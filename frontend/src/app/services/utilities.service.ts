import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UtilitiesService {

  constructor() { }

  public globalCalendarLastDirectory: string = "global";
  public PersonalHolidayCalendarId: number = 4;
}
