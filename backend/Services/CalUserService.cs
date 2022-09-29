using CalApp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CalApp.Services;

public class CalUserService{

    private MongoClient client { get; }
    public IMongoDatabase database { get; }
    private readonly IMongoCollection<Caluser> _users_cal_collection;

    public CalUserService(IOptions<MongoDBSettings> mongoDBSettings){
        client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _users_cal_collection = database.GetCollection<Caluser>(mongoDBSettings.Value.CalUserCollectionName);
    }

    public async Task createAsync(Caluser user){
        await _users_cal_collection.InsertOneAsync(user);
        return;
    }

    public async Task<List<Caluser>> GetAsyncAll(){
        return await _users_cal_collection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<Caluser?> GetAsyncById(string id){
        return await _users_cal_collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
    public async Task<Caluser?> GetAsyncByUserAndPass(string username, string password){
        return await _users_cal_collection.Find(x => x.username == username && x.password == password).FirstOrDefaultAsync();
    }

    public async Task UpdatePasswordAsync(string id, string newPassword){
        FilterDefinition<Caluser> filter = Builders<Caluser>.Filter.Eq("Id", id);
        UpdateDefinition<Caluser> update = Builders<Caluser>.Update.Set("password", newPassword);
        await _users_cal_collection.UpdateOneAsync(filter, update);
        return;
    }

    public async Task DeleteAsync(string id){
        FilterDefinition<Caluser> filter = Builders<Caluser>.Filter.Eq("Id", id);
        await _users_cal_collection.DeleteOneAsync(filter);
        return;
    }

}