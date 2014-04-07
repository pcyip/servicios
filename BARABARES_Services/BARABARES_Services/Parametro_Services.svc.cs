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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Parametro_Services" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Parametro_Services.svc or Parametro_Services.svc.cs at the Solution Explorer and start debugging.
    public class Parametro_Services : IParametro_Services
    {
        #region Parametro

        public ResponseBD add_Parametro(Parametro p)
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

                    SqlCommand sqlCmd = new SqlCommand("PARAMETRO_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipnCodigoPadre", SqlDbType.Int).Value = p.CodigoPadre;
                    sqlCmd.Parameters.Add("@ipsCodigo", SqlDbType.VarChar).Value = p.Codigo;
                    sqlCmd.Parameters.Add("@ipsValor", SqlDbType.VarChar).Value = p.Valor;
                    sqlCmd.Parameters.Add("@ipnValorNum", SqlDbType.Int).Value = p.ValorNum;
                    sqlCmd.Parameters.Add("@ipsNombre", SqlDbType.VarChar).Value = p.Nombre;
                    sqlCmd.Parameters.Add("@ipbActivo", SqlDbType.Bit).Value = p.Activo;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_CREAR;
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
                    Servicio = Constantes.Add_Parametro,
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

        public List<Parametro> selectAll_Parametro()
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro p = new Parametro();

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

                    SqlCommand sqlCmd = new SqlCommand("PARAMETRO_SELECT_ALL", SqlConn);
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
                    p = Utils.parametro_parse(rows[i]);
                    parametros.Add(p);
                }


                return parametros;
            }
            catch (Exception ex)
            {
                Parametro p = new Parametro();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_Parametro,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = p.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Parametro>();
            }

        }

        public List<Parametro> selectByPadre_Parametro(int id)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro p = new Parametro();

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

                    SqlCommand sqlCmd = new SqlCommand("PARAMETRO_SELECT_BY_PADRE", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipnCodigoPadre", SqlDbType.Int).Value = id;
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
                    p = Utils.parametro_parse(rows[i]);
                    parametros.Add(p);
                }

                return parametros;
            }
            catch (Exception ex)
            {
                Parametro p = new Parametro();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectByPadre_Parametro,
                    Input = JsonSerializer.selectByPadre_Parametro(id),
                    Descripcion = ex.ToString(),
                    Clase = p.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Parametro>();
            }
        }

        #endregion

        #region ParametrosSeguridad

        public List<ParametrosSeguridad> selectAll_ParametrosSeguridad()
        {
            try
            {
                List<ParametrosSeguridad> parametros = new List<ParametrosSeguridad>();
                ParametrosSeguridad p = new ParametrosSeguridad();

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

                    SqlCommand sqlCmd = new SqlCommand("PARAMETRO_SEGURIDAD_SELECT_ALL", SqlConn);
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
                    p = Utils.parametroSeguridad_parse(rows[i]);
                    parametros.Add(p);
                }

                return parametros;
            }
            catch (Exception ex)
            {
                ParametrosSeguridad p = new ParametrosSeguridad();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_ParametrosSeguridad,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = p.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<ParametrosSeguridad>();
            }

        }

        public ResponseBD add_ParametrosSeguridad(ParametrosSeguridad p)
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

                    SqlCommand sqlCmd = new SqlCommand("PARAMETRO_SEGURIDAD_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipsCaracteresContrasena", SqlDbType.VarChar).Value = p.CaracteresContrasena;
                    sqlCmd.Parameters.Add("@ipnTiempoVigenciaDias", SqlDbType.Int).Value = p.TiempoVigenciaDias;
                    sqlCmd.Parameters.Add("@ipnCantidadIntentosFallidos", SqlDbType.Int).Value = p.CantidadIntentosFallidos;
                    sqlCmd.Parameters.Add("@ipnLongitudContrasena", SqlDbType.Int).Value = p.LongitudContrasena;
                    sqlCmd.Parameters.Add("@ipnTiempoMaximoSesion", SqlDbType.Int).Value = p.TiempoMaximoSesion;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_CREAR;
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
                    Servicio = Constantes.Add_ParametrosSeguridad,
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

    }
}
