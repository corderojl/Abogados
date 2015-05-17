
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE;


namespace VelaychuADO
{
    public class AsociacionADO
    {
        
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableAsociacion_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_AsociacionAll";
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
        public List<AsociacionBE> ListAsociacion_All()
        {
            string conexion = MiConexion.GetCnx();
            List<AsociacionBE> lAsociacionBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Listar_AsociacionAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lAsociacionBE = new List<AsociacionBE>();
                int posCodigoAsociacion = drd.GetOrdinal("CodigoAsociacion");
                int posNombreAsociaccion = drd.GetOrdinal("NombreAsociaccion");
                //int posactivo = drd.GetOrdinal("activo");
                AsociacionBE oAsociacionBE = null;
                while (drd.Read())
                {
                    oAsociacionBE = new AsociacionBE();
                    oAsociacionBE.CodigoAsociacion = drd.GetInt32(posCodigoAsociacion);
                    oAsociacionBE.NombreAsociaccion = drd.GetString(posNombreAsociaccion);
                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lAsociacionBE.Add(oAsociacionBE);
                }
                drd.Close();
            }
            con.Close();
            return (lAsociacionBE);
           
        }


    }
}
