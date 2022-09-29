import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username?: string;
  password?: string;

  constructor(private router: Router , private userService: UsersService) { }

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
        console.log("User Logged!");
        this.router.navigate([""]);
      }else {
        console.log("Wrong username or password!");
      }
    });
  }

}
