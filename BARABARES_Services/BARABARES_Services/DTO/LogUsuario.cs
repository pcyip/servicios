using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class LogUsuario
    {
        public int IdLogUsuario { get; set; }
        public string Accion { get; set; }
        public string Clase { get; set; }
        public string ValorAnterior { get; set; }
        public string ValorPosterior { get; set; }
        public DateTime Fecha { get; set; }
        public string Ip { get; set; }
        public int IdUsuario { get; set; }

    }
}