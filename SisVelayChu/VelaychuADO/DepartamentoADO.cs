using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE; 

namespace VelaychuADO
{
    public class DepartamentoADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableDepartamento_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_DepartamentoAll";
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

        public List<DepartamentoBE> ListDepartamento_All()
        {
            string conexion = MiConexion.GetCnx();
            List<DepartamentoBE> lDepartamentoBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Listar_DepartamentoAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lDepartamentoBE = new List<DepartamentoBE>();
                int posCodigoDepartamento = drd.GetOrdinal("CodigoDepartamento");
                int posDescripciondepartamento = drd.GetOrdinal("Descripciondepartamento");

                //int posactivo = drd.GetOrdinal("activo");
                DepartamentoBE oDepartamentoBE = null;
                while (drd.Read())
                {
                    oDepartamentoBE = new DepartamentoBE();
                    oDepartamentoBE.CodigoDepartamento = drd.GetString(posCodigoDepartamento);
                    oDepartamentoBE.Descripciondepartamento = drd.GetString(posDescripciondepartamento);

                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lDepartamentoBE.Add(oDepartamentoBE);
                }
                drd.Close();
            }
            con.Close();
            return (lDepartamentoBE);
        }
    }
}
