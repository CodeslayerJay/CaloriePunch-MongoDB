using CaloriePunch.Data.Entities;
using MongoDB.Driver;

namespace CaloriePunch.Data
{
    public interface IDataContext
    {
        IMongoCollection<CalorieEntry> CalorieEntries { get; }
        IMongoDatabase Context { get; }
        IMongoCollection<Log> Logs { get; }
        IMongoCollection<UserGoal> UserGoals { get; }
        IMongoCollection<User> Users { get; }
        //IMongoCollection<T> GetCollection<T>() where T : class;
    }
}