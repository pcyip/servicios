using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class Provincia
    {
        public int IdProvincia { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }
        public int IdDepartamento { get; set; }
    }
}