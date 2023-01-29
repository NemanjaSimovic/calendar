import { Component, OnInit } from '@angular/core';
import { Role } from 'src/app/models/role.model';
import { User } from 'src/app/models/user.model';
import { RoleService } from 'src/app/services/role.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  username: string = "";
  password: string = "";
  confirmPassword: string = "";
  name: string = "";
  email: string = "";
  roleId: number = -1;

  allRoles: Role[] = [];

  constructor(private userService: UsersService, private roleService: RoleService) { }

  ngOnInit(): void {
    this.getAllRoles();
  }


  getAllRoles(){
    this.roleService.getAllRoles().subscribe((data) => {
      this.allRoles = data;
    });
  }

  registerUser(){

    if(this.username == "" || this.password == "" || this.name == "" || this.email == "" || this.roleId < 1)
    {
      alert("All form fields, must be filled!");
      return;
    }
    if(this.password != this.confirmPassword){
      alert("Password and confirmation password missmatch!");
      return;
    }

    this.userService.registerUser(this.username, this.password, this.name, this.email, this.roleId).subscribe((data) => {
      // console.log(data);
    });
  }
}
