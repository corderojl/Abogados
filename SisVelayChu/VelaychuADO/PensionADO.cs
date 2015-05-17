using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE; 
namespace VelaychuADO
{
    public class PensionADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTablePension_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_PensionAll";
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

        public List<PensionBE> ListPension_All()
        {
            string conexion = MiConexion.GetCnx();
            List<PensionBE> lPensionBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Listar_PensionAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lPensionBE = new List<PensionBE>();
                int posCodigoPension = drd.GetOrdinal("CodigoPension");
                int posDescripcionPension = drd.GetOrdinal("DescripcionPension");
       
                //int posactivo = drd.GetOrdinal("activo");
                PensionBE oPensionBE = null;
                while (drd.Read())
                {
                    oPensionBE = new PensionBE();
                    oPensionBE.CodigoPension = drd.GetInt32(posCodigoPension);
                    oPensionBE.DescripcionPension = drd.GetString(posDescripcionPension);
                    
                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lPensionBE.Add(oPensionBE);
                }
                drd.Close();
            }
            con.Close();
            return (lPensionBE);
        }
    }
}
