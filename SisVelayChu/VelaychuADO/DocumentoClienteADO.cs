﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace VelaychuADO
{
    public class DocumentoClienteADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable BuscarDocumentoClienteByExpedienteContrato(int CodigoExpedienteContrato)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspDocumentoClienteBuscarByExpedienteContrato";
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoExpedienteContrato", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoExpedienteContrato"].Value = CodigoExpedienteContrato;
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
        public bool CambiarDocumentoCliente(int _CodigoDocumentoCliente, bool _Presento)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspDocumentosClienteCambiar";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@CodigoDocumentoCliente", SqlDbType.Int));
                cmd.Parameters["@CodigoDocumentoCliente"].Value = _CodigoDocumentoCliente;
                cmd.Parameters.Add(new SqlParameter("@Presento", SqlDbType.Int));
                cmd.Parameters["@Presento"].Value = _Presento;
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
