export class Urgencycolor {
    id?: number;
    name: string = "";
    BackgroundColor: string = "";
    FontColor?: string

    constructor(name: string, backgroundColor: string, fontColor?: string){
        this.name = name;
        this.BackgroundColor = backgroundColor;
        this.FontColor = fontColor;
    }
}
