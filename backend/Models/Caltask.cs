using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace CalApp.Models;

public class Caltask
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string title { get; set; } = "";
    public string description { get; set; } = "";

    public string color { get; set; } = "";

    // public DateTime taskDate { get; set; }
    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime startTime { get; set; }
    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime endTime { get; set; }
    public string[]? participantIds { get; set;}
    public string[]? participantFullNames { get; set;}
    public string? creatorId { get; set; }
    public string? creatorFullName { get; set; }
    
    public Caltask(){}

}