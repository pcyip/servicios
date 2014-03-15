using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class Movimiento
    {
        public int IdMovimiento { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaFin { get; set; }
        public int IdTipoMovimiento { get; set; }
        public int IdAlmacen { get; set; }
        public int IdVehiculo { get; set; }
        public int IdUsuario { get; set; }
        public int IdPedido { get; set; }
    }
}