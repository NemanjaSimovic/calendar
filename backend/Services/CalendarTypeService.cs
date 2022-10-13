using CalApp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CalApp.Services;

public class CalendarTypeService{

    private MongoClient client { get; }
    public IMongoDatabase database { get; }
    private readonly IMongoCollection<CalendarType> _calendar_types_collection;

    public CalendarTypeService(IOptions<MongoDBSettings> mongoDBSettings){
        client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _calendar_types_collection = database.GetCollection<CalendarType>(mongoDBSettings.Value.CalendarTypeCollectionName);
    }

    public async Task createAsync(CalendarType calType){
        await _calendar_types_collection.InsertOneAsync(calType);
        return;
    }

    public async Task<List<CalendarType>> GetAsyncAll(){
        return await _calendar_types_collection.Find(new BsonDocument()).ToListAsync();
    }

    // public async Task UpdateColorAsync(string urgency, string color){
    //     FilterDefinition<UrgencyColor> filter = Builders<UrgencyColor>.Filter.Eq("urgency", urgency);
    //     UpdateDefinition<UrgencyColor> update = Builders<UrgencyColor>.Update.Set("color", color);
    //     await _urgency_color_cal_collection.UpdateOneAsync(filter, update);
    //     return;
    // }

    // public async Task DeleteAsync(string id){
    //     FilterDefinition<UrgencyColor> filter = Builders<UrgencyColor>.Filter.Eq("Id", id);
    //     await _urgency_color_cal_collection.DeleteOneAsync(filter);
    //     return;
    // }

}