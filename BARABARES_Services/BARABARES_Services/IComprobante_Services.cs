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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IComprobante_Services" in both code and config file together.
    [ServiceContract]
    public interface IComprobante_Services
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectAll_Comprobante")]
        List<ComprobantePago> selectAll_Comprobante();

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "list_Comprobante")]
        List<Select.ComprobantePago> list_Comprobante();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "search_Comprobante")]
        List<Select.ComprobantePago> search_Comprobante(Search.ComprobantePago c);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "add_Comprobante")]
        ResponseBD add_Comprobante(ComprobantePago c);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectAll_DetalleComprobante")]
        List<DetalleComprobante> selectAll_DetalleComprobante();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "add_DetalleComprobante")]
        ResponseBD add_DetalleComprobante(DetalleComprobante d);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectAll_MedioPago")]
        List<MedioPago> selectAll_MedioPago();

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "combo_MedioPago")]
        List<MedioPago> combo_MedioPago();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "add_MedioPago")]
        ResponseBD add_MedioPago(MedioPago m);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectAll_TipoComprobante")]
        List<TipoComprobante> selectAll_TipoComprobante();

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "combo_TipoComprobante")]
        List<TipoComprobante> combo_TipoComprobante();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "add_TipoComprobante")]
        ResponseBD add_TipoComprobante(TipoComprobante t);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectAll_TipoTarjeta")]
        List<TipoTarjeta> selectAll_TipoTarjeta();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "add_TipoTarjeta")]
        ResponseBD add_TipoTarjeta(TipoTarjeta t);

    }
}
