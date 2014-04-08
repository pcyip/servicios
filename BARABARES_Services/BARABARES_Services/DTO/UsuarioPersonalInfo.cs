using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class UsuarioPersonalInfo
    {
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Tienda { get; set; }
        public string DescripcionVehiculo { get; set; }
        public string Placa { get; set; }
        public int Marca { get; set; }
        public int Modelo { get; set; }
    }
}