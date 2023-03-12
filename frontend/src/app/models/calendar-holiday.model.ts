export class CalendarHoliday {
  id?: number;
  title: string = "";
  description: string = "";
  calendarId: number = 1;
  calendarColorId: number = 1;
  emojiId: number = 1;
  isRepeatedYearly: boolean = true;
  day: number = 1;
  month: number = 1;
  year?: number;

  constructor(title?: string, description?: string,
    calendarId?: number, colorId?: number, emojiId?: number,
    isRepeatedYearly?: boolean, day?: number, month?: number, year?: number){
    this.title = title ?? "";
    this.description = description ?? "";
    this.calendarId = calendarId ?? 1;
    this.calendarColorId = colorId ?? 1;
    this.emojiId = emojiId ?? 1;
    this.isRepeatedYearly = isRepeatedYearly ?? true;
    this.day = day ?? 1;
    this.month = month ?? 1;
    this.year = year;
  }
}
