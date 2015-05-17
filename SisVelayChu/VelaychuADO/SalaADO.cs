using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE; 

namespace VelaychuADO
{
    public class SalaADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableSala_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_SalaAll";
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

        public List<SalaBE> ListSala_All()
        {
            string conexion = MiConexion.GetCnx();
            List<SalaBE> lSalaBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Listar_SalaAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lSalaBE = new List<SalaBE>();
                int posCodigoSala = drd.GetOrdinal("CodigoSala");
                int posDescripcionSalas = drd.GetOrdinal("DescripcionSalas");

                //int posactivo = drd.GetOrdinal("activo");
                SalaBE oSalaBE = null;
                while (drd.Read())
                {
                    oSalaBE = new SalaBE();
                    oSalaBE.CodigoSala = drd.GetInt32(posCodigoSala);
                    oSalaBE.DescripcionSalas = drd.GetString(posDescripcionSalas);
           
                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lSalaBE.Add(oSalaBE);
                }
                drd.Close();
            }
            con.Close();
            return (lSalaBE);
        }
    }


}
