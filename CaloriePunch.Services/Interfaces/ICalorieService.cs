using CaloriePunch.Data.Entities;
using CaloriePunch.Services.Common;
using System.Threading.Tasks;

namespace CaloriePunch.Services.Interfaces
{
    public interface ICalorieService
    {
        Task<ServiceResult> AddEntryAsync(CalorieEntry entry);
        Task<ServiceResult> GetUserEntriesAsync(string userId);
        Task<ServiceResult> GetUserEntryByIdAsync(string entryId, string userId);
        Task<ServiceResult> UpdateEntryAsync(CalorieEntry entry);
    }
}