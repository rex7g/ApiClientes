using ApiClientes.Modelos;
using ApiClientes.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiClientes.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ClienteController : Controller
    {
            public IClienteCollection db = new ClienteCollection();

        //EndPoints

            [HttpGet]
            public async Task<IActionResult> GetAllClientes()
            {
                return Ok(await db.GetAllClientes());

            }

            //Obtener Cliente por ID
            [HttpGet("id")]

            public async Task<IActionResult> GetClienttDetails(string id)
            {
                return Ok(await db.GetClienteById(id));
            }
            //Crea el cliente asegurandose que los principales Campos no deben estar vacio

            [HttpPost]
            public async Task CreateCliente([FromBody] Clientes clientes)
            {

                if (clientes.Nombre == string.Empty)
                {

                    ModelState.AddModelError("Nombre", "El nombre del Cliente No puede estar vacio");

                }
                 if (clientes.Cedula == string.Empty)
                 {
                     ModelState.AddModelError("Cedula", "La Cedula del Cliente No puede estar vacia");

                 }
                 if (clientes.Email == string.Empty)
                   {
                    ModelState.AddModelError("Email", "El Email del Cliente No puede estar vacio");

                     }
                if(clientes.Telefono == string.Empty)
                 {
                    ModelState.AddModelError("Telefono", "El Telefono del Cliente No puede estar vacio");

                }
                else
              {
                await db.InsertCliente(clientes);

              }


        }
        //Actualiza el cliente segun su ID 

            [HttpPut("{id}")]
            public async Task UpdateCliente([FromBody] Clientes clientes, string id)
          {


            if (clientes.Nombre == string.Empty)
            {
                ModelState.AddModelError("Nombre", "El nombre del cliente no debe estar vacio");

            }
            if (clientes.Cedula == string.Empty)
            {
                ModelState.AddModelError("Cedula", "La Cedula del Cliente No puede estar vacia");

            }
            if (clientes.Email == string.Empty)
            {
                ModelState.AddModelError("Email", "El Email del Cliente No puede estar vacio");

            }
            if (clientes.Telefono == string.Empty)
            {
                ModelState.AddModelError("Telefono", "El Telefono del Cliente No puede estar vacio");

            }
            else
            {
                clientes.ID = new MongoDB.Bson.ObjectId(id);
                await db.UpdateCliente(clientes);
            }


        }
        //Elimina un CLiente segun su ID
        [HttpDelete]
        public async Task<ActionResult> DeleteCliente(string id)
        {
            await db.DeleteCliente(id);
            return NoContent();
        }

        
    }
}

