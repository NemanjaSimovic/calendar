using CalApp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CalApp.Services;

public class NameEmojiService{

    private MongoClient client { get; }
    public IMongoDatabase database { get; }
    private readonly IMongoCollection<NameEmoji> _emoji_collection;

    public NameEmojiService(IOptions<MongoDBSettings> mongoDBSettings){
        client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _emoji_collection = database.GetCollection<NameEmoji>(mongoDBSettings.Value.NameEmojiCollectionName);
    }

    public async Task createAsync(NameEmoji nameEmoji){
        await _emoji_collection.InsertOneAsync(nameEmoji);
        return;
    }

    public async Task<List<NameEmoji>> GetAsyncAll(){
        return await _emoji_collection.Find(new BsonDocument()).ToListAsync();
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