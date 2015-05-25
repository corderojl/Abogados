using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE; 

namespace VelaychuADO
{
    public class ContratoADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableContrato_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_ContratoAll";
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

        public List<ContratoBE> ListContrato_All()
        {
            string conexion = MiConexion.GetCnx();
            List<ContratoBE> lContratoBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Listar_ContratoAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lContratoBE = new List<ContratoBE>();
                int posCodigoContrato = drd.GetOrdinal("CodigoContrato");
                int posDescripcionContrato = drd.GetOrdinal("DescripcionContrato");
                int posAbreviaturaContrato = drd.GetOrdinal("AbreviaturaContrato");
                int posPorcentaje = drd.GetOrdinal("Porcentaje");
                //int posactivo = drd.GetOrdinal("activo");
                ContratoBE oContratoBE = null;
                while (drd.Read())
                {
                    oContratoBE = new ContratoBE();
                    oContratoBE.CodigoContrato = drd.GetInt32(posCodigoContrato);
                    oContratoBE.DescripcionContrato = drd.GetString(posDescripcionContrato);
                    oContratoBE.AbreviaturaContrato = drd.GetString(posAbreviaturaContrato);
                    oContratoBE.Porcentaje = drd.GetDecimal(posPorcentaje);
                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lContratoBE.Add(oContratoBE);
                }
                drd.Close();
            }
            con.Close();
            return (lContratoBE);
        }
        public DataTable BuscarContratoByExpediente(int CodigoExpediente)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspBuscarContratoByExpediente";
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoExpediente", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoExpediente"].Value = CodigoExpediente;
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
