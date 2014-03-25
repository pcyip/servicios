using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.AppCode
{
    public class Constantes
    {
        #region Utils

        public const string GetHash = "ABCD";
        public const string LOG_CREAR = "Crear";
        public const string LOG_MODIFICAR = "Modificar";
        public const string LOG_BUSCAR = "Buscar";
        public const string LOG_ACTIVAR = "Activar";
        public const string LOG_DESACTIVAR = "Desactivar";
        public const string LOG_LISTAR = "Listar";
        public const string LOG_LOGIN = "Login";
        public const string LOG_LOGOUT = "Logout";

        #endregion

        #region URLs Servicios

        //Almacen
        public const string List_Almacen = "http://localhost:2576/Almacen_Services.svc/list_Almacen";
        public const string List_InventarioAlmacen = "http://localhost:2576/Almacen_Services.svc/list_InventarioAlmacen";
        public const string SelectAll_Almacen = "http://localhost:2576/Almacen_Services.svc/selectAll_Almacen";
        public const string Add_Almacen = "http://localhost:2576/Almacen_Services.svc/add_Almacen";
        public const string Search_Almacen = "http://localhost:2576/Almacen_Services.svc/search_Almacen";

        //ComprobantePago
        public const string List_Comprobante = "http://localhost:2576/Comprobante_Services.svc/list_Comprobante";
        public const string Search_Comprobante = "http://localhost:2576/Comprobante_Services.svc/search_Comprobante";
        public const string SelectAll_MedioPago = "http://localhost:2576/Comprobante_Services.svc/selectAll_MedioPago";
        public const string SelectAll_TipoComprobante = "http://localhost:2576/Comprobante_Services.svc/selectAll_TipoComprobante";

        //Direccion
        public const string SelectAll_TipoCalle = "http://localhost:2576/Direccion_Services.svc/selectAll_TipoCalle";
        public const string SelectAll_TipoUrb = "http://localhost:2576/Direccion_Services.svc/selectAll_TipoUrb";
        public const string SelectAll_Departamento = "http://localhost:2576/Direccion_Services.svc/selectAll_Departamento";
        public const string SelectAll_Provincia = "http://localhost:2576/Direccion_Services.svc/selectAll_Provincia";
        public const string SelectByDepartamento_Provincia = "http://localhost:2576/Direccion_Services.svc/selectByDepartamento_Provincia";
        public const string SelectAll_Distrito = "http://localhost:2576/Direccion_Services.svc/selectAll_Distrito";
        public const string SelectByProvincia_Distrito = "http://localhost:2576/Direccion_Services.svc/selectByProvincia_Distrito";
        public const string Add_Direccion = "http://localhost:2576/Direccion_Services.svc/add_Direccion";

        //Pedido
        public const string SelectAll_Pedido = "http://localhost:2576/Pedido_Services.svc/selectAll_Pedido";
        public const string List_Pedido = "http://localhost:2576/Pedido_Services.svc/list_Pedido";
        public const string Search_Pedido = "http://localhost:2576/Pedido_Services.svc/search_Pedido";
        public const string SelectAll_EstadoPedido = "http://localhost:2576/Pedido_Services.svc/selectAll_EstadoPedido";
        public const string SelectAll_MotivoCancelacion = "http://localhost:2576/Pedido_Services.svc/selectAll_MotivoCancelacion";

        //Perfil
        public const string SelectAll_Perfil = "http://localhost:2576/Perfil_Services.svc/selectAll_Perfil";
        public const string Search_Perfil = "http://localhost:2576/Perfil_Services.svc/search_Perfil";
        public const string SelectByUsuario_Perfil = "http://localhost:2576/Perfil_Services.svc/selectByUsuario_Perfil";
        public const string SelectById_Perfil = "http://localhost:2576/Perfil_Services.svc/selectById_Perfil";
        public const string Add_Perfil = "http://localhost:2576/Perfil_Services.svc/add_Perfil";
        public const string Add_PerfilXUsuario = "http://localhost:2576/Perfil_Services.svc/add_PerfilXUsuario";

        //Persona
        public const string SelectAll_Persona = "http://localhost:2576/Persona_Services.svc/selectAll_Persona";
        public const string SelectByTipo_Persona = "http://localhost:2576/Persona_Services.svc/selectByTipo_Persona";
        public const string Search_Persona = "http://localhost:2576/Persona_Services.svc/search_Persona";
        public const string Add_Persona = "http://localhost:2576/Persona_Services.svc/add_Persona";
        public const string SelectAll_TipoDocumento = "http://localhost:2576/Persona_Services.svc/selectAll_TipoDocumento";

        //Producto
        public const string SelectAll_Producto = "http://localhost:2576/Producto_Services.svc/selectAll_Producto";
        public const string SelectByTipo_Producto = "http://localhost:2576/Producto_Services.svc/selectByTipo_Producto";
        public const string SelectById_Producto = "http://localhost:2576/Producto_Services.svc/selectById_Producto";
        public const string Search_Producto = "http://localhost:2576/Producto_Services.svc/search_Producto";
        public const string Add_Producto = "http://localhost:2576/Producto_Services.svc/add_Producto";
        public const string SelectAll_UnidadProducto = "http://localhost:2576/Producto_Services.svc/selectAll_UnidadProducto";

        //Promocion
        public const string Add_Promocion = "http://localhost:2576/Promocion_Services.svc/add_Promocion";
        public const string Add_DetallePromocion = "http://localhost:2576/Promocion_Services.svc/add_DetallePromocion";

        //Rol
        public const string SelectAll_Rol = "http://localhost:2576/Rol_Services.svc/selectAll_Rol";
        public const string SelectById_Rol = "http://localhost:2576/Rol_Services.svc/selectById_Rol";
        public const string Add_RolXPerfil = "http://localhost:2576/Rol_Services.svc/add_RolXPerfil";

        //Tienda
        public const string List_Tienda = "http://localhost:2576/Tienda_Services.svc/list_Tienda";
        public const string SelectAll_Tienda = "http://localhost:2576/Tienda_Services.svc/selectAll_Tienda";
        public const string Search_Tienda = "http://localhost:2576/Tienda_Services.svc/search_Tienda";

        //Usuario
        public const string SelectAll_Usuario = "http://localhost:2576/Usuario_Services.svc/selectAll_Usuario";
        public const string Search_Usuario = "http://localhost:2576/Usuario_Services.svc/search_Usuario";
        public const string List_Usuario = "http://localhost:2576/Usuario_Services.svc/list_Usuario";
        public const string List_LogUsuario = "http://localhost:2576/Usuario_Services.svc/list_LogUsuario";
        public const string SelectAll_LogUsuario = "http://localhost:2576/Usuario_Services.svc/selectAll_LogUsuario";
        public const string Search_LogUsuario = "http://localhost:2576/Usuario_Services.svc/search_LogUsuario";
        public const string Login_Usuario = "http://localhost:2576/Usuario_Services.svc/login_Usuario";
        public const string Add_Usuario = "http://localhost:2576/Usuario_Services.svc/add_Usuario";
        public const string Add_LogUsuario = "http://localhost:2576/Usuario_Services.svc/add_LogUsuario";

        //Vehiculo
        public const string List_Vehiculo = "http://localhost:2576/Vehiculo_Services.svc/list_Vehiculo";
        public const string SelectAll_Vehiculo = "http://localhost:2576/Vehiculo_Services.svc/selectAll_Vehiculo";
        public const string List_InventarioVehiculo = "http://localhost:2576/Vehiculo_Services.svc/list_InventarioVehiculo";
        public const string Search_Vehiculo = "http://localhost:2576/Vehiculo_Services.svc/search_Vehiculo";
        public const string Add_Vehiculo = "http://localhost:2576/Vehiculo_Services.svc/add_Vehiculo";
        public const string SelectAll_Marca = "http://localhost:2576/Vehiculo_Services.svc/selectAll_Marca";
        public const string SelectByMarca_Modelo = "http://localhost:2576/Vehiculo_Services.svc/selectByMarca_Modelo";

        #endregion

        #region Flujo BD

        public const string OK = "OK";
        public const string ERROR = "ERROR";
        public const string FALLA = "FALLA";

        #endregion
    }
}