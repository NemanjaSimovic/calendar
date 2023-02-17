namespace Calendar_api.Models
{
    public class Calendar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsForHolidays  { get; set; }

        public Calendar(int id, string name, string description, bool isForHolidays)
        {
            Id = id;
            Name = name;
            Description = description;
            IsForHolidays = isForHolidays;
        }
    }
}
