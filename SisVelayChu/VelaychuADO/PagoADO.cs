using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE;

namespace VelaychuADO
{
    public class PagoADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable BuscarPagoByClienteExpediente(int _CodigoCliente, int _CodigoExpediente)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspPagoBuscarByClienteExpediente";
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoCliente", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoCliente"].Value = _CodigoCliente;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoExpediente", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoExpediente"].Value = _CodigoExpediente;
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

        public bool ActualizarPago(PagoBE _PagoBE)
        {
            SqlParameter par1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspPagoActualizar";
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoPago", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoPago"].Value = _PagoBE.CodigoPago;
                par1 = cmd.Parameters.Add(new SqlParameter("@Porcentaje", SqlDbType.Float));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Porcentaje"].Value = _PagoBE.Porcentaje;
                par1 = cmd.Parameters.Add(new SqlParameter("@Monto", SqlDbType.Decimal));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Monto"].Value = _PagoBE.Monto;
                cnx.Open();
                cmd.ExecuteNonQuery();
                vexito = true;
            }
            catch (SqlException x)
            {
                vexito = false;
            }
            catch (Exception x)
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
        public bool ActualizarPago(List<PagoBE> ltPagoBE)
        {
            SqlParameter par1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;

            try
            {
                foreach (PagoBE _PagoBE in ltPagoBE)
                {
                    cnx.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "uspPagoActualizar";
                    par1 = cmd.Parameters.Add(new SqlParameter("@CodigoPago", SqlDbType.Int));
                    par1.Direction = ParameterDirection.Input;
                    cmd.Parameters["@CodigoPago"].Value = _PagoBE.CodigoPago;
                    par1 = cmd.Parameters.Add(new SqlParameter("@Porcentaje", SqlDbType.Float));
                    par1.Direction = ParameterDirection.Input;
                    cmd.Parameters["@Porcentaje"].Value = _PagoBE.Porcentaje;
                    par1 = cmd.Parameters.Add(new SqlParameter("@Monto", SqlDbType.Decimal));
                    par1.Direction = ParameterDirection.Input;
                    cmd.Parameters["@Monto"].Value = _PagoBE.Monto;
                    cmd.ExecuteNonQuery();
                    vexito = true;
                    cnx.Close();
                    cmd.Parameters.Clear();
                }
            }
            catch (SqlException x)
            {
                vexito = false;
            }
            catch (Exception x)
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
