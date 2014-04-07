using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class ParametrosSeguridad
    {
        public int IdParametrosSeguridad { get; set; }
        public string CaracteresContrasena { get; set; }
        public int TiempoVigenciaDias { get; set; }
        public int CantidadIntentosFallidos { get; set; }
        public int LongitudContrasena { get; set; }
        public int TiempoMaximoSesion { get; set; }

    }
}