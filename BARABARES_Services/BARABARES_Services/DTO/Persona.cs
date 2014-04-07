using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Telefono { get; set; }
        public int Celular { get; set; }
        public string Email { get; set; }
        public int NumeroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public char Sexo { get; set; }
        public int IdTipoPersona { get; set; }
        public int IdTipoDocumento { get; set; }
        public int IdDireccion { get; set; }
        public bool Activo { get; set; }
        public int IdUsuario { get; set; }
    }
}