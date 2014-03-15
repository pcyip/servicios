using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class Contrasena
    {
        public int IdContrasena { get; set; }
        public string Valor { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}