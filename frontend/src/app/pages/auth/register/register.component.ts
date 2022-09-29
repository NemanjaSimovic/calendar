import { Component, OnInit } from '@angular/core';
import { Caluser } from 'src/app/models/caluser.model';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  username?: string;
  password?: string;
  confirmPassword?: string;
  name?: string;
  surname?: string;
  email?: string;

  constructor(private userService: UsersService) { }

  ngOnInit(): void {
  }

  registerUser(){
    if(!this.username || this.username == "" || !this.password || this.password == ""
    || !this.name || this.name == "" || !this.surname || this.surname == ""
    || !this.email || this.email == "" || this.password != this.confirmPassword){
      console.log("Empty Field!");
      return;
    }

    // console.log(this.username);
    this.userService.registerUser(this.username, this.password, this.name, this.surname, this.email).subscribe((data) => {
      console.log(data);
    });
  }
}
