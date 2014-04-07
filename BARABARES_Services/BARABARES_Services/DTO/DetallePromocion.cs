using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class DetallePromocion
    {
        public int IdPromocion { get; set; }
        public int IdDetallePromocion { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public int IdProducto { get; set; }

    }
}