using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace CalApp.Models;

public class NameEmoji
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string name { get; set; } = "";
    public string emoji { get; set; } = "";
    public string type { get; set; } = "";
    public NameEmoji(){}

}