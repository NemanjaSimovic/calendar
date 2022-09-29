using CalApp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CalApp.Services;

public class UrgencyColorService{

    private MongoClient client { get; }
    public IMongoDatabase database { get; }
    private readonly IMongoCollection<UrgencyColor> _urgency_color_cal_collection;

    public UrgencyColorService(IOptions<MongoDBSettings> mongoDBSettings){
        client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _urgency_color_cal_collection = database.GetCollection<UrgencyColor>(mongoDBSettings.Value.UrgencyColorCollectionName);
    }

    public async Task createAsync(UrgencyColor color){
        await _urgency_color_cal_collection.InsertOneAsync(color);
        return;
    }

    public async Task<List<UrgencyColor>> GetAsyncAll(){
        return await _urgency_color_cal_collection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task UpdateColorAsync(string urgency, string color){
        FilterDefinition<UrgencyColor> filter = Builders<UrgencyColor>.Filter.Eq("urgency", urgency);
        UpdateDefinition<UrgencyColor> update = Builders<UrgencyColor>.Update.Set("color", color);
        await _urgency_color_cal_collection.UpdateOneAsync(filter, update);
        return;
    }

    public async Task DeleteAsync(string id){
        FilterDefinition<UrgencyColor> filter = Builders<UrgencyColor>.Filter.Eq("Id", id);
        await _urgency_color_cal_collection.DeleteOneAsync(filter);
        return;
    }

}