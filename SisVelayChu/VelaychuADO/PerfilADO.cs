using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE; 

namespace VelaychuADO
{
    public class PerfilADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTablePerfil_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_PerfilAll";
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

        public List<PerfilBE> ListPerfil_All()
        {
            string conexion = MiConexion.GetCnx();
            List<PerfilBE> lPerfilBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Listar_PerfilAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lPerfilBE = new List<PerfilBE>();
                int posCodigoPerfil = drd.GetOrdinal("CodigoPerfil");
                int posDescripcionPerfil = drd.GetOrdinal("DescripcionPerfil");
                int posAbreviaturaPerfil = drd.GetOrdinal("AbreviaturaPerfil");
                //int posactivo = drd.GetOrdinal("activo");
                PerfilBE oPerfilBE = null;
                while (drd.Read())
                {
                    oPerfilBE = new PerfilBE();
                    oPerfilBE.CodigoPerfil = drd.GetInt32(posCodigoPerfil);
                    oPerfilBE.DescripcionPerfil = drd.GetString(posDescripcionPerfil);
                    oPerfilBE.AbreviaturaPerfil = drd.GetString(posAbreviaturaPerfil);
                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lPerfilBE.Add(oPerfilBE);
                }
                drd.Close();
            }
            con.Close();
            return (lPerfilBE);
        }
    }
}
