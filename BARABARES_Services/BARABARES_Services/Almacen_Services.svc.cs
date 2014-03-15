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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Almacen_Services" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Almacen_Services.svc or Almacen_Services.svc.cs at the Solution Explorer and start debugging.
    public class Almacen_Services : IAlmacen_Services
    {
        #region IAlmacen_Services Members

        public List<Almacen> selectAll_Almacen()
        {
            List<Almacen> almacenes = new List<Almacen>();
            Almacen a;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("ALMACEN_SELECT_ALL", SqlConn);
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
                    a = Utils.almacen_parse(rows[i]);
                    almacenes.Add(a);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return almacenes;

        }

        public List<Select.Almacen> list_Almacen()
        {
            List<Select.Almacen> almacenes = new List<Select.Almacen>();
            Select.Almacen a;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("ALMACEN_LIST_SISTEMA", SqlConn);
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
                    a = Utils.select_almacen_parse(rows[i]);
                    almacenes.Add(a);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return almacenes;

        }

        public List<Select.Almacen> search_Almacen(Search.Almacen alm)
        {
            List<Select.Almacen> almacenes = new List<Select.Almacen>();
            Select.Almacen a;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("ALMACEN_SEARCH", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsDescripcion", SqlDbType.VarChar).Value = alm.Descripcion;
                    sqlCmd.Parameters.Add("@ipnIdDepartamento", SqlDbType.Int).Value = alm.IdDepartamento;
                    sqlCmd.Parameters.Add("@ipnIdProvincia", SqlDbType.Int).Value = alm.IdProvincia;
                    sqlCmd.Parameters.Add("@ipnIdDistrito", SqlDbType.Int).Value = alm.IdDistrito;
                    sqlCmd.Parameters.Add("@ipnIdTienda", SqlDbType.Int).Value = alm.IdTienda;
                    sqlCmd.Parameters.Add("@ipbEstado", SqlDbType.Bit).Value = alm.Activo;
                    sqlCmd.Parameters.Add("@ipdDesde", SqlDbType.DateTime).Value = alm.Desde;
                    sqlCmd.Parameters.Add("@ipdHasta", SqlDbType.DateTime).Value = alm.Hasta;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    a = Utils.select_almacen_parse(rows[i]);
                    almacenes.Add(a);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return almacenes;

        }

        public ResponseBD add_Almacen(Almacen a)
        {
            ResponseBD response = new ResponseBD();

            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("ALMACEN_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipsDescripcion", SqlDbType.VarChar).Value = a.Descripcion;
                    sqlCmd.Parameters.Add("@ipnCapacidad", SqlDbType.Int).Value = a.Capacidad;
                    sqlCmd.Parameters.Add("@ipnArea", SqlDbType.Real).Value = a.Area;
                    sqlCmd.Parameters.Add("@ipdFechaCreacion", SqlDbType.DateTime).Value = a.FechaCreacion;
                    sqlCmd.Parameters.Add("@ipbActivo", SqlDbType.Bit).Value = a.Activo;
                    sqlCmd.Parameters.Add("@ipnIdTienda", SqlDbType.Int).Value = a.IdTienda;
                    sqlCmd.Parameters.Add("@ipnIdDireccion", SqlDbType.Int).Value = a.IdDireccion;
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

        public List<Select.InventarioAlmacen> list_InventarioAlmacen()
        {
            List<Select.InventarioAlmacen> almacenes = new List<Select.InventarioAlmacen>();
            Select.InventarioAlmacen a;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("PRODUCTO_X_ALMACEN_LIST_SISTEMA", SqlConn);
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
                    a = Utils.select_inventario_almacen_parse(rows[i]);
                    almacenes.Add(a);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return almacenes;

        }

        #endregion
    }
}
