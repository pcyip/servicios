using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BARABARES_Services.DTO;
using BARABARES_Services.AppCode;

namespace BARABARES_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProducto_Services" in both code and config file together.
    [ServiceContract]
    public interface IProducto_Services
    {
        /*
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "xml/{id}")]
        string XMLData(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "json/{id}")]
        string JSONData(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "data/{id}")]
        Person GetData(string id);
        */

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectAll_Producto")]
        List<Producto> selectAll_Producto();

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectByTipo_Producto")]
        List<Producto> selectByTipo_Producto(int idTipo);

        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectByTipo_Web_Producto/{idTipo}")]
        List<Select.Producto_Web> selectByTipo_Web_Producto(string idTipo);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "search_Producto")]
        List<Producto> search_Producto(Search.Producto p);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectById_Producto")]
        Producto selectById_Producto(int id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "add_Producto")]
        ResponseBD add_Producto(Producto p);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectAll_TipoProducto")]
        List<TipoProducto> selectAll_TipoProducto();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "add_TipoProducto")]
        ResponseBD add_TipoProducto(TipoProducto t);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectAll_UnidadProducto")]
        List<UnidadProducto> selectAll_UnidadProducto();

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "combo_UnidadProducto")]
        List<UnidadProducto> combo_UnidadProducto();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "add_UnidadProducto")]
        ResponseBD add_UnidadProducto(UnidadProducto u);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectAll_ProductoXAlmacen")]
        List<ProductoXAlmacen> selectAll_ProductoXAlmacen();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "add_ProductoXAlmacen")]
        ResponseBD add_ProductoXAlmacen(ProductoXAlmacen p);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectAll_ProductoXVehiculo")]
        List<ProductoXVehiculo> selectAll_ProductoXVehiculo();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "add_ProductoXVehiculo")]
        ResponseBD add_ProductoXVehiculo(ProductoXVehiculo p);       

    }
}
