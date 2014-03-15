using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class Carrito
    {
        public int IdCarrito { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }
        public bool Activo { get; set; }
        public double Total { get; set; }
    }
}