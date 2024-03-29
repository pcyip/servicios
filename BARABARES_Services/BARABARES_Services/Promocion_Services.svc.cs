﻿using BARABARES_Services.AppCode;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Promocion_Services" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Promocion_Services.svc or Promocion_Services.svc.cs at the Solution Explorer and start debugging.
    public class Promocion_Services : IPromocion_Services
    {
        #region Promocion

        public List<Select.Promocion> selectAll_Promocion()
        {
            try
            {
                List<Select.Promocion> promociones = new List<Select.Promocion>();
                Select.Promocion p;

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
                        return promociones;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PROMOCION_SELECT_ALL", SqlConn);
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
                    p = Utils.select_promocion_parse(rows[i]);
                    promociones.Add(p);
                }

                return promociones;

            }
            catch (Exception ex)
            {
                Select.Promocion d = new Select.Promocion();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_Promocion,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Promocion>();
            }

        }

        public Select.Promocion_Sistema selectById_Sistema_Promocion(int id)
        {
            try
            {
                Select.Promocion_Sistema p =  new Select.Promocion_Sistema();

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

                    SqlCommand sqlCmd = new SqlCommand("PROMOCION_SELECT_BY_ID_SISTEMA", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipnIdPromocion", SqlDbType.Int).Value = id;

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
                    p = Utils.promocion_sistema_parse(rows[i]);
                }

                return p;

            }
            catch (Exception ex)
            {
                Select.Promocion d = new Select.Promocion();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectById_Sistema_Promocion,
                    Input = JsonSerializer.selectById(id),
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new Select.Promocion_Sistema();
            }

        }

        public List<Select.Promocion> search_Promocion(Search.Promocion pro)
        {
            try
            {
                List<Select.Promocion> promociones = new List<Select.Promocion>();
                Select.Promocion p = new Select.Promocion();

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
                        return promociones;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PROMOCION_SEARCH", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsNombre", SqlDbType.VarChar).Value = pro.Nombre;
                    sqlCmd.Parameters.Add("@ipnMinimo", SqlDbType.Real).Value = pro.Minimo;
                    sqlCmd.Parameters.Add("@ipnMaximo", SqlDbType.Real).Value = pro.Maximo;
                    sqlCmd.Parameters.Add("@ipbSemana", SqlDbType.Bit).Value = pro.Semana;
                    sqlCmd.Parameters.Add("@ipdDesde", SqlDbType.DateTime).Value = pro.Desde;
                    sqlCmd.Parameters.Add("@ipdHasta", SqlDbType.DateTime).Value = pro.Hasta;

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
                    p = Utils.select_promocion_parse(rows[i]);
                    promociones.Add(p);
                }

                return promociones;

            }
            catch (Exception ex)
            {
                Select.Promocion d = new Select.Promocion();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_BUSCAR,
                    Servicio = Constantes.Search_Promocion,
                    Input = JsonSerializer.search_Promocion(pro),
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Promocion>();
            }

        }

        public List<Select.PromocionSemana> semana_Promocion()
        {
            try
            {
                List<Select.PromocionSemana> promociones = new List<Select.PromocionSemana>();
                Select.PromocionSemana p;

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
                        return promociones;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PROMOCION_SEMANA", SqlConn);
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
                    p = Utils.semana_promocion_parse(rows[i]);
                    promociones.Add(p);
                }

                return promociones;

            }
            catch (Exception ex)
            {
                Promocion d = new Promocion();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.Semana_Promocion,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.PromocionSemana>();
            }

        }

        public Select.Promocion_Web semana_WEB_Promocion()
        {
            try
            {
                Select.Promocion_Web promocion = new Select.Promocion_Web();

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
                        return promocion;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PROMOCION_SEMANA_WEB", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();
                DataRow[] rows2;

                //rows.Length = 1
                if (rows.Length > 0)
                {
                    promocion = Utils.promocion_web_parse(rows[0]);

                    Select.DetallePromocion_Web dpw;

                    dt = null;
                    sda = null;
                    dt = new DataTable();
                    sda = new SqlDataAdapter();

                    using (SqlConnection SqlConn = new SqlConnection(ConnString))
                    {
                        SqlConn.Open();
                        SqlCommand sqlCmd = new SqlCommand("PROMOCION_DETALLE_LIST_WEB", SqlConn);
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.Add("@ipnIdPromocion", SqlDbType.Int).Value = promocion.IdPromocion;

                        sda.SelectCommand = sqlCmd;
                        sda.Fill(dt);
                        SqlConn.Close();
                        sqlCmd.Dispose();
                        sda.Dispose();
                    }

                    rows2 = null;
                    rows2 = dt.Select();

                    for (int j = 0; j < rows2.Length; j++)
                    {
                        dpw = Utils.detallePromocion_Web_parse(rows2[j]);
                        promocion.Detalle.Add(dpw);
                    }

                }

                return promocion;
            }
            catch (Exception ex)
            {
                Select.Promocion_Web d = new Select.Promocion_Web();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.List_web_Promocion,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new Select.Promocion_Web();
            }
        }

        public ResponseBD add_Promocion(Promocion p)
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

                    SqlCommand sqlCmd = new SqlCommand("PROMOCION_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipsNombre", SqlDbType.VarChar).Value = p.Nombre;
                    sqlCmd.Parameters.Add("@ipsDescripcion", SqlDbType.VarChar).Value = p.Descripcion;
                    sqlCmd.Parameters.Add("@ipdFechaInicio", SqlDbType.DateTime).Value = p.FechaInicio;
                    sqlCmd.Parameters.Add("@ipdFechaFin", SqlDbType.DateTime).Value = p.FechaFin;
                    sqlCmd.Parameters.Add("@ipbSemana", SqlDbType.Bit).Value = p.Semana;
                    sqlCmd.Parameters.Add("@ipnPrecioUnitario", SqlDbType.Real).Value = p.PrecioUnitario;
                    sqlCmd.Parameters.Add("@ipsImagen", SqlDbType.VarChar).Value = p.Imagen;
                    sqlCmd.Parameters.Add("@ipnIdMoneda", SqlDbType.Int).Value = p.IdMoneda;
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
                    Servicio = Constantes.Add_Promocion,
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

        #region DetallePromocion

        public List<DetallePromocion> selectAll_DetallePromocion()
        {
            try
            {
                List<DetallePromocion> detallePromociones = new List<DetallePromocion>();
                DetallePromocion d;

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
                        return detallePromociones;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PROMOCION_DETALLE_SELECT_ALL", SqlConn);
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
                    d = Utils.detallePromocion_parse(rows[i]);
                    detallePromociones.Add(d);
                }

                return detallePromociones;
            }
            catch (Exception ex)
            {
                DetallePromocion d = new DetallePromocion();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_DetallePromocion,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<DetallePromocion>();
            }

        }

        public List<Select.DetallePromocion_Sistema> selectByPromo_Sistema_DetallePromocion(int id)
        {
            try
            {
                List<Select.DetallePromocion_Sistema> detallePromociones = new List<Select.DetallePromocion_Sistema>();
                Select.DetallePromocion_Sistema d = new Select.DetallePromocion_Sistema();

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
                        return detallePromociones;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PROMOCION_DETALLE_SELECT_BY_PROMO_SISTEMA", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipnIdPromocion", SqlDbType.Int).Value = id;

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
                    d = Utils.detallePromocion_sistema_parse(rows[i]);
                    detallePromociones.Add(d);
                }

                return detallePromociones;
            }
            catch (Exception ex)
            {
                Select.DetallePromocion_Sistema d = new Select.DetallePromocion_Sistema();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SselectByPromo_Sistema_DetallePromocion,
                    Input = JsonSerializer.selectById(id),
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.DetallePromocion_Sistema>();
            }

        }

        public ResponseBD add_DetallePromocion(DetallePromocion d)
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

                    SqlCommand sqlCmd = new SqlCommand("PROMOCION_DETALLE_INSERT", SqlConn);
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
                    sqlCmd.Parameters.Add("@ipnPrecioUnitario", SqlDbType.Real).Value = d.PrecioUnitario;
                    sqlCmd.Parameters.Add("@ipnIdProducto", SqlDbType.Int).Value = d.IdProducto;
                    sqlCmd.Parameters.Add("@ipnIdPromocion", SqlDbType.Int).Value = d.IdPromocion;
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
                    Servicio = Constantes.Add_DetallePromocion,
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

        public List<Select.Promocion_Web> list_WEB_Promocion()
        {
            try
            {
                List<Select.Promocion_Web> promociones = new List<Select.Promocion_Web>();
                Select.Promocion_Web pw;

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
                        return promociones;
                    }

                    SqlCommand sqlCmd = new SqlCommand("PROMOCION_LIST_WEB", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();
                DataRow[] rows2;

                for (int i = 0; i < rows.Length; i++)
                {
                    pw = Utils.promocion_web_parse(rows[i]);

                    Select.DetallePromocion_Web dpw;

                    dt = null;
                    sda = null;
                    dt = new DataTable();
                    sda = new SqlDataAdapter();

                    using (SqlConnection SqlConn = new SqlConnection(ConnString))
                    {
                        SqlConn.Open();
                        SqlCommand sqlCmd = new SqlCommand("PROMOCION_DETALLE_LIST_WEB", SqlConn);
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.Add("@ipnIdPromocion", SqlDbType.Int).Value = pw.IdPromocion;

                        sda.SelectCommand = sqlCmd;
                        sda.Fill(dt);
                        SqlConn.Close();
                        sqlCmd.Dispose();
                        sda.Dispose();
                    }

                    rows2 = null;
                    rows2 = dt.Select();

                    for (int j = 0; j < rows2.Length; j++)
                    {
                        dpw = Utils.detallePromocion_Web_parse(rows2[j]);
                        pw.Detalle.Add(dpw);
                    }

                    promociones.Add(pw);
                }

                return promociones;
            }
            catch (Exception ex)
            {
                Select.Promocion_Web d = new Select.Promocion_Web();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.List_web_Promocion,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = d.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Select.Promocion_Web>();
            }

        }

        #endregion
    }
}
