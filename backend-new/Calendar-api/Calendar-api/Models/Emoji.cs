namespace Calendar_api.Models
{
    public class Emoji
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Emoticon { get; set; }

        public Emoji(int id, string name, string emoticon)
        {
            Id = id;
            Name = name;
            Emoticon = emoticon;
        }
    }
    
}
