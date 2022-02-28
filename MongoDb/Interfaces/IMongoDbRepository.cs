using MongoDb.Models;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDb.Interfaces
{
    public interface IMongoDbRepository<TDocument>
    {
        Task<List<TDocument>> GetAll();
        Task<TDocument> GetById(string id);
        Task Add(TDocument document);
        Task Update(TDocument document);
        Task Update(string id, TDocument document);
        Task Remove(string id);
        Task Remove(TDocument document);
    }
}
