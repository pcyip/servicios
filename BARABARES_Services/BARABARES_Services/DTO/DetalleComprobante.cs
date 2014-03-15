using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class DetalleComprobante
    {
        public int IdComprobantePago { get; set; }
        public int IdDetalleComprobante { get; set; }
        public double Cantidad { get; set; }
        public double Subtotal { get; set; }
        public int IdProducto { get; set; }
        public int IdPromocion { get; set; }

    }
}