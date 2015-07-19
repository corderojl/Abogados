using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE;

namespace VelaychuADO
{
    public class ExpedienteADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableExpediente_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_ExpedientesAll";
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

        public List<ExpedientesBE> ListExpediente_All()
        {
            string conexion = MiConexion.GetCnx();
            List<ExpedientesBE> lExpedientesBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Listar_ExpedientesAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lExpedientesBE = new List<ExpedientesBE>();
                int posCodigoExpediente = drd.GetOrdinal("CodigoExpediente");
                int posNumeroExpediente = drd.GetOrdinal("NumeroExpediente");
                int posFechaRegistro = drd.GetOrdinal("FechaRegistro");
                int posCodigoContrato = drd.GetOrdinal("CodigoContrato");
                int posCodigoCliente = drd.GetOrdinal("CodigoCliente");
                int posCodigoMateria = drd.GetOrdinal("CodigoMateria");
                int posCodigoJuzgado = drd.GetOrdinal("CodigoJuzgado");
                int posCodigoEspecialista = drd.GetOrdinal("CodigoEspecialista");
                int posCodigoSala = drd.GetOrdinal("CodigoSala");

                //int posactivo = drd.GetOrdinal("activo");
                ExpedientesBE oExpedientesBE = null;
                while (drd.Read())
                {
                    oExpedientesBE = new ExpedientesBE();
                    oExpedientesBE.CodigoExpediente = drd.GetInt32(posCodigoExpediente);
                    oExpedientesBE.NumeroExpediente = drd.GetString(posNumeroExpediente);
                    oExpedientesBE.FechaRegistro = Convert.ToDateTime(drd.GetValue(posFechaRegistro));
                    oExpedientesBE.CodigoContrato = drd.GetInt32(posCodigoContrato);
                    oExpedientesBE.CodigoCliente = drd.GetInt32(posCodigoCliente);
                    oExpedientesBE.CodigoMateria = drd.GetInt32(posCodigoMateria);
                    oExpedientesBE.CodigoJuzgado = drd.GetInt32(posCodigoJuzgado);
                    oExpedientesBE.CodigoEspecialista = drd.GetInt32(posCodigoEspecialista);
                    oExpedientesBE.CodigoSala = drd.GetInt32(posCodigoSala);
                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lExpedientesBE.Add(oExpedientesBE);
                }
                drd.Close();
            }
            con.Close();
            return (lExpedientesBE);
        }
        public DataTable BuscarExpedienteByCliente(int _CodigoCliente)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspExpedienteBuscarByCliente";
                cmd.Parameters.Add(new SqlParameter("@CodigoCliente", SqlDbType.Int));
                cmd.Parameters["@CodigoCliente"].Value = _CodigoCliente;
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

        public ExpedientesBE TraerExpediente(int _CodigoExpediente)
        {
            SqlDataReader dtr = default(SqlDataReader);
            ExpedientesBE _ExpedientesBE = new ExpedientesBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspExpedienteTraer";
                cmd.Parameters.Add(new SqlParameter("@CodigoExpediente", SqlDbType.Int));
                cmd.Parameters["@CodigoExpediente"].Value = _CodigoExpediente;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _ExpedientesBE;
                    _with1.CodigoExpediente = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoExpediente")));
                    _with1.NumeroExpediente = dtr.GetValue(dtr.GetOrdinal("NumeroExpediente")).ToString();
                    _with1.FechaRegistro = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaRegistro")));
                    _with1.CodigoMateria = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoMateria")));
                    _with1.CodigoJuzgado = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoJuzgado")));
                    _with1.CodigoEspecialista = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoEspecialista")));
                    _with1.CodigoSala = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoSala")));

                    _with1.Activo = Convert.ToBoolean(dtr.GetValue(dtr.GetOrdinal("Activo")));
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
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
            return _ExpedientesBE;
        }
        public int InsertarExpedientes(ExpedientesBE _ExpedientesBE)
        {
            SqlParameter par1;
            int IdEmpleado = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspExpedienteAdicionar";
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@NumeroExpediente", SqlDbType.VarChar, 50));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@NumeroExpediente"].Value = _ExpedientesBE.NumeroExpediente;
                par1 = cmd.Parameters.Add(new SqlParameter("@FechaRegistro", SqlDbType.Date));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@FechaRegistro"].Value = _ExpedientesBE.FechaRegistro;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoJuzgado", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoJuzgado"].Value = _ExpedientesBE.CodigoJuzgado;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoEspecialista", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoEspecialista"].Value = _ExpedientesBE.CodigoEspecialista;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoSala", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoSala"].Value = _ExpedientesBE.CodigoSala;

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
        public bool ActualizarExpedientes(ExpedientesBE _ExpedientesBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspExpedienteActualizar";
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoExpediente", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoExpediente"].Value = _ExpedientesBE.CodigoExpediente;
                par1 = cmd.Parameters.Add(new SqlParameter("@NumeroExpediente", SqlDbType.VarChar, 50));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@NumeroExpediente"].Value = _ExpedientesBE.NumeroExpediente;
                par1 = cmd.Parameters.Add(new SqlParameter("@FechaRegistro", SqlDbType.Date));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@FechaRegistro"].Value = _ExpedientesBE.FechaRegistro;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoJuzgado", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoJuzgado"].Value = _ExpedientesBE.CodigoJuzgado;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoEspecialista", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoEspecialista"].Value = _ExpedientesBE.CodigoEspecialista;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoSala", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoSala"].Value = _ExpedientesBE.CodigoSala;
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
    }
}
