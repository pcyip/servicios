using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class PedidoUsuario
    {
        public int IdPedido { get; set; }
        public string Direccion { get; set; }
        public string Solicitante { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public double MontoCobrar { get; set; }
        public double MontoPagar { get; set; }
        public double MontoVuelto { get; set; }
        public List<ProductoPedido> Productos { get; set; }
    }
}