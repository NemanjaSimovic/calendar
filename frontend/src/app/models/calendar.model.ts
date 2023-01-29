export class Calendar {
    id?: number;
    name: string;
    description: string;
    constructor(name?: string, description?: string){
        this.name = name? name: "defaultName";
        this.description = description? description: "defaultDescription";
    }
}
