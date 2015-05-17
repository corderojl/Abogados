using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE; 
namespace VelaychuADO
{
    public class DistritoADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableDistrito_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_DistritoAll";
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

        public List<DistritoBE> ListDistrito_All()
        {
            string conexion = MiConexion.GetCnx();
            List<DistritoBE> lDistritoBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Listar_DepartamentoAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lDistritoBE = new List<DistritoBE>();
                int posCodigoDistrito = drd.GetOrdinal("CodigoDistrito");
                int posCodigoDepartamento = drd.GetOrdinal("CodigoDepartamento");
                int posCodigoProvincia = drd.GetOrdinal("CodigoProvincia");
                int posDescripcionDistrito = drd.GetOrdinal("DescripcionDistrito");

                //int posactivo = drd.GetOrdinal("activo");
                DistritoBE oDistritoBE = null;
                while (drd.Read())
                {
                    oDistritoBE = new DistritoBE();
                    oDistritoBE.CodigoDistrito = drd.GetString(posCodigoDistrito);
                    oDistritoBE.CodigoDepartamento = drd.GetString(posCodigoDepartamento);
                    oDistritoBE.CodigoProvincia = drd.GetString(posCodigoProvincia);
                    oDistritoBE.DescripcionDistrito = drd.GetString(posDescripcionDistrito);

                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lDistritoBE.Add(oDistritoBE);
                }
                drd.Close();
            }
            con.Close();
            return (lDistritoBE);
        }
    }
}
