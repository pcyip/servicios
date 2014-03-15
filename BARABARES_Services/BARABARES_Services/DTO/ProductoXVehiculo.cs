using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class ProductoXVehiculo
    {
        public int IdProductoXVehiculo { get; set; }
        public int Stock { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int IdProducto { get; set; }
        public int IdVehiculo { get; set; }
    }
}