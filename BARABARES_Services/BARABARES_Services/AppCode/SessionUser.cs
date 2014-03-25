using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.AppCode
{
    public class SessionUser
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }
        public bool Activo { get; set; }
        public int IdContrasena { get; set; }
        public int IdTienda { get; set; }
        public DateTime UltimaActividad { get; set; }
        public DateTime UltimoLogin { get; set; }
        public int IdPerfil { get; set; }
    }
}