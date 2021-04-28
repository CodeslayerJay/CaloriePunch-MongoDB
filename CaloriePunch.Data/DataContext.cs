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


        public IMongoCollection<User> Users => Context.GetCollection<User>("Users");
        public IMongoCollection<CalorieEntry> CalorieEntries => Context.GetCollection<CalorieEntry>("CalorieEntries");
        public IMongoCollection<UserGoal> UserGoals => Context.GetCollection<UserGoal>("UserGoals");
        public IMongoCollection<Log> Logs => Context.GetCollection<Log>("Logs");


        //public IMongoCollection<T> GetCollection<T>() where T : class
        //{
        //    return Context.GetCollection<T>(nameof(T));
        //}

    }
}
