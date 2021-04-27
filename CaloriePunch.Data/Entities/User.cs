using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaloriePunch.Data.Entities
{
    public class User
    {
        public User()
        {
            CalorieEntries = new HashSet<CalorieEntry>();
            UserGoals = new HashSet<UserGoal>();
        }


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<CalorieEntry> CalorieEntries { get; set; }
        public virtual ICollection<UserGoal> UserGoals { get; set; }
    }
}
