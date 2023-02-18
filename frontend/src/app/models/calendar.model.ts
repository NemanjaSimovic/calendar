export class Calendar {
    Id?: number;
    Name: string;
    Description: string;
    IsForHolidays: boolean = false;
    constructor(name?: string, description?: string, isForHolidays?: boolean){
        this.Name = name? name: "defaultName";
        this.Description = description? description: "defaultDescription";
        this.IsForHolidays = isForHolidays? isForHolidays: false;
    }
}
