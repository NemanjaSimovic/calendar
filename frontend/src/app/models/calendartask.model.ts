export class Calendartask {
  Id?: number;
  Title: string = "";
  Description: string = "";

  StartTime: Date = new Date(2023, 1, 1);
  EndTime: Date = new Date(2023, 1, 1);

  CalendarId: number = 1;

  CreatorId: number = 1;

  CalendarColorId: number = 1;

  EmojiId: number = 1;

  KnownForEveryone: boolean = true;
  TitleForEveryone?: string;
  DescriptionForEveryone?: string;
}
