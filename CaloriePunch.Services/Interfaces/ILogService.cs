using CaloriePunch.Data;
using CaloriePunch.Data.Entities;
using System;
using System.Collections.Generic;

namespace CaloriePunch.Services.Interfaces
{
    public interface ILogService
    {
        Log AddLog(Log log);
        void AddLog(string msg, LogType logType = LogType.Info, string externalId = null);

        void LogError(string msg, string externalId = null);
        void Delete(string id);
        Log Find(string id);
        IList<Log> GetLogs();
        void Update(Log log);
    }
}