using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE; 

namespace VelaychuADO
{
    public class CargoADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableCargo_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_CargoAll";
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Sistemas");
                dtv = dts.Tables["Sistemas"].DefaultView;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return dts.Tables["Sistemas"];
        }

        public List<CargoBE> ListCargo_All()
        {
            string conexion = MiConexion.GetCnx();
            List<CargoBE> lCargoBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Listar_CargoAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lCargoBE = new List<CargoBE>();
                int posCodigoCargo = drd.GetOrdinal("CodigoCargo");
                int posDescripcionCargo = drd.GetOrdinal("DescripcionCargo");
                int posAbreviaturaCargo = drd.GetOrdinal("AbreviaturaCargo");
                //int posactivo = drd.GetOrdinal("activo");
                CargoBE oCargoBE = null;
                while (drd.Read())
                {
                    oCargoBE = new CargoBE();
                    oCargoBE.CodigoCargo = drd.GetInt32(posCodigoCargo);
                    oCargoBE.DescripcionCargo = drd.GetString(posDescripcionCargo);
                    oCargoBE.AbreviaturaCargo = drd.GetString(posAbreviaturaCargo);
                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lCargoBE.Add(oCargoBE);
                }
                drd.Close();
            }
            con.Close();
            return (lCargoBE);
        }
    }
}
