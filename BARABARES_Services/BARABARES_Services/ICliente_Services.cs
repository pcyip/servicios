using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BARABARES_Services.DTO;
using System.ServiceModel.Web;

namespace BARABARES_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICliente_Services" in both code and config file together.
    [ServiceContract]
    public interface ICliente_Services
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "getAll_Clientes")]
        List<Cliente> getAll_Clientes();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "get_Cliente/{id}")]
        Cliente get_Cliente(string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "add_Cliente")]
        bool add_Cliente(Cliente cliente);
    }
}
