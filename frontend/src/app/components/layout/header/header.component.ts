import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  curUser?: User | null;

  loggedIn: boolean = false;

  constructor(private router: Router, private userService: UserService) {
    this.userService.curUserSubject.subscribe((data) => {
      this.curUser = data;
      if(this.curUser != null)
        this.loggedIn = true;
      else
        this.loggedIn = false;
    });
  }

  ngOnInit(): void {
    this.curUser = this.userService.getCurUser();
    if(this.curUser != null)
        this.loggedIn = true;
      else
        this.loggedIn = false;
  }

  // ngOnDestroy(){
  //   this.userService.curUserSubject.unsubscribe();
  // }

  printCurrentUser(){
    console.log(this.curUser);
    console.log(this.loggedIn);
  }



  logout(){
    this.curUser = undefined;
    this.userService.clearCurUser();
    this.loggedIn = false;
    this.router.navigate(['']);
  }

}
