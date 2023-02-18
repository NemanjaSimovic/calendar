export class User {
    Id?: number;
    Username: string = "";
    Password: string = "";
    Name: string = "";
    Email: string = "";
    RoleId: number = 0;

    constructor(username: string, password: string, name: string, email: string, roleId: number){
        this.Username = username;
        this.Password = password;
        this.Name = name;
        this.Email = email;
        this.RoleId = roleId;
    }
}
