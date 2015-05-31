using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE;

namespace VelaychuADO
{
    public class ExpedienteContratoADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        
        public int InsertarExpedienteContrato(ExpedienteContratoBE _ExpedienteContratoBE)
        {
            SqlParameter par1;
            int IdEmpleado = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspExpedienteContratoAdicionar";
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoExpediente", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoExpediente"].Value = _ExpedienteContratoBE.CodigoExpediente;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoContrato", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoContrato"].Value = _ExpedienteContratoBE.CodigoContrato;

                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdEmpleado = (int)par4.Value;
            }
            catch (SqlException x)
            {
                IdEmpleado = 0;
            }
            catch (Exception x)
            {
                IdEmpleado = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdEmpleado);
        }

        public bool EliminarExpedienteContrato(int _CodigoExpedienteContrato)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspExpedienteContratoEliminar";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@CodigoExpedienteContrato", SqlDbType.Int));
                cmd.Parameters["@CodigoExpedienteContrato"].Value = _CodigoExpedienteContrato;
                cnx.Open();
                cmd.ExecuteNonQuery();
                vexito = true;

            }
            catch (SqlException x)
            {
                vexito = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }

            return vexito;
        }
    }
}
