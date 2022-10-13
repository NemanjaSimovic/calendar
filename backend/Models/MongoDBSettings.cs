namespace CalApp.Models;

public class MongoDBSettings {
    public string ConnectionURI { get; set; } = null!; 
    public string DatabaseName { get; set; } = null!; 
    public string CalTestCollectionName { get; set; } = null!; 
    public string CalTaskCollectionName { get; set; } = null!; 
    public string CalUserCollectionName { get; set; } = null!; 
    public string UrgencyColorCollectionName { get; set; } = null!;
    public string CalendarTypeCollectionName { get; set; } = null!;
    public string NameEmojiCollectionName { get; set; } = null!;
}