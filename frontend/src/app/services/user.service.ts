import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { catchError, Subject, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, private router: Router) { }

  uri = 'http://localhost:5188/api/User';

  getCurUser(): User | null{
    var user = localStorage.getItem("curUser");
    if(user)
      return JSON.parse(user);
    else
      return null;
  }
  setCurUser(user: User): void{
    localStorage.setItem('curUser', JSON.stringify(user));
  }
  clearCurUser(): void{
    localStorage.setItem('curUser', "");
  };

  public curUserSubject =  new Subject<User>();

  emmitCurUser(user: User){
    this.curUserSubject.next(user);
  }

  loginUser(username: string, password: string){
    var body = {
      username: username,
      password: password
    }
    return  this.http.post<User>(`${this.uri}/login`, body)
    .pipe(catchError(this.handleError));
  }

  registerUser(username: string, password: string, name: string, email: string, roleId: number){
    var body = {
      username: username,
      password: password,
      name: name,
      email: email,
      roleId: roleId
    }

    return this.http.post<string>(`${this.uri}/register`, body)
    .pipe(catchError(this.handleError));
  }

  getAll(){
    return this.http.get<User[]>(`${this.uri}`)
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
