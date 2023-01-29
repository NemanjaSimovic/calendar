import { Time } from "@angular/common";
import { User } from "./user.model";

export class Calendartaskextended {
    id: number = 0;
    title: string = "";
    description: string = "";

    startTime: Date = new Date(2023, 1, 1);
    endTime: Date = new Date(2023, 1, 1);

    calendarId: number = 1;
    calendarName: string = "work";

    participantIds: number[] = [];
    participantNames: string[] = [];

    creatorId: number = 1;
    creatorName: string = "";

    calendarColorId: number = 1;
    calendarColorRGBString: string = "";

    emojiId: number = 1;
    emojiEmoticon: string = "";

    knownForEveryone: boolean = true;
    titleForEveryone?: string;
    descriptionForEveryone?: string;
}
