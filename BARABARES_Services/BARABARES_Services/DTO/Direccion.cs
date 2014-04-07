using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        public string Referencia { get; set; }
        public int Numero { get; set; }
        public string Interior { get; set; }
        public string Mzlt { get; set; }
        public int IdTipoUrb { get; set; }
        public int IdTipoCalle { get; set; }
        public int IdDistrito { get; set; }
        public int IdProvincia { get; set; }
        public int IdDepartamento { get; set; }
        public string Urbanizacion { get; set; }
        public string Calle { get; set; }
    }
}