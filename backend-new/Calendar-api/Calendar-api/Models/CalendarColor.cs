using System.ComponentModel.DataAnnotations;

namespace Calendar_api.Models
{
    public class CalendarColor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public string? FontColor { get; set; }

        public CalendarColor(int id, string name, string backgroundColor, string? fontColor)
        {
            Id = id;
            Name = name;
            BackgroundColor = backgroundColor;
            FontColor = fontColor;
        }
    }
}
