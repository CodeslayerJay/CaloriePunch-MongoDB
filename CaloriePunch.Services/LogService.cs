using CaloriePunch.Data;
using CaloriePunch.Data.Entities;
using CaloriePunch.Services.Common;
using CaloriePunch.Services.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CaloriePunch.Services
{
    public class LogService : ILogService
    {
        private IDataContext _db;
        private readonly IMongoCollection<Log> _logCollection;

        public LogService(IDataContext dataService)
        {
            _db = dataService;
            _logCollection = _db.Logs;
        }

        public void AddLog(string msg, LogType logType = LogType.Info, string externalId = null)
        {
            if (string.IsNullOrEmpty(msg) == false)
            {
                var log = new Log
                {
                    Message = msg,
                    CreatedAt = DateTime.Now,
                    LogType = logType,
                    ExternalIdentifier = externalId
                };

                AddLog(log);
            }
        }

        public Log AddLog(Log log)
        {
            if (log == null) return null;
            
            _logCollection.InsertOne(log);
            return log;
        }

        public void LogError(string message, string externalId = null)
        {
            AddLog(new Log
            {
                Message = message,
                LogType = LogType.Error,
                ExternalIdentifier = externalId,
                CreatedAt = DateTime.Now
            });
        }

        public IList<Log> GetLogs() => _logCollection.Find(x => true).ToList();
        public Log Find(string id) => _logCollection.Find(x => x.Id == id).FirstOrDefault();
        public void Update(Log log) => _logCollection.ReplaceOne(x => x.Id == log.Id, log);
        public void Delete(string id) => _logCollection.DeleteOne(x => x.Id == id);
    }
}
