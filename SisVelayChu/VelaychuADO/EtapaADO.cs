using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE; 
using System.Text;

namespace VelaychuADO
{
    public class EtapaADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableEtapa_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_EtapaAll";
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

        public List<EtapaBE> ListEtapaOBJ()
        {
            string conexion = MiConexion.GetCnx();
            List<EtapaBE> lEtapaBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Listar_EtapaAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lEtapaBE = new List<EtapaBE>();
                int posCodigoEtapa = drd.GetOrdinal("CodigoEtapa");
                int posDescripcionEtapa = drd.GetOrdinal("DescripcionEtapa");
                int posOrden = drd.GetOrdinal("Orden");
                //int posactivo = drd.GetOrdinal("activo");
                EtapaBE oEtapaBE = null;
                while (drd.Read())
                {
                    oEtapaBE = new EtapaBE();
                    oEtapaBE.CodigoEtapa = drd.GetInt32(posCodigoEtapa);
                    oEtapaBE.DescripcionEtapa = drd.GetString(posDescripcionEtapa);
                    oEtapaBE.Orden = drd.GetString(posOrden);
                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lEtapaBE.Add(oEtapaBE);
                }
                drd.Close();
            }
            con.Close();
            return (lEtapaBE);
        }

        public DataTable BuscarEtapaByDescripcion(string _descripcion)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_EtapaBuscarByNombres";

                par1 = cmd.Parameters.Add(new SqlParameter("@DescripcionEtapa", SqlDbType.VarChar, 150));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@DescripcionEtapa"].Value = _descripcion;

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
