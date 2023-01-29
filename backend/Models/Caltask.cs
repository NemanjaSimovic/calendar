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
    public bool appliesToEveryone { get; set; } = false;
    public string? creatorId { get; set; }
    public string? creatorFullName { get; set; }

    public string? calendarType { get; set; } = "work";

    //true = wholeday - birthday or holiday
    //false = fixedtime - fixed time of task, mostly work/business related or something like going to dentist, or car repair
    public bool wholeday { get; set; } = false;

    //true = when someone is adding new task it can not overlap with another markAsWork task (for the same person)
    //false = can overlap with everything, used for rough timings of tasks/events of lesser importance as a rather reminder 
    public bool canOverlap { get; set; } = true;

    public bool knownByEveryone { get; set; } = true;
    public string emoji { get; set; } = "";
    
    public Caltask(){}

}