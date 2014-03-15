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
            List<ComprobantePago> comprobantes = new List<ComprobantePago>();
            ComprobantePago c;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("COMPROBANTE_PAGO_SELECT_ALL", SqlConn);
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
                    c = Utils.comprobante_parse(rows[i]);
                    comprobantes.Add(c);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return comprobantes;

        }

        public List<Select.ComprobantePago> list_Comprobante()
        {
            List<Select.ComprobantePago> comprobantes = new List<Select.ComprobantePago>();
            Select.ComprobantePago c;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("COMPROBANTE_PAGO_LIST_SISTEMA", SqlConn);
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
                    c = Utils.select_comprobante_parse(rows[i]);
                    comprobantes.Add(c);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return comprobantes;

        }

        public List<Select.ComprobantePago> search_Comprobante(Search.ComprobantePago p)
        {
            List<Select.ComprobantePago> comprobantes = new List<Select.ComprobantePago>();
            Select.ComprobantePago c;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
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

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return comprobantes;

        }

        public ResponseBD add_Comprobante(ComprobantePago c)
        {
            ResponseBD response = new ResponseBD();

            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
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

        #region DetalleComprobante


        public List<DetalleComprobante> selectAll_DetalleComprobante()
        {
            List<DetalleComprobante> detalleComprobantes = new List<DetalleComprobante>();
            DetalleComprobante d;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
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

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return detalleComprobantes;

        }

        public ResponseBD add_DetalleComprobante(DetalleComprobante d)
        {
            ResponseBD response = new ResponseBD();

            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
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

        #region MedioPago

        public List<MedioPago> selectAll_MedioPago()
        {
            List<MedioPago> mediopagos = new List<MedioPago>();
            MedioPago m;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("COMPROBANTE_MEDIO_PAGO_SELECT_ALL", SqlConn);
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

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return mediopagos;

        }

        public ResponseBD add_MedioPago(MedioPago m)
        {
            ResponseBD response = new ResponseBD();

            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
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

        #region TipoComprobante

        public List<TipoComprobante> selectAll_TipoComprobante()
        {
            List<TipoComprobante> tipoComprobantes = new List<TipoComprobante>();
            TipoComprobante t;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("COMPROBANTE_TIPO_SELECT_ALL", SqlConn);
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

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return tipoComprobantes;

        }

        public ResponseBD add_TipoComprobante(TipoComprobante t)
        {
            ResponseBD response = new ResponseBD();

            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
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

        #region TipoTarjeta

        public List<TipoTarjeta> selectAll_TipoTarjeta()
        {
            List<TipoTarjeta> tipoTarjetas = new List<TipoTarjeta>();
            TipoTarjeta t;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("COMPROBANTE_TARJETA_TIPO_SELECT_ALL", SqlConn);
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
                    t = Utils.tipoTarjeta_parse(rows[i]);
                    tipoTarjetas.Add(t);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return tipoTarjetas;

        }

        public ResponseBD add_TipoTarjeta(TipoTarjeta t)
        {
            ResponseBD response = new ResponseBD();

            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
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
