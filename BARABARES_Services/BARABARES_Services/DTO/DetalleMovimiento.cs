using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class DetalleMovimiento
    {
        public int IdMovimiento { get; set; }
        public int IdDetalleMovimiento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaFin { get; set; }
        public double Cantidad { get; set; }
        public int IdProductoXVehiculo { get; set; }
    }
}