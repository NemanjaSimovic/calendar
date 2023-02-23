import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';
import { Emoji } from '../models/emoji.model';

@Injectable({
  providedIn: 'root'
})
export class EmojiService {

  constructor(private http: HttpClient, private router: Router) { }

  uri = 'http://localhost:5188/api/Emoji';

  getAll(){
    return this.http.get<Emoji[]>(`${this.uri}`)
    .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      alert("Status code: 0. This is usually due to CORS problems.");
      console.error('An error occurred:', error.error);
    } else {
      alert(error.error);
      console.error(
        `Backend returned code ${error.status}, with message: `, error.error);
    }
    return throwError(() => new Error(error.error));
  }
}
