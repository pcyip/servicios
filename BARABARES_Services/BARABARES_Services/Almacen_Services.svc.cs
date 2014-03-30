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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Almacen_Services" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Almacen_Services.svc or Almacen_Services.svc.cs at the Solution Explorer and start debugging.
    public class Almacen_Services : IAlmacen_Services
    {
        #region Almacen

        public List<Almacen> selectAll_Almacen()
        {
            try
            {
                List<Almacen> almacenes = new List<Almacen>();
                Almacen a = new Almacen();

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
                        return almacenes;
                    }
                    SqlCommand sqlCmd = new SqlCommand("ALMACEN_SELECT_ALL", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();


                    DataRow[] rows = dt.Select();

                    for (int i = 0; i < rows.Length; i++)
                    {
                        a = Utils.almacen_parse(rows[i]);
                        almacenes.Add(a);
                    }


                }

                return almacenes;

            }
            catch (Exception ex)
            {
                Almacen a = new Almacen();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_Almacen,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = a.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Almacen>();
            }

        }

        public List<Select.Almacen> list_Almacen()
        {
            try
            {
                List<Select.Almacen> almacenes = new List<Select.Almacen>();
                Select.Almacen a = new Select.Almacen();

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
                        return almacenes;
                    }
                    SqlCommand sqlCmd = new SqlCommand("ALMACEN_LIST_SISTEMA", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_LISTAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = a.GetType().Name;
                    sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = 1;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();


                    DataRow[] rows = dt.Select();

                    for (int i = 0; i < rows.Length; i++)
                    {
                        a = Utils.select_almacen_parse(rows[i]);
                        almacenes.Add(a);
                    }


                }
                return almacenes;
            }
            catch (Exception ex)
            {
                Select.Almacen a = new Select.Almacen();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.List_Almacen,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = a.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Almacen>();
            }
        }

        public List<Select.Almacen> search_Almacen(Search.Almacen alm)
        {
            try
            {
                List<Select.Almacen> almacenes = new List<Select.Almacen>();
                Select.Almacen a = new Select.Almacen();

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
                        return almacenes;
                    }
                    SqlCommand sqlCmd = new SqlCommand("ALMACEN_SEARCH", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsDescripcion", SqlDbType.VarChar).Value = alm.Descripcion;
                    sqlCmd.Parameters.Add("@ipnIdDepartamento", SqlDbType.Int).Value = alm.IdDepartamento;
                    sqlCmd.Parameters.Add("@ipnIdProvincia", SqlDbType.Int).Value = alm.IdProvincia;
                    sqlCmd.Parameters.Add("@ipnIdDistrito", SqlDbType.Int).Value = alm.IdDistrito;
                    sqlCmd.Parameters.Add("@ipnIdTienda", SqlDbType.Int).Value = alm.IdTienda;
                    sqlCmd.Parameters.Add("@ipbEstado", SqlDbType.Bit).Value = alm.Activo;
                    sqlCmd.Parameters.Add("@ipdDesde", SqlDbType.DateTime).Value = alm.Desde;
                    sqlCmd.Parameters.Add("@ipdHasta", SqlDbType.DateTime).Value = alm.Hasta;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_BUSCAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = alm.GetType().Name;
                    sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = 1;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();


                    DataRow[] rows = dt.Select();

                    for (int i = 0; i < rows.Length; i++)
                    {
                        a = Utils.select_almacen_parse(rows[i]);
                        almacenes.Add(a);
                    }


                    return almacenes;
                }
            }
            catch (Exception ex)
            {
                Select.Almacen a = new Select.Almacen();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_BUSCAR,
                    Servicio = Constantes.Search_Almacen,
                    Input = JsonSerializer.search_Almacen(alm),
                    Descripcion = ex.ToString(),
                    Clase = a.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Almacen>();
            }
        }

        public ResponseBD add_Almacen(Almacen a)
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
                    SqlCommand sqlCmd = new SqlCommand("ALMACEN_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipsDescripcion", SqlDbType.VarChar).Value = a.Descripcion;
                    sqlCmd.Parameters.Add("@ipnCapacidad", SqlDbType.Int).Value = a.Capacidad;
                    sqlCmd.Parameters.Add("@ipnArea", SqlDbType.Real).Value = a.Area;
                    sqlCmd.Parameters.Add("@ipdFechaCreacion", SqlDbType.DateTime).Value = a.FechaCreacion;
                    sqlCmd.Parameters.Add("@ipbActivo", SqlDbType.Bit).Value = a.Activo;
                    sqlCmd.Parameters.Add("@ipnIdTienda", SqlDbType.Int).Value = a.IdTienda;
                    sqlCmd.Parameters.Add("@ipnIdDireccion", SqlDbType.Int).Value = a.IdDireccion;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_CREAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = a.GetType().Name;
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
                    Servicio = Constantes.Add_Almacen,
                    Input = JsonSerializer.add_Almacen(a),
                    Descripcion = ex.ToString(),
                    Clase = (a == null) ? "null" : a.GetType().Name,
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

        public List<Select.InventarioAlmacen> list_InventarioAlmacen()
        {
            try
            {
                List<Select.InventarioAlmacen> almacenes = new List<Select.InventarioAlmacen>();
                Select.InventarioAlmacen a = new Select.InventarioAlmacen();

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
                        return almacenes;
                    }
                    SqlCommand sqlCmd = new SqlCommand("PRODUCTO_X_ALMACEN_LIST_SISTEMA", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();


                    DataRow[] rows = dt.Select();

                    for (int i = 0; i < rows.Length; i++)
                    {
                        a = Utils.select_inventario_almacen_parse(rows[i]);
                        almacenes.Add(a);
                    }
                }

                return almacenes;
            }
            catch (Exception ex)
            {
                Select.InventarioAlmacen a = new Select.InventarioAlmacen();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.List_InventarioAlmacen,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = a.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);
                return new List<Select.InventarioAlmacen>();
            }

        }

        #endregion
    }
}
