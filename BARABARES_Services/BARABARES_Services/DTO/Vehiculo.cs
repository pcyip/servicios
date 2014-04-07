using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public string Descripcion { get; set; }
        public string Placa { get; set; }
        public int Marca { get; set; }
        public int Modelo { get; set; }
        public int Capacidad { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }
        public int IdTienda { get; set; }

    }
}