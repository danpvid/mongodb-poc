using Microsoft.Extensions.Configuration;
using MongoDb.Interfaces;
using MongoDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDb.Services
{
    public class ProdutoRepository : MongoDbRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(IConfiguration config) 
            : base(
                connectionString: config.GetConnectionString("MongoDbConnection"), 
                databaseName: "smartfield", 
                collectionName: "produto"
            )
        {
        }
    }
}
