using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class RolXPerfil
    {
        public int IdRolXPerfil { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public int IdPerfil { get; set; }
        public int IdRol { get; set; }
    }
}