using Microsoft.Extensions.Configuration;
using MongoDb.Interfaces;
using MongoDb.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDb.Services
{
    public class MongoDbRepository<TDocument> : IMongoDbRepository<TDocument> where TDocument: DocumentMongoDb
    {
        private readonly string DatabaseName;
        private readonly string CollectionName;
        private readonly string ConnectionString;
        public IMongoCollection<TDocument> Collection => new MongoClient(ConnectionString)
                .GetDatabase(DatabaseName)
                .GetCollection<TDocument>(CollectionName);
        public IMongoQueryable<TDocument> QueryableCollection => 
            Collection.AsQueryable();

        public MongoDbRepository(string connectionString, string databaseName, string collectionName)
        {
            DatabaseName = databaseName;
            CollectionName = collectionName;
            ConnectionString = connectionString;
        }

        public async Task<List<TDocument>> GetAll() =>
            await Collection.AsQueryable().ToListAsync();

        public async Task<TDocument> GetById(string id) =>
            await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task Add(TDocument document) =>
            await Collection.InsertOneAsync(document);

        public async Task Update(TDocument document) =>
            await Collection.ReplaceOneAsync(x => x.Id == document.Id, document);

        public async Task Update(string id, TDocument document) =>
            await Collection.ReplaceOneAsync(x => x.Id == id, document);

        public async Task Remove(string id) =>
            await Collection.DeleteOneAsync(x => x.Id == id);

        public async Task Remove(TDocument document) =>
            await Collection.DeleteOneAsync(x => x.Id == document.Id);
    }
}
