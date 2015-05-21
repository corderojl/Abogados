using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE; 

namespace VelaychuADO
{
    public class TipoClienteADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableTipoCliente_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_TipoClienteAll";
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

        public List<TipoClienteBE> ListTipoCliente_All()
        {
            string conexion = MiConexion.GetCnx();
            List<TipoClienteBE> lTipoClienteBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Listar_TipoClienteAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTipoClienteBE = new List<TipoClienteBE>();
                int posCodigoTipoCliente = drd.GetOrdinal("CodigoTipoCliente");
                int posDescripcionTipoCliente = drd.GetOrdinal("DescripcionTipoCliente");
                int posAbreviatura = drd.GetOrdinal("Abreviatura");
                //int posactivo = drd.GetOrdinal("activo");
                TipoClienteBE oTipoClienteBE = null;
                while (drd.Read())
                {
                    oTipoClienteBE = new TipoClienteBE();
                    oTipoClienteBE.CodigoTipoCliente = drd.GetInt32(posCodigoTipoCliente);
                    oTipoClienteBE.DescripcionTipoCliente = drd.GetString(posDescripcionTipoCliente);
                    oTipoClienteBE.Abreviatura = drd.GetString(posAbreviatura);
                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lTipoClienteBE.Add(oTipoClienteBE);
                }
                drd.Close();
            }
            con.Close();
            return (lTipoClienteBE);
        }

        public DataTable BuscarTipoClienteByDescripcion(string _descripcion)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TipoClienteBuscarByNombres";

                par1 = cmd.Parameters.Add(new SqlParameter("@DescripcionTipoCliente", SqlDbType.VarChar, 150));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@DescripcionTipoCliente"].Value = _descripcion;

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
