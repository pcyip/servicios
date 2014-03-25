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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Usuario_Services" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Usuario_Services.svc or Usuario_Services.svc.cs at the Solution Explorer and start debugging.
    public class Usuario_Services : IUsuario_Services
    {
        #region Usuario

        public List<Usuario> selectAll_Usuario()
        {
            List<Usuario> usuarios = new List<Usuario>();
            Usuario u;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("USUARIO_SELECT_ALL", SqlConn);
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
                    u = Utils.usuario_parse(rows[i]);
                    usuarios.Add(u);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return usuarios;

        }

        public List<Select.Usuario> list_Usuario()
        {
            List<Select.Usuario> usuarios = new List<Select.Usuario>();
            Select.Usuario u = new Select.Usuario();

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("USUARIO_LIST_SISTEMA", SqlConn);
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
                    u = Utils.select_usuario_parse(rows[i]);
                    usuarios.Add(u);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return usuarios;

        }

        public List<Select.Usuario> search_Usuario(Search.Usuario usu)
        {
            List<Select.Usuario> usuarios = new List<Select.Usuario>();
            Select.Usuario u;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("USUARIO_SEARCH", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsNombre", SqlDbType.VarChar).Value = usu.Nombre;
                    sqlCmd.Parameters.Add("@ipbEstado", SqlDbType.Bit).Value = usu.Activo;
                    sqlCmd.Parameters.Add("@ipdDesde", SqlDbType.DateTime).Value = usu.Desde;
                    sqlCmd.Parameters.Add("@ipdHasta", SqlDbType.DateTime).Value = usu.Hasta;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    u = Utils.select_usuario_parse(rows[i]);
                    usuarios.Add(u);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return usuarios;

        }

        public ResponseBD add_Usuario(Usuario u)
        {
            ResponseBD response = new ResponseBD();

            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("USUARIO_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipsNombre", SqlDbType.VarChar).Value = u.Nombre;
                    sqlCmd.Parameters.Add("@ipdFechaCreacion", SqlDbType.DateTime).Value = u.FechaCreacion;
                    sqlCmd.Parameters.Add("@ipbActivo", SqlDbType.Bit).Value = u.Activo;
                    sqlCmd.Parameters.Add("@ipnIdContrasena", SqlDbType.Int).Value = u.IdContrasena;
                    sqlCmd.Parameters.Add("@ipnIdTienda", SqlDbType.Int).Value = u.IdTienda;
                    sqlCmd.Parameters.Add(flujo);
                    sqlCmd.Parameters.Add(mensaje);

                    sqlCmd.ExecuteNonQuery();

                    response.Flujo = flujo.Value.ToString();
                    response.Mensaje = mensaje.Value.ToString();

                    SqlConn.Close();

                }
            }
            catch (Exception ex)
            {

                //add_LogBarabares();
                Debug.WriteLine(ex.ToString());
            }

            return response;
        }

        public ResponseBD login_Usuario(Select.Login l)
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

                        response.Flujo = Constantes.ERROR;
                        response.Mensaje = "Error al abrir la conexión a BD";
                        return response;
                    }
                    SqlCommand sqlCmd = new SqlCommand("USUARIO_LOGIN", SqlConn);
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

                    SqlParameter nombreUsuario = new SqlParameter("@opsNombreUsuario", SqlDbType.VarChar)
                    {
                        Direction = ParameterDirection.Output,
                        Size = 100
                    };

                    SqlParameter idUsuario = new SqlParameter("@opnIdUsuario", SqlDbType.VarChar)
                    {
                        Direction = ParameterDirection.Output,
                        Size = 100
                    };

                    SqlParameter token = new SqlParameter("@opsToken", SqlDbType.VarBinary)
                    {
                        Direction = ParameterDirection.Output,
                        Size = 8000
                    };

                    sqlCmd.Parameters.Add("@ipsUsuario", SqlDbType.VarChar).Value = l.usuario;
                    sqlCmd.Parameters.Add("@ipsContrasena", SqlDbType.VarChar).Value = l.contrasena;
                    sqlCmd.Parameters.Add(flujo);
                    sqlCmd.Parameters.Add(mensaje);
                    sqlCmd.Parameters.Add(token);
                    sqlCmd.Parameters.Add(nombreUsuario);
                    sqlCmd.Parameters.Add(idUsuario);

                    sqlCmd.ExecuteNonQuery();

                    response.Flujo = flujo.Value.ToString();
                    response.Mensaje = mensaje.Value.ToString();

                    //Procesar Usuario

                    //nombreUsuario.ToString()
                    //Int32.Parse(idUsuario.ToString())

                    SqlConn.Close();

                    if (flujo.Value.ToString().Equals(Constantes.OK))
                    {
                        string token_bd = "";
                        foreach (Byte b in (Byte[])token.Value)
                        {
                            token_bd = token_bd + b.ToString();
                        }
                        response.Mensaje = BBSessionManager.Instance.addNewSession(Int32.Parse(idUsuario.Value.ToString()), nombreUsuario.Value.ToString(), token_bd, 0);
                        Debug.WriteLine(response.Mensaje, "Mensaje");
                        Debug.WriteLine(token_bd, "Token");
                    }
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    LogBarabares b = new LogBarabares()
                    {
                        Accion = Constantes.LOG_BUSCAR,
                        Servicio = Constantes.Search_LogUsuario,
                        Input = JsonSerializer.login_Usuario(l.usuario, l.contrasena),
                        Descripcion = ex.ToString(),
                        Clase = l.GetType().Name,
                        Aplicacion = "Servicios",
                        Estado = Constantes.FALLA,
                        Ip = "ip",
                        IdUsuario = 1 //TODO: obtener usuario de la sesión

                    };

                    Utils.add_LogBarabares(b);
                }
            }

            return response;
        }

        public ResponseBD logout_Usuario(string token)
        {
            ResponseBD response = new ResponseBD();
            BBSessionManager.Instance.logOut(token);

            return response;
        }

        #endregion

        #region LogUsuario

        public List<LogUsuario> selectAll_LogUsuario()
        {
            List<LogUsuario> logUsuarios = new List<LogUsuario>();
            LogUsuario l = new LogUsuario();

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("USUARIO_LOG_SELECT_ALL", SqlConn);
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
                    l = Utils.logUsuario_parse(rows[i]);
                    logUsuarios.Add(l);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return logUsuarios;

        }

        public List<Select.LogUsuario> list_LogUsuario()
        {
            List<Select.LogUsuario> logUsuarios = new List<Select.LogUsuario>();
            Select.LogUsuario l = new Select.LogUsuario();

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("USUARIO_LOG_LIST_SISTEMA", SqlConn);
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
                    l = Utils.select_logUsuario_parse(rows[i]);
                    logUsuarios.Add(l);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return logUsuarios;

        }

        public List<Select.LogUsuario> search_LogUsuario(Search.LogUsuario t)
        {
            List<Select.LogUsuario> logUsuarios = new List<Select.LogUsuario>();
            Select.LogUsuario l;


            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
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

                        //TODO:guardar info del error

                        return logUsuarios;
                    }
                    SqlCommand sqlCmd = new SqlCommand("USUARIO_LOG_SEARCH", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsNombre", SqlDbType.VarChar).Value = t.Nombre;
                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = t.Accion;
                    sqlCmd.Parameters.Add("@ipdDesde", SqlDbType.DateTime).Value = t.Desde;
                    sqlCmd.Parameters.Add("@ipdHasta", SqlDbType.DateTime).Value = t.Hasta;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();


                    DataRow[] rows = dt.Select();

                    for (int i = 0; i < rows.Length; i++)
                    {
                        l = Utils.select_logUsuario_parse(rows[i]);
                        logUsuarios.Add(l);
                    }

                }
                catch (Exception ex)
                {
                    LogBarabares b = new LogBarabares()
                    {
                        Accion = Constantes.LOG_BUSCAR,
                        Servicio = Constantes.Search_LogUsuario,
                        Input = JsonSerializer.search_LogUsuario(t),
                        Descripcion = ex.ToString(),
                        Clase = t.GetType().Name,
                        Aplicacion = "Servicios",
                        Estado = Constantes.FALLA,
                        IdUsuario = 1 //TODO: obtener usuario de la sesión

                    };

                    Utils.add_LogBarabares(b);
                }
            }

            return logUsuarios;

        }

        public ResponseBD add_LogUsuario(LogUsuario u)
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
                        response.Flujo = Constantes.ERROR;
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
                        IdUsuario = 1 //TODO: obtener usuario de la sesión

                    };

                    Utils.add_LogBarabares(b);
                }
            }
            return response;
        }

        #endregion

        #region LogBarabares

        public ResponseBD add_LogBarabares(LogBarabares u)
        {
            ResponseBD response = new ResponseBD();

            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return response;
        }

        #endregion
    }
}
