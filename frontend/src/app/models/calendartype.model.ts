export class Calendartype {
    id?: string;
    name: string = "";
    wholeday: boolean = false;
    canOverlap: boolean = false;
    knownByEveryone: boolean = true;

    constructor(name: string, wholeday: boolean, canOverlap: boolean, knownByEveryone: boolean){
        this.name = name;
        this.wholeday = wholeday;
        this.canOverlap = canOverlap;
        this.knownByEveryone = knownByEveryone;
    }
}
