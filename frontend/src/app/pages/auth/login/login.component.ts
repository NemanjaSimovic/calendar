import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username?: string;
  password?: string;

  constructor(private router: Router , private userService: UserService) { }

  ngOnInit(): void {
  }

  updateUser(){
    if(!this.username || this.username == "" || !this.password || this.password == ""){
      console.log("Empty Field!");
      return;
    }
    // console.log(this.username);
    this.userService.loginUser(this.username, this.password).subscribe((data) => {
      this.userService.setCurUser(data);
      this.userService.emmitCurUser(data);
      if(this.userService.getCurUser() != null){
        this.router.navigate([""]);
        alert("Welcome " + this.userService.getCurUser()?.Name + "!")
      }else {
        console.log("Wrong username or password!");
      }
    });
  }

}
