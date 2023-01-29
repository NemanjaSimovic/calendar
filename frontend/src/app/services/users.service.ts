import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { catchError, Subject, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

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
    // const params = new HttpParams().append('user', user);
    var body = {
      username: username,
      password: password,
      name: name,
      email: email,
      roleId: roleId
    }

    return this.http.post<string>(`${this.uri}/register`, body)
    // .pipe(catchError(this.handleError));
  }

  getAllUsers(){
    return this.http.get<User[]>(`${this.uri}`)
    .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('An error occurred:', error.error);
    } else {
      alert(error.error);
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }

}
