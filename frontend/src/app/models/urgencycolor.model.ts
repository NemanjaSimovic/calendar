export class Urgencycolor {
    id: string | undefined;
    urgency: string = "";
    color: string = "";

    constructor(urgency: string, color: string){
        this.urgency = urgency;
        this.color = color;
    }
}
