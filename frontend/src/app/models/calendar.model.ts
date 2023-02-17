export class Calendar {
    id?: number;
    name: string;
    description: string;
    isForHolidays: boolean = false;
    constructor(name?: string, description?: string, isForHolidays?: boolean){
        this.name = name? name: "defaultName";
        this.description = description? description: "defaultDescription";
        this.isForHolidays = isForHolidays? isForHolidays: false;
    }
}
