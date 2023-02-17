import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Urgencycolor } from '../models/calendarcolor.model';

@Injectable({
  providedIn: 'root'
})
export class CalendarcolorService {

  constructor(private http: HttpClient, private router: Router) { }

  uri = 'http://localhost:5188';

  getAllUrgencyColors(){
    return this.http.get<Urgencycolor[]>(`${this.uri}/urgency/color/get/all`);
  }
}
