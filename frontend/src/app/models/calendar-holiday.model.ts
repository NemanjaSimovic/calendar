export class CalendarHoliday {
  id?: number;
  title: string = "";
  description: string = "";
  day: number = 1;
  month: number = 1;
  calendarId: number = 1;
  colorId: number = 1;
  emojiId: number = 1;

  constructor(title?: string, description?: string,
    day?: number, month?: number, calendarId?: number,
    colorId?: number, emojiId?: number){
    this.title = title ?? "";
    this.description = description ?? "";
    this.day = day ?? 1;
    this.month = month ?? 1;
    this.calendarId = calendarId ?? 1;
    this.colorId = colorId ?? 1;
    this.emojiId = emojiId ?? 1;
  }
}
