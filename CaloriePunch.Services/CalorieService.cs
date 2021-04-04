using CaloriePunch.Data;
using CaloriePunch.Data.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaloriePunch.Services
{
    public class CalorieService
    {
        private IDataContext _db;
        private readonly IMongoCollection<CalorieEntry> _logCollection;

        public CalorieService(IDataContext dataService)
        {
            _db = dataService;
            _logCollection = _db.GetCollection<CalorieEntry>();
        }
    }
}
