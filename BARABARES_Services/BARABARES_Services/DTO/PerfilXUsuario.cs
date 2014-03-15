using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class PerfilXUsuario
    {
        public int IdPerfilXUsuario { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }

    }
}