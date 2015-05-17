using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE; 

namespace VelaychuADO
{
    public class JuzgadoADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableJuzgado_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_JuzgadoAll";
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

        public List<JuzgadoBE> ListJuzgado_All()
        {
            string conexion = MiConexion.GetCnx();
            List<JuzgadoBE> lJuzgadoBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Listar_JuzgadoAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lJuzgadoBE = new List<JuzgadoBE>();
                int posCodigoJuzgado = drd.GetOrdinal("CodigoJuzgado");
                int posDescripcionJuzgado = drd.GetOrdinal("DescripcionJuzgado");
         
                //int posactivo = drd.GetOrdinal("activo");
                JuzgadoBE oJuzgadoBE = null;
                while (drd.Read())
                {
                    oJuzgadoBE = new JuzgadoBE();
                    oJuzgadoBE.CodigoJuzgado = drd.GetInt32(posCodigoJuzgado);
                    oJuzgadoBE.DescripcionJuzgado = drd.GetString(posDescripcionJuzgado);

                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lJuzgadoBE.Add(oJuzgadoBE);
                }
                drd.Close();
            }
            con.Close();
            return (lJuzgadoBE);
        }
    }
}
