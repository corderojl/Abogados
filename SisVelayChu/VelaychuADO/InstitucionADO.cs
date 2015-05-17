using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE; 

namespace VelaychuADO
{
    public class InstitucionADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableInstitucion_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_InstitucionAll";
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

        public List<InstitucionBE> ListInstitucion_All()
        {
            string conexion = MiConexion.GetCnx();
            List<InstitucionBE> lInstitucionBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Listar_InstitucionAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lInstitucionBE = new List<InstitucionBE>();
                int posCodigoInstitucion = drd.GetOrdinal("CodigoInstitucion");
                int posDescripcionInstitucion = drd.GetOrdinal("DescripcionInstitucion");

                //int posactivo = drd.GetOrdinal("activo");
                InstitucionBE oGradoBE = null;
                while (drd.Read())
                {
                    oGradoBE = new InstitucionBE();
                    oGradoBE.CodigoInstitucion = drd.GetInt32(posCodigoInstitucion);
                    oGradoBE.DescripcionInstitucion = drd.GetString(posDescripcionInstitucion);

                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lInstitucionBE.Add(oGradoBE);
                }
                drd.Close();
            }
            con.Close();
            return (lInstitucionBE);
        }
    }
}
