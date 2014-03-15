using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class Tienda
    {
        public int IdTienda { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdDireccion { get; set; }
        public bool Activo { get; set; }

    }
}