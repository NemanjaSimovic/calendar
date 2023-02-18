export class Calendarcolor {
    id?: number;
    name: string = "";
    backgroundColor: string = "";
    fontColor?: string

    constructor(name: string, backgroundColor: string, fontColor?: string){
        this.name = name;
        this.backgroundColor = backgroundColor;
        this.fontColor = fontColor;
    }
}
