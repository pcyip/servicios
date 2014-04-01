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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Movimiento_Services" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Movimiento_Services.svc or Movimiento_Services.svc.cs at the Solution Explorer and start debugging.
    public class Movimiento_Services : IMovimiento_Services
    {
        #region Movimiento

        public List<Movimiento> selectAll_Movimiento()
        {
            try
            {
                List<Movimiento> movimientos = new List<Movimiento>();
                Movimiento m = new Movimiento();

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
                        return movimientos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("MOVIMIENTO_SELECT_ALL", SqlConn);
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
                    m = Utils.movimiento_parse(rows[i]);
                    movimientos.Add(m);
                }

                return movimientos;
            }
            catch (Exception ex)
            {
                Movimiento m = new Movimiento();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_Movimiento,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = m.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Movimiento>();
            }

        }

        public List<Select.Movimiento> list_Movimiento()
        {
            try
            {
                List<Select.Movimiento> movimientos = new List<Select.Movimiento>();
                Select.Movimiento m = new Select.Movimiento();

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
                        return movimientos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("MOVIMIENTO_LIST_SISTEMA", SqlConn);
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
                    m = Utils.select_movimiento_parse(rows[i]);
                    movimientos.Add(m);
                }

                return movimientos;
            }
            catch (Exception ex)
            {
                Select.Movimiento m = new Select.Movimiento();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.List_Movimiento,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = m.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Movimiento>();
            }

        }

        public List<Select.Movimiento> search_Movimiento(Search.Movimiento mov)
        {
            try
            {
                List<Select.Movimiento> movimientos = new List<Select.Movimiento>();
                Select.Movimiento m = new Select.Movimiento();

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
                        return movimientos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("MOVIMIENTO_SEARCH", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipnIdMovimiento", SqlDbType.Int).Value = mov.IdMovimiento;
                    sqlCmd.Parameters.Add("@ipnIdTipoMovimiento", SqlDbType.Int).Value = mov.TipoMovimiento;
                    sqlCmd.Parameters.Add("@ipnIdAlmacen", SqlDbType.Int).Value = mov.Almacen;
                    sqlCmd.Parameters.Add("@ipsUsuario", SqlDbType.VarChar).Value = mov.Usuario;
                    sqlCmd.Parameters.Add("@ipdDesde", SqlDbType.DateTime).Value = mov.Desde;
                    sqlCmd.Parameters.Add("@ipdHasta", SqlDbType.DateTime).Value = mov.Hasta;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_BUSCAR;
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
                    m = Utils.select_movimiento_parse(rows[i]);
                    movimientos.Add(m);
                }

                return movimientos;
            }
            catch (Exception ex)
            {
                Select.Movimiento m = new Select.Movimiento();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_BUSCAR,
                    Servicio = Constantes.Search_Movimiento,
                    Input = JsonSerializer.search_Movimiento(mov),
                    Descripcion = ex.ToString(),
                    Clase = m.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Movimiento>();
            }

        }

        public ResponseBD add_Movimiento(Movimiento m)
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

                    SqlCommand sqlCmd = new SqlCommand("MOVIMIENTO_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipsDescripcion", SqlDbType.VarChar).Value = m.Descripcion;
                    sqlCmd.Parameters.Add("@ipdFechaCreacion", SqlDbType.DateTime).Value = m.FechaCreacion;
                    sqlCmd.Parameters.Add("@ipdFechaFin", SqlDbType.DateTime).Value = m.FechaFin;
                    sqlCmd.Parameters.Add("@ipnIdTipoMovimiento", SqlDbType.Int).Value = m.IdTipoMovimiento;
                    sqlCmd.Parameters.Add("@ipnIdAlmacen", SqlDbType.Int).Value = m.IdAlmacen;
                    sqlCmd.Parameters.Add("@ipnIdVehiculo", SqlDbType.Int).Value = m.IdVehiculo;
                    sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = m.IdUsuario;
                    sqlCmd.Parameters.Add("@ipnIdPedido", SqlDbType.Int).Value = m.IdPedido;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_CREAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = m.GetType().Name;

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
                    Servicio = Constantes.Add_Movimiento,
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

        #region DetalleMovimiento

        public List<DetalleMovimiento> selectAll_DetalleMovimiento()
        {
            try
            {
                List<DetalleMovimiento> detalleMovimientos = new List<DetalleMovimiento>();
                DetalleMovimiento d = new DetalleMovimiento();

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
                        return detalleMovimientos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("MOVIMIENTO_DETALLE_SELECT_ALL", SqlConn);
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
                    d = Utils.detalleMovimiento_parse(rows[i]);
                    detalleMovimientos.Add(d);
                }

                return detalleMovimientos;
            }
            catch (Exception ex)
            {
                DetalleMovimiento m = new DetalleMovimiento();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_DetalleMovimiento,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = m.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<DetalleMovimiento>();
            }

        }

        public ResponseBD add_DetalleMovimiento(DetalleMovimiento d)
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

                    SqlCommand sqlCmd = new SqlCommand("MOVIMIENTO_DETALLE_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipdFechaCreacion", SqlDbType.DateTime).Value = d.FechaCreacion;
                    sqlCmd.Parameters.Add("@ipdFechaFin", SqlDbType.DateTime).Value = d.FechaFin;
                    sqlCmd.Parameters.Add("@ipnIdMovimiento", SqlDbType.Int).Value = d.IdMovimiento;
                    sqlCmd.Parameters.Add("@ipnCantidad", SqlDbType.Int).Value = d.Cantidad;
                    sqlCmd.Parameters.Add("@ipnIdProductoXVehiculo", SqlDbType.Int).Value = d.IdProductoXVehiculo;

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
                    Servicio = Constantes.Add_DetalleMovimiento,
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

        #region TipoMovimiento

        public List<TipoMovimiento> selectAll_TipoMovimiento()
        {
            try
            {
                List<TipoMovimiento> tipoMovimientos = new List<TipoMovimiento>();
                TipoMovimiento t = new TipoMovimiento();

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
                        return tipoMovimientos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("MOVIMIENTO_TIPO_SELECT_ALL", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_LISTAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = t.GetType().Name;
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
                    t = Utils.tipoMovimiento_parse(rows[i]);
                    tipoMovimientos.Add(t);
                }

                return tipoMovimientos;
            }
            catch (Exception ex)
            {
                TipoMovimiento m = new TipoMovimiento();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_TipoMovimiento,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = m.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<TipoMovimiento>();
            }

        }

        public List<TipoMovimiento> combo_TipoMovimiento()
        {
            try
            {
                List<TipoMovimiento> tipoMovimientos = new List<TipoMovimiento>();
                TipoMovimiento t = new TipoMovimiento();

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
                        return tipoMovimientos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("MOVIMIENTO_TIPO_COMBO", SqlConn);
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
                    t = Utils.tipoMovimiento_parse(rows[i]);
                    tipoMovimientos.Add(t);
                }

                return tipoMovimientos;
            }
            catch (Exception ex)
            {
                TipoMovimiento m = new TipoMovimiento();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.Combo_TipoMovimiento,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = m.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<TipoMovimiento>();
            }

        }

        public ResponseBD add_TipoMovimiento(TipoMovimiento t)
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

                    SqlCommand sqlCmd = new SqlCommand("MOVIMIENTO_TIPO_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipsNombre", SqlDbType.VarChar).Value = t.Nombre;
                    sqlCmd.Parameters.Add("@ipsDescripcion", SqlDbType.VarChar).Value = t.Descripcion;
                    sqlCmd.Parameters.Add("@ipsActivo", SqlDbType.Bit).Value = t.Activo;
                    sqlCmd.Parameters.Add("@ipdFechaCreacion", SqlDbType.DateTime).Value = t.FechaCreacion;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_CREAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = t.GetType().Name;
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
                    Servicio = Constantes.Add_TipoMovimiento,
                    Input = "", //TODO
                    Descripcion = ex.ToString(),
                    Clase = (t == null) ? "null" : t.GetType().Name,
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
