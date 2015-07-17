using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE;

namespace VelaychuADO
{
    public class ExpedienteClienteADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableExpedienteCliente_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_ExpedienteClienteAll";
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
        public List<ExpedienteClienteBE> ListExpedienteCliente_All()
        {
            //string conexion = MiConexion.GetCnx();
            //List<ExpedienteClienteBE> lExpedienteClienteBE = null;
            //SqlConnection con = new SqlConnection(conexion);
            //con.Open();
            //SqlCommand cmd = new SqlCommand("sp_Listar_ExpedienteClienteAll", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            //if (drd != null)
            //{
            //    lExpedienteClienteBE = new List<ExpedienteClienteBE>();
            //    int posCodigoExpedienteCliente = drd.GetOrdinal("CodigoExpedienteCliente");
            //    int posNombreAsociaccion = drd.GetOrdinal("NombreAsociaccion");
            //    //int posactivo = drd.GetOrdinal("activo");
            //    ExpedienteClienteBE oExpedienteClienteBE = null;
            //    while (drd.Read())
            //    {
            //        oExpedienteClienteBE = new ExpedienteClienteBE();
            //        oExpedienteClienteBE.CodigoExpedienteCliente = drd.GetInt32(posCodigoExpedienteCliente);
            //        oExpedienteClienteBE.NombreAsociaccion = drd.GetString(posNombreAsociaccion);
            //        //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
            //        lExpedienteClienteBE.Add(oExpedienteClienteBE);
            //    }
            //    drd.Close();
            //}
            //con.Close();
            //return (lExpedienteClienteBE);
            return null;
        }

        

        public int InsertarExpedienteCliente(ExpedienteClienteBE _ExpedienteClienteBE)
        {
            SqlParameter par1;
            int IdAcociacion = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspExpedienteClienteAdicionar";
            try
            {
                //par1 = cmd.Parameters.Add(new SqlParameter("@CodigoExpedienteCliente", SqlDbType.Int));
                //par1.Direction = ParameterDirection.Input;
                //cmd.Parameters["@CodigoExpedienteCliente"].Value = _ExpedienteClienteBE.CodigoExpedienteCliente;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoCliente", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoCliente"].Value = _ExpedienteClienteBE.CodigoCliente;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoExpediente", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoExpediente"].Value = _ExpedienteClienteBE.CodigoExpediente;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoAsociacion", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoAsociacion"].Value = _ExpedienteClienteBE.CodigoAsociacion;
                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdAcociacion = (int)par4.Value;
            }
            catch (SqlException x)
            {
                IdAcociacion = 0;
            }
            catch (Exception x)
            {
                IdAcociacion = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdAcociacion);
        }
        public int InsertarExpedienteCliente(List<ExpedienteClienteBE> ltExpedienteClienteBE)
        {
            SqlParameter par1;
            int IdAcociacion = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
           
            try
            {
                foreach (ExpedienteClienteBE _ExpedienteClienteBE in ltExpedienteClienteBE)
                {
                    cnx.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "uspExpedienteClienteAdicionar";
                    par1 = cmd.Parameters.Add(new SqlParameter("@CodigoCliente", SqlDbType.Int));
                    par1.Direction = ParameterDirection.Input;
                    cmd.Parameters["@CodigoCliente"].Value = _ExpedienteClienteBE.CodigoCliente;
                    par1 = cmd.Parameters.Add(new SqlParameter("@CodigoExpediente", SqlDbType.Int));
                    par1.Direction = ParameterDirection.Input;
                    cmd.Parameters["@CodigoExpediente"].Value = _ExpedienteClienteBE.CodigoExpediente;
                    par1 = cmd.Parameters.Add(new SqlParameter("@CodigoAsociacion", SqlDbType.Int));
                    par1.Direction = ParameterDirection.Input;
                    cmd.Parameters["@CodigoAsociacion"].Value = _ExpedienteClienteBE.CodigoAsociacion;
                    SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                    par4.Direction = ParameterDirection.ReturnValue;
                    
                    int n = cmd.ExecuteNonQuery();
                    if (n > 0) IdAcociacion = (int)par4.Value;
                    cnx.Close();
                    cmd.Parameters.Clear();
                }
            }
            catch (SqlException x)
            {
                IdAcociacion = -1;
            }
            catch (Exception x)
            {
                IdAcociacion = -1;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdAcociacion);
        }
    }
}
