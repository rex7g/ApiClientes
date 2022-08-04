using ApiClientes.Modelos;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ApiClientes.Repositorio.MondoDBConexion;

namespace ApiClientes.Repositorio
{
    public class ClienteCollection:IClienteCollection
     {
        internal Mongo_conexion _repository = new Mongo_conexion();
        private IMongoCollection<Clientes> Collection;

        public ClienteCollection()
        {
            Collection = _repository.db.GetCollection<Clientes>("Clientes");

        }


        public async Task DeleteCliente(string id)
        {
            //añadiendo filtro al metodo delete , 
            //cuando el Id sea igual al id de la base de datos sera eliminado
            var filter = Builders<Clientes>.Filter.Eq(s => s.ID, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);

        }

        public async Task<List<Clientes>> GetAllClientes()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Clientes> GetClienteById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }
        public async Task InsertCliente(Clientes clientes)
        {
            await Collection.InsertOneAsync(clientes);
        }

        public async Task UpdateCliente(Clientes clientes)
        {
            var filter = Builders<Clientes>.Filter.Eq(s => s.ID, clientes.ID);
            await Collection.ReplaceOneAsync(filter, clientes);
        }

    }
}
