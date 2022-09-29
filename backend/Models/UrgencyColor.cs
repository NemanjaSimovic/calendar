using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace CalApp.Models;

public class UrgencyColor
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string urgency { get; set; } = "";
    public string color { get; set; } = "";

    public UrgencyColor(string urgency, string color){
        this.urgency = urgency;
        this.color = color;
    }

    public UrgencyColor(){
        this.urgency = "";
        this.color = "";
    }
}