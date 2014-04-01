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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Vehiculo_Services" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Vehiculo_Services.svc or Vehiculo_Services.svc.cs at the Solution Explorer and start debugging.
    public class Vehiculo_Services : IVehiculo_Services
    {
        #region Vehiculo

        public List<Vehiculo> selectAll_Vehiculo()
        {
            try
            {
                List<Vehiculo> vehiculos = new List<Vehiculo>();
                Vehiculo v;

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
                        return vehiculos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("VEHICULO_SELECT_ALL", SqlConn);
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
                    v = Utils.vehiculo_parse(rows[i]);
                    vehiculos.Add(v);
                }

                return vehiculos;
            }
            catch (Exception ex)
            {
                Vehiculo v = new Vehiculo();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_Vehiculo,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = v.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Vehiculo>();
            }

        }

        public List<Vehiculo> combo_Vehiculo()
        {
            try
            {
                List<Vehiculo> vehiculos = new List<Vehiculo>();
                Vehiculo v;

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
                        return vehiculos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("VEHICULO_COMBO", SqlConn);
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
                    v = Utils.vehiculo_parse(rows[i]);
                    vehiculos.Add(v);
                }

                return vehiculos;
            }
            catch (Exception ex)
            {
                Vehiculo v = new Vehiculo();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.Combo_Vehiculo,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = v.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Vehiculo>();
            }

        }

        public List<Select.Vehiculo> list_Vehiculo()
        {
            try
            {
                List<Select.Vehiculo> vehiculos = new List<Select.Vehiculo>();
                Select.Vehiculo v;

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
                        return vehiculos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("VEHICULO_LIST_SISTEMA", SqlConn);
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
                    v = Utils.select_vehiculo_parse(rows[i]);
                    vehiculos.Add(v);
                }

                return vehiculos;
            }
            catch (Exception ex)
            {
                Select.Vehiculo v = new Select.Vehiculo();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.List_Vehiculo,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = v.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Vehiculo>();
            }

        }

        public List<Select.Vehiculo> search_Vehiculo(Search.Vehiculo veh)
        {
            try
            {
                List<Select.Vehiculo> vehiculos = new List<Select.Vehiculo>();
                Select.Vehiculo v;

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
                        return vehiculos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("VEHICULO_SEARCH", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsDescripcion", SqlDbType.VarChar).Value = veh.Descripcion;
                    sqlCmd.Parameters.Add("@ipsPlaca", SqlDbType.VarChar).Value = veh.Placa;
                    sqlCmd.Parameters.Add("@ipnMarca", SqlDbType.Int).Value = veh.Marca;
                    sqlCmd.Parameters.Add("@ipnModelo", SqlDbType.Int).Value = veh.Modelo;
                    sqlCmd.Parameters.Add("@ipnIdTienda", SqlDbType.Int).Value = veh.IdTienda;
                    sqlCmd.Parameters.Add("@ipbEstado", SqlDbType.Bit).Value = veh.Activo;
                    sqlCmd.Parameters.Add("@ipdDesde", SqlDbType.DateTime).Value = veh.Desde;
                    sqlCmd.Parameters.Add("@ipdHasta", SqlDbType.DateTime).Value = veh.Hasta;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    v = Utils.select_vehiculo_parse(rows[i]);
                    vehiculos.Add(v);
                }

                return vehiculos;
            }
            catch (Exception ex)
            {
                Select.Vehiculo v = new Select.Vehiculo();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_BUSCAR,
                    Servicio = Constantes.Search_Vehiculo,
                    Input = JsonSerializer.search_Vehiculo(veh),
                    Descripcion = ex.ToString(),
                    Clase = v.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Vehiculo>();
            }

        }

        public ResponseBD add_Vehiculo(Vehiculo v)
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
                    SqlCommand sqlCmd = new SqlCommand("VEHICULO_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipsDescripcion", SqlDbType.VarChar).Value = v.Descripcion;
                    sqlCmd.Parameters.Add("@ipsPlaca", SqlDbType.VarChar).Value = v.Placa;
                    sqlCmd.Parameters.Add("@ipnMarca", SqlDbType.Int).Value = v.Marca;
                    sqlCmd.Parameters.Add("@ipnModelo", SqlDbType.Int).Value = v.Modelo;
                    sqlCmd.Parameters.Add("@ipdFechaCreacion", SqlDbType.DateTime).Value = v.FechaCreacion;
                    sqlCmd.Parameters.Add("@ipbActivo", SqlDbType.Bit).Value = v.Activo;
                    sqlCmd.Parameters.Add("@ipnCapacidad", SqlDbType.Int).Value = v.Capacidad;
                    sqlCmd.Parameters.Add("@ipnIdTienda", SqlDbType.Int).Value = v.IdTienda;
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
                    Servicio = Constantes.Add_Vehiculo,
                    Input = JsonSerializer.add_Vehiculo(v),
                    Descripcion = ex.ToString(),
                    Clase = (v == null) ? "null" : v.GetType().Name,
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

        public List<Select.InventarioVehiculo> list_InventarioVehiculo()
        {
            try
            {
                List<Select.InventarioVehiculo> vehiculos = new List<Select.InventarioVehiculo>();
                Select.InventarioVehiculo a;

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
                        return vehiculos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PRODUCTO_X_VEHICULO_LIST_SISTEMA", SqlConn);
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
                    a = Utils.select_inventario_vehiculo_parse(rows[i]);
                    vehiculos.Add(a);
                }

                return vehiculos;
            }
            catch (Exception ex)
            {
                Select.InventarioVehiculo v = new Select.InventarioVehiculo();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.List_InventarioVehiculo,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = v.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.InventarioVehiculo>();
            }

        }

        public List<Select.InventarioVehiculo> search_InventarioVehiculo(Search.InventarioVehiculo veh)
        {
            try
            {
                List<Select.InventarioVehiculo> vehiculos = new List<Select.InventarioVehiculo>();
                Select.InventarioVehiculo a = new Select.InventarioVehiculo();

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
                        return vehiculos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PRODUCTO_X_VEHICULO_SEARCH", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsNombre", SqlDbType.VarChar).Value = veh.Nombre;
                    sqlCmd.Parameters.Add("@ipnVehiculo", SqlDbType.Int).Value = veh.Vehiculo;
                    sqlCmd.Parameters.Add("@ipnIdUnidad", SqlDbType.Int).Value = veh.Unidad;
                    sqlCmd.Parameters.Add("@ipnPresentacion", SqlDbType.Int).Value = veh.Presentacion;
                    sqlCmd.Parameters.Add("@ipdDesde", SqlDbType.DateTime).Value = veh.Desde;
                    sqlCmd.Parameters.Add("@ipdHasta", SqlDbType.DateTime).Value = veh.Hasta;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_BUSCAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = a.GetType().Name;
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
                    a = Utils.select_inventario_vehiculo_parse(rows[i]);
                    vehiculos.Add(a);
                }

                return vehiculos;
            }
            catch (Exception ex)
            {
                Select.InventarioVehiculo v = new Select.InventarioVehiculo();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_BUSCAR,
                    Servicio = Constantes.Search_InventarioVehiculo,
                    Input = JsonSerializer.search_InventarioVehiculo(veh),
                    Descripcion = ex.ToString(),
                    Clase = v.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.InventarioVehiculo>();
            }

        }

        #endregion

        #region Marca

        public List<Select.Combo> selectAll_Marca()
        {
            try
            {
                List<Select.Combo> parametros = new List<Select.Combo>();
                Select.Combo p;

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
                        return parametros;
                    }

                    SqlCommand sqlCmd = new SqlCommand("VEHICULO_MARCA_SELECT_ALL", SqlConn);
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
                    p = Utils.combo_parametro_parse(rows[i]);
                    parametros.Add(p);
                }

                return parametros;
            }
            catch (Exception ex)
            {
                Select.Combo v = new Select.Combo();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_Marca,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = v.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Combo>();
            }

        }

        public List<Select.Combo> combo_Marca()
        {
            try
            {
                List<Select.Combo> parametros = new List<Select.Combo>();
                Select.Combo p;

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
                        return parametros;
                    }

                    SqlCommand sqlCmd = new SqlCommand("VEHICULO_MARCA_COMBO", SqlConn);
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
                    p = Utils.combo_parametro_parse(rows[i]);
                    parametros.Add(p);
                }

                return parametros;
            }
            catch (Exception ex)
            {
                Select.Combo v = new Select.Combo();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.Combo_Marca,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = v.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Combo>();
            }

        }

        public List<Select.Combo> selectByMarca_Modelo(int id)
        {
            try
            {
                List<Select.Combo> parametros = new List<Select.Combo>();
                Select.Combo p;

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
                        return parametros;
                    }

                    SqlCommand sqlCmd = new SqlCommand("VEHICULO_MODELO_SELECT_BY_MARCA", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipnCodigoPadre", SqlDbType.Int).Value = id;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    p = Utils.combo_parametro_parse(rows[i]);
                    parametros.Add(p);
                }

                return parametros;
            }
            catch (Exception ex)
            {
                Select.Combo v = new Select.Combo();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectByMarca_Modelo,
                    Input = JsonSerializer.selectByMarca_Modelo(id),
                    Descripcion = ex.ToString(),
                    Clase = v.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Combo>();
            }

        }

        public List<Select.Combo> combo_Modelo(int id)
        {
            try
            {
                List<Select.Combo> parametros = new List<Select.Combo>();
                Select.Combo p;

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
                        return parametros;
                    }

                    SqlCommand sqlCmd = new SqlCommand("VEHICULO_MODELO_COMBO", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipnCodigoPadre", SqlDbType.Int).Value = id;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    p = Utils.combo_parametro_parse(rows[i]);
                    parametros.Add(p);
                }

                return parametros;
            }
            catch (Exception ex)
            {
                Select.Combo v = new Select.Combo();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.Combo_Modelo,
                    Input = JsonSerializer.selectByMarca_Modelo(id),
                    Descripcion = ex.ToString(),
                    Clase = v.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Combo>();
            }

        }

        #endregion
    }
}
