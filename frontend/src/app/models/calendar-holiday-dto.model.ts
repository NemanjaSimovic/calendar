export class CalendarHolidayDto {
  id?: number;
  title: string = "";
  description: string = "";
  day: number = 1;
  month: number = 1;
  calendarId: number = 1;
  calendarColorId: number = 1;
  calendarColorBackgroundColor: string = "";
  calendarColorFontColor: string = "";
  emojiId: number = 1;
  emojiEmoticon: string = "";

  constructor(title?: string, description?: string,
    day?: number, month?: number, calendarId?: number,
    colorId?: number, calendarColorBackgroundColor?: string,
    calendarColorFontColor?: string, emojiId?: number,
    emojiEmoticon?: string ){
    this.title = title ?? "";
    this.description = description ?? "";
    this.day = day ?? 1;
    this.month = month ?? 1;
    this.calendarId = calendarId ?? 1;
    this.calendarColorId = colorId ?? 1;
    this.calendarColorBackgroundColor = calendarColorBackgroundColor ?? "";
    this.calendarColorFontColor = calendarColorFontColor ?? "";
    this.emojiId = emojiId ?? 1;
    this.emojiEmoticon = emojiEmoticon ?? "";
  }
}
