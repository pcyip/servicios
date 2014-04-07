using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaPago { get; set; }
        public double Total { get; set; }
        public double CuantoPaga { get; set; }
        public double Vuelto { get; set; }
        public int IdPersona { get; set; }
        public int IdEstadoPedido { get; set; }
        public int IdMotivoCancelacion { get; set; }
        public int IdDireccion { get; set; }
        public int IdTienda { get; set; }
        public int IdAlmacen { get; set; }
        public int IdMoneda { get; set; }
        public int IdMedioPago { get; set; }
        public int IdCarrito { get; set; }

    }
}