using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Perecible { get; set; }
        public double PrecioUnitario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }
        public int IdTipoProducto { get; set; }
        public int IdUnidadProducto { get; set; }
        public int IdMoneda { get; set; }
        public string Imagen { get; set; }
        public int Presentacion { get; set; }
        public string Observaciones { get; set; }
        public bool Activo { get; set; }
    }
}