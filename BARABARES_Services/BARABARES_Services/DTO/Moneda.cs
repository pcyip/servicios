using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class Moneda
    {
        public int IdMoneda { get; set; }
        public string Nombre { get; set; }
        public string Simbolo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }
        public bool Activo { get; set; }
    }
}