using CaloriePunch.Data.Entities;
using CaloriePunch.Data.Settings.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaloriePunch.Data
{
    public class DataContext : IDataContext
    {
        public IMongoDatabase Context { get; }

        public DataContext(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            Context = client.GetDatabase(databaseSettings.DatabaseName);
        }


        public IMongoCollection<User> Users => GetCollection<User>();
        public IMongoCollection<CalorieEntry> CalorieEntries => GetCollection<CalorieEntry>();
        public IMongoCollection<UserGoal> UserGoals => GetCollection<UserGoal>();


        public IMongoCollection<T> GetCollection<T>() where T : class
        {
            return Context.GetCollection<T>(nameof(T));
        }

    }
}
