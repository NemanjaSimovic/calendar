using CalApp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CalApp.Services;

public class MongoDBService{

    private MongoClient client { get; }
    public IMongoDatabase database { get; }


    private readonly IMongoCollection<Caltest> _playlistcollection;
    // private readonly IMongoCollection<Caltask> _tasks_cal_collection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings){
        client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _playlistcollection = database.GetCollection<Caltest>(mongoDBSettings.Value.CalTestCollectionName);
        // _tasks_cal_collection = database.GetCollection<Caltask>(mongoDBSettings.Value.CalTaskCollectionName);
    }

    public async Task createAsync(Caltest test){
        await _playlistcollection.InsertOneAsync(test);
        return;
    }

    public async Task<List<Caltest>> GetAsync(){
        return await _playlistcollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task UpdateTitleAsync(string id, string newTitle){
        FilterDefinition<Caltest> filter = Builders<Caltest>.Filter.Eq("Id", id);
        UpdateDefinition<Caltest> update = Builders<Caltest>.Update.Set("title", newTitle);
        await _playlistcollection.UpdateOneAsync(filter, update);
        return;
    }

    public async Task DeleteAsync(string id){
        FilterDefinition<Caltest> filter = Builders<Caltest>.Filter.Eq("Id", id);
        await _playlistcollection.DeleteOneAsync(filter);
        return;
    }

}