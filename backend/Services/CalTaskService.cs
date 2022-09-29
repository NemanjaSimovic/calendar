using CalApp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Globalization;

namespace CalApp.Services;

public class CalTaskService{

    private MongoClient client { get; }
    public IMongoDatabase database { get; }
    private readonly IMongoCollection<Caltask> _tasks_cal_collection;

    public CalTaskService(IOptions<MongoDBSettings> mongoDBSettings){
        client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _tasks_cal_collection = database.GetCollection<Caltask>(mongoDBSettings.Value.CalTaskCollectionName);
    }

    

    public async Task createAsync(Caltask task){
        await _tasks_cal_collection.InsertOneAsync(task);
        return;
    }

    public async Task<List<Caltask>> GetAsyncAll(){
        return await _tasks_cal_collection.Find(new BsonDocument()).ToListAsync();
    }

    // public async Task<Caluser?> GetAsyncById(string id){
    //     return await _users_cal_collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    // }

    public List<Caltask> FilterForThisMonth(List<Caltask> tasks, DateTime month)
    {
        month = new DateTime(month.Year, month.Month, 1);
        DateTime nextMonth = month;
        nextMonth = nextMonth.AddMonths(1);
        List<Caltask> result = new List<Caltask>();
        foreach (Caltask tsk in tasks)
        {
            if (tsk.startTime > month & tsk.startTime < nextMonth)
            {
                result.Add(tsk);
            }
        }

        return result;
    }

    public async Task<List<Caltask>?> GetAsyncAllByMonth(string mth){
        DateTime month = DateTime.ParseExact(mth, "yyyy/MM/dd", CultureInfo.InvariantCulture); 

        List<Caltask> tasks = await _tasks_cal_collection.Find(new BsonDocument()).ToListAsync();
        List<Caltask> result = FilterForThisMonth(tasks, month);
       
        return result;
    }
    public async Task<List<Caltask>?> GetAsyncByIdAndMonth(string mth, string id){
        DateTime month = DateTime.ParseExact(mth, "yyyy/MM/dd", CultureInfo.InvariantCulture);
        
        FilterDefinition<Caltask> filter = Builders<Caltask>.Filter.AnyStringIn("participantIds", id); // .Eq("creatorId", id);
        List<Caltask> tasks =  await _tasks_cal_collection.Find(filter).ToListAsync();
        List<Caltask> result =  FilterForThisMonth(tasks, month);
        return result;
    }

    // public async Task UpdatePasswordAsync(string id, string newPassword){
    //     FilterDefinition<Caluser> filter = Builders<Caluser>.Filter.Eq("Id", id);
    //     UpdateDefinition<Caluser> update = Builders<Caluser>.Update.Set("password", newPassword);
    //     await _users_cal_collection.UpdateOneAsync(filter, update);
    //     return;
    // }

    // public async Task DeleteAsync(string id){
    //     FilterDefinition<Caluser> filter = Builders<Caluser>.Filter.Eq("Id", id);
    //     await _users_cal_collection.DeleteOneAsync(filter);
    //     return;
    // }

}