using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace CalApp.Models;

public class Caluser
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? username { get; set; }
    public string? password { get; set; }

    public string? name { get; set; }
    public string? surname { get; set; }
    public string? email { get; set; }

    public Caluser(string username, string password, string name, string surname, string email){
        this.username = username;
        this.password = password;
        this.name = name;
        this.surname = surname;
        this.email = email;
    }

    public Caluser(){
        this.username = "";
        this.password = "";
        this.name = "";
        this.surname = "";
        this.email = "";
    }
}