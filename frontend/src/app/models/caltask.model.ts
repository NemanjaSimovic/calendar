import { Time } from "@angular/common";
import { Caluser } from "./caluser.model";

export class Caltask {
    id?: string;
    title: string = "";
    color: string = "";
    description: string = "";
    startTime: Date = new Date(2022, 1, 1);
    endTime: Date = new Date(2022, 1, 1);
    participantIds?: string[];
    participantFullNames?: string[];
    creatorId?: string;
    creatorFullName?: string;

    calendarType: string = "work";
    wholeday: boolean = false;
    canOverlap: boolean = false;
    knownByEveryone: boolean = true;
    holidayIcon: string = "";
}
