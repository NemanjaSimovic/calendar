export class Calendarcolor {
    Id?: number;
    Name: string = "";
    BackgroundColor: string = "";
    FontColor?: string

    constructor(name: string, backgroundColor: string, fontColor?: string){
        this.Name = name;
        this.BackgroundColor = backgroundColor;
        this.FontColor = fontColor;
    }
}
