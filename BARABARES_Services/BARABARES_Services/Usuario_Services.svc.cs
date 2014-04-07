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
            try
            {
                List<Usuario> usuarios = new List<Usuario>();
                Usuario u;

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
                        return usuarios;
                    }

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

                return usuarios;
            }
            catch (Exception ex)
            {
                Usuario d = new Usuario();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_Usuario,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Usuario>();
            }

        }

        public List<Select.Usuario> list_Usuario()
        {
            try
            {
                List<Select.Usuario> usuarios = new List<Select.Usuario>();
                Select.Usuario u = new Select.Usuario();

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
                        return usuarios;
                    }

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

                return usuarios;
            }
            catch (Exception ex)
            {
                Select.Usuario d = new Select.Usuario();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.List_Usuario,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Usuario>();
            }

        }

        public List<Select.Usuario> search_Usuario(Search.Usuario usu)
        {
            try
            {
                List<Select.Usuario> usuarios = new List<Select.Usuario>();
                Select.Usuario u;

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
                        return usuarios;
                    }

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

                return usuarios;
            }
            catch (Exception ex)
            {
                Select.Usuario d = new Select.Usuario();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_BUSCAR,
                    Servicio = Constantes.Search_Usuario,
                    Input = JsonSerializer.search_Usuario(usu),
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Usuario>();
            }

        }

        public ResponseBD add_Usuario(Usuario u)
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

                return response;
            }
            catch (Exception ex)
            {
                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_CREAR,
                    Servicio = Constantes.Add_Usuario,
                    Input = JsonSerializer.add_Usuario(u),
                    Descripcion = ex.ToString(),
                    Clase = (u == null) ? "null" : u.GetType().Name,
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

        public ResponseBD login_Usuario(Select.Login l)
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

                return response;
            }
            catch (Exception ex)
            {
                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LOGIN,
                    Servicio = Constantes.Login_Usuario,
                    Input = JsonSerializer.login_Usuario(l.usuario, l.contrasena),
                    Descripcion = ex.ToString(),
                    Clase = (l == null) ? "null" : l.GetType().Name,
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

        public ResponseBD logout_Usuario(string token)
        {
            try
            {
                ResponseBD response = new ResponseBD();
                BBSessionManager.Instance.logOut(token);

                return response;

            }
            catch (Exception ex)
            {
                Usuario d = new Usuario();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LOGOUT,
                    Servicio = Constantes.Logout_Usuario,
                    Input = token,
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
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

        #region LogUsuario

        public List<LogUsuario> selectAll_LogUsuario()
        {
            try
            {
                List<LogUsuario> logUsuarios = new List<LogUsuario>();
                LogUsuario l = new LogUsuario();

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
                        return logUsuarios;
                    }

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

                return logUsuarios;
            }
            catch (Exception ex)
            {
                LogUsuario d = new LogUsuario();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_LogUsuario,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<LogUsuario>();
            }

        }

        public List<Select.LogUsuario> list_LogUsuario()
        {
            try
            {
                List<Select.LogUsuario> logUsuarios = new List<Select.LogUsuario>();
                Select.LogUsuario l = new Select.LogUsuario();

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
                        return logUsuarios;
                    }

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

                return logUsuarios;
            }
            catch (Exception ex)
            {
                Select.LogUsuario d = new Select.LogUsuario();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.List_LogUsuario,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.LogUsuario>();
            }

        }

        public List<Select.LogUsuario> search_LogUsuario(Search.LogUsuario t)
        {
            try
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
                        SqlConn.Open();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
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

                return logUsuarios;
            }
            catch (Exception ex)
            {
                Select.LogUsuario l = new Select.LogUsuario();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_BUSCAR,
                    Servicio = Constantes.Search_LogUsuario,
                    Input = JsonSerializer.search_LogUsuario(t),
                    Descripcion = ex.ToString(),
                    Clase = l.GetType().Name,
                    Aplicacion = "Servicios",
                    Estado = Constantes.FALLA,
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.LogUsuario>();
            }

        }

        public ResponseBD add_LogUsuario(LogUsuario u)
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
                return response;
            }
            catch (Exception ex)
            {
                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_CREAR,
                    Servicio = Constantes.Add_LogUsuario,
                    Input = JsonSerializer.add_LogUsuario(u),
                    Descripcion = ex.ToString(),
                    Clase = (u == null) ? "null" : u.GetType().Name,
                    Aplicacion = "Servicios",
                    Estado = Constantes.FALLA,
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

        #region LogBarabares

        public ResponseBD add_LogBarabares(LogBarabares u)
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

                return response;
            }
            catch (Exception ex)
            {
                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_CREAR,
                    Servicio = Constantes.Add_LogBarabares,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = (u == null) ? "null" : u.GetType().Name,
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
