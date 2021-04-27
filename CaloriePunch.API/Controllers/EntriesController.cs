using CaloriePunch.API.Utils;
using CaloriePunch.Data.Entities;
using CaloriePunch.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaloriePunch.API.Controllers
{
    public class EntriesController : BaseApiController
    {
        private readonly ICalorieService _calorieService;

        public EntriesController(ICalorieService calorieService, ILogService logService) : base(logService)
        {
            _calorieService = calorieService;
        }

        // Entries
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _calorieService.GetUserEntriesAsync(base.UserId);
                return Ok(response.ResultCollection);
            }
            catch(Exception ex)
            {
                base.LogError(ex.StackTrace);
                return BadRequest(AppConstants.GenericErrorMsg);
            }

        }

        // Entries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var response = await _calorieService.GetUserEntryByIdAsync(id, base.UserId);
                return Ok(response.Result);
            }
            catch (Exception ex)
            {
                base.LogError(ex.StackTrace);
                return BadRequest(AppConstants.GenericErrorMsg);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CalorieEntryUpsertBindingModel model)
        {
            try
            {
                return Ok(await _calorieService.AddEntryAsync(MapToCalorieEntry(model)));
            }
            catch(Exception ex)
            {
                base.LogError(ex.StackTrace);
                return BadRequest(AppConstants.GenericErrorMsg);
            }
        }

        public class CalorieEntryUpsertBindingModel
        {
            public string Id { get; set; }
            [Required]
            public string UserId { get; set; }
            public double? Calories { get; set; }
            public double? Fat { get; set; }
            public double? Carbs { get; set; }
            public double? Protein { get; set; }
            public int Quantity { get; set; } = 1;
            public string EntryName { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.Now;
        }

        private CalorieEntry MapToCalorieEntry(CalorieEntryUpsertBindingModel model)
        {
            var entry = new CalorieEntry
            {
                Id = model.Id,
                UserId = model.UserId,
                Calories = model.Calories,
                Fat = model.Fat,
                Carbs = model.Carbs,
                Protein = model.Protein,
                Quantity = model.Quantity,
                EntryName = model.EntryName,
                CreatedAt = model.CreatedAt
            };

            return entry;
        }

    }
}
