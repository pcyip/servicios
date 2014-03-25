using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class ProductoXAlmacen
    {
        public int IdProductoXAlmacen { get; set; }
        public int Stock { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int IdProducto { get; set; }
        public int IdAlmacen { get; set; }
    }
}