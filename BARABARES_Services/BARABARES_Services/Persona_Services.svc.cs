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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Persona_Services" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Persona_Services.svc or Persona_Services.svc.cs at the Solution Explorer and start debugging.
    public class Persona_Services : IPersona_Services
    {
        #region Persona

        public List<Persona> selectAll_Persona()
        {
            try
            {
                List<Persona> personas = new List<Persona>();
                Persona p;

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
                        return personas;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PERSONA_SELECT_ALL", SqlConn);
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
                    p = Utils.persona_parse(rows[i]);
                    personas.Add(p);
                }

                return personas;
            }
            catch (Exception ex)
            {
                Persona p = new Persona();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_Persona,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = p.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Persona>();
            }

        }

        public List<Select.Persona> selectByTipo_Persona(int idTipo)
        {
            try
            {
                List<Select.Persona> personas = new List<Select.Persona>();
                Select.Persona p;

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
                        return personas;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PERSONA_SELECT_BY_TIPO", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipnIdTipoPersona", SqlDbType.Int).Value = idTipo;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    p = Utils.select_persona_parse(rows[i]);
                    personas.Add(p);
                }

                return personas;
            }
            catch (Exception ex)
            {
                Select.Persona p = new Select.Persona();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectByTipo_Persona,
                    Input = JsonSerializer.selectByTipo_Persona(idTipo),
                    Descripcion = ex.ToString(),
                    Clase = p.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Persona>();
            }

        }

        public Select.DetallePersona selectById_Persona(int id)
        {
            try
            {
                Select.DetallePersona p = new Select.DetallePersona();

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

                    SqlCommand sqlCmd = new SqlCommand("PERSONA_SELECT_BY_ID_SISTEMA", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipnIdPersona", SqlDbType.Int).Value = id;

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
                    p = Utils.persona_sistema_parse(rows[i]);
                }

                return p;
            }
            catch (Exception ex)
            {
                Select.Persona p = new Select.Persona();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectById_Persona,
                    Input = JsonSerializer.selectById_Persona(id),
                    Descripcion = ex.ToString(),
                    Clase = p.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new Select.DetallePersona();
            }

        }

        public List<Select.Persona> search_Persona(Search.Persona p)
        {

            try
            {
                List<Select.Persona> personas = new List<Select.Persona>();
                Select.Persona per;

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
                        return personas;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PERSONA_SEARCH", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsNombres", SqlDbType.VarChar).Value = p.Nombres;
                    sqlCmd.Parameters.Add("@ipsApellidoPaterno", SqlDbType.VarChar).Value = p.ApellidoPaterno;
                    sqlCmd.Parameters.Add("@ipsApellidoMaterno", SqlDbType.VarChar).Value = p.ApellidoMaterno;
                    sqlCmd.Parameters.Add("@ipnNumeroDocumento", SqlDbType.Int).Value = p.NumeroDocumento;
                    sqlCmd.Parameters.Add("@ipnIdTipoPersona", SqlDbType.Int).Value = p.IdTipoPersona;
                    sqlCmd.Parameters.Add("@ipnIdTipoDocumento", SqlDbType.Int).Value = p.IdTipoDocumento;
                    sqlCmd.Parameters.Add("@ipbEstado", SqlDbType.Bit).Value = p.Activo;
                    sqlCmd.Parameters.Add("@ipdDesde", SqlDbType.DateTime).Value = p.Desde;
                    sqlCmd.Parameters.Add("@ipdHasta", SqlDbType.DateTime).Value = p.Hasta;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    per = Utils.select_persona_parse(rows[i]);
                    personas.Add(per);
                }

                return personas;

            }
            catch (Exception ex)
            {
                Select.Persona per = new Select.Persona();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_BUSCAR,
                    Servicio = Constantes.Search_Persona,
                    Input = JsonSerializer.search_Persona(p),
                    Descripcion = ex.ToString(),
                    Clase = per.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Persona>();
            }

        }

        public ResponseBD add_Persona(Persona p)
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

                    SqlCommand sqlCmd = new SqlCommand("PERSONA_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipsNombres", SqlDbType.VarChar).Value = p.Nombres;
                    sqlCmd.Parameters.Add("@ipsApellidoPaterno", SqlDbType.VarChar).Value = p.ApellidoPaterno;
                    sqlCmd.Parameters.Add("@ipsApellidoMaterno", SqlDbType.VarChar).Value = p.ApellidoMaterno;
                    sqlCmd.Parameters.Add("@ipnTelefono", SqlDbType.Int).Value = p.Telefono;
                    sqlCmd.Parameters.Add("@ipnCelular", SqlDbType.Int).Value = p.Celular;
                    sqlCmd.Parameters.Add("@ipsEmail", SqlDbType.VarChar).Value = p.Email;
                    sqlCmd.Parameters.Add("@ipnNumeroDocumento", SqlDbType.Int).Value = p.NumeroDocumento;
                    sqlCmd.Parameters.Add("@ipdFechaNacimiento", SqlDbType.DateTime).Value = p.FechaNacimiento;
                    sqlCmd.Parameters.Add("@ipcSexo", SqlDbType.Char).Value = p.Sexo;
                    sqlCmd.Parameters.Add("@ipnIdTipoPersona", SqlDbType.Int).Value = p.IdTipoPersona;
                    sqlCmd.Parameters.Add("@ipnIdTipoDocumento", SqlDbType.Int).Value = p.IdTipoDocumento;
                    sqlCmd.Parameters.Add("@ipnIdDireccion", SqlDbType.Int).Value = p.IdDireccion;
                    sqlCmd.Parameters.Add("@ipbActivo", SqlDbType.Bit).Value = p.Activo;
                    sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = p.IdUsuario;
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
                    Servicio = Constantes.Add_Persona,
                    Input = JsonSerializer.add_Persona(p),
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

        #region TipoPersona

        public List<TipoPersona> selectAll_TipoPersona()
        {
            try
            {
                List<TipoPersona> tipoPersonas = new List<TipoPersona>();
                TipoPersona t;

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
                        return tipoPersonas;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PERSONA_TIPO_SELECT_ALL", SqlConn);
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
                    t = Utils.tipoPersona_parse(rows[i]);
                    tipoPersonas.Add(t);
                }

                return tipoPersonas;

            }
            catch (Exception ex)
            {
                TipoPersona p = new TipoPersona();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_TipoPersona,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = p.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<TipoPersona>();
            }

        }

        public ResponseBD add_TipoPersona(TipoPersona t)
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

                    SqlCommand sqlCmd = new SqlCommand("PERSONA_TIPO_INSERT", SqlConn);
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
                    sqlCmd.Parameters.Add("@ipdFechaCreacion", SqlDbType.DateTime).Value = t.FechaCreacion;
                    sqlCmd.Parameters.Add("@ipbActivo", SqlDbType.Bit).Value = t.Activo;
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
                    Servicio = Constantes.Add_TipoPersona,
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

        #region TipoDocumento

        public List<TipoDocumento> selectAll_TipoDocumento()
        {
            try
            {
                List<TipoDocumento> tipoDocumentos = new List<TipoDocumento>();
                TipoDocumento t;

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
                        return tipoDocumentos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PERSONA_DOCUMENTO_TIPO_SELECT_ALL", SqlConn);
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
                    t = Utils.tipoDocumento_parse(rows[i]);
                    tipoDocumentos.Add(t);
                }

                return tipoDocumentos;
            }
            catch (Exception ex)
            {
                TipoDocumento p = new TipoDocumento();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_TipoDocumento,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = p.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<TipoDocumento>();
            }

        }

        public List<TipoDocumento> combo_TipoDocumento()
        {
            try
            {
                List<TipoDocumento> tipoDocumentos = new List<TipoDocumento>();
                TipoDocumento t;

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
                        return tipoDocumentos;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PERSONA_DOCUMENTO_TIPO_COMBO", SqlConn);
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
                    t = Utils.tipoDocumento_parse(rows[i]);
                    tipoDocumentos.Add(t);
                }

                return tipoDocumentos;
            }
            catch (Exception ex)
            {
                TipoDocumento p = new TipoDocumento();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.Combo_TipoDocumento,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = p.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<TipoDocumento>();
            }

        }

        public ResponseBD add_TipoDocumento(TipoDocumento t)
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

                    SqlCommand sqlCmd = new SqlCommand("PERSONA_DOCUMENTO_TIPO_INSERT", SqlConn);
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
                    sqlCmd.Parameters.Add("@ipdFechaCreacion", SqlDbType.DateTime).Value = t.FechaCreacion;
                    sqlCmd.Parameters.Add("@ipbActivo", SqlDbType.Bit).Value = t.Activo;
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
                    Servicio = Constantes.Add_TipoDocumento,
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
