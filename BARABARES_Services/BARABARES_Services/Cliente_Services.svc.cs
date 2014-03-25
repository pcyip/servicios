using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BARABARES_Services.DTO;

namespace BARABARES_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Cliente_Services" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Cliente_Services.svc or Cliente_Services.svc.cs at the Solution Explorer and start debugging.
    public class Cliente_Services : ICliente_Services
    {
        #region IClientes_Services Members

        public List<Cliente> getAll_Clientes()
        {
            List<Cliente> all_Clientes = new List<Cliente>();
            all_Clientes.Add(new Cliente()
            {
                Id = 1,
                Descripcion = "GG"
            });
            all_Clientes.Add(new Cliente()
            {
                Id = 2,
                Descripcion = "FF"
            });
            return all_Clientes;
        }

        public Cliente get_Cliente(string id)
        {
            return new Cliente()
            {
                Id = Convert.ToInt32(id),
                Descripcion = "get_Cliente"
            };
        }

        public bool add_Cliente(Cliente prod)
        {
            return true;
        }
        #endregion
    }
}
