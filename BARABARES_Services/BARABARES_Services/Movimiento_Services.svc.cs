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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Movimiento_Services" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Movimiento_Services.svc or Movimiento_Services.svc.cs at the Solution Explorer and start debugging.
    public class Movimiento_Services : IMovimiento_Services
    {
        #region Movimiento

        public List<Movimiento> selectAll_Movimiento()
        {
            List<Movimiento> movimientos = new List<Movimiento>();
            Movimiento m;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("MOVIMIENTO_SELECT_ALL", SqlConn);
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
                    m = Utils.movimiento_parse(rows[i]);
                    movimientos.Add(m);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return movimientos;

        }

        public ResponseBD add_Movimiento(Movimiento m)
        {
            ResponseBD response = new ResponseBD();

            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("MOVIMIENTO_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipsDescripcion", SqlDbType.VarChar).Value = m.Descripcion;
                    sqlCmd.Parameters.Add("@ipdFechaCreacion", SqlDbType.DateTime).Value = m.FechaCreacion;
                    sqlCmd.Parameters.Add("@ipdFechaFin", SqlDbType.DateTime).Value = m.FechaFin;
                    sqlCmd.Parameters.Add("@ipnIdTipoMovimiento", SqlDbType.Int).Value = m.IdTipoMovimiento;
                    sqlCmd.Parameters.Add("@ipnIdAlmacen", SqlDbType.Int).Value = m.IdAlmacen;
                    sqlCmd.Parameters.Add("@ipnIdVehiculo", SqlDbType.Int).Value = m.IdVehiculo;
                    sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = m.IdUsuario;
                    sqlCmd.Parameters.Add("@ipnIdPedido", SqlDbType.Int).Value = m.IdPedido;
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

        #region DetalleMovimiento

        public List<DetalleMovimiento> selectAll_DetalleMovimiento()
        {
            List<DetalleMovimiento> detalleMovimientos = new List<DetalleMovimiento>();
            DetalleMovimiento d;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("MOVIMIENTO_DETALLE_SELECT_ALL", SqlConn);
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
                    d = Utils.detalleMovimiento_parse(rows[i]);
                    detalleMovimientos.Add(d);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return detalleMovimientos;

        }

        public ResponseBD add_DetalleMovimiento(DetalleMovimiento d)
        {
            ResponseBD response = new ResponseBD();

            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("MOVIMIENTO_DETALLE_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipdFechaCreacion", SqlDbType.DateTime).Value = d.FechaCreacion;
                    sqlCmd.Parameters.Add("@ipdFechaFin", SqlDbType.DateTime).Value = d.FechaFin;
                    sqlCmd.Parameters.Add("@ipnIdMovimiento", SqlDbType.Int).Value = d.IdMovimiento;
                    sqlCmd.Parameters.Add("@ipnCantidad", SqlDbType.Int).Value = d.Cantidad;
                    sqlCmd.Parameters.Add("@ipnIdProductoXVehiculo", SqlDbType.Int).Value = d.IdProductoXVehiculo;
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

        #region TipoMovimiento

        public List<TipoMovimiento> selectAll_TipoMovimiento()
        {
            List<TipoMovimiento> tipoMovimientos = new List<TipoMovimiento>();
            TipoMovimiento t;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("MOVIMIENTO_TIPO_SELECT_ALL", SqlConn);
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
                    t = Utils.tipoMovimiento_parse(rows[i]);
                    tipoMovimientos.Add(t);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return tipoMovimientos;

        }

        public ResponseBD add_TipoMovimiento(TipoMovimiento t)
        {
            ResponseBD response = new ResponseBD();

            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("MOVIMIENTO_TIPO_INSERT", SqlConn);
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
                    sqlCmd.Parameters.Add("@ipsActivo", SqlDbType.Bit).Value = t.Activo;
                    sqlCmd.Parameters.Add("@ipdFechaCreacion", SqlDbType.DateTime).Value = t.FechaCreacion;
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
