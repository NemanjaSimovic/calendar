import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Caluser } from 'src/app/models/caluser.model';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http: HttpClient, private router: Router) { }

  uri = 'http://localhost:5124';

  getCurUser(): Caluser | null{
    var user = localStorage.getItem("curUser");
    if(user)
      return JSON.parse(user);
    else
      return null;
  }
  setCurUser(user: Caluser): void{
    localStorage.setItem('curUser', JSON.stringify(user));
  }
  clearCurUser(): void{
    localStorage.setItem('curUser', "");
  };

  public curUserSubject =  new Subject<Caluser>();

  emmitCurUser(user: Caluser){
    this.curUserSubject.next(user);
  }

  loginUser(username: string, password: string){
    const params = new HttpParams().append('username', username).append('password', password);
    
    return this.http.get<Caluser>(`${this.uri}/user/get/byuserandpass`, {params: params});
  }

  registerUser(username: string, password: string, name: string, surname: string, email: string){
    // const params = new HttpParams().append('user', user);
    
    var body = {
      username: username,
      password: password,
      name: name,
      surname: surname,
      email: email
    }

    return this.http.post<Caluser>(`${this.uri}/user/post/register`, body);
  }

  getAllUsers(){
    return this.http.get<Caluser[]>(`${this.uri}/user/get/all`);
  }

}
