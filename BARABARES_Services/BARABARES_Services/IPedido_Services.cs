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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPedido_Services" in both code and config file together.
    [ServiceContract]
    public interface IPedido_Services
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "usuario_Pedido")]
        List<PedidoUsuario> usuario_Pedido(int idUsuario);
         
        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectAll_Pedido")]
        List<Pedido> selectAll_Pedido();

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectById_Pedido")]
        Select.Pedido_Sistema selectById_Pedido(int id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "search_Pedido")]
        List<Select.Pedido> search_Pedido(Search.Pedido p);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "list_Pedido")]
        List<Select.Pedido> list_Pedido();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "add_Pedido")]
        ResponseBD add_Pedido(Pedido p);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectAll_DetallePedido")]
        List<DetallePedido> selectAll_DetallePedido();

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectByPedido_DetallePedido")]
        List<Select.DetallePedido_Sistema> selectByPedido_DetallePedido(int id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "add_DetallePedido")]
        ResponseBD add_DetallePedido(DetallePedido d);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectAll_EstadoPedido")]
        List<EstadoPedido> selectAll_EstadoPedido();

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "combo_EstadoPedido")]
        List<EstadoPedido> combo_EstadoPedido();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "add_EstadoPedido")]
        ResponseBD add_EstadoPedido(EstadoPedido e);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectAll_MotivoCancelacion")]
        List<MotivoCancelacion> selectAll_MotivoCancelacion();

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "combo_MotivoCancelacion")]
        List<MotivoCancelacion> combo_MotivoCancelacion();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "add_MotivoCancelacion")]
        ResponseBD add_MotivoCancelacion(MotivoCancelacion m);
    }
}
