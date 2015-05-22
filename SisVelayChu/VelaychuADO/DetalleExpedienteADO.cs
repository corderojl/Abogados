using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE;

namespace VelaychuADO
{
    public class DetalleExpedienteADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableDetalleExpediente_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_DetalleExpedienteAll";
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

        public List<DetalleExpedienteBE> ListDetalleExpediente_All()
        {
            string conexion = MiConexion.GetCnx();
            List<DetalleExpedienteBE> lDetalleExpedienteBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Listar_DetalleExpedienteAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lDetalleExpedienteBE = new List<DetalleExpedienteBE>();
                int posCodigoDetalleExpediente = drd.GetOrdinal("CodigoDetalleExpediente");
                int posCodigoContrato = drd.GetOrdinal("CodigoContrato");
                int posCodigoEvento = drd.GetOrdinal("CodigoEvento");
                int posCodigoEtapa = drd.GetOrdinal("CodigoEtapa");
                int posFecha = drd.GetOrdinal("Fecha");
                int posEstado = drd.GetOrdinal("Estado");
                int posCodigoUsuario = drd.GetOrdinal("CodigoUsuario");
                //int posactivo = drd.GetOrdinal("activo");
                DetalleExpedienteBE oDetalleExpedienteBE = null;
                while (drd.Read())
                {
                    oDetalleExpedienteBE = new DetalleExpedienteBE();
                    oDetalleExpedienteBE.CodigoDetalleExpediente = drd.GetInt32(posCodigoDetalleExpediente);
                    oDetalleExpedienteBE.CodigoContrato = drd.GetInt32(posCodigoContrato);
                    oDetalleExpedienteBE.CodigoEvento = drd.GetInt32(posCodigoEvento);
                    oDetalleExpedienteBE.CodigoEtapa = drd.GetInt32(posCodigoEtapa);
                    oDetalleExpedienteBE.Fecha = drd.GetDateTime(posFecha);
                    oDetalleExpedienteBE.Estado = drd.GetString(posEstado);
                    oDetalleExpedienteBE.CodigoUsuario = drd.GetInt32(posCodigoUsuario);
                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lDetalleExpedienteBE.Add(oDetalleExpedienteBE);
                }
                drd.Close();
            }
            con.Close();
            return (lDetalleExpedienteBE);
        }
        public DataTable ListarDetalleExpedienteByContrato(int CodigoContrato)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspListarDetalleExpedienteByContrato";
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoContrato", SqlDbType.VarChar, 150));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoContrato"].Value = CodigoContrato;
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
