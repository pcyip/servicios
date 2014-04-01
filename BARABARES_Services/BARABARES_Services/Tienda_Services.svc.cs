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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Tienda_Services" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Tienda_Services.svc or Tienda_Services.svc.cs at the Solution Explorer and start debugging.
    public class Tienda_Services : ITienda_Services
    {
        #region Tienda

        public List<Tienda> selectAll_Tienda()
        {
            try
            {
                List<Tienda> tiendas = new List<Tienda>();
                Tienda t;

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
                        return tiendas;
                    }

                    SqlCommand sqlCmd = new SqlCommand("TIENDA_SELECT_ALL", SqlConn);
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
                    t = Utils.tienda_parse(rows[i]);
                    tiendas.Add(t);
                }

                return tiendas;
            }
            catch (Exception ex)
            {
                Tienda t = new Tienda();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_Tienda,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = t.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Tienda>();
            }

        }

        public List<Tienda> combo_Tienda()
        {
            try
            {
                List<Tienda> tiendas = new List<Tienda>();
                Tienda t;

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
                        return tiendas;
                    }

                    SqlCommand sqlCmd = new SqlCommand("TIENDA_COMBO", SqlConn);
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
                    t = Utils.tienda_parse(rows[i]);
                    tiendas.Add(t);
                }

                return tiendas;
            }
            catch (Exception ex)
            {
                Tienda t = new Tienda();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.Combo_Tienda,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = t.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Tienda>();
            }

        }

        public List<Select.Tienda> list_Tienda()
        {
            try
            {
                List<Select.Tienda> tiendas = new List<Select.Tienda>();
                Select.Tienda t;

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
                        return tiendas;
                    }

                    SqlCommand sqlCmd = new SqlCommand("TIENDA_LIST_SISTEMA", SqlConn);
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
                    t = Utils.select_tienda_parse(rows[i]);
                    tiendas.Add(t);
                }

                return tiendas;
            }
            catch (Exception ex)
            {
                Select.Tienda t = new Select.Tienda();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.List_Tienda,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = t.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Tienda>();
            }

        }

        public List<Select.Tienda> search_Tienda(Search.Tienda ti)
        {
            try
            {
                List<Select.Tienda> tiendas = new List<Select.Tienda>();
                Select.Tienda t;

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
                        return tiendas;
                    }

                    SqlCommand sqlCmd = new SqlCommand("TIENDA_SEARCH", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsNombre", SqlDbType.VarChar).Value = ti.Nombre;
                    sqlCmd.Parameters.Add("@ipnIdDepartamento", SqlDbType.Int).Value = ti.IdDepartamento;
                    sqlCmd.Parameters.Add("@ipnIdProvincia", SqlDbType.Int).Value = ti.IdProvincia;
                    sqlCmd.Parameters.Add("@ipnIdDistrito", SqlDbType.Int).Value = ti.IdDistrito;
                    sqlCmd.Parameters.Add("@ipbEstado", SqlDbType.Bit).Value = ti.Activo;
                    sqlCmd.Parameters.Add("@ipdDesde", SqlDbType.DateTime).Value = ti.Desde;
                    sqlCmd.Parameters.Add("@ipdHasta", SqlDbType.DateTime).Value = ti.Hasta;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    t = Utils.select_tienda_parse(rows[i]);
                    tiendas.Add(t);
                }


                return tiendas;
            }
            catch (Exception ex)
            {
                Select.Tienda t = new Select.Tienda();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_BUSCAR,
                    Servicio = Constantes.Search_Tienda,
                    Input = JsonSerializer.search_Tienda(ti),
                    Descripcion = ex.ToString(),
                    Clase = t.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Tienda>();
            }

        }

        public ResponseBD add_Tienda(Tienda t)
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

                    SqlCommand sqlCmd = new SqlCommand("TIENDA_INSERT", SqlConn);
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
                    sqlCmd.Parameters.Add("@ipdFechaCreacion", SqlDbType.DateTime).Value = t.FechaCreacion;
                    sqlCmd.Parameters.Add("@ipnIdDireccion", SqlDbType.Int).Value = t.IdDireccion;
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
                    Servicio = Constantes.Add_Tienda,
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
