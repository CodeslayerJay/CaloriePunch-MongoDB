using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaloriePunch.Data.Entities
{
    public class UserGoal
    {
        [BsonId] // primary key
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserId { get; set; }
        public GoalType GoalType { get; set; }
        public double? WeeklyCalories { get; set; }

        public double? GoalWeight { get; set; }
        public DateTime? DateAchieved { get; set; }

        public bool IsCurrent { get; set; }
        public virtual User User { get; set; }
    }

    public enum GoalType
    {
        Lose = 0,
        Maintain,
        Gain
    }
}
