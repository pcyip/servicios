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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Rol_Services" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Rol_Services.svc or Rol_Services.svc.cs at the Solution Explorer and start debugging.
    public class Rol_Services : IRol_Services
    {
        #region Rol

        public List<Rol> selectAll_Rol()
        {
            List<Rol> roles = new List<Rol>();
            Rol r;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("ROL_SELECT_ALL", SqlConn);
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
                    r = Utils.rol_parse(rows[i]);
                    roles.Add(r);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return roles;

        }

        public Rol selectById_Rol(int id)
        {
            Rol r = new Rol();

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("ROL_SELECT_BY_ID", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipnIdRol", SqlDbType.Int).Value = id;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    r = Utils.rol_parse(rows[i]);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return r;

        }

        public ResponseBD add_Rol(Rol d)
        {
            ResponseBD response = new ResponseBD();

            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("ROL_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = d.Accion;
                    sqlCmd.Parameters.Add("@ipsDescripcion", SqlDbType.VarChar).Value = d.Descripcion;
                    sqlCmd.Parameters.Add("@ipbActivo", SqlDbType.Bit).Value = d.Activo;
                    sqlCmd.Parameters.Add("@ipdFechaCreacion", SqlDbType.DateTime).Value = d.FechaCreacion;
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

        #region RolXPerfil

        public List<RolXPerfil> selectAll_RolXPerfil()
        {
            List<RolXPerfil> rxps = new List<RolXPerfil>();
            RolXPerfil rxp;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("ROL_X_PERFIL_SELECT_ALL", SqlConn);
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
                    rxp = Utils.rolXPerfil_parse(rows[i]);
                    rxps.Add(rxp);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return rxps;

        }

        public ResponseBD add_RolXPerfil(RolXPerfil rxp)
        {
            ResponseBD response = new ResponseBD();

            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    SqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand("ROL_X_PERFIL_INSERT", SqlConn);
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

                    sqlCmd.Parameters.Add("@ipdFechaAsignacion", SqlDbType.DateTime).Value = rxp.FechaAsignacion;
                    sqlCmd.Parameters.Add("@ipnIdPerfil", SqlDbType.Int).Value = rxp.IdPerfil;
                    sqlCmd.Parameters.Add("@ipnIdRol", SqlDbType.Int).Value = rxp.IdRol;
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
