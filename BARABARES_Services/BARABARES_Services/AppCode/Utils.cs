using BARABARES_Services.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BARABARES_Services.AppCode
{
    public class Utils
    {
        #region Almacen

        public static Almacen almacen_parse(DataRow r)
        {
            Almacen a = new Almacen();
            a.IdAlmacen = Int32.Parse(r["idAlmacen"].ToString());
            a.Descripcion = r["descripcion"].ToString();
            a.Capacidad = Int32.Parse(r["capacidad"].ToString());
            a.Area = Double.Parse(r["area"].ToString());
            a.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            a.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            a.Activo = Boolean.Parse(r["activo"].ToString());
            a.IdTienda = Int32.Parse(r["idTienda"].ToString());
            a.IdDireccion = Int32.Parse(r["idDireccion"].ToString());

            return a;
        }
        public static Select.Almacen select_almacen_parse(DataRow r)
        {
            Select.Almacen a = new Select.Almacen();
            a.IdAlmacen = Int32.Parse(r["Almacen"].ToString());
            a.Descripcion = r["Descripcion"].ToString();
            a.Capacidad = Int32.Parse(r["Capacidad"].ToString());
            a.Fecha = DateTime.ParseExact(r["Fecha"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            a.Departamento = r["Departamento"].ToString();
            a.Provincia = r["Provincia"].ToString();
            a.Distrito = r["Distrito"].ToString();
            a.Tienda = r["Tienda"].ToString();

            return a;
        }

        public static Select.InventarioAlmacen select_inventario_almacen_parse(DataRow r)
        {
            Select.InventarioAlmacen p = new Select.InventarioAlmacen();
            p.IdProducto = Int32.Parse(r["IdProducto"].ToString());
            p.Nombre = r["Nombre"].ToString();
            p.Descripcion = r["Descripcion"].ToString();
            p.Tipo = r["Tipo"].ToString();
            p.FechaVencimiento = DateTime.ParseExact(r["FechaVencimiento"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            p.Tipo = r["Tipo"].ToString();
            p.Unidad = r["Unidad"].ToString();
            p.Presentacion = Int32.Parse(r["Presentacion"].ToString());
            p.Precio = Double.Parse(r["Precio"].ToString());
            p.Activo = Boolean.Parse(r["activo"].ToString());
            p.Almacen = r["Almacen"].ToString();
            p.Stock = Int32.Parse(r["Stock"].ToString());

            return p;
        }

        #endregion

        #region Carrito

        public static Carrito carrito_parse(DataRow r)
        {
            Carrito c = new Carrito();
            c.IdCarrito = Int32.Parse(r["idCarrito"].ToString());
            c.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            c.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            c.Activo = Boolean.Parse(r["activo"].ToString());
            c.Total = Double.Parse(r["total"].ToString());

            return c;
        }

        public static DetalleCarrito detalleCarrito_parse(DataRow r)
        {
            DetalleCarrito d = new DetalleCarrito();
            d.IdDetalleCarrito = Int32.Parse(r["idDetalleCarrito"].ToString());
            d.Cantidad = Int32.Parse(r["cantidad"].ToString());
            d.Subtotal = Double.Parse(r["subtotal"].ToString());
            d.IdProducto = Int32.Parse(r["idProducto"].ToString());
            d.IdPromocion = Int32.Parse(r["idPromcion"].ToString());
            d.IdCarrito = Int32.Parse(r["idCarrito"].ToString());

            return d;
        }

        #endregion

        #region ComprobantePago

        public static ComprobantePago comprobante_parse(DataRow r)
        {
            ComprobantePago c = new ComprobantePago();
            c.IdComprobantePago = Int32.Parse(r["idComprobantePago"].ToString());
            c.NumeroComprobante = Int32.Parse(r["numeroComprobante"].ToString());
            c.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            c.Total = Double.Parse(r["total"].ToString());
            c.TransaccionPOS = Int32.Parse(r["transaccionPOS"].ToString());
            c.IdTipoComprobante = Int32.Parse(r["idTipoComprobante"].ToString());
            c.IdMoneda = Int32.Parse(r["idMoneda"].ToString());
            c.IdPedido = Int32.Parse(r["idPedido"].ToString());
            c.IdPersona = Int32.Parse(r["idPersona"].ToString());

            return c;
        }

        public static Select.ComprobantePago select_comprobante_parse(DataRow r)
        {
            Select.ComprobantePago p = new Select.ComprobantePago();
            p.IdComprobante = Int32.Parse(r["Comprobante"].ToString());
            p.Numero = Int32.Parse(r["Numero"].ToString());
            p.Cliente = r["Cliente"].ToString();
            p.Moneda = r["Moneda"].ToString();
            p.Fecha = DateTime.ParseExact(r["Fecha"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            p.Total = Double.Parse(r["Total"].ToString());
            p.Tipo = r["Tipo"].ToString();
            p.Documento = r["Documento"].ToString();

            return p;
        }

        public static DetalleComprobante detalleComprobante_parse(DataRow r)
        {
            DetalleComprobante d = new DetalleComprobante();
            d.IdDetalleComprobante = Int32.Parse(r["idDetalleComprobante"].ToString());
            d.Cantidad = Int32.Parse(r["cantidad"].ToString());
            d.Subtotal = Double.Parse(r["subtotal"].ToString());
            d.IdProducto = Int32.Parse(r["idProducto"].ToString());
            d.IdPromocion = Int32.Parse(r["idPromcion"].ToString());
            d.IdComprobantePago = Int32.Parse(r["idComprobantePago"].ToString());

            return d;
        }

        public static MedioPago medioPago_parse(DataRow r)
        {
            MedioPago m = new MedioPago();
            m.IdMedioPago = Int32.Parse(r["idMedioPago"].ToString());
            m.Nombre = r["nombre"].ToString();
            m.Descripcion = r["descripcion"].ToString();
            m.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            m.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            m.Activo = Boolean.Parse(r["activo"].ToString());

            return m;
        }

        public static TipoTarjeta tipoTarjeta_parse(DataRow r)
        {
            TipoTarjeta t = new TipoTarjeta();
            t.IdTipoTarjeta = Int32.Parse(r["idTipoTarjeta"].ToString());
            t.Nombre = r["nombre"].ToString();
            t.Descripcion = r["descripcion"].ToString();
            t.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            t.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            t.Activo = Boolean.Parse(r["activo"].ToString());
            t.IdMedioPago = Int32.Parse(r["idMedioPago"].ToString());

            return t;
        }

        public static TipoComprobante tipoComprobante_parse(DataRow r)
        {
            TipoComprobante t = new TipoComprobante();
            t.IdTipoComprobante = Int32.Parse(r["idTipoComprobante"].ToString());
            t.Nombre = r["nombre"].ToString();
            t.Descripcion = r["descripcion"].ToString();
            t.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            t.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            t.Activo = Boolean.Parse(r["activo"].ToString());

            return t;
        }

        #endregion

        #region Contrasena

        public static Contrasena contrasena_parse(DataRow r)
        {
            Contrasena c = new Contrasena();
            c.IdContrasena = Int32.Parse(r["idContrasena"].ToString());
            c.Valor = r["valor"].ToString();
            c.Activo = Boolean.Parse(r["activo"].ToString());
            c.FechaInicio = DateTime.ParseExact(r["fechaInicio"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            c.FechaFin = DateTime.ParseExact(r["fechaFin"].ToString(), "M/d/yyyy h:mm:ss ttt", null);

            return c;
        }

        #endregion

        #region Direccion

        public static Direccion direccion_parse(DataRow r)
        {
            Direccion d = new Direccion();
            d.IdDireccion = Int32.Parse(r["idDireccion"].ToString());
            d.Referencia = r["referencia"].ToString();
            d.Numero = Int32.Parse(r["numero"].ToString());
            d.Interior = r["interior"].ToString();
            d.Mzlt = r["mzlt"].ToString();
            d.Calle = r["calle"].ToString();
            d.Urbanizacion = r["urbanizacion"].ToString();
            d.IdDepartamento = Int32.Parse(r["idDepartamento"].ToString());
            d.IdProvincia = Int32.Parse(r["idProvincia"].ToString());
            d.IdDistrito = Int32.Parse(r["idDistrito"].ToString());
            d.IdTipoCalle = Int32.Parse(r["idtipoCalle"].ToString());
            d.IdTipoUrb = Int32.Parse(r["idtipoUrb"].ToString());

            return d;
        }

        public static Departamento departamento_parse(DataRow r)
        {
            Departamento d = new Departamento();
            d.IdDepartamento = Int32.Parse(r["idDepartamento"].ToString());
            d.Nombre = r["nombre"].ToString();
            d.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss tt", null);
            d.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);

            return d;
        }

        public static Distrito distrito_parse(DataRow r)
        {
            Distrito d = new Distrito();
            d.IdDistrito = Int32.Parse(r["idDistrito"].ToString());
            d.Nombre = r["nombre"].ToString();
            d.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss tt", null);
            d.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss tt", null);
            d.IdDepartamento = Int32.Parse(r["idDepartamento"].ToString());
            d.IdProvincia = Int32.Parse(r["idProvincia"].ToString());

            return d;
        }

        public static Provincia provincia_parse(DataRow r)
        {
            Provincia p = new Provincia();
            p.IdProvincia = Int32.Parse(r["idProvincia"].ToString());
            p.Nombre = r["nombre"].ToString();
            p.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            p.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            p.IdDepartamento = Int32.Parse(r["idDepartamento"].ToString());

            return p;
        }

        public static TipoCalle tipoCalle_parse(DataRow r)
        {
            TipoCalle t = new TipoCalle();
            t.IdTipoCalle = Int32.Parse(r["idtipoCalle"].ToString());
            t.Nombre = r["nombre"].ToString();
            t.Descripcion = r["descripcion"].ToString();
            t.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            t.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            t.Activo = Boolean.Parse(r["activo"].ToString());

            return t;
        }

        public static TipoUrb tipoUrb_parse(DataRow r)
        {
            TipoUrb t = new TipoUrb();
            t.IdTipoUrb = Int32.Parse(r["idtipoUrb"].ToString());
            t.Nombre = r["nombre"].ToString();
            t.Descripcion = r["descripcion"].ToString();
            t.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            t.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            t.Activo = Boolean.Parse(r["activo"].ToString());

            return t;
        }

        public static Select.Combo combo_departamento_parse(DataRow r)
        {
            Select.Combo p = new Select.Combo();
            p.id = Int32.Parse(r["idDepartamento"].ToString());
            p.value = r["nombre"].ToString();

            return p;
        }

        public static Select.Combo combo_provincia_parse(DataRow r)
        {
            Select.Combo p = new Select.Combo();
            p.id= Int32.Parse(r["idProvincia"].ToString());
            p.value = r["nombre"].ToString();

            return p;
        }

        public static Select.Combo combo_distrito_parse(DataRow r)
        {
            Select.Combo p = new Select.Combo();
            p.id = Int32.Parse(r["idDistrito"].ToString());
            p.value = r["nombre"].ToString();

            return p;
        }

        #endregion

        #region Moneda

        public static Moneda moneda_parse(DataRow r)
        {
            Moneda m = new Moneda();
            m.IdMoneda = Int32.Parse(r["idMoneda"].ToString());
            m.Nombre = r["nombre"].ToString();
            m.Simbolo = r["simbolo"].ToString();
            m.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            m.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            m.Activo = Boolean.Parse(r["activo"].ToString());

            return m;
        }

        #endregion

        #region Movimiento

        public static Movimiento movimiento_parse(DataRow r)
        {
            Movimiento m = new Movimiento();
            m.IdMovimiento = Int32.Parse(r["idMovimiento"].ToString());
            m.Descripcion = r["descripcion"].ToString();
            m.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            m.FechaFin = DateTime.ParseExact(r["fechaFin"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            m.IdTipoMovimiento = Int32.Parse(r["idTipoMovimiento"].ToString());
            m.IdAlmacen = Int32.Parse(r["idAlmacen"].ToString());
            m.IdVehiculo = Int32.Parse(r["idVehiculo"].ToString());
            m.IdUsuario = Int32.Parse(r["idUsuario"].ToString());
            m.IdPedido = Int32.Parse(r["idPedido"].ToString());

            return m;
        }

        public static DetalleMovimiento detalleMovimiento_parse(DataRow r)
        {
            DetalleMovimiento d = new DetalleMovimiento();
            d.IdMovimiento = Int32.Parse(r["idMovimiento"].ToString());
            d.IdDetalleMovimiento = Int32.Parse(r["idDetalleMovimiento"].ToString());
            d.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            d.FechaFin = DateTime.ParseExact(r["fechaFin"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            d.Cantidad = Int32.Parse(r["cantidad"].ToString());
            d.IdProductoXVehiculo = Int32.Parse(r["idProductoXVehiculo"].ToString());

            return d;
        }

        public static TipoMovimiento tipoMovimiento_parse(DataRow r)
        {
            TipoMovimiento t = new TipoMovimiento();
            t.IdTipoMovimiento = Int32.Parse(r["idTipoMovimiento"].ToString());
            t.Nombre = r["nombre"].ToString();
            t.Descripcion = r["descripcion"].ToString();
            t.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            t.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            t.Activo = Boolean.Parse(r["activo"].ToString());
            return t;
        }

        #endregion

        #region Parametro

        public static Parametro parametro_parse(DataRow r)
        {
            Parametro p = new Parametro();
            p.IdParametro = Int32.Parse(r["idParametros"].ToString());
            p.CodigoPadre = Int32.Parse(r["codigoPadre"].ToString());
            p.Codigo = r["codigo"].ToString();
            p.Valor = r["valor"].ToString();
            p.ValorNum = Int32.Parse(r["valorNum"].ToString());
            p.Nombre = r["nombre"].ToString();
            p.Activo = Boolean.Parse(r["activo"].ToString());

            return p;
        }

        public static Select.Combo combo_parametro_parse(DataRow r)
        {
            Select.Combo p = new Select.Combo();
            p.id = Int32.Parse(r["idParametros"].ToString());
            p.value = r["valor"].ToString();

            return p;
        }

        public static ParametrosSeguridad parametroSeguridad_parse(DataRow r)
        {
            ParametrosSeguridad p = new ParametrosSeguridad();
            p.IdParametrosSeguridad = Int32.Parse(r["idParametrosSeguridad"].ToString());
            p.CaracteresContrasena = r["caracteresContrasena"].ToString();
            p.TiempoVigenciaDias = Int32.Parse(r["tiempoVigenciaDias"].ToString());
            p.CantidadIntentosFallidos = Int32.Parse(r["cantidadIntentosFallidos"].ToString());
            p.LongitudContrasena = Int32.Parse(r["longitudContrasena "].ToString());
            p.TiempoMaximoSesion = Int32.Parse(r["tiempoMaximoSesion"].ToString());

            return p;
        }

        #endregion

        #region Pedido

        public static Pedido pedido_parse(DataRow r)
        {
            Pedido p = new Pedido();
            p.IdPedido = Int32.Parse(r["idPedido"].ToString());
            p.FechaEntrega = DateTime.ParseExact(r["fechaEntrega"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            p.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            p.FechaPago = DateTime.ParseExact(r["fechaPago"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            p.Total = Double.Parse(r["total"].ToString());
            p.CuantoPaga = Double.Parse(r["cuantoPaga"].ToString());
            p.Vuelto = Double.Parse(r["vuelto"].ToString());
            p.IdPersona = Int32.Parse(r["idPersona"].ToString());
            p.IdEstadoPedido = Int32.Parse(r["idEstadoPedido"].ToString());
            p.IdMotivoCancelacion = Int32.Parse(r["idMotivoCancelacion"].ToString());
            p.IdDireccion = Int32.Parse(r["idDireccion"].ToString());
            p.IdTienda = Int32.Parse(r["idTienda"].ToString());
            p.IdAlmacen = Int32.Parse(r["idAlmacen"].ToString());
            p.IdMoneda = Int32.Parse(r["idMoneda"].ToString());
            p.IdMedioPago = Int32.Parse(r["idMedioPago"].ToString());
            p.IdCarrito = Int32.Parse(r["idCarrito"].ToString());

            return p;
        }

        public static Select.Pedido select_pedido_parse(DataRow r)
        {
            Select.Pedido p = new Select.Pedido();
            p.IdPedido = Int32.Parse(r["Pedido"].ToString());
            p.Cliente = r["Cliente"].ToString();
            p.Estado = r["Estado"].ToString();
            p.Fecha = DateTime.ParseExact(r["Fecha"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            p.Total = Double.Parse(r["Total"].ToString());
            p.Tienda = r["Tienda"].ToString();
            p.Almacen = r["Almacen"].ToString();
            p.Motivo = r["Motivo"].ToString();
            p.Medio = r["Medio"].ToString();
            p.Documento = r["Documento"].ToString();

            return p;
        }

        public static DetallePedido detallePedido_parse(DataRow r)
        {
            DetallePedido d = new DetallePedido();
            d.IdDetallePedido = Int32.Parse(r["idDetallePedido"].ToString());
            d.Cantidad = Int32.Parse(r["cantidad"].ToString());
            d.Subtotal = Double.Parse(r["subtotal"].ToString());
            d.IdProducto = Int32.Parse(r["idProducto"].ToString());
            d.IdPromocion = Int32.Parse(r["idPromcion"].ToString());
            d.IdPedido = Int32.Parse(r["idPedido"].ToString());

            return d;
        }

        public static EstadoPedido estadoPedido_parse(DataRow r)
        {
            EstadoPedido e = new EstadoPedido();
            e.IdEstadoPedido = Int32.Parse(r["idEstadoPedido"].ToString());
            e.Nombre = r["nombre"].ToString();
            e.Descripcion = r["descripcion"].ToString();
            e.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            e.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            e.Activo = Boolean.Parse(r["activo"].ToString());

            return e;
        }

        public static MotivoCancelacion motivoCancelacion_parse(DataRow r)
        {
            MotivoCancelacion m = new MotivoCancelacion();
            m.IdMotivoCancelacion = Int32.Parse(r["idMotivoCancelacion"].ToString());
            m.Nombre = r["nombre"].ToString();
            m.Descripcion = r["descripcion"].ToString();
            m.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            m.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            m.Activo = Boolean.Parse(r["activo"].ToString());

            return m;
        }

        #endregion

        #region Perfil

        public static Perfil perfil_parse(DataRow r)
        {
            Perfil p = new Perfil();
            p.IdPerfil = Int32.Parse(r["idPerfil"].ToString());
            p.Nombre = r["nombre"].ToString();
            p.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            p.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            p.Activo = Boolean.Parse(r["activo"].ToString());

            return p;
        }

        public static PerfilXUsuario perfilXUsuario_parse(DataRow r)
        {
            PerfilXUsuario pxu = new PerfilXUsuario();
            pxu.IdPerfilXUsuario = Int32.Parse(r["idPerfilXUsuario"].ToString());
            pxu.IdPerfil = Int32.Parse(r["idPerfil"].ToString());
            pxu.IdUsuario= Int32.Parse(r["idUsuario"].ToString());
            pxu.FechaAsignacion = DateTime.ParseExact(r["fechaAsignacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);

            return pxu;
        }

        #endregion

        #region Persona

        public static Persona persona_parse(DataRow r)
        {

            Persona p = new Persona();
            p.IdPersona = Int32.Parse(r["idPersona"].ToString());
            p.Nombres = r["nombres"].ToString();
            p.ApellidoPaterno = r["apellidoPaterno"].ToString();
            p.ApellidoMaterno = r["apellidoMaterno"].ToString();
            p.Telefono = Int32.Parse(r["telefono"].ToString());
            p.Celular = Int32.Parse(r["celular"].ToString());
            p.Email = r["email"].ToString();
            p.NumeroDocumento = Int32.Parse(r["numeroDocumento"].ToString());
            p.FechaNacimiento = DateTime.ParseExact(r["fechaNacimiento"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            p.Sexo = r["sexo"].ToString()[0];
            p.IdTipoDocumento = Int32.Parse(r["idTipoDocumento"].ToString());
            p.IdTipoPersona = Int32.Parse(r["idTipoPersona"].ToString());
            p.IdDireccion = Int32.Parse(r["idDireccion"].ToString());
            p.Activo = Boolean.Parse(r["activo"].ToString());
            p.IdUsuario = Int32.Parse(r["idUsuario"].ToString());

            return p;
        }

        public static Select.Persona select_persona_parse(DataRow r)
        {

            Select.Persona p = new Select.Persona();
            p.IdPersona = Int32.Parse(r["Persona"].ToString());
            p.Nombres = r["Nombres"].ToString();
            p.ApellidoPaterno = r["ApellidoPaterno"].ToString();
            p.ApellidoMaterno = r["ApellidoMaterno"].ToString();
            p.Celular = Int32.Parse(r["Celular"].ToString());
            p.Email = r["Email"].ToString();
            p.NumeroDocumento = Int32.Parse(r["NumeroDocumento"].ToString());
            p.Sexo = r["Sexo"].ToString()[0];
            p.TipoDocumento = r["TipoDocumento"].ToString();
            p.Activo = Boolean.Parse(r["Activo"].ToString());
            p.Usuario = r["Usuario"].ToString();

            return p;
        }

        public static TipoDocumento tipoDocumento_parse(DataRow r)
        {
            TipoDocumento t = new TipoDocumento();
            t.IdTipoDocumento = Int32.Parse(r["idTipoDocumento"].ToString());
            t.Nombre = r["nombre"].ToString();
            t.Descripcion = r["descripcion"].ToString();
            t.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            t.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            t.Activo = Boolean.Parse(r["activo"].ToString());

            return t;
        }

        public static TipoPersona tipoPersona_parse(DataRow r)
        {
            TipoPersona t = new TipoPersona();
            t.IdTipoPersona = Int32.Parse(r["idTipoPersona"].ToString());
            t.Nombre = r["nombre"].ToString();
            t.Descripcion = r["descripcion"].ToString();
            t.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            t.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            t.Activo = Boolean.Parse(r["activo"].ToString());

            return t;
        }

        #endregion

        #region Producto

        public static Producto producto_parse(DataRow r)
        {

            Producto p = new Producto();
            p.IdProducto = Int32.Parse(r["idProducto"].ToString());
            p.Nombre = r["nombre"].ToString();
            p.Descripcion = r["descripcion"].ToString();
            p.Perecible = Boolean.Parse(r["perecible"].ToString());
            p.PrecioUnitario = Double.Parse(r["precioUnitario"].ToString());
            p.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            p.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            p.IdTipoProducto = Int32.Parse(r["idTipoProducto"].ToString());
            p.IdUnidadProducto = Int32.Parse(r["idUnidadProducto"].ToString());
            p.Imagen = r["imagen"].ToString();
            p.Presentacion = Int32.Parse(r["presentacion"].ToString());
            p.Observaciones = r["observaciones"].ToString();
            p.Activo = Boolean.Parse(r["activo"].ToString());

            return p;
        }

        public static TipoProducto tipoProducto_parse(DataRow r)
        {
            TipoProducto t = new TipoProducto();
            t.IdTipoProducto = Int32.Parse(r["idTipoProducto"].ToString());
            t.Nombre = r["nombre"].ToString();
            t.Descripcion = r["descripcion"].ToString();
            t.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            t.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            t.Activo = Boolean.Parse(r["activo"].ToString());

            return t;
        }

        public static UnidadProducto unidadProducto_parse(DataRow r)
        {
            UnidadProducto u = new UnidadProducto();
            u.IdUnidadProducto = Int32.Parse(r["idUnidadProducto"].ToString());
            u.Unidad = r["unidad"].ToString();
            u.Descripcion = r["descripcion"].ToString();
            u.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            u.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            u.Activo = Boolean.Parse(r["activo"].ToString());

            return u;
        }

        public static ProductoXAlmacen productoXAlmacen_parse(DataRow r)
        {
            ProductoXAlmacen pxa = new ProductoXAlmacen();
            pxa.IdProductoXAlmacen = Int32.Parse(r["idProductoXAlmacen"].ToString());
            pxa.Stock = Int32.Parse(r["stock"].ToString());
            pxa.FechaVencimiento = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            pxa.IdProducto = Int32.Parse(r["idProducto"].ToString());
            pxa.IdAlmacen = Int32.Parse(r["idAlmacen"].ToString());

            return pxa;
        }

        public static ProductoXVehiculo productoXVehiculo_parse(DataRow r)
        {
            ProductoXVehiculo pxv = new ProductoXVehiculo();
            pxv.IdProductoXVehiculo = Int32.Parse(r["idProductoXVehiculo"].ToString());
            pxv.Stock = Int32.Parse(r["stock"].ToString());
            pxv.FechaVencimiento = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            pxv.IdProducto = Int32.Parse(r["idProducto"].ToString());
            pxv.IdVehiculo = Int32.Parse(r["idVehiculo"].ToString());

            return pxv;
        }

        #endregion

        #region Promocion

        public static Promocion promocion_parse(DataRow r)
        {
            Promocion p = new Promocion();
            p.IdPromocion = Int32.Parse(r["idPromocion"].ToString());
            p.Nombre = r["nombre"].ToString();
            p.Descripcion = r["descripcion"].ToString();
            p.FechaInicio = DateTime.ParseExact(r["fechaInicio"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            p.FechaFin = DateTime.ParseExact(r["fechaFin"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            p.Imagen = r["imagen"].ToString();
            p.PrecioUnitario = Double.Parse(r["precioUnitario"].ToString());
            p.Semana = Boolean.Parse(r["semana"].ToString());

            return p;
        }

        public static DetallePromocion detallePromocion_parse(DataRow r)
        {
            DetallePromocion d = new DetallePromocion();
            d.IdPromocion = Int32.Parse(r["idPromocion"].ToString());
            d.IdDetallePromocion = Int32.Parse(r["idDetallePromocion"].ToString());
            d.Cantidad = Int32.Parse(r["cantidad"].ToString());
            d.PrecioUnitario = Double.Parse(r["precioUnitario"].ToString());
            d.IdProducto = Int32.Parse(r["idProducto"].ToString());

            return d;
        }

        public static Select.Promocion_Web promocion_web_parse(DataRow r)
        {
            Select.Promocion_Web p = new Select.Promocion_Web();
            p.IdPromocion = Int32.Parse(r["idPromocion"].ToString());
            p.Nombre = r["nombre"].ToString();
            p.Imagen = r["imagen"].ToString();
            p.Precio = Double.Parse(r["precioUnitario"].ToString());
            p.Semana = Boolean.Parse(r["semana"].ToString());
            p.Detalle = new List<Select.DetallePromocion_Web>();

            return p;
        }

        public static Select.DetallePromocion_Web detallePromocion_Web_parse(DataRow r)
        {
            Select.DetallePromocion_Web d = new Select.DetallePromocion_Web();
            d.Nombre = r["nombre"].ToString();
            d.Cantidad = Int32.Parse(r["cantidad"].ToString());
            d.Presentacion = Int32.Parse(r["presentacion"].ToString());
            d.Unidad = r["unidad"].ToString();

            return d;
        }

        #endregion

        #region Rol

        public static Rol rol_parse(DataRow r)
        {
            Rol rol = new Rol();
            rol.IdRol = Int32.Parse(r["idRol"].ToString());
            rol.Accion = r["accion"].ToString();
            rol.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            rol.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            rol.Activo = Boolean.Parse(r["activo"].ToString());
            rol.Descripcion = r["descripcion"].ToString();

            return rol;
        }

        public static RolXPerfil rolXPerfil_parse(DataRow r)
        {
            RolXPerfil rxp = new RolXPerfil();
            rxp.IdRolXPerfil = Int32.Parse(r["idRolXPerfil"].ToString());
            rxp.IdRol = Int32.Parse(r["idRol"].ToString());
            rxp.IdPerfil = Int32.Parse(r["idPerfil"].ToString());
            rxp.FechaAsignacion = DateTime.ParseExact(r["fechaAsignacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);

            return rxp;
        }

        #endregion

        #region Tienda

        public static Tienda tienda_parse(DataRow r)
        {
            Tienda t = new Tienda();
            t.IdTienda = Int32.Parse(r["idTienda"].ToString());
            t.Nombre = r["nombre"].ToString();
            t.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            t.IdDireccion = Int32.Parse(r["idDireccion"].ToString());
            t.Activo = Boolean.Parse(r["activo"].ToString());

            return t;
        }

        public static Select.Tienda select_tienda_parse(DataRow r)
        {
            Select.Tienda t = new Select.Tienda();
            t.IdTienda = Int32.Parse(r["Tienda"].ToString());
            t.Nombre = r["Nombre"].ToString();
            t.Fecha = DateTime.ParseExact(r["Fecha"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            t.Departamento = r["Departamento"].ToString();
            t.Provincia = r["Provincia"].ToString();
            t.Distrito = r["Distrito"].ToString();
            t.Activo = Boolean.Parse(r["Activo"].ToString());

            return t;
        }

        #endregion

        #region Usuario

        public static Usuario usuario_parse(DataRow r)
        {
            Usuario u = new Usuario();
            u.IdUsuario = Int32.Parse(r["idUsuario"].ToString());
            u.Nombre = r["nombre"].ToString();
            u.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            u.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            u.Activo = Boolean.Parse(r["activo"].ToString());
            u.IdContrasena = Int32.Parse(r["idContrasena"].ToString());
            u.IdTienda = Int32.Parse(r["idTienda"].ToString());

            return u;
        }

        public static Select.Usuario select_usuario_parse(DataRow r)
        {
            Select.Usuario u = new Select.Usuario();
            u.IdUsuario = Int32.Parse(r["Usuario"].ToString());
            u.Nombre = r["Nombre"].ToString();
            u.Fecha = DateTime.ParseExact(r["Fecha"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            u.Activo = Boolean.Parse(r["activo"].ToString());
            u.Perfil = r["Perfil"].ToString();
            u.Tienda = r["Tienda"].ToString();

            return u;
        }

        public static LogUsuario logUsuario_parse(DataRow r)
        {
            LogUsuario l = new LogUsuario();
            l.IdLogUsuario= Int32.Parse(r["idLogUsuario"].ToString());
            l.Accion = r["accion"].ToString();
            l.Clase = r["clase"].ToString();
            l.Fecha = DateTime.ParseExact(r["fecha"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            l.Ip= r["ip"].ToString();
            l.IdUsuario = Int32.Parse(r["idUsuario"].ToString());

            return l;
        }

        public static Select.LogUsuario select_logUsuario_parse(DataRow r)
        {
            Select.LogUsuario l = new Select.LogUsuario();
            l.IdLogUsuario = Int32.Parse(r["LogUsuario"].ToString());
            l.Accion = r["Accion"].ToString();
            l.Clase = r["Clase"].ToString();
            l.Fecha = DateTime.ParseExact(r["Fecha"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            l.Usuario = r["Usuario"].ToString();

            return l;
        }

        public static ResponseBD add_LogUsuario(LogUsuario u)
        {
            ResponseBD response = new ResponseBD();

            string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
            using (SqlConnection SqlConn = new SqlConnection(ConnString))
            {
                try
                {
                    try
                    {
                        SqlConn.Open();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        response.Flujo = "ERROR";
                        response.Mensaje = "Error al abrir la conexión a BD";
                        return response;
                    }

                    SqlCommand sqlCmd = new SqlCommand("USUARIO_LOG_INSERT", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter flujo = new SqlParameter("@opsFlujo", SqlDbType.VarChar)
                    {
                        Direction = ParameterDirection.Output,
                        Size = 10

                    };

                    SqlParameter mensaje = new SqlParameter("@opsMsj", SqlDbType.VarChar)
                    {
                        Direction = ParameterDirection.Output,
                        Size = 100
                    };

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = u.Accion;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = u.Clase;
                    sqlCmd.Parameters.Add("@ipdFecha", SqlDbType.DateTime).Value = u.Fecha;
                    sqlCmd.Parameters.Add("@ipsIp", SqlDbType.VarChar).Value = u.Ip;
                    sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = u.IdUsuario;
                    sqlCmd.Parameters.Add(flujo);
                    sqlCmd.Parameters.Add(mensaje);

                    sqlCmd.ExecuteNonQuery();

                    response.Flujo = flujo.Value.ToString();
                    response.Mensaje = mensaje.Value.ToString();

                    SqlConn.Close();

                }
                catch (Exception ex)
                {
                    LogBarabares b = new LogBarabares()
                    {
                        Accion = Constantes.LOG_CREAR,
                        Servicio = Constantes.Add_LogUsuario,
                        Input = JsonSerializer.add_LogUsuario(u),
                        Descripcion = ex.ToString(),
                        Clase = u.GetType().Name,
                        Aplicacion = "Servicios",
                        Estado = Constantes.FALLA,
                        Ip = "",
                        IdUsuario = 1 //TODO: obtener usuario de la sesión

                    };

                    Utils.add_LogBarabares(b);
                }
            }
            return response;
        }

        public static ResponseBD add_LogBarabares(LogBarabares u)
        {
            ResponseBD response = new ResponseBD();
            
            string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
            using (SqlConnection SqlConn = new SqlConnection(ConnString))
            {
                try
                {
                    try
                    {
                        SqlConn.Open();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        response.Flujo = "ERROR";
                        response.Mensaje = "Error al abrir la conexión a BD";
                        return response;
                    }

                    SqlCommand sqlCmd = new SqlCommand("BARABARES_LOG_INSERT", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter flujo = new SqlParameter("@opsFlujo", SqlDbType.VarChar)
                    {
                        Direction = ParameterDirection.Output,
                        Size = 10

                    };

                    SqlParameter mensaje = new SqlParameter("@opsMsj", SqlDbType.VarChar)
                    {
                        Direction = ParameterDirection.Output,
                        Size = 100
                    };

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = u.Accion;
                    sqlCmd.Parameters.Add("@ipsServicio", SqlDbType.VarChar).Value = u.Servicio;
                    sqlCmd.Parameters.Add("@ipsInput", SqlDbType.VarChar).Value = u.Input;
                    sqlCmd.Parameters.Add("@ipsDescripcion", SqlDbType.VarChar).Value = u.Descripcion;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = u.Clase;
                    sqlCmd.Parameters.Add("@ipsAplicacion", SqlDbType.VarChar).Value = u.Aplicacion;
                    sqlCmd.Parameters.Add("@ipsEstado", SqlDbType.VarChar).Value = u.Estado;
                    sqlCmd.Parameters.Add("@ipsIp", SqlDbType.VarChar).Value = u.Ip;
                    sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = u.IdUsuario;
                    sqlCmd.Parameters.Add(flujo);
                    sqlCmd.Parameters.Add(mensaje);

                    sqlCmd.ExecuteNonQuery();

                    response.Flujo = flujo.Value.ToString();
                    response.Mensaje = mensaje.Value.ToString();

                    SqlConn.Close();

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

            return response;
        }

        #endregion

        #region Vehiculo

        public static Vehiculo vehiculo_parse(DataRow r)
        {
            Vehiculo v = new Vehiculo();
            v.IdVehiculo = Int32.Parse(r["idVehiculo"].ToString());
            v.Descripcion = r["descripcion"].ToString();
            v.Placa = r["placa"].ToString();
            v.Marca = Int32.Parse(r["marca"].ToString());
            v.Modelo = Int32.Parse(r["modelo"].ToString());
            v.Capacidad= Int32.Parse(r["capacidad"].ToString());
            v.FechaCreacion = DateTime.ParseExact(r["fechaCreacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            v.UltimaModificacion = DateTime.ParseExact(r["ultimaModificacion"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            v.Activo = Boolean.Parse(r["activo"].ToString());
            v.IdTienda = Int32.Parse(r["idTienda"].ToString());

            return v;
        }

        public static Select.Vehiculo select_vehiculo_parse(DataRow r)
        {
            Select.Vehiculo v = new Select.Vehiculo();
            v.IdVehiculo = Int32.Parse(r["Vehiculo"].ToString());
            v.Descripcion = r["Descripcion"].ToString();
            v.Placa = r["Placa"].ToString();
            v.Marca = r["Marca"].ToString();
            v.Modelo = r["Modelo"].ToString();
            v.Capacidad = Int32.Parse(r["Capacidad"].ToString());
            v.Fecha = DateTime.ParseExact(r["Fecha"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            v.Activo = Boolean.Parse(r["activo"].ToString());
            v.Tienda = r["Tienda"].ToString();

            return v;
        }

        public static Select.InventarioVehiculo select_inventario_vehiculo_parse(DataRow r)
        {
            Select.InventarioVehiculo p = new Select.InventarioVehiculo();
            p.IdProducto = Int32.Parse(r["IdProducto"].ToString());
            p.Nombre = r["Nombre"].ToString();
            p.Descripcion = r["Descripcion"].ToString();
            p.Tipo = r["Tipo"].ToString();
            p.FechaVencimiento = DateTime.ParseExact(r["FechaVencimiento"].ToString(), "M/d/yyyy h:mm:ss ttt", null);
            p.Tipo = r["Tipo"].ToString();
            p.Unidad = r["Unidad"].ToString();
            p.Presentacion = Int32.Parse(r["Presentacion"].ToString());
            p.Precio = Double.Parse(r["Precio"].ToString());
            p.Activo = Boolean.Parse(r["activo"].ToString());
            p.Vehiculo = r["Vehiculo"].ToString();
            p.Stock = Int32.Parse(r["Stock"].ToString());

            return p;
        }

        #endregion

        #region Utils

        public static string GetSHA1(string usuario, string contrasena)
        {
            string str = usuario + Constantes.GetHash + contrasena;

            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public static string GetSHA1NSS(string usuario, string contrasena)
        {
            string str = usuario + Constantes.GetHash + contrasena;

            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(str);
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
            string hash = BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");

            return hash;
        }

        public static string dateToJson(DateTime d)
        {
            return "/Date(" + d.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds + "-0500)/";
        }

        #endregion
    }
}