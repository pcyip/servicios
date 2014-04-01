using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.AppCode
{
    public class Search
    {
        public class Almacen
        {
            public string Descripcion { get; set; }
            public int IdDepartamento { get; set; }
            public int IdProvincia { get; set; }
            public int IdDistrito { get; set; }
            public int IdTienda { get; set; }
            public bool Activo { get; set; }
            public DateTime Desde { get; set; }
            public DateTime Hasta { get; set; }
        }

        public class ComprobantePago
        {
            public string Nombres { get; set; }
            public string ApellidoPaterno { get; set; }
            public int IdTipoDocumento { get; set; }
            public int NumeroDocumento { get; set; }
            public int Numerocomprobante { get; set; }
            public int IdTipoComprobante { get; set; }
            public DateTime Desde { get; set; }
            public DateTime Hasta { get; set; }
        }

        public class InventarioAlmacen
        {
            public string Nombre { get; set; }
            public int Almacen { get; set; }
            public int Unidad { get; set; }
            public int Presentacion { get; set; }
            public DateTime Desde { get; set; }
            public DateTime Hasta { get; set; }
        }

        public class InventarioVehiculo
        {
            public string Nombre { get; set; }
            public int Vehiculo { get; set; }
            public int Unidad { get; set; }
            public int Presentacion { get; set; }
            public DateTime Desde { get; set; }
            public DateTime Hasta { get; set; }
        }

        public class LogUsuario
        {
            public string Nombre { get; set; }
            public string Accion { get; set; }
            public DateTime Desde { get; set; }
            public DateTime Hasta { get; set; }
        }

        public class Movimiento
        {
            public int IdMovimiento { get; set; }
            public int TipoMovimiento { get; set; }
            public int Almacen { get; set; }
            public string Usuario { get; set; }
            public DateTime Desde { get; set; }
            public DateTime Hasta { get; set; }
        }

        public class Pedido
        {
            public string Nombres { get; set; }
            public string ApellidoPaterno { get; set; }
            public int IdTipoDocumento { get; set; }
            public int NumeroDocumento { get; set; }
            public int IdMedioPago { get; set; }
            public int IdEstadoPedido { get; set; }
            public int IdMotivoCancelacion { get; set; }
            public int IdTienda { get; set; }
            public DateTime Desde { get; set; }
            public DateTime Hasta { get; set; }
        }

        public class Perfil
        {
            public string Nombre { get; set; }
            public bool Activo { get; set; }
            public DateTime Desde { get; set; }
            public DateTime Hasta { get; set; }
        }

        public class Persona
        {
            public string Nombres { get; set; }
            public string ApellidoPaterno { get; set; }
            public string ApellidoMaterno { get; set; }
            public int IdTipoDocumento { get; set; }
            public int IdTipoPersona { get; set; }
            public int NumeroDocumento { get; set; }
            public bool Activo { get; set; }
            public DateTime Desde { get; set; }
            public DateTime Hasta { get; set; }
        }

        public class Producto
        {
            public string Nombre { get; set; }
            public double Minimo { get; set; }
            public double Maximo { get; set; }
            public int IdTipoProducto { get; set; }
            public int IdUnidadProducto { get; set; }
            public int Presentacion { get; set; }
            public bool Activo { get; set; }
            public DateTime Desde { get; set; }
            public DateTime Hasta { get; set; }
        }

        public class Promocion
        {
            public string Nombre { get; set; }
            public double Minimo { get; set; }
            public double Maximo { get; set; }
            public bool Semana { get; set; }
            public DateTime Desde { get; set; }
            public DateTime Hasta { get; set; }
        }

        public class Tienda
        {
            public string Nombre { get; set; }
            public int IdDepartamento { get; set; }
            public int IdProvincia { get; set; }
            public int IdDistrito { get; set; }
            public bool Activo { get; set; }
            public DateTime Desde { get; set; }
            public DateTime Hasta { get; set; }
        }

        public class Usuario
        {
            public string Nombre { get; set; }
            public bool Activo { get; set; }
            public DateTime Desde { get; set; }
            public DateTime Hasta { get; set; }
        }

        public class Vehiculo
        {
            public string Placa { get; set; }
            public string Descripcion { get; set; }
            public int Marca { get; set; }
            public int Modelo { get; set; }
            public int IdTienda { get; set; }
            public bool Activo { get; set; }
            public DateTime Desde { get; set; }
            public DateTime Hasta { get; set; }
        }
    }
}