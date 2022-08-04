using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiClientes.Repositorio
{
    public class MondoDBConexion
    {
        public class Mongo_conexion
        {
            public MongoClient Client;
            public IMongoDatabase db;

            //conexion a mongodb
            public Mongo_conexion()
            {

                Client = new MongoClient("mongodb://127.0.0.1:27017");
                db = Client.GetDatabase("coopanuesp");

            }
            public async Task<T> GetByIdAsync<T>(string id) where T : class
            {
                if (!id.Length.Equals(24))
                    return default(T);

                var filter = Builders<T>.Filter.Eq("id", id);

                var x = await db.GetCollection<T>(typeof(T).Name)
                    .Find(filter).FirstOrDefaultAsync();
                return x;
            }
            public async Task<List<T>> GetAll<T>() where T : class
            {
                var lst = await db.GetCollection<T>(typeof(T).Name).FindAsync("{}");
                return lst.ToList();
            }

            public async Task<List<T>> GetByFilter<T>(FilterDefinition<T> filter) where T : class
            {
                var lst = await db.GetCollection<T>(typeof(T).Name).FindAsync(filter);
                return lst.ToList();
            }

            public async Task<T> PostAsync<T>(T source) where T : class
            {
                var collection = db.GetCollection<T>(typeof(T).Name);

                try
                {
                    await collection.InsertOneAsync(source);

                    return source;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            public async Task<T> PutAsync<T>(T source, string id) where T : class
            {
                var filter = Builders<T>.Filter.Eq("id", id);

                await db.GetCollection<T>(typeof(T).Name).ReplaceOneAsync(filter, source);
                return source;
            }

            public async Task<bool> DeleteAsync<T>(string id) where T : class
            {
                try
                {
                    var filter = Builders<T>.Filter.Eq("id", id);
                    await db.GetCollection<T>(typeof(T).Name).DeleteOneAsync(filter);

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }




        }
    }
}
