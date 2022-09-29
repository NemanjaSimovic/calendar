export class Caluser {
    id?: string;
    username: string = "";
    password: string = "";
    name: string = "";
    surname: string = "";
    email: string = "";

    constructor(username: string, password: string, name: string, surname: string, email: string){
        this.username = username;
        this.password = password;
        this.name = name;
        this.surname = surname;
        this.email = email;
    }
}
