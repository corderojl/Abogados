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
                int posCodigoExpedienteContrato = drd.GetOrdinal("CodigoExpedienteContrato");
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
                    oDetalleExpedienteBE.CodigoExpedienteContrato = drd.GetInt32(posCodigoExpedienteContrato);
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
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoExpedienteContrato", SqlDbType.VarChar, 150));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoExpedienteContrato"].Value = CodigoContrato;
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
        public DetalleExpedienteBE TraerExpediente(int _CodigoDetalleExpediente)
        {
            SqlDataReader dtr = default(SqlDataReader);
            DetalleExpedienteBE _DetalleExpedienteBE = new DetalleExpedienteBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspDetalleExpedienteTraer";
                cmd.Parameters.Add(new SqlParameter("@CodigoDetalleExpediente", SqlDbType.Int));
                cmd.Parameters["@CodigoDetalleExpediente"].Value = _CodigoDetalleExpediente;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _DetalleExpedienteBE;
                    _with1.CodigoDetalleExpediente = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoDetalleExpediente")));
                    _with1.CodigoExpedienteContrato = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoExpedienteContrato")));
                    _with1.CodigoEvento = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoEvento")));
                    _with1.CodigoEtapa = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoEtapa")));
                    _with1.Fecha = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("Fecha")));
                    _with1.Estado = dtr.GetValue(dtr.GetOrdinal("Estado")).ToString();
                    _with1.CodigoUsuario = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoUsuario")));
                    _with1.FechaImpulso = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaImpulso")));
                    _with1.CodigoUsuarioImpulso = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoUsuarioImpulso")));
                }
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
            return _DetalleExpedienteBE;
        }
        public int InsertarDetalleExpediente(DetalleExpedienteBE _DetalleExpedienteBE)
        {
            SqlParameter par1;
            int IdEmpleado = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspDetalleExpedienteAdicionar";
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoExpedienteContrato", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoExpedienteContrato"].Value = _DetalleExpedienteBE.CodigoExpedienteContrato;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoEvento", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoEvento"].Value = _DetalleExpedienteBE.CodigoEvento;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoEtapa", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoEtapa"].Value = _DetalleExpedienteBE.CodigoEtapa;
                par1 = cmd.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.Date));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Fecha"].Value = _DetalleExpedienteBE.Fecha;
                par1 = cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 350));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Estado"].Value = _DetalleExpedienteBE.Estado;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoUsuario", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoUsuario"].Value = _DetalleExpedienteBE.CodigoUsuario;
                par1 = cmd.Parameters.Add(new SqlParameter("@FechaImpulso", SqlDbType.Date));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@FechaImpulso"].Value = _DetalleExpedienteBE.FechaImpulso;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoUsuarioImpulso", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoUsuarioImpulso"].Value = _DetalleExpedienteBE.CodigoUsuarioImpulso;
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
        public bool ActualizarDetalleExpediente(DetalleExpedienteBE _DetalleExpedienteBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspDetalleExpedienteActualizar";
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoDetalleExpediente", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoDetalleExpediente"].Value = _DetalleExpedienteBE.CodigoDetalleExpediente;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoExpedienteContrato", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoExpedienteContrato"].Value = _DetalleExpedienteBE.CodigoExpedienteContrato;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoEvento", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoEvento"].Value = _DetalleExpedienteBE.CodigoEvento;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoEtapa", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoEtapa"].Value = _DetalleExpedienteBE.CodigoEtapa;
                par1 = cmd.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.Date));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Fecha"].Value = _DetalleExpedienteBE.Fecha;
                par1 = cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 350));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Estado"].Value = _DetalleExpedienteBE.Estado;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoUsuario", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoUsuario"].Value = _DetalleExpedienteBE.CodigoUsuario;
                par1 = cmd.Parameters.Add(new SqlParameter("@FechaImpulso", SqlDbType.Date));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@FechaImpulso"].Value = _DetalleExpedienteBE.FechaImpulso;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoUsuarioImpulso", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoUsuarioImpulso"].Value = _DetalleExpedienteBE.CodigoUsuarioImpulso;
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
