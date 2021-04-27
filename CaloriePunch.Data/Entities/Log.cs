using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaloriePunch.Data.Entities
{
    public class Log
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public LogType LogType { get; set; }
        public string Message { get; set; }
        public string ExternalIdentifier { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public enum LogType
    {
        Info,
        Error,
        Warning
    }
}
