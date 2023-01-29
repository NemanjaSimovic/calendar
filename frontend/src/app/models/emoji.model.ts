export class Emoji {
    id?: number;
    name: string = "";
    emoticon: string = "";

    constructor(name: string, emoticon: string){
        this.name = name;
        this.emoticon = emoticon;
    }
}
