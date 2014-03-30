using BARABARES_Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.AppCode
{
    public class JsonSerializer
    {
        #region Almacen

        public static string add_Almacen(Almacen d)
        {
            return "{" +
                '"' + "IdAlmacen" + '"' + ": " + d.IdAlmacen.ToString() + ',' +
                '"' + "IdDireccion" + '"' + ": " + d.IdDireccion.ToString() + ',' +
                '"' + "Descripcion" + '"' + ": " + '"' + d.Descripcion + '"' + ',' +
                '"' + "Capacidad" + '"' + ": " + d.Capacidad.ToString() + ',' +
                '"' + "Area" + '"' + ": " + d.Area.ToString() + ',' +
                '"' + "Activo" + '"' + ": " + (d.Activo ? "true" : "false") + ',' +
                '"' + "FechaCreacion" + '"' + ": " + '"' + Utils.dateToJson(d.FechaCreacion) + '"' + ',' +
                '"' + "IdTienda" + '"' + ": " + d.IdTienda.ToString() +
                "}";
        }

        public static string search_Almacen(Search.Almacen p)
        {
            return "{" +
                '"' + "Activo" + '"' + ": " + (p.Activo ? "true" : "false") + ',' +
                '"' + "Descripcion" + '"' + ": " + '"' + p.Descripcion + '"' + ',' +
                '"' + "Desde" + '"' + ": " + '"' + Utils.dateToJson(p.Desde) + '"' + ',' +
                '"' + "Hasta" + '"' + ": " + '"' + Utils.dateToJson(p.Hasta) + '"' + ',' +
                '"' + "IdDepartamento" + '"' + ": " + p.IdDepartamento.ToString() + ',' +
                '"' + "IdProvincia" + '"' + ": " + p.IdProvincia.ToString() + ',' +
                '"' + "IdDistrito" + '"' + ": " + p.IdDistrito.ToString() + ',' +
                '"' + "IdTienda" + '"' + ": " + p.IdTienda.ToString() + ',' +
                "}";
        }

        #endregion

        #region Carrito

        #endregion

        #region Comprobante

        public static string search_ComprobantePago(Search.ComprobantePago p)
        {
            return "{" +
                '"' + "ApellidoPaterno" + '"' + ": " + '"' + p.ApellidoPaterno + '"' + ',' +
                '"' + "Desde" + '"' + ": " + '"' + Utils.dateToJson(p.Desde) + '"' + ',' +
                '"' + "Hasta" + '"' + ": " + '"' + Utils.dateToJson(p.Hasta) + '"' + ',' +
                '"' + "IdTipoDocumento" + '"' + ": " + p.IdTipoDocumento.ToString() + ',' +
                '"' + "IdTipoComprobante" + '"' + ": " + p.IdTipoComprobante.ToString() + ',' +
                '"' + "NumeroComprobante" + '"' + ": " + p.Numerocomprobante.ToString() + ',' +
                '"' + "Nombres" + '"' + ": " + '"' + p.Nombres + '"' + ',' +
                '"' + "NumeroDocumento" + '"' + ": " + p.NumeroDocumento.ToString() + ',' +
                "}";
        }

        #endregion

        #region Contrasena

        #endregion

        #region Direccion

        public static string selectByDepartamento_Provincia(int id)
        {
            return "{" + '"' + "id" + '"' + ": " + id.ToString() + "}";
        }

        public static string selectByProvincia_Distrito(int id)
        {
            return "{" + '"' + "id" + '"' + ": " + id.ToString() + "}";
        }

        public static string add_Direccion(Direccion d)
        {
            return "{" +
                '"' + "Calle" + '"' + ": " + '"' + d.Calle + '"' + ',' +
                '"' + "IdDepartamento" + '"' + ": " + d.IdDepartamento.ToString() + ',' +
                '"' + "IdDireccion" + '"' + ": " + d.IdDireccion.ToString() + ',' +
                '"' + "IdDistrito" + '"' + ": " + d.IdDistrito.ToString() + ',' +
                '"' + "IdProvincia" + '"' + ": " + d.IdProvincia.ToString() + ',' +
                '"' + "IdTipoCalle" + '"' + ": " + d.IdTipoCalle.ToString() + ',' +
                '"' + "IdTipoUrb" + '"' + ": " + d.IdTipoUrb.ToString() + ',' +
                '"' + "Interior" + '"' + ": " + '"' + d.Interior + '"' + ',' +
                '"' + "Mzlt" + '"' + ": " + '"' + d.Mzlt + '"' + ',' +
                '"' + "Numero" + '"' + ": " + d.Numero.ToString() + ',' +
                '"' + "Referencia" + '"' + ": " + '"' + d.Referencia + '"' + ',' +
                '"' + "Urbanizacion" + '"' + ": " + '"' + d.Urbanizacion + '"' +
                "}";

        }


        #endregion

        #region Moneda

        #endregion

        #region Movimiento

        #endregion

        #region Parametro

        public static string selectByPadre_Parametro(int id)
        {
            return "{" + '"' + "id" + '"' + ": " + id.ToString() + "}";
        }

        #endregion

        #region Pedido

        public static string search_Pedido(Search.Pedido p)
        {
            return "{" +
                '"' + "ApellidoPaterno" + '"' + ": " + '"' + p.ApellidoPaterno + '"' + ',' +
                '"' + "Desde" + '"' + ": " + '"' + Utils.dateToJson(p.Desde) + '"' + ',' +
                '"' + "Hasta" + '"' + ": " + '"' + Utils.dateToJson(p.Hasta) + '"' + ',' +
                '"' + "IdTipoDocumento" + '"' + ": " + p.IdTipoDocumento.ToString() + ',' +
                '"' + "IdEstadoPedido" + '"' + ": " + p.IdEstadoPedido.ToString() + ',' +
                '"' + "IdMedioPago" + '"' + ": " + p.IdMedioPago.ToString() + ',' +
                '"' + "IdTienda" + '"' + ": " + p.IdTienda.ToString() + ',' +
                '"' + "IdMotivoCancelacion" + '"' + ": " + p.IdMotivoCancelacion.ToString() + ',' +
                '"' + "Nombres" + '"' + ": " + '"' + p.Nombres + '"' + ',' +
                '"' + "NumeroDocumento" + '"' + ": " + p.NumeroDocumento.ToString() + ',' +
                "}";
        }

        #endregion

        #region Perfil

        public static string selectByUsuario_Perfil(int id)
        {
            return "{" + '"' + "id" + '"' + ": " + id.ToString() + "}";
        }

        public static string selectById_Perfil(int id)
        {
            return "{" + '"' + "id" + '"' + ": " + id.ToString() + "}";
        }

        public static string add_Perfil(Perfil d)
        {
            return "{" +
                '"' + "IdPerfil" + '"' + ": " + d.IdPerfil.ToString() + ',' +
                '"' + "Nombre" + '"' + ": " + '"' + d.Nombre + '"' + ',' +
                '"' + "Activo" + '"' + ": " + (d.Activo ? "true" : "false") + ',' +
                '"' + "FechaCreacion" + '"' + ": " + '"' + Utils.dateToJson(d.FechaCreacion) + '"' +
                "}";
        }

        public static string add_PerfilXUsuario(PerfilXUsuario d)
        {
            return "{" +
                '"' + "IdPerfilXUsuario" + '"' + ": " + d.IdPerfilXUsuario.ToString() + ',' +
                '"' + "IdPerfil" + '"' + ": " + d.IdPerfil.ToString() + ',' +
                '"' + "IdUsuario" + '"' + ": " + d.IdUsuario.ToString() + ',' +
                '"' + "FechaAsignacion" + '"' + ": " + '"' + Utils.dateToJson(d.FechaAsignacion) + '"' +
                "}";
        }

        public static string search_Perfil(Search.Perfil p)
        {
            return "{" +
                '"' + "Activo" + '"' + ": " + (p.Activo ? "true" : "false") + ',' +
                '"' + "Nombre" + '"' + ": " + '"' + p.Nombre + '"' + ',' +
                '"' + "Desde" + '"' + ": " + '"' + Utils.dateToJson(p.Desde) + '"' + ',' +
                '"' + "Hasta" + '"' + ": " + '"' + Utils.dateToJson(p.Hasta) + '"' +
                "}";
        }


        #endregion

        #region Persona

        public static string selectByTipo_Persona(int idTipo)
        {
            return "{" + '"' + "idTipo" + '"' + ": " + idTipo.ToString() + "}";
        }

        public static string add_Persona(Persona p)
        {
            return "{" +
                '"' + "Activo" + '"' + ": " + (p.Activo ? "true" : "false") + ',' +
                '"' + "ApellidoMaterno" + '"' + ": " + '"' + p.ApellidoMaterno + '"' + ',' +
                '"' + "ApellidoPaterno" + '"' + ": " + '"' + p.ApellidoPaterno + '"' + ',' +
                '"' + "Celular" + '"' + ": " + p.Celular.ToString() + ',' +
                '"' + "Email" + '"' + ": " + '"' + p.Email + '"' + ',' +
                '"' + "FechaNacimiento" + '"' + ": " + '"' + Utils.dateToJson(p.FechaNacimiento) + '"' + ',' +
                '"' + "IdDireccion" + '"' + ": " + p.IdDireccion.ToString() + ',' +
                '"' + "IdPersona" + '"' + ": " + p.IdPersona.ToString() + ',' +
                '"' + "IdTipoDocumento" + '"' + ": " + p.IdTipoDocumento.ToString() + ',' +
                '"' + "IdTipoPersona" + '"' + ": " + p.IdTipoPersona.ToString() + ',' +
                '"' + "IdUsuario" + '"' + ": " + p.IdUsuario.ToString() + ',' +
                '"' + "Nombres" + '"' + ": " + '"' + p.Nombres + '"' + ',' +
                '"' + "NumeroDocumento" + '"' + ": " + p.NumeroDocumento.ToString() + ',' +
                '"' + "Sexo" + '"' + ": " + '"' + p.Sexo + '"' + ',' +
                '"' + "Telefono" + '"' + ": " + p.Telefono.ToString() +
                "}";
        }

        public static string search_Persona(Search.Persona p)
        {
            return "{" +
                '"' + "Activo" + '"' + ": " + (p.Activo ? "true" : "false") + ',' +
                '"' + "ApellidoMaterno" + '"' + ": " + '"' + p.ApellidoMaterno + '"' + ',' +
                '"' + "ApellidoPaterno" + '"' + ": " + '"' + p.ApellidoPaterno + '"' + ',' +
                '"' + "Desde" + '"' + ": " + '"' + Utils.dateToJson(p.Desde) + '"' + ',' +
                '"' + "Hasta" + '"' + ": " + '"' + Utils.dateToJson(p.Hasta) + '"' + ',' +
                '"' + "IdTipoDocumento" + '"' + ": " + p.IdTipoDocumento.ToString() + ',' +
                '"' + "IdTipoPersona" + '"' + ": " + p.IdTipoPersona.ToString() + ',' +
                '"' + "Nombres" + '"' + ": " + '"' + p.Nombres + '"' + ',' +
                '"' + "NumeroDocumento" + '"' + ": " + p.NumeroDocumento.ToString() + ',' +
                "}";
        }

        #endregion

        #region Producto

        public static string selectById_Producto(int id)
        {
            return "{" + '"' + "id" + '"' + ": " + id.ToString() + "}";
        }

        public static string selectByTipo_Producto(int idTipo)
        {
            return "{" + '"' + "idTipo" + '"' + ": " + idTipo.ToString() + "}";
        }

        public static string add_Producto(Producto d)
        {
            return "{" +
                '"' + "IdProducto" + '"' + ": " + d.IdProducto.ToString() + ',' +
                '"' + "IdTipoProducto" + '"' + ": " + d.IdTipoProducto.ToString() + ',' +
                '"' + "Nombre" + '"' + ": " + '"' + d.Nombre + '"' + ',' +
                '"' + "Descripcion" + '"' + ": " + '"' + d.Descripcion + '"' + ',' +
                '"' + "IdUnidadProducto" + '"' + ": " + d.IdUnidadProducto.ToString() + ',' +
                '"' + "Presentacion" + '"' + ": " + d.Presentacion.ToString() + ',' +
                '"' + "Perecible" + '"' + ": " + (d.Perecible ? "true" : "false") + ',' +
                '"' + "Activo" + '"' + ": " + (d.Activo ? "true" : "false") + ',' +
                '"' + "PrecioUnitario" + '"' + ": " + d.PrecioUnitario.ToString() + ',' +
                '"' + "Observaciones" + '"' + ": " + '"' + d.Observaciones + '"' + ',' +
                '"' + "FechaCreacion" + '"' + ": " + '"' + Utils.dateToJson(d.FechaCreacion) + '"' + ',' +
                '"' + "Imagen" + '"' + ": " + '"' + d.Imagen + '"' +
                "}";

        }

        public static string search_Producto(Search.Producto d)
        {
            return "{" +
                '"' + "IdTipoProducto" + '"' + ": " + d.IdTipoProducto.ToString() + ',' +
                '"' + "Nombre" + '"' + ": " + '"' + d.Nombre + '"' + ',' +
                '"' + "IdUnidadProducto" + '"' + ": " + d.IdUnidadProducto.ToString() + ',' +
                '"' + "Presentacion" + '"' + ": " + d.Presentacion.ToString() + ',' +
                '"' + "Activo" + '"' + ": " + (d.Activo ? "true" : "false") + ',' +
                '"' + "Minimo" + '"' + ": " + d.Minimo.ToString() + ',' +
                '"' + "Maximo" + '"' + ": " + d.Maximo.ToString() + ',' +
                '"' + "Desde" + '"' + ": " + '"' + Utils.dateToJson(d.Desde) + '"' + ',' +
                '"' + "Hasta" + '"' + ": " + '"' + Utils.dateToJson(d.Hasta) + '"' + ',' +
                "}";

        }

        #endregion

        #region Promocion

        public static string add_Promocion(Promocion d)
        {
            return "{" +
                '"' + "IdPromocion" + '"' + ": " + d.IdPromocion.ToString() + ',' +
                '"' + "Nombre" + '"' + ": " + '"' + d.Nombre + '"' + ',' +
                '"' + "Descripcion" + '"' + ": " + '"' + d.Descripcion + '"' + ',' +
                '"' + "Semana" + '"' + ": " + (d.Semana ? "true" : "false") + ',' +
                '"' + "PrecioUnitario" + '"' + ": " + d.PrecioUnitario.ToString() + ',' +
                '"' + "FechaInicio" + '"' + ": " + '"' + Utils.dateToJson(d.FechaInicio) + '"' + ',' +
                '"' + "FechaFin" + '"' + ": " + '"' + Utils.dateToJson(d.FechaFin) + '"' + ',' +
                '"' + "Imagen" + '"' + ": " + '"' + d.Imagen + '"' +
                "}";

        }

        public static string add_DetallePromocion(DetallePromocion d)
        {
            return "{" +
                '"' + "IdPromocion" + '"' + ": " + d.IdPromocion.ToString() + ',' +
                '"' + "IdDetallePromocion" + '"' + ": " + d.IdDetallePromocion.ToString() + ',' +
                '"' + "Cantidad" + '"' + ": " + d.Cantidad.ToString() + ',' +
                '"' + "PrecioUnitario" + '"' + ": " + d.PrecioUnitario.ToString() + ',' +
                '"' + "IdProducto" + '"' + ": " + d.IdProducto.ToString() +
                "}";

        }

        #endregion

        #region Rol

        public static string selectById_Rol(int id)
        {
            return "{" + '"' + "id" + '"' + ": " + id.ToString() + "}";
        }

        public static string add_RolXPerfil(RolXPerfil d)
        {
            return "{" +
                '"' + "IdRolXPerfil" + '"' + ": " + d.IdRolXPerfil.ToString() + ',' +
                '"' + "IdPerfil" + '"' + ": " + d.IdPerfil.ToString() + ',' +
                '"' + "IdRol" + '"' + ": " + d.IdRol.ToString() + ',' +
                '"' + "FechaAsignacion" + '"' + ": " + '"' + Utils.dateToJson(d.FechaAsignacion) + '"' +
                "}";
        }

        #endregion

        #region Tienda

        public static string search_Tienda(Search.Tienda p)
        {
            return "{" +
                '"' + "Activo" + '"' + ": " + (p.Activo ? "true" : "false") + ',' +
                '"' + "Nombre" + '"' + ": " + '"' + p.Nombre + '"' + ',' +
                '"' + "Desde" + '"' + ": " + '"' + Utils.dateToJson(p.Desde) + '"' + ',' +
                '"' + "Hasta" + '"' + ": " + '"' + Utils.dateToJson(p.Hasta) + '"' + ',' +
                '"' + "IdDepartamento" + '"' + ": " + p.IdDepartamento.ToString() + ',' +
                '"' + "IdProvincia" + '"' + ": " + p.IdProvincia.ToString() + ',' +
                '"' + "IdDistrito" + '"' + ": " + p.IdDistrito.ToString() +
                "}";
        }

        #endregion

        #region Usuario

        public static string login_Usuario(string usuario, string contrasena)
        {
            return "{" + '"' + "usuario" + '"' + ": " + '"' + usuario + '"' + ','
                + '"' + "contrasena" + '"' + ": " + '"' + contrasena + '"' + "}";
        }

        public static string add_Usuario(Usuario d)
        {
            return "{" +
                '"' + "IdUsuario" + '"' + ": " + d.IdUsuario.ToString() + ',' +
                '"' + "IdTienda" + '"' + ": " + d.IdTienda.ToString() + ',' +
                '"' + "Nombre" + '"' + ": " + '"' + d.Nombre + '"' + ',' +
                '"' + "Activo" + '"' + ": " + (d.Activo ? "true" : "false") + ',' +
                '"' + "FechaCreacion" + '"' + ": " + '"' + Utils.dateToJson(d.FechaCreacion) + '"' + ',' +
                '"' + "IdContrasena" + '"' + ": " + d.IdContrasena.ToString() +
                "}";
        }

        public static string search_Usuario(Search.Usuario p)
        {
            return "{" +
                '"' + "Activo" + '"' + ": " + (p.Activo ? "true" : "false") + ',' +
                '"' + "Nombre" + '"' + ": " + '"' + p.Nombre + '"' + ',' +
                '"' + "Desde" + '"' + ": " + '"' + Utils.dateToJson(p.Desde) + '"' + ',' +
                '"' + "Hasta" + '"' + ": " + '"' + Utils.dateToJson(p.Hasta) + '"' +
                "}";
        }

        public static string search_LogUsuario(Search.LogUsuario p)
        {
            return "{" +
                '"' + "Nombre" + '"' + ": " + '"' + p.Nombre + '"' + ',' +
                '"' + "Accion" + '"' + ": " + '"' + p.Accion + '"' + ',' +
                '"' + "Desde" + '"' + ": " + '"' + Utils.dateToJson(p.Desde) + '"' + ',' +
                '"' + "Hasta" + '"' + ": " + '"' + Utils.dateToJson(p.Hasta) + '"' +
                "}";
        }

        public static string add_LogUsuario(LogUsuario p)
        {
            return "{" +
                '"' + "Accion" + '"' + ": " + '"' + p.Accion + '"' + ',' +
                '"' + "Clase" + '"' + ": " + '"' + p.Clase + '"' + ',' +
                '"' + "Ip" + '"' + ": " + '"' + p.Ip + '"' + ',' +
                '"' + "Fecha" + '"' + ": " + '"' + Utils.dateToJson(p.Fecha) + '"' +
                "}";
        }

        public static string add_LogBarabares(LogBarabares p)
        {
            return "{" +
                '"' + "Accion" + '"' + ": " + '"' + p.Accion + '"' + ',' +
                '"' + "Servicio" + '"' + ": " + '"' + p.Servicio + '"' + ',' +
                '"' + "Input" + '"' + ": " + '"' + p.Input + '"' + ',' +
                '"' + "Descripcion" + '"' + ": " + '"' + p.Descripcion + '"' + ',' +
                '"' + "Clase" + '"' + ": " + '"' + p.Clase + '"' + ',' +
                '"' + "Aplicacion" + '"' + ": " + '"' + p.Aplicacion + '"' + ',' +
                '"' + "Estado" + '"' + ": " + '"' + p.Estado + '"' + ',' +
                '"' + "Ip" + '"' + ": " + '"' + p.Ip + '"' +
                "}";
        }

        #endregion

        #region Vehiculo

        public static string selectByMarca_Modelo(int id)
        {
            return "{" + '"' + "id" + '"' + ": " + id.ToString() + "}";
        }

        public static string add_Vehiculo(Vehiculo d)
        {
            return "{" +
                '"' + "IdVehiculo" + '"' + ": " + d.IdVehiculo.ToString() + ',' +
                '"' + "Placa" + '"' + ": " + '"' + d.Placa + '"' + ',' +
                '"' + "Descripcion" + '"' + ": " + '"' + d.Descripcion + '"' + ',' +
                '"' + "Capacidad" + '"' + ": " + d.Capacidad.ToString() + ',' +
                '"' + "Marca" + '"' + ": " + d.Marca.ToString() + ',' +
                '"' + "Modelo" + '"' + ": " + d.Modelo.ToString() + ',' +
                '"' + "Activo" + '"' + ": " + (d.Activo ? "true" : "false") + ',' +
                '"' + "FechaCreacion" + '"' + ": " + '"' + Utils.dateToJson(d.FechaCreacion) + '"' + ',' +
                '"' + "IdTienda" + '"' + ": " + d.IdTienda.ToString() +
                "}";
        }

        public static string search_Vehiculo(Search.Vehiculo p)
        {
            return "{" +
                '"' + "Activo" + '"' + ": " + (p.Activo ? "true" : "false") + ',' +
                '"' + "Placa" + '"' + ": " + '"' + p.Placa + '"' + ',' +
                '"' + "Descripcion" + '"' + ": " + '"' + p.Descripcion + '"' + ',' +
                '"' + "Desde" + '"' + ": " + '"' + Utils.dateToJson(p.Desde) + '"' + ',' +
                '"' + "Hasta" + '"' + ": " + '"' + Utils.dateToJson(p.Hasta) + '"' + ',' +
                '"' + "Marca" + '"' + ": " + p.Marca.ToString() + ',' +
                '"' + "Modelo" + '"' + ": " + p.Modelo.ToString() + ',' +
                '"' + "IdTienda" + '"' + ": " + p.IdTienda.ToString() + ',' +
                "}";
        }

        #endregion
    }
}