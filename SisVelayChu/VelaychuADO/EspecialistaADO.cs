using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE; 

namespace VelaychuADO
{
    public class EspecialistaADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableEspecialista_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_EspecialistaAll";
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

        public List<EspecialistaBE> ListEspecialista_All()
        {
            string conexion = MiConexion.GetCnx();
            List<EspecialistaBE> lEspecialistaBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Listar_EspecialistaAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lEspecialistaBE = new List<EspecialistaBE>();
                int posCodigoEspecialista = drd.GetOrdinal("CodigoEspecialista");
                int posNombreEspecialista = drd.GetOrdinal("NombreEspecialista");

                //int posactivo = drd.GetOrdinal("activo");
                EspecialistaBE oEspecialistaBE = null;
                while (drd.Read())
                {
                    oEspecialistaBE = new EspecialistaBE();
                    oEspecialistaBE.CodigoEspecialista = drd.GetInt32(posCodigoEspecialista);
                    oEspecialistaBE.NombreEspecialista = drd.GetString(posNombreEspecialista);

                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lEspecialistaBE.Add(oEspecialistaBE);
                }
                drd.Close();
            }
            con.Close();
            return (lEspecialistaBE);
        }
    }
}
