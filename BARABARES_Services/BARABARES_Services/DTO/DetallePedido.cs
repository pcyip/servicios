using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class DetallePedido
    {
        public int IdPedido { get; set; }
        public int IdDetallePedido { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }
        public int IdProducto { get; set; }
        public int IdPromocion { get; set; }
    }
}