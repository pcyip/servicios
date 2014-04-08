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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPromocion_Services" in both code and config file together.
    [ServiceContract]
    public interface IPromocion_Services
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectAll_Promocion")]
        List<Select.Promocion> selectAll_Promocion();

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectById_Sistema_Promocion")]
        Select.Promocion_Sistema selectById_Sistema_Promocion(int id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "search_Promocion")]
        List<Select.Promocion> search_Promocion(Search.Promocion pro);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "semana_Promocion")]
        List<Select.PromocionSemana> semana_Promocion();

        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "semana_WEB_Promocion")]
        Select.Promocion_Web semana_WEB_Promocion();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "add_Promocion")]
        ResponseBD add_Promocion(Promocion p);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectAll_DetallePromocion")]
        List<DetallePromocion> selectAll_DetallePromocion();

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "selectByPromo_Sistema_DetallePromocion")]
        List<Select.DetallePromocion_Sistema> selectByPromo_Sistema_DetallePromocion(int id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "add_DetallePromocion")]
        ResponseBD add_DetallePromocion(DetallePromocion d);

        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle= WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "list_WEB_Promocion")]
        List<Select.Promocion_Web> list_WEB_Promocion();
        
    }
}
