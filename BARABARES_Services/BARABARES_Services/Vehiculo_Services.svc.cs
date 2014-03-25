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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Vehiculo_Services" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Vehiculo_Services.svc or Vehiculo_Services.svc.cs at the Solution Explorer and start debugging.
    public class Vehiculo_Services : IVehiculo_Services
    {
        #region Vehiculo

        public List<Vehiculo> selectAll_Vehiculo()
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            Vehiculo v;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("VEHICULO_SELECT_ALL", SqlConn);
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
                    v = Utils.vehiculo_parse(rows[i]);
                    vehiculos.Add(v);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return vehiculos;

        }

        public List<Select.Vehiculo> list_Vehiculo()
        {
            List<Select.Vehiculo> vehiculos = new List<Select.Vehiculo>();
            Select.Vehiculo v;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("VEHICULO_LIST_SISTEMA", SqlConn);
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
                    v = Utils.select_vehiculo_parse(rows[i]);
                    vehiculos.Add(v);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return vehiculos;

        }

        public List<Select.Vehiculo> search_Vehiculo(Search.Vehiculo veh)
        {
            List<Select.Vehiculo> vehiculos = new List<Select.Vehiculo>();
            Select.Vehiculo v;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("VEHICULO_SEARCH", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsDescripcion", SqlDbType.VarChar).Value = veh.Descripcion;
                    sqlCmd.Parameters.Add("@ipsPlaca", SqlDbType.VarChar).Value = veh.Placa;
                    sqlCmd.Parameters.Add("@ipnMarca", SqlDbType.Int).Value = veh.Marca;
                    sqlCmd.Parameters.Add("@ipnModelo", SqlDbType.Int).Value = veh.Modelo;
                    sqlCmd.Parameters.Add("@ipnIdTienda", SqlDbType.Int).Value = veh.IdTienda;
                    sqlCmd.Parameters.Add("@ipbEstado", SqlDbType.Bit).Value = veh.Activo;
                    sqlCmd.Parameters.Add("@ipdDesde", SqlDbType.DateTime).Value = veh.Desde;
                    sqlCmd.Parameters.Add("@ipdHasta", SqlDbType.DateTime).Value = veh.Hasta;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    v = Utils.select_vehiculo_parse(rows[i]);
                    vehiculos.Add(v);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return vehiculos;

        }

        public ResponseBD add_Vehiculo(Vehiculo v)
        {
            ResponseBD response = new ResponseBD();

            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("VEHICULO_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipsDescripcion", SqlDbType.VarChar).Value = v.Descripcion;
                    sqlCmd.Parameters.Add("@ipsPlaca", SqlDbType.VarChar).Value = v.Placa;
                    sqlCmd.Parameters.Add("@ipnMarca", SqlDbType.Int).Value = v.Marca;
                    sqlCmd.Parameters.Add("@ipnModelo", SqlDbType.Int).Value = v.Modelo;
                    sqlCmd.Parameters.Add("@ipdFechaCreacion", SqlDbType.DateTime).Value = v.FechaCreacion;
                    sqlCmd.Parameters.Add("@ipbActivo", SqlDbType.Bit).Value = v.Activo;
                    sqlCmd.Parameters.Add("@ipnCapacidad", SqlDbType.Int).Value = v.Capacidad;
                    sqlCmd.Parameters.Add("@ipnIdTienda", SqlDbType.Int).Value = v.IdTienda;
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

        public List<Select.InventarioVehiculo> list_InventarioVehiculo()
        {
            List<Select.InventarioVehiculo> vehiculos = new List<Select.InventarioVehiculo>();
            Select.InventarioVehiculo a;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("PRODUCTO_X_VEHICULO_LIST_SISTEMA", SqlConn);
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
                    a = Utils.select_inventario_vehiculo_parse(rows[i]);
                    vehiculos.Add(a);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return vehiculos;

        }

        #endregion

        #region Marca

        public List<Select.Combo> selectAll_Marca()
        {
            List<Select.Combo> parametros = new List<Select.Combo>();
            Select.Combo p;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("VEHICULO_MARCA_SELECT_ALL", SqlConn);
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
                    p = Utils.combo_parametro_parse(rows[i]);
                    parametros.Add(p);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return parametros;

        }

        public List<Select.Combo> selectByMarca_Modelo(int id)
        {
            List<Select.Combo> parametros = new List<Select.Combo>();
            Select.Combo p;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("VEHICULO_MODELO_SELECT_BY_MARCA", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipnCodigoPadre", SqlDbType.Int).Value = id;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    p = Utils.combo_parametro_parse(rows[i]);
                    parametros.Add(p);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return parametros;

        }

        #endregion
    }
}
