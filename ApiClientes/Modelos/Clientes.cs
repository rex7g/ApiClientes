using ApiClientes.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ApiClientes.Modelos
{
    public class Clientes
    {

        //Para demostrar mis conocimientos de BACKEND y de como se manejarian los clientes de una Empresa X Cree una api , la api esta hecha con la base de datos 
        //MONGODB ,  es una base de datos no relacional conocida como NOSQL , Para esto utilizo paquetes como MONGOCLIENT , MONGODRIVER 
        //En los controladores estan las validaciones y los metodos que permiten hacer un Crud de CLientes digase que puedo , Crear , Actualizar , Leer y Eliminarlos
        //Esta api esta realizada en ASP.NetCore 5 y MongoDB, estoy usando el patron repositorio  por lo que no estoy usando Midelwares

        [BsonId]
        

        public ObjectId ID { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Edad { get; set; }
        public DateTime fecha_Nacimiento { get; set; }
        public string Cedula { get; set; }
        public Esexo Genero { get; set; }



    }
}
