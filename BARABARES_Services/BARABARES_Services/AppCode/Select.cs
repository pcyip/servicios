using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.AppCode
{
    public class Select
    {
        public class Almacen
        {
            public int IdAlmacen { get; set; }
            public string Descripcion { get; set; }
            public int Capacidad { get; set; }
            public DateTime Fecha { get; set; }
            public string Departamento { get; set; }
            public string Provincia { get; set; }
            public string Distrito { get; set; }
            public string Tienda { get; set; }
        }

        public class Almacen_Sistema
        {
            public int IdAlmacen { get; set; }
            public string Descripcion { get; set; }
            public int Capacidad { get; set; }
            public double Area { get; set; }
            public bool Activo { get; set; }
            public string Tienda { get; set; }
            public DateTime FechaCreacion { get; set; }
            public DateTime UltimaModificacion { get; set; }
            public string TipoCalle { get; set; }
            public string Calle { get; set; }
            public int Numero { get; set; }
            public string Interior { get; set; }
            public string TipoUrb { get; set; }
            public string Urbanizacion { get; set; }
            public string Mzlt { get; set; }
            public string Referencia { get; set; }
            public string Departamento { get; set; }
            public string Provincia { get; set; }
            public string Distrito { get; set; }
        }

        public class Combo
        {
            public int id { get; set; }
            public string value { get; set; }
        }

        public class ComprobantePago
        {
            public int IdComprobante { get; set; }
            public int Numero { get; set; }
            public string Cliente { get; set; }
            public string Moneda { get; set; }
            public double Total { get; set; }
            public DateTime Fecha { get; set; }
            public string Tipo { get; set; }
            public string Documento { get; set; }
        }

        public class ComprobantePago_Sistema
        {
            public int IdComprobante { get; set; }
            public int Numero { get; set; }
            public int IdPedido { get; set; }
            public string Documento { get; set; }
            public string Cliente { get; set; }
            public string Direccion { get; set; }
            public string TipoComprobante { get; set; }
            public DateTime FechaCreacion { get; set; }
            public string Medio { get; set; }
            public string Tarjeta { get; set; }
            public string Moneda { get; set; }
            public double Total { get; set; }
            public string Usuario { get; set; }
            public string Almacen { get; set; }
            public string Tienda { get; set; }
        }

        public class DetalleComprobante_Sistema
        {
            public int IdDetalleComprobante{ get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public string Presentacion { get; set; }
            public string PrecioUnitario { get; set; }
            public int Cantidad { get; set; }
            public string Subtotal { get; set; }
        }

        public class Login
        {
            public string usuario { get; set; }
            public string contrasena { get; set; }
        }

        public class LogUsuario
        {
            public int IdLogUsuario { get; set; }
            public string Usuario { get; set; }
            public string Accion { get; set; }
            public string Clase { get; set; }
            public DateTime Fecha { get; set; }
        }

        public class Movimiento
        {
            public int IdMovimiento { get; set; }
            public string Descripcion { get; set; }
            public DateTime Fecha { get; set; }
            public string Almacen { get; set; }
            public string Usuario { get; set; }
            public string Tipo { get; set; }
            public string Vehiculo { get; set; }
            public int Pedido { get; set; }
        }

        public class Pedido
        {
            public int IdPedido { get; set; }
            public string Cliente { get; set; }            
            public string Estado { get; set; }
            public string Total { get; set; }
            public DateTime Fecha { get; set; }
            public string Tienda{ get; set; }
            public string Almacen { get; set; }
            public string Motivo { get; set; }
            public string Medio { get; set; }
            public string Documento { get; set; }
        }

        public class Pedido_Sistema
        {
            public int IdPedido { get; set; }
            public string Documento { get; set; }
            public string Cliente { get; set; }
            public string Direccion { get; set; }
            public DateTime FechaCreacion { get; set; }
            public DateTime FechaEntrega { get; set; }
            public DateTime FechaPago { get; set; }
            public string Estado { get; set; }
            public string Medio { get; set; }
            public string Tarjeta { get; set; }
            public string Moneda { get; set; }
            public double Total { get; set; }
            public double CuantoPaga { get; set; }
            public double Vuelto { get; set; }
            public string Motivo { get; set; }
            public string Usuario { get; set; }
            public string Almacen { get; set; }
            public string Tienda { get; set; }
        }

        public class DetallePedido_Sistema
        {
            public int IdDetallePedido { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public string Presentacion { get; set; }
            public string PrecioUnitario { get; set; }
            public int Cantidad { get; set; }
            public string Subtotal { get; set; }
        }

        public class Perfil_Usuario
        {
            public int IdPerfil { get; set; }
            public string Nombre { get; set; }
            public bool Activo { get; set; }
            public DateTime FechaCreacion { get; set; }
            public DateTime UltimaModificacion { get; set; }
            public DateTime FechaAsignacion { get; set; }
        }


        public class Persona
        {
            public int IdPersona { get; set; }
            public string Nombres { get; set; }
            public string ApellidoPaterno { get; set; }
            public string ApellidoMaterno { get; set; }
            public int Celular { get; set; }
            public string Email { get; set; }
            public string TipoDocumento { get; set; }
            public int NumeroDocumento { get; set; }
            public char Sexo { get; set; }        
            public bool Activo { get; set; }
            public string Usuario { get; set; }
        }

        public class Persona_Sistema
        {
            public int IdPersona { get; set; }
            public int IdTipoPersona { get; set; }
            public string Nombres { get; set; }
            public string TipoDocumento { get; set; }
            public int NumeroDocumento { get; set; }
            public int Telefono { get; set; }
            public int Celular { get; set; }
            public char Sexo { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public string Email { get; set; }
            public bool Activo { get; set; }
            public string Usuario { get; set; }
            public string TipoCalle { get; set; }
            public string Calle { get; set; }
            public int Numero { get; set; }
            public string Interior { get; set; }
            public string TipoUrb { get; set; }
            public string Urbanizacion { get; set; }
            public string Mzlt { get; set; }
            public string Referencia { get; set; }
            public string Departamento { get; set; }
            public string Provincia { get; set; }
            public string Distrito { get; set; }
            public string Imagen { get; set; }
            
        }

        public class Producto
        {
            public int IdProducto { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public bool Perecible { get; set; }
            public string PrecioUnitario { get; set; }
            public DateTime FechaCreacion { get; set; }
            public string Presentacion { get; set; }
            public bool Activo { get; set; }
        }

        public class Producto_Sistema
        {
            public int IdProducto { get; set; }
            public int IdTipoProducto { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public string Unidad { get; set; }
            public int Presentacion { get; set; }
            public string Moneda { get; set; }
            public double PrecioUnitario { get; set; }
            public bool Activo { get; set; }
            public bool Perecible { get; set; }
            public string Observaciones { get; set; }
            public string Imagen { get; set; }
            public DateTime FechaCreacion { get; set; }
            public DateTime UltimaModificacion { get; set; }
        }

        public class Promocion
        {
            public int IdPromocion { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
            public bool Semana { get; set; }
            public string Precio { get; set; }
        }

        public class Promocion_Sistema
        {
            public int IdPromocion { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public string Moneda { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
            public string Imagen { get; set; }
            public bool Semana { get; set; }
            public double PrecioUnitario { get; set; }
            public int IdMoneda { get; set; }
            public string Observaciones { get; set; }
        }

        public class DetallePromocion_Sistema
        {
            public int IdDetallePromocion { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public bool Perecible { get; set; }
            public string PrecioUnitario { get; set; }
            public string Presentacion { get; set; }
            public int Cantidad { get; set; }
            public bool Activo { get; set; }
        }

        public class PromocionSemana
        {
            public string Descripcion { get; set; }
            public double Precio { get; set; }
            public string Imagen { get; set; }
            public int Cantidad { get; set; }
            public string NombreProducto { get; set; }
            public int Presentacion { get; set; }
            public string Unidad { get; set; }
        }

        public class InventarioAlmacen
        {
            public int IdProducto { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public string Tipo { get; set; }
            public DateTime FechaVencimiento { get; set; }
            public string Unidad { get; set; }
            public int Presentacion { get; set; }
            public double Precio { get; set; }
            public bool Activo { get; set; }
            public string Almacen { get; set; }
            public int Stock { get; set; }
        }

        public class InventarioVehiculo
        {
            public int IdProducto { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public string Tipo { get; set; }
            public DateTime FechaVencimiento { get; set; }
            public string Unidad { get; set; }
            public int Presentacion { get; set; }
            public double Precio { get; set; }
            public bool Activo { get; set; }
            public string Vehiculo { get; set; }
            public int Stock { get; set; }
        }

        public class Rol_Perfil
        {
            public int IdRol { get; set; }
            public string Accion { get; set; }
            public string Descripcion { get; set; }
            public bool Activo { get; set; }
            public DateTime FechaCreacion { get; set; }
            public DateTime FechaAsignacion { get; set; }
            public DateTime UltimaModificacion { get; set; }
        }

        public class Tienda
        {
            public int IdTienda { get; set; }
            public string Nombre { get; set; }
            public DateTime Fecha { get; set; }
            public string Departamento { get; set; }
            public string Provincia { get; set; }
            public string Distrito { get; set; }
            public bool Activo { get; set; }
        }

        public class Tienda_Sistema
        {
            public int IdTienda { get; set; }
            public string Nombre { get; set; }
            public bool Activo { get; set; }
            public DateTime FechaCreacion { get; set; }
            public string TipoCalle { get; set; }
            public string Calle { get; set; }
            public int Numero { get; set; }
            public string Interior { get; set; }
            public string TipoUrb { get; set; }
            public string Urbanizacion { get; set; }
            public string Mzlt { get; set; }
            public string Referencia { get; set; }
            public string Departamento { get; set; }
            public string Provincia { get; set; }
            public string Distrito { get; set; }
        }

        public class Usuario
        {
            public int IdUsuario { get; set; }
            public string Nombre { get; set; }
            public DateTime Fecha { get; set; }
            public string Perfil { get; set; }
            public string Tienda { get; set; }
            public bool Activo { get; set; }
        }

        public class Usuario_Sistema
        {
            public int IdUsuario { get; set; }
            public string Nombre { get; set; }
            public bool Activo { get; set; }
            public string Tienda { get; set; }
            public DateTime FechaCreacion { get; set; }
            public DateTime UltimaModificacion { get; set; }
        }

        public class Vehiculo
        {
            public int IdVehiculo { get; set; }
            public string Placa { get; set; }
            public string Descripcion { get; set; }
            public int Capacidad { get; set; }
            public DateTime Fecha { get; set; }
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public bool Activo { get; set; }
            public string Tienda { get; set; }
        }

        public class Vehiculo_Sistema
        {
            public int IdVehiculo { get; set; }
            public string Placa { get; set; }
            public string Descripcion { get; set; }
            public int Capacidad { get; set; }
            public string Usuario { get; set; }
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public bool Activo { get; set; }
            public string Tienda { get; set; }
            public DateTime FechaCreacion { get; set; }
            public DateTime UltimaModificacion { get; set; }
        }

        public class DetallePromocion_Web
        {
            public string Nombre { get; set; }
            public int Cantidad { get; set; }
            public string Unidad { get; set; }
            public int Presentacion { get; set; }
            public double PrecioUnitario { get; set; }
        }

        public class Promocion_Web
        {
            public int IdPromocion { get; set; }
            public string Nombre { get; set; }
            public double Precio { get; set; }
            public string Imagen { get; set; }
            public bool Semana { get; set; }
            public List<DetallePromocion_Web> Detalle { get; set; }
        }

        public class Producto_Web
        {
            public int IdProducto { get; set; }
            public string Nombre { get; set; }
            public string Imagen { get; set; }
            public string Descripcion { get; set; }
            public double PrecioUnitario { get; set; }
        }

        public class DetalleProducto_Web
        {
            public int IdProducto { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public string Unidad { get; set; }
            public int Presentacion { get; set; }
            public string Moneda { get; set; }
            public double PrecioUnitario { get; set; }
            public string Observaciones { get; set; }
            public string Imagen { get; set; }
        }
    }
}