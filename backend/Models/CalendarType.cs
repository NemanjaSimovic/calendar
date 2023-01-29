using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace CalApp.Models;

public class CalendarType
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    //1. global work/bussines, 2. local work/business, 3. local fixedtime (dentist, car repair, see a doctor ...), 4. birthdays 5. holidays
    public string name { get; set; } = "";
    //true = wholeday - birthday or holiday, false = fixedtime - fixed time of task, mostly work/business or something like going to dentist, or car repair
    public bool wholeday { get; set; } = false;

    //true = when someone is adding new task it can not overlap with another markAsWork task (for the same person),
    //false = can overlap with everything, used for rough timings of tasks/events of lesser importance as a rather reminder. 
    public bool canOverlap { get; set; } = false;
    
    public bool knownByEveryone { get; set; } = true;    
    
    public CalendarType(){}

}