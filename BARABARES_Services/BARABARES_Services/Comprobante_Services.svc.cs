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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Comprobante_Services" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Comprobante_Services.svc or Comprobante_Services.svc.cs at the Solution Explorer and start debugging.
    public class Comprobante_Services : IComprobante_Services
    {
        #region ComprobantePago

        public List<ComprobantePago> selectAll_Comprobante()
        {
            try
            {
                List<ComprobantePago> comprobantes = new List<ComprobantePago>();
                ComprobantePago c = new ComprobantePago();

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
                        return comprobantes;
                    }
                    SqlCommand sqlCmd = new SqlCommand("COMPROBANTE_PAGO_SELECT_ALL", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_LISTAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = c.GetType().Name;
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
                    c = Utils.comprobante_parse(rows[i]);
                    comprobantes.Add(c);
                }


                return comprobantes;
            }
            catch (Exception ex)
            {
                ComprobantePago c = new ComprobantePago();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_Comprobante,
                    Input = "", //TODO
                    Descripcion = ex.ToString(),
                    Clase = c.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<ComprobantePago>();
            }

        }

        public List<Select.ComprobantePago> list_Comprobante()
        {
            try
            {
                List<Select.ComprobantePago> comprobantes = new List<Select.ComprobantePago>();
                Select.ComprobantePago c = new Select.ComprobantePago();

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
                        return comprobantes;
                    }
                    SqlCommand sqlCmd = new SqlCommand("COMPROBANTE_PAGO_LIST_SISTEMA", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_LISTAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = c.GetType().Name;
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
                    c = Utils.select_comprobante_parse(rows[i]);
                    comprobantes.Add(c);
                }

                return comprobantes;
            }
            catch (Exception ex)
            {
                ComprobantePago c = new ComprobantePago();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.List_Comprobante,
                    Input = "", //TODO
                    Descripcion = ex.ToString(),
                    Clase = c.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.ComprobantePago>();
            }

        }

        public List<Select.ComprobantePago> search_Comprobante(Search.ComprobantePago p)
        {
            try
            {
                List<Select.ComprobantePago> comprobantes = new List<Select.ComprobantePago>();
                Select.ComprobantePago c = new Select.ComprobantePago();

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
                        return comprobantes;
                    }
                    SqlCommand sqlCmd = new SqlCommand("COMPROBANTE_PAGO_SEARCH", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsNombres", SqlDbType.VarChar).Value = p.Nombres;
                    sqlCmd.Parameters.Add("@ipsApellidoPaterno", SqlDbType.VarChar).Value = p.ApellidoPaterno;
                    sqlCmd.Parameters.Add("@ipnNumeroDocumento", SqlDbType.Int).Value = p.NumeroDocumento;
                    sqlCmd.Parameters.Add("@ipnIdTipoDocumento", SqlDbType.Int).Value = p.IdTipoDocumento;
                    sqlCmd.Parameters.Add("@ipnNumeroComprobante", SqlDbType.Int).Value = p.Numerocomprobante;
                    sqlCmd.Parameters.Add("@ipnIdTipoComprobante", SqlDbType.Int).Value = p.IdTipoComprobante;
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
                    c = Utils.select_comprobante_parse(rows[i]);
                    comprobantes.Add(c);
                }


                return comprobantes;
            }
            catch (Exception ex)
            {
                Select.ComprobantePago c = new Select.ComprobantePago();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_BUSCAR,
                    Servicio = Constantes.Search_Comprobante,
                    Input = JsonSerializer.search_ComprobantePago(p),
                    Descripcion = ex.ToString(),
                    Clase = c.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.ComprobantePago>();
            }

        }

        public ResponseBD add_Comprobante(ComprobantePago c)
        {
            try
            {
                ResponseBD response = new ResponseBD();

                try
                {
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
                        SqlCommand sqlCmd = new SqlCommand("COMPROBANTE_PAGO_INSERT", SqlConn);
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

                        sqlCmd.Parameters.Add("@ipnNumeroComprobante", SqlDbType.Int).Value = c.NumeroComprobante;
                        sqlCmd.Parameters.Add("@ipdFechaCreacion", SqlDbType.DateTime).Value = c.FechaCreacion;
                        sqlCmd.Parameters.Add("@ipnTotal", SqlDbType.Real).Value = c.Total;
                        sqlCmd.Parameters.Add("@ipnTransaccionPOS", SqlDbType.Int).Value = c.TransaccionPOS;
                        sqlCmd.Parameters.Add("@ipnIdTipoComprobante", SqlDbType.Int).Value = c.IdTipoComprobante;
                        sqlCmd.Parameters.Add("@ipnIdMoneda", SqlDbType.Int).Value = c.IdMoneda;
                        sqlCmd.Parameters.Add("@ipnIdPedido", SqlDbType.Int).Value = c.IdPedido;
                        sqlCmd.Parameters.Add("@ipnIdPersona", SqlDbType.Int).Value = c.IdPersona;

                        sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_CREAR;
                        sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = c.GetType().Name;
                        sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = 1;

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
            catch (Exception ex)
            {
                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_CREAR,
                    Servicio = Constantes.Add_Comprobante,
                    Input = "", //TODO
                    Descripcion = ex.ToString(),
                    Clase = (c == null) ? "null" : c.GetType().Name,
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

        #region DetalleComprobante


        public List<DetalleComprobante> selectAll_DetalleComprobante()
        {
            try
            {
                List<DetalleComprobante> detalleComprobantes = new List<DetalleComprobante>();
                DetalleComprobante d = new DetalleComprobante();

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
                        return detalleComprobantes;
                    }
                    SqlCommand sqlCmd = new SqlCommand("COMPROBANTE_DETALLE_SELECT_ALL", SqlConn);
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
                    d = Utils.detalleComprobante_parse(rows[i]);
                    detalleComprobantes.Add(d);
                }


                return detalleComprobantes;
            }
            catch (Exception ex)
            {
                DetalleComprobante d = new DetalleComprobante();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_DetalleComprobante,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<DetalleComprobante>();
            }
        }

        public ResponseBD add_DetalleComprobante(DetalleComprobante d)
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
                    SqlCommand sqlCmd = new SqlCommand("COMPROBANTE_DETALLE_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipnCantidad", SqlDbType.Int).Value = d.Cantidad;
                    sqlCmd.Parameters.Add("@ipnSubtotal", SqlDbType.Real).Value = d.Subtotal;
                    sqlCmd.Parameters.Add("@ipnIdProducto", SqlDbType.Int).Value = d.IdProducto;
                    sqlCmd.Parameters.Add("@ipnIdComprobantePago", SqlDbType.Int).Value = d.IdComprobantePago;
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
                    Servicio = Constantes.Add_DetalleComprobante,
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

        #region MedioPago

        public List<MedioPago> selectAll_MedioPago()
        {
            try
            {
                List<MedioPago> mediopagos = new List<MedioPago>();
                MedioPago m = new MedioPago();

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
                        return mediopagos;
                    }
                    SqlCommand sqlCmd = new SqlCommand("COMPROBANTE_MEDIO_PAGO_SELECT_ALL", SqlConn);
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
                    m = Utils.medioPago_parse(rows[i]);
                    mediopagos.Add(m);
                }

                return mediopagos;
            }
            catch (Exception ex)
            {
                MedioPago m = new MedioPago();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_MedioPago,
                    Input = "", //TODO
                    Descripcion = ex.ToString(),
                    Clase = m.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<MedioPago>();
            }

        }

        public List<MedioPago> combo_MedioPago()
        {
            try
            {
                List<MedioPago> mediopagos = new List<MedioPago>();
                MedioPago m = new MedioPago();

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
                        return mediopagos;
                    }
                    SqlCommand sqlCmd = new SqlCommand("COMPROBANTE_MEDIO_PAGO_COMBO", SqlConn);
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
                    m = Utils.medioPago_parse(rows[i]);
                    mediopagos.Add(m);
                }

                return mediopagos;
            }
            catch (Exception ex)
            {
                MedioPago m = new MedioPago();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.Combo_MedioPago,
                    Input = "", //TODO
                    Descripcion = ex.ToString(),
                    Clase = m.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<MedioPago>();
            }

        }

        public ResponseBD add_MedioPago(MedioPago m)
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
                    SqlCommand sqlCmd = new SqlCommand("COMPROBANTE_MEDIO_PAGO_INSERT", SqlConn);
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
                    Servicio = Constantes.Add_MedioPago,
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

        #region TipoComprobante

        public List<TipoComprobante> selectAll_TipoComprobante()
        {
            try
            {
                List<TipoComprobante> tipoComprobantes = new List<TipoComprobante>();
                TipoComprobante t = new TipoComprobante();

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
                        return tipoComprobantes;
                    }
                    SqlCommand sqlCmd = new SqlCommand("COMPROBANTE_TIPO_SELECT_ALL", SqlConn);
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
                    t = Utils.tipoComprobante_parse(rows[i]);
                    tipoComprobantes.Add(t);
                }



                return tipoComprobantes;
            }
            catch (Exception ex)
            {
                TipoComprobante t = new TipoComprobante();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_TipoComprobante,
                    Input = "", //TODO
                    Descripcion = ex.ToString(),
                    Clase = t.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<TipoComprobante>();
            }

        }

        public List<TipoComprobante> combo_TipoComprobante()
        {
            try
            {
                List<TipoComprobante> tipoComprobantes = new List<TipoComprobante>();
                TipoComprobante t = new TipoComprobante();

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
                        return tipoComprobantes;
                    }
                    SqlCommand sqlCmd = new SqlCommand("COMPROBANTE_TIPO_COMBO", SqlConn);
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
                    t = Utils.tipoComprobante_parse(rows[i]);
                    tipoComprobantes.Add(t);
                }



                return tipoComprobantes;
            }
            catch (Exception ex)
            {
                TipoComprobante t = new TipoComprobante();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.Combo_TipoComprobante,
                    Input = "", //TODO
                    Descripcion = ex.ToString(),
                    Clase = t.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<TipoComprobante>();
            }

        }

        public ResponseBD add_TipoComprobante(TipoComprobante t)
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
                    SqlCommand sqlCmd = new SqlCommand("COMPROBANTE_TIPO_INSERT", SqlConn);
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
                    Servicio = Constantes.Add_TipoComprobante,
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

        #region TipoTarjeta

        public List<TipoTarjeta> selectAll_TipoTarjeta()
        {
            try
            {
                List<TipoTarjeta> tipoTarjetas = new List<TipoTarjeta>();
                TipoTarjeta t = new TipoTarjeta();

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
                        return tipoTarjetas;
                    }
                    SqlCommand sqlCmd = new SqlCommand("COMPROBANTE_TARJETA_TIPO_SELECT_ALL", SqlConn);
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
                    t = Utils.tipoTarjeta_parse(rows[i]);
                    tipoTarjetas.Add(t);
                }


                return tipoTarjetas;
            }
            catch (Exception ex)
            {
                TipoTarjeta t = new TipoTarjeta();
                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_TipoTarjeta,
                    Input = "", //TODO
                    Descripcion = ex.ToString(),
                    Clase = t.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<TipoTarjeta>();
            }

        }

        public ResponseBD add_TipoTarjeta(TipoTarjeta t)
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

                    SqlCommand sqlCmd = new SqlCommand("COMPROBANTE_TARJETA_TIPO_INSERT", SqlConn);
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
                    sqlCmd.Parameters.Add("@ipnIdMedioPago", SqlDbType.Int).Value = t.IdMedioPago;

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
                    Servicio = Constantes.Add_TipoTarjeta,
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
