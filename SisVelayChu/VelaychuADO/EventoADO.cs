using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE; 

namespace VelaychuADO
{
    public class EventoADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableEvento_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_EventoAll";
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

        public List<EventoBE> ListEvento_All()
        {
            string conexion = MiConexion.GetCnx();
            List<EventoBE> lEventoBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Listar_EventoAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lEventoBE = new List<EventoBE>();
                int posCodigoEvento = drd.GetOrdinal("CodigoEvento");
                int posDescripcionEvento = drd.GetOrdinal("DescripcionEvento");
                int posColorEvento = drd.GetOrdinal("ColorEvento");

                //int posactivo = drd.GetOrdinal("activo");
                EventoBE oEventoBE = null;
                while (drd.Read())
                {
                    oEventoBE = new EventoBE();
                    oEventoBE.CodigoEvento = drd.GetInt32(posCodigoEvento);
                    oEventoBE.DescripcionEvento = drd.GetString(posDescripcionEvento);
                    oEventoBE.ColorEvento = drd.GetString(posColorEvento);
                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lEventoBE.Add(oEventoBE);
                }
                drd.Close();
            }
            con.Close();
            return (lEventoBE);
        }
    }
}
