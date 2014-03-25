using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class LogBarabares
    {
        public int IdLogBarabares { get; set; }
        public string Accion { get; set; }
        public string Servicio { get; set; }
        public string Input { get; set; }
        public string Descripcion { get; set; }
        public string Clase { get; set; }
        public string Aplicacion { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
        public string Ip { get; set; }
        public int IdUsuario { get; set; }
    }
}