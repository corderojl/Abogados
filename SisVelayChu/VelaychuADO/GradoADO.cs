using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE; 

namespace VelaychuADO
{
    public class GradoADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableGrado_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_GradoAll";
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

        public List<GradoBE> ListGrado_All()
        {
            string conexion = MiConexion.GetCnx();
            List<GradoBE> lGradoBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Listar_GradoAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lGradoBE = new List<GradoBE>();
                int posCodigoGrado = drd.GetOrdinal("CodigoGrado");
                int posDescripcionGrado = drd.GetOrdinal("DescripcionGrado");
                
                //int posactivo = drd.GetOrdinal("activo");
                GradoBE oGradoBE = null;
                while (drd.Read())
                {
                    oGradoBE = new GradoBE();
                    oGradoBE.CodigoGrado = drd.GetInt32(posCodigoGrado);
                    oGradoBE.DescripcionGrado = drd.GetString(posDescripcionGrado);

                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lGradoBE.Add(oGradoBE);
                }
                drd.Close();
            }
            con.Close();
            return (lGradoBE);
        }

        public DataTable BuscarGradoByDescripcion(string _descripcion)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_GradoBuscarByNombres";

                par1 = cmd.Parameters.Add(new SqlParameter("@DescripcionGrado", SqlDbType.VarChar, 150));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@DescripcionGrado"].Value = _descripcion;

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
    }
}
