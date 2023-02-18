import { Time } from "@angular/common";
import { User } from "./user.model";

export class Calendartaskextended {
    Id: number = 0;
    Title: string = "";
    Description: string = "";

    StartTime: Date = new Date(2023, 1, 1);
    EndTime: Date = new Date(2023, 1, 1);

    CalendarId: number = 1;
    CalendarName: string = "work";

    ParticipantIds: number[] = [];
    ParticipantNames: string[] = [];

    CreatorId: number = 1;
    CreatorName: string = "";

    CalendarColorId: number = 1;
    CalendarColorBackgroundColor: string = "";
    CalendarColorFontColor: string = "";

    EmojiId: number = 1;
    EmojiEmoticon: string = "";

    KnownForEveryone: boolean = true;
    TitleForEveryone?: string;
    DescriptionForEveryone?: string;
}
