using BARABARES_Services.AppCode;
using BARABARES_Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BARABARES_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAlmacen_Services" in both code and config file together.
    [ServiceContract]
    public interface IAlmacen_Services
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectAll_Almacen")]
        List<Almacen> selectAll_Almacen();

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "combo_Almacen")]
        List<Almacen> combo_Almacen();

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "list_Almacen")]
        List<Select.Almacen> list_Almacen();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "search_Almacen")]
        List<Select.Almacen> search_Almacen(Search.Almacen a);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "add_Almacen")]
        ResponseBD add_Almacen(Almacen a);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "list_InventarioAlmacen")]
        List<Select.InventarioAlmacen> list_InventarioAlmacen();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "search_InventarioAlmacen")]
        List<Select.InventarioAlmacen> search_InventarioAlmacen(Search.InventarioAlmacen i);

    }
}
