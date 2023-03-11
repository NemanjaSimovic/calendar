namespace Calendar_api.Models
{
    public class UserAvailabilityDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public bool IsAvailable { get; set; }

        public UserAvailabilityDto(int id, string name, bool isAvailable)
        {
            Id = id;
            Name = name;
            IsAvailable = isAvailable;
        }
    }
}
