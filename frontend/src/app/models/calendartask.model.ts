export class Calendartask {
  id?: number;
  title: string = "";
  description: string = "";

  startTime: Date = new Date(2023, 1, 1);
  endTime: Date = new Date(2023, 1, 1);

  calendarId: number = 1;

  creatorId: number = 1;

  calendarColorId: number = 1;

  emojiId: number = 1;

  knownForEveryone: boolean = true;
  titleForEveryone?: string;
  descriptionForEveryone?: string;
}
