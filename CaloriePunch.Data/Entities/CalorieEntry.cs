using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaloriePunch.Data.Entities
{
    public class CalorieEntry
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserId { get; set; }
        public double? Calories { get; set; }
        public double? Fat { get; set; }
        public double? Carbs { get; set; }
        public double? Protein { get; set; }
        public int Quantity { get; set; }
        public string EntryName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
