export class User {
    id?: number;
    username: string = "";
    password: string = "";
    name: string = "";
    email: string = "";
    roleId: number = 0;

    constructor(username: string, password: string, name: string, email: string, roleId: number){
        this.username = username;
        this.password = password;
        this.name = name;
        this.email = email;
        this.roleId = roleId;
    }
}
