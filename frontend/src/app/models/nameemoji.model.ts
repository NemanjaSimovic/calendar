export class Nameemoji {
    id?: string;
    name: string = "";
    emoji: string = "";
    type: string = "";

    constructor(name: string, emoji: string, type: string){
        this.name = name;
        this.emoji = emoji;
        this.type = type;
    }
}
