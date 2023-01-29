export class Urgencycolor {
    id?: number;
    name: string = "";
    rGBString: string = "";

    constructor(name: string, rGBString: string){
        this.name = name;
        this.rGBString = rGBString;
    }
}
