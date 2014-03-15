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
            ResponseBD response = new ResponseBD();

            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
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

        public List<Parametro> selectAll_Parametro()
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro p;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("PARAMETRO_SELECT_ALL", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[]  rows = dt.Select();
                
                for (int i = 0; i < rows.Length; i++)
                {
                    p = Utils.parametro_parse(rows[i]);
                    parametros.Add(p);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return parametros;

        }

        public List<Parametro> selectByPadre_Parametro(int id)
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro p;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("PARAMETRO_SELECT_BY_PADRE", SqlConn);
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
                    p = Utils.parametro_parse(rows[i]);
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

        #region ParametrosSeguridad

        public List<ParametrosSeguridad> selectAll_ParametrosSeguridad()
        {
            List<ParametrosSeguridad> parametros = new List<ParametrosSeguridad>();
            ParametrosSeguridad p;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("PARAMETRO_SEGURIDAD_SELECT_ALL", SqlConn);
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
                    p = Utils.parametroSeguridad_parse(rows[i]);
                    parametros.Add(p);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return parametros;

        }

        public ResponseBD add_ParametrosSeguridad(ParametrosSeguridad p)
        {
            ResponseBD response = new ResponseBD();

            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
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
