export class Emoji {
    Id?: number;
    Name: string = "";
    Emoticon: string = "";

    constructor(name: string, emoticon: string){
        this.Name = name;
        this.Emoticon = emoticon;
    }
}
