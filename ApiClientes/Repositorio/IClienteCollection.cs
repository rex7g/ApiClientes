using ApiClientes.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiClientes.Repositorio
{
    public interface IClienteCollection
    {
        Task InsertCliente(Clientes clientes);
        Task UpdateCliente(Clientes clientes);
        Task DeleteCliente (string id);
        Task<List<Clientes>> GetAllClientes();
        Task<Clientes> GetClienteById(string id);
    }
}
