using MongoDB.Driver;

namespace CaloriePunch.Data
{
    public interface IDataContext
    {
        IMongoDatabase Context { get; }

        IMongoCollection<T> GetCollection<T>() where T : class;
    }
}