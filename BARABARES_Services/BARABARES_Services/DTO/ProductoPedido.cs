using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class ProductoPedido
    {
        public int IdPedido { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }
}