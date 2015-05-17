using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE; 

namespace VelaychuADO
{
    public class EstadosImpulsosADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableEstadosImpulsos_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_EstadosImpulsosAll";
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

        public List<EstadosImpulsosBE> ListEstadosImpulso_All()
        {
            string conexion = MiConexion.GetCnx();
            List<EstadosImpulsosBE> lEstadosImpulsosBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Listar_EstadosImpulsosAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lEstadosImpulsosBE = new List<EstadosImpulsosBE>();
                int posCodigoEstadosImpulsos = drd.GetOrdinal("CodigoEstadosImpulsos");
                int posDescripcionEstados = drd.GetOrdinal("DescripcionEstados");

                //int posactivo = drd.GetOrdinal("activo");
                EstadosImpulsosBE oEstadosImpulsosBE = null;
                while (drd.Read())
                {
                    oEstadosImpulsosBE = new EstadosImpulsosBE();
                    oEstadosImpulsosBE.CodigoEstadosImpulsos = drd.GetInt32(posCodigoEstadosImpulsos);
                    oEstadosImpulsosBE.DescripcionEstados = drd.GetString(posDescripcionEstados);

                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lEstadosImpulsosBE.Add(oEstadosImpulsosBE);
                }
                drd.Close();
            }
            con.Close();
            return (lEstadosImpulsosBE);
        }
    }
}
