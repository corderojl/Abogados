using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE;

namespace VelaychuADO
{
    public class TmpAlertaADO
    {
        ConexionADO MiConexion = new ConexionADO();

        public List<TmpAlertaBE> TraerAlerta()
        {
            string conexion = MiConexion.GetCnx();
            List<TmpAlertaBE> lTmpAlertaBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("uspListarEmailImpulso", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTmpAlertaBE = new List<TmpAlertaBE>();
                int posCodigoDetalleExpediente = drd.GetOrdinal("CodigoDetalleExpediente");
                int posCodigoExpediente = drd.GetOrdinal("CodigoExpediente");
                int posCodigoExpedienteContrato = drd.GetOrdinal("CodigoExpedienteContrato");
                int posCodigoEvento = drd.GetOrdinal("CodigoEvento");
                int posCodigoEtapa = drd.GetOrdinal("CodigoEtapa");
                int posFecha = drd.GetOrdinal("Fecha");
                int posEstado = drd.GetOrdinal("Estado");
                int posCodigoUsuario = drd.GetOrdinal("CodigoUsuario");
                int posNombreCompletoAbogado = drd.GetOrdinal("NombreCompletoAbogado");
                int posEmail = drd.GetOrdinal("Email");
                int posFechaImpulso = drd.GetOrdinal("FechaImpulso");
                int posDiasAlerta = drd.GetOrdinal("DiasAlerta");
                int posCodigoCliente = drd.GetOrdinal("CodigoCliente");
                int posNombreCompletoCliente = drd.GetOrdinal("NombreCompletoCliente");
                //int posactivo = drd.GetOrdinal("activo");
                TmpAlertaBE oTmpAlertaBE = null;
                while (drd.Read())
                {
                    oTmpAlertaBE = new TmpAlertaBE();
                    oTmpAlertaBE.CodigoDetalleExpediente = drd.GetInt32(posCodigoDetalleExpediente);
                    oTmpAlertaBE.CodigoExpediente = drd.GetInt32(posCodigoExpediente);
                    oTmpAlertaBE.CodigoExpedienteContrato = drd.GetInt32(posCodigoExpedienteContrato);
                    oTmpAlertaBE.CodigoEvento = drd.GetInt32(posCodigoEvento);
                    oTmpAlertaBE.CodigoEtapa = drd.GetInt32(posCodigoEtapa);
                    oTmpAlertaBE.Fecha = drd.GetDateTime(posFecha);
                    oTmpAlertaBE.Estado = drd.GetString(posEstado);
                    oTmpAlertaBE.CodigoUsuario = drd.GetInt32(posCodigoUsuario);
                    oTmpAlertaBE.NombreCompletoAbogado = drd.GetString(posNombreCompletoAbogado);
                    oTmpAlertaBE.Email = drd.GetString(posEmail);
                    oTmpAlertaBE.FechaImpulso = drd.GetDateTime(posFechaImpulso);
                    oTmpAlertaBE.DiasAlerta = drd.GetInt32(posDiasAlerta);
                    oTmpAlertaBE.CodigoCliente = drd.GetInt32(posCodigoCliente);
                    oTmpAlertaBE.NombreCompletoCliente = drd.GetString(posNombreCompletoCliente);

                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lTmpAlertaBE.Add(oTmpAlertaBE);
                }
                drd.Close();
            }
            con.Close();
            return (lTmpAlertaBE);
        }
    }
}
