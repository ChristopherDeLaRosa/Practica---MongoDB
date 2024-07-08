using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvinciasMongoDB
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Provincia> _provinciasCollection;

        public MongoDBService()
        {
            var client = new MongoClient("mongodb+srv://dchristopher556:ft1w3cb60bPdbFQh@cluster0.lbjjgjc.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
            var database = client.GetDatabase("ProvinciasDB");
            _provinciasCollection = database.GetCollection<Provincia>("Provincias");
        }

        public async Task<List<Provincia>> GetAllProvinciasAsync()
        {
            return await _provinciasCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task InsertProvinciaAsync(Provincia provincia)
        {
            await _provinciasCollection.InsertOneAsync(provincia);
        }
    }
}
