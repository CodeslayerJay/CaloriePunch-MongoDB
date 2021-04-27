using CaloriePunch.Data;
using CaloriePunch.Data.Entities;
using CaloriePunch.Services.Common;
using CaloriePunch.Services.DTOs;
using CaloriePunch.Services.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriePunch.Services
{
    public class CalorieService : ICalorieService
    {
        private IDataContext _db;
        private readonly IMongoCollection<CalorieEntry> _entriesCollection;
        private readonly ServiceResult _serviceResult;

        public CalorieService(IDataContext dataService)
        {
            _db = dataService;
            _entriesCollection = _db.GetCollection<CalorieEntry>();
            _serviceResult = new ServiceResult();
        }

        public async Task<ServiceResult> GetUserEntriesAsync(string userId)
        {
            var entries = await _entriesCollection.Find(q => q.UserId == userId).ToListAsync();

            _serviceResult.ResultCollection.AddRange(entries.Select(q => MapToCalorieEntryDTO(q)));

            return _serviceResult;
        }

        public async Task<ServiceResult> GetUserEntryByIdAsync(string entryId, string userId)
        {
            var entry = await _entriesCollection.Find(q => q.Id == entryId && q.UserId == userId).FirstOrDefaultAsync();

            _serviceResult.ResultCollection.Add(MapToCalorieEntryDTO(entry));

            return _serviceResult;
        }

        public async Task<ServiceResult> AddEntryAsync(CalorieEntry entry)
        {

            if (ValidateEntry(entry) == false)
                return _serviceResult;

            await _entriesCollection.InsertOneAsync(entry);

            return null;
        }

        public async Task<ServiceResult> UpdateEntryAsync(CalorieEntry entry)
        {
            await _entriesCollection.ReplaceOneAsync(q => q.Id == entry.Id && q.UserId == entry.UserId, entry);
            _serviceResult.ResultCollection.Add(MapToCalorieEntryDTO(entry));

            return _serviceResult;
        }


        private bool ValidateEntry(CalorieEntry entry)
        {
            if (string.IsNullOrEmpty(entry.UserId))
                _serviceResult.Errors.Add("UserId is required.");

            return _serviceResult.Errors.Any();
        }

        private CalorieEntryDTO MapToCalorieEntryDTO(CalorieEntry entry)
        {
            var dto = new CalorieEntryDTO
            {
                Id = entry.Id,
                UserId = entry.UserId,
                Calories = entry.Calories,
                Carbs = entry.Carbs,
                Protein = entry.Protein,
                Fat = entry.Fat,
                CreatedAt = entry.CreatedAt,
                EntryName = entry.EntryName,
                Quantity = entry.Quantity
            };

            return dto;
        }
    }
}
