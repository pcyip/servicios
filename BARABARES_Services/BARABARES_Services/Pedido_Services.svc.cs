using BARABARES_Services.AppCode;
using BARABARES_Services.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BARABARES_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Pedido_Services" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Pedido_Services.svc or Pedido_Services.svc.cs at the Solution Explorer and start debugging.
    public class Pedido_Services : IPedido_Services
    {
        #region Pedido

        public List<PedidoUsuario> usuario_Pedido(int idUsuario)
        {
            List<PedidoUsuario> pedidos = null;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
            using (SqlConnection SqlConn = new SqlConnection(ConnString))
            {
                bool open = false;
                try
                {
                    SqlConn.Open();
                    open = true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }

                if (open)
                {
                    SqlCommand sqlCmd = new SqlCommand("PEDIDO_USUARIO", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = idUsuario;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();

                    DataRow[] rows = dt.Select();

                    if (rows != null)
                        pedidos = Utils.usuario_pedido_parse(rows);
                }
            }

            return pedidos;
        }

        public List<Pedido> selectAll_Pedido()
        {
            try
            {
                List<Pedido> pedidos = new List<Pedido>();
                Pedido p = new Pedido();

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    try
                    {
                        SqlConn.Open();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        return pedidos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PEDIDO_SELECT_ALL", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_LISTAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = p.GetType().Name;
                    sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = 1;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    p = Utils.pedido_parse(rows[i]);
                    pedidos.Add(p);
                }

                return pedidos;
            }
            catch (Exception ex)
            {
                Pedido p = new Pedido();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_Pedido,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = p.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Pedido>();
            }

        }

        public Select.Pedido_Sistema selectById_Pedido(int id)
        {
            try
            {
                Select.Pedido_Sistema p = new Select.Pedido_Sistema();

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    try
                    {
                        SqlConn.Open();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        return p;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PEDIDO_SELECT_BY_ID_SISTEMA", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipnIdPedido", SqlDbType.Int).Value = id;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_LISTAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = p.GetType().Name;
                    sqlCmd.Parameters.Add("@ipnIdUsuarioLog", SqlDbType.Int).Value = 1;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    p = Utils.pedido_sistema_parse(rows[i]);
                }

                return p;
            }
            catch (Exception ex)
            {
                Select.Pedido_Sistema p = new Select.Pedido_Sistema();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectById_Pedido,
                    Input = JsonSerializer.selectById(id),
                    Descripcion = ex.ToString(),
                    Clase = p.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new Select.Pedido_Sistema();
            }

        }

        public List<Select.Pedido> list_Pedido()
        {
            try
            {
                List<Select.Pedido> pedidos = new List<Select.Pedido>();
                Select.Pedido p = new Select.Pedido();

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    try
                    {
                        SqlConn.Open();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        return pedidos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PEDIDO_LIST_SISTEMA", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_LISTAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = p.GetType().Name;
                    sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = 1;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    p = Utils.select_pedido_parse(rows[i]);
                    pedidos.Add(p);
                }

                return pedidos;
            }
            catch (Exception ex)
            {
                Select.Pedido p = new Select.Pedido();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.List_Pedido,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = p.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Pedido>();
            }

        }

        public List<Select.Pedido> search_Pedido(Search.Pedido p)
        {
            try
            {
                List<Select.Pedido> pedidos = new List<Select.Pedido>();
                Select.Pedido pe;

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    try
                    {
                        SqlConn.Open();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        return pedidos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PEDIDO_SEARCH", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsNombres", SqlDbType.VarChar).Value = p.Nombres;
                    sqlCmd.Parameters.Add("@ipsApellidoPaterno", SqlDbType.VarChar).Value = p.ApellidoPaterno;
                    sqlCmd.Parameters.Add("@ipnNumeroDocumento", SqlDbType.Int).Value = p.NumeroDocumento;
                    sqlCmd.Parameters.Add("@ipnIdTipoDocumento", SqlDbType.Int).Value = p.IdTipoDocumento;
                    sqlCmd.Parameters.Add("@ipnIdEstadoPedido", SqlDbType.Int).Value = p.IdEstadoPedido;
                    sqlCmd.Parameters.Add("@ipnIdMedioPago", SqlDbType.Int).Value = p.IdMedioPago;
                    sqlCmd.Parameters.Add("@ipnIdMotivoCancelacion", SqlDbType.Int).Value = p.IdMotivoCancelacion;
                    sqlCmd.Parameters.Add("@ipnIdTienda", SqlDbType.Int).Value = p.IdTienda;
                    sqlCmd.Parameters.Add("@ipdDesde", SqlDbType.DateTime).Value = p.Desde;
                    sqlCmd.Parameters.Add("@ipdHasta", SqlDbType.DateTime).Value = p.Hasta;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_BUSCAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = p.GetType().Name;
                    sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = 1;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    pe = Utils.select_pedido_parse(rows[i]);
                    pedidos.Add(pe);
                }

                return pedidos;
            }
            catch (Exception ex)
            {
                Select.Pedido per = new Select.Pedido();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_BUSCAR,
                    Servicio = Constantes.Search_Pedido,
                    Input = JsonSerializer.search_Pedido(p),
                    Descripcion = ex.ToString(),
                    Clase = per.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Pedido>();
            }

        }

        public ResponseBD add_Pedido(Pedido p)
        {
            try
            {
                ResponseBD response = new ResponseBD();

                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    try
                    {
                        SqlConn.Open();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        response.Flujo = Constantes.FALLA;
                        response.Mensaje = "Error al abrir la conexión a BD";
                        return response;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PEDIDO_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipdFechaEntrega", SqlDbType.DateTime).Value = p.FechaEntrega;
                    sqlCmd.Parameters.Add("@ipdFechaCreacion", SqlDbType.DateTime).Value = p.FechaCreacion;
                    sqlCmd.Parameters.Add("@ipdFechaPago", SqlDbType.DateTime).Value = p.FechaPago;
                    sqlCmd.Parameters.Add("@ipnTotal", SqlDbType.Real).Value = p.Total;
                    sqlCmd.Parameters.Add("@ipnCuantoPaga", SqlDbType.Real).Value = p.CuantoPaga;
                    sqlCmd.Parameters.Add("@ipnIdPersona", SqlDbType.Int).Value = p.IdPersona;
                    sqlCmd.Parameters.Add("@ipnIdEstadoPedido", SqlDbType.Int).Value = p.IdEstadoPedido;
                    sqlCmd.Parameters.Add("@ipnIdMotivoCancelacion", SqlDbType.Int).Value = p.IdMotivoCancelacion;
                    sqlCmd.Parameters.Add("@ipnIdDireccion", SqlDbType.Int).Value = p.IdDireccion;
                    sqlCmd.Parameters.Add("@ipnIdTienda", SqlDbType.Int).Value = p.IdTienda;
                    sqlCmd.Parameters.Add("@ipnIdAlmacen", SqlDbType.Int).Value = p.IdAlmacen;
                    sqlCmd.Parameters.Add("@ipnIdMoneda", SqlDbType.Int).Value = p.IdMoneda;
                    sqlCmd.Parameters.Add("@ipnIdMedioPago", SqlDbType.Int).Value = p.IdMedioPago;
                    sqlCmd.Parameters.Add("@ipnIdCarrito", SqlDbType.Int).Value = p.IdCarrito;
                    sqlCmd.Parameters.Add("@ipnVuelto", SqlDbType.Real).Value = p.Vuelto;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_LISTAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = p.GetType().Name;
                    sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = 1;

                    sqlCmd.Parameters.Add(flujo);
                    sqlCmd.Parameters.Add(mensaje);

                    sqlCmd.ExecuteNonQuery();

                    response.Flujo = flujo.Value.ToString();
                    response.Mensaje = mensaje.Value.ToString();

                    SqlConn.Close();

                }

                return response;
            }
            catch (Exception ex)
            {
                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_CREAR,
                    Servicio = Constantes.Add_Pedido,
                    Input = "", //TODO
                    Descripcion = ex.ToString(),
                    Clase = (p == null) ? "null" : p.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                ResponseBD response = new ResponseBD();
                response.Flujo = Constantes.FALLA;
                response.Mensaje = "Error al abrir la conexión a BD";
                return response;
            }
        }

        #endregion

        #region DetallePedido

        public List<DetallePedido> selectAll_DetallePedido()
        {
            try
            {
                List<DetallePedido> detallePedidos = new List<DetallePedido>();
                DetallePedido d = new DetallePedido();

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    try
                    {
                        SqlConn.Open();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        return detallePedidos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PEDIDO_DETALLE_SELECT_ALL", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_LISTAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = d.GetType().Name;
                    sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = 1;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    d = Utils.detallePedido_parse(rows[i]);
                    detallePedidos.Add(d);
                }

                return detallePedidos;
            }
            catch (Exception ex)
            {
                DetallePedido d = new DetallePedido();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_DetallePedido,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<DetallePedido>();
            }

        }

        public List<Select.DetallePedido_Sistema> selectByPedido_DetallePedido(int id)
        {
            try
            {
                List<Select.DetallePedido_Sistema> detallePedidos = new List<Select.DetallePedido_Sistema>();
                Select.DetallePedido_Sistema d = new Select.DetallePedido_Sistema();

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    try
                    {
                        SqlConn.Open();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        return detallePedidos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PEDIDO_DETALLE_SELECT_BY_PED_SISTEMA", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipnIdPedido", SqlDbType.Int).Value = id;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_LISTAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = d.GetType().Name;
                    sqlCmd.Parameters.Add("@ipnIdUsuarioLog", SqlDbType.Int).Value = 1;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    d = Utils.detallePedido_sistema_parse(rows[i]);
                    detallePedidos.Add(d);
                }

                return detallePedidos;
            }
            catch (Exception ex)
            {
                Select.DetallePedido_Sistema d = new Select.DetallePedido_Sistema();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectByPedido_DetallePedido,
                    Input = JsonSerializer.selectById(id),
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.DetallePedido_Sistema>();
            }

        }

        public ResponseBD add_DetallePedido(DetallePedido d)
        {
            try
            {
                ResponseBD response = new ResponseBD();

                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    try
                    {
                        SqlConn.Open();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        response.Flujo = Constantes.FALLA;
                        response.Mensaje = "Error al abrir la conexión a BD";
                        return response;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PEDIDO_DETALLE_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipnCantidad", SqlDbType.DateTime).Value = d.Cantidad;
                    sqlCmd.Parameters.Add("@ipnSubtotal", SqlDbType.Real).Value = d.Subtotal;
                    sqlCmd.Parameters.Add("@ipnIdPedido", SqlDbType.Int).Value = d.IdPedido;
                    sqlCmd.Parameters.Add("@ipnIdProducto", SqlDbType.Int).Value = d.IdProducto;
                    sqlCmd.Parameters.Add("@ipnIdPromocion", SqlDbType.Int).Value = d.IdPromocion;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_CREAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = d.GetType().Name;
                    sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = 1;

                    sqlCmd.Parameters.Add(flujo);
                    sqlCmd.Parameters.Add(mensaje);

                    sqlCmd.ExecuteNonQuery();

                    response.Flujo = flujo.Value.ToString();
                    response.Mensaje = mensaje.Value.ToString();

                    SqlConn.Close();

                }

                return response;
            }
            catch (Exception ex)
            {
                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_CREAR,
                    Servicio = Constantes.Add_DetallePedido,
                    Input = "", //TODO
                    Descripcion = ex.ToString(),
                    Clase = (d == null) ? "null" : d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                ResponseBD response = new ResponseBD();
                response.Flujo = Constantes.FALLA;
                response.Mensaje = "Error al abrir la conexión a BD";
                return response;
            }
        }

        #endregion

        #region EstadoPedido

        public List<EstadoPedido> selectAll_EstadoPedido()
        {
            try
            {
                List<EstadoPedido> estadoPedidos = new List<EstadoPedido>();
                EstadoPedido e = new EstadoPedido();

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    try
                    {
                        SqlConn.Open();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        return estadoPedidos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PEDIDO_ESTADO_SELECT_ALL", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_LISTAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = e.GetType().Name;
                    sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = 1;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    e = Utils.estadoPedido_parse(rows[i]);
                    estadoPedidos.Add(e);
                }

                return estadoPedidos;
            }
            catch (Exception ex)
            {
                EstadoPedido d = new EstadoPedido();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_EstadoPedido,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<EstadoPedido>();
            }

        }

        public List<EstadoPedido> combo_EstadoPedido()
        {
            try
            {
                List<EstadoPedido> estadoPedidos = new List<EstadoPedido>();
                EstadoPedido e = new EstadoPedido();

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    try
                    {
                        SqlConn.Open();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        return estadoPedidos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PEDIDO_ESTADO_COMBO", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    e = Utils.estadoPedido_parse(rows[i]);
                    estadoPedidos.Add(e);
                }

                return estadoPedidos;
            }
            catch (Exception ex)
            {
                EstadoPedido d = new EstadoPedido();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.Combo_EstadoPedido,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<EstadoPedido>();
            }

        }

        public ResponseBD add_EstadoPedido(EstadoPedido e)
        {
            try
            {
                ResponseBD response = new ResponseBD();

                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    try
                    {
                        SqlConn.Open();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        response.Flujo = Constantes.FALLA;
                        response.Mensaje = "Error al abrir la conexión a BD";
                        return response;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PEDIDO_ESTADO_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipsNombre", SqlDbType.VarChar).Value = e.Nombre;
                    sqlCmd.Parameters.Add("@ipsDescripcion", SqlDbType.VarChar).Value = e.Descripcion;
                    sqlCmd.Parameters.Add("@ipdFechaCreacion", SqlDbType.DateTime).Value = e.FechaCreacion;
                    sqlCmd.Parameters.Add("@ipbActivo", SqlDbType.Bit).Value = e.Activo;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_CREAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = e.GetType().Name;
                    sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = 1;
                    sqlCmd.Parameters.Add(flujo);
                    sqlCmd.Parameters.Add(mensaje);

                    sqlCmd.ExecuteNonQuery();

                    response.Flujo = flujo.Value.ToString();
                    response.Mensaje = mensaje.Value.ToString();

                    SqlConn.Close();

                }

                return response;
            }
            catch (Exception ex)
            {
                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_CREAR,
                    Servicio = Constantes.Add_EstadoPedido,
                    Input = "", //TODO
                    Descripcion = ex.ToString(),
                    Clase = (e == null) ? "null" : e.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                ResponseBD response = new ResponseBD();
                response.Flujo = Constantes.FALLA;
                response.Mensaje = "Error al abrir la conexión a BD";
                return response;
            }
        }

        #endregion

        #region MotivoCancelacion

        public List<MotivoCancelacion> selectAll_MotivoCancelacion()
        {
            try
            {
                List<MotivoCancelacion> motivosCancelacion = new List<MotivoCancelacion>();
                MotivoCancelacion m = new MotivoCancelacion();

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    try
                    {
                        SqlConn.Open();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        return motivosCancelacion;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PEDIDO_MOTIVO_CANCELACION_SELECT_ALL", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_LISTAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = m.GetType().Name;
                    sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = 1;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    m = Utils.motivoCancelacion_parse(rows[i]);
                    motivosCancelacion.Add(m);
                }

                return motivosCancelacion;
            }
            catch (Exception ex)
            {
                MotivoCancelacion d = new MotivoCancelacion();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_MotivoCancelacion,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<MotivoCancelacion>();
            }

        }

        public List<MotivoCancelacion> combo_MotivoCancelacion()
        {
            try
            {
                List<MotivoCancelacion> motivosCancelacion = new List<MotivoCancelacion>();
                MotivoCancelacion m = new MotivoCancelacion();

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    try
                    {
                        SqlConn.Open();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        return motivosCancelacion;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PEDIDO_MOTIVO_CANCELACION_COMBO", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    m = Utils.motivoCancelacion_parse(rows[i]);
                    motivosCancelacion.Add(m);
                }

                return motivosCancelacion;
            }
            catch (Exception ex)
            {
                MotivoCancelacion d = new MotivoCancelacion();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.Combo_MotivoCancelacion,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<MotivoCancelacion>();
            }

        }

        public ResponseBD add_MotivoCancelacion(MotivoCancelacion m)
        {
            try
            {
                ResponseBD response = new ResponseBD();

                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    try
                    {
                        SqlConn.Open();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        response.Flujo = Constantes.FALLA;
                        response.Mensaje = "Error al abrir la conexión a BD";
                        return response;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PEDIDO_MOTIVO_CANCELACION_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipsNombre", SqlDbType.VarChar).Value = m.Nombre;
                    sqlCmd.Parameters.Add("@ipsDescripcion", SqlDbType.VarChar).Value = m.Descripcion;
                    sqlCmd.Parameters.Add("@ipdFechaCreacion", SqlDbType.DateTime).Value = m.FechaCreacion;
                    sqlCmd.Parameters.Add("@ipbActivo", SqlDbType.Bit).Value = m.Activo;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_CREAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = m.GetType().Name;
                    sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = 1;

                    sqlCmd.Parameters.Add(flujo);
                    sqlCmd.Parameters.Add(mensaje);

                    sqlCmd.ExecuteNonQuery();

                    response.Flujo = flujo.Value.ToString();
                    response.Mensaje = mensaje.Value.ToString();

                    SqlConn.Close();

                }

                return response;
            }
            catch (Exception ex)
            {
                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_CREAR,
                    Servicio = Constantes.Add_MotivoCancelacion,
                    Input = "", //TODO
                    Descripcion = ex.ToString(),
                    Clase = (m == null) ? "null" : m.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                ResponseBD response = new ResponseBD();
                response.Flujo = Constantes.FALLA;
                response.Mensaje = "Error al abrir la conexión a BD";
                return response;
            }
        }

        #endregion
    }
}
