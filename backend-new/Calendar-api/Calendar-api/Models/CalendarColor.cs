using System.ComponentModel.DataAnnotations;

namespace Calendar_api.Models
{
    public class CalendarColor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RGBString { get; set; }
    }
}
