using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE;
using System.Configuration;

namespace VelaychuADO
{
    public class ClienteADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableCliente_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_ClienteAll";
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
        public List<ClienteBE> ListCliente_All()
        {
            string conexion = MiConexion.GetCnx();
            List<ClienteBE> lClienteBE = null;
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar_ClienteAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (drd != null)
                {
                    lClienteBE = new List<ClienteBE>();
                    int posCodigoCliente = drd.GetOrdinal("CodigoCliente");
                    int posNombreCompleto = drd.GetOrdinal("NombreCompleto");
                    int posCodigoTipoDocumento = drd.GetOrdinal("CodigoTipoDocumento");
                    int posCodigoAsociacion = drd.GetOrdinal("CodigoAsociacion");
                    int posCodigoTipoCliente = drd.GetOrdinal("CodigoTipoCliente");
                    int posCodigoGrado = drd.GetOrdinal("CodigoGrado");
                    int posCodigoInstitucion = drd.GetOrdinal("CodigoInstitucion");
                    int posCodigoPension = drd.GetOrdinal("CodigoPension");
                    int posNumeroDocumento = drd.GetOrdinal("NumeroDocumento");
                    int posDirecccionCompleta = drd.GetOrdinal("DirecccionCompleta");
                    int posCodigoDepartamento = drd.GetOrdinal("CodigoDepartamento");
                    int posCodigoProvincia = drd.GetOrdinal("CodigoProvincia");
                    int posCodigoDistrito = drd.GetOrdinal("CodigoDistrito");
                    int posTelefonoFijo = drd.GetOrdinal("TelefonoFijo");
                    int posTelefonoCelular1 = drd.GetOrdinal("TelefonoCelular1");
                    int posTelefonoCelular2 = drd.GetOrdinal("TelefonoCelular2");
                    int posEmail = drd.GetOrdinal("Email");
                    int posactivo = drd.GetOrdinal("activo");
                    ClienteBE oClienteBE = null;
                    while (drd.Read())
                    {
                        oClienteBE = new ClienteBE();
                        oClienteBE.CodigoCliente = drd.GetInt32(posCodigoCliente);
                        oClienteBE.NombreCompleto = drd.GetString(posNombreCompleto);
                        oClienteBE.CodigoTipoDocumento = drd.GetInt32(posCodigoTipoDocumento);
                        oClienteBE.CodigoAsociacion = drd.GetInt32(posCodigoAsociacion);
                        oClienteBE.CodigoTipoCliente = drd.GetInt32(posCodigoTipoCliente);
                        oClienteBE.CodigoGrado = drd.GetInt32(posCodigoGrado);
                        oClienteBE.CodigoInstitucion = drd.GetInt32(posCodigoInstitucion);
                        oClienteBE.CodigoPension = drd.GetInt32(posCodigoPension);
                        oClienteBE.NumeroDocumento = drd.GetString(posNumeroDocumento);
                        oClienteBE.DirecccionCompleta = drd.GetString(posDirecccionCompleta);
                        oClienteBE.CodigoDepartamento = drd.GetString(posCodigoDepartamento);
                        oClienteBE.CodigoProvincia = drd.GetString(posCodigoProvincia);
                        oClienteBE.CodigoDistrito = drd.GetString(posCodigoDistrito);
                        oClienteBE.TelefonoFijo = drd.GetString(posTelefonoFijo);
                        oClienteBE.TelefonoCelular1 = drd.GetString(posTelefonoCelular1);
                        oClienteBE.TelefonoCelular2 = drd.GetString(posTelefonoCelular2);
                        oClienteBE.Email = drd.GetString(posEmail);
                        oClienteBE.Activo = drd.GetBoolean(posactivo);
                        lClienteBE.Add(oClienteBE);
                    }
                    drd.Close();
                    con.Close();
                }
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex)
            {

            }
            return (lClienteBE);
        }


        public DataTable BuscarClienyeByNombres(string _nombresCompletos)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ClienteBuscarByNombres";

                par1 = cmd.Parameters.Add(new SqlParameter("@NombreCompleto", SqlDbType.VarChar, 150));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@NombreCompleto"].Value = _nombresCompletos;

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

        public int InsertarCliente(ClienteBE _ClienteBE)
        {
            SqlParameter par1;
            int CodigoCliente = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspClienteAdicionar";
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@NombreCompleto", SqlDbType.VarChar, 150));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@NombreCompleto"].Value = _ClienteBE.NombreCompleto;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoTipoDocumento", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoTipoDocumento"].Value = _ClienteBE.CodigoTipoDocumento;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoAsociacion", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoAsociacion"].Value = _ClienteBE.CodigoAsociacion;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoTipoCliente", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoTipoCliente"].Value = _ClienteBE.CodigoTipoCliente;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoGrado", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoGrado"].Value = _ClienteBE.CodigoGrado;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoInstitucion", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoInstitucion"].Value = _ClienteBE.CodigoInstitucion;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoPension", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoPension"].Value = _ClienteBE.CodigoPension;
                par1 = cmd.Parameters.Add(new SqlParameter("@NumeroDocumento", SqlDbType.VarChar, 50));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@NumeroDocumento"].Value = _ClienteBE.NumeroDocumento;
                par1 = cmd.Parameters.Add(new SqlParameter("@DirecccionCompleta", SqlDbType.VarChar, 350));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@DirecccionCompleta"].Value = _ClienteBE.DirecccionCompleta;
                //par1 = cmd.Parameters.Add(new SqlParameter("@CodigoDepartamento", SqlDbType.VarChar, 3));
                //par1.Direction = ParameterDirection.Input;
                //cmd.Parameters["@CodigoDepartamento"].Value = _ClienteBE.CodigoDepartamento;
                //par1 = cmd.Parameters.Add(new SqlParameter("@CodigoProvincia", SqlDbType.VarChar, 3));
                //par1.Direction = ParameterDirection.Input;
                //cmd.Parameters["@CodigoProvincia"].Value = _ClienteBE.CodigoProvincia;
                //par1 = cmd.Parameters.Add(new SqlParameter("@CodigoDistrito", SqlDbType.VarChar, 3));
                //par1.Direction = ParameterDirection.Input;
                //cmd.Parameters["@CodigoDistrito"].Value = _ClienteBE.CodigoDistrito;
                par1 = cmd.Parameters.Add(new SqlParameter("@TelefonoFijo", SqlDbType.VarChar, 20));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@TelefonoFijo"].Value = _ClienteBE.TelefonoFijo;
                par1 = cmd.Parameters.Add(new SqlParameter("@TelefonoCelular1", SqlDbType.VarChar, 20));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@TelefonoCelular1"].Value = _ClienteBE.TelefonoCelular1;
                par1 = cmd.Parameters.Add(new SqlParameter("@TelefonoCelular2", SqlDbType.VarChar, 20));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@TelefonoCelular2"].Value = _ClienteBE.TelefonoCelular2;
                par1 = cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 50));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Email"].Value = _ClienteBE.Email;

                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) CodigoCliente = (int)par4.Value;
            }
            catch (SqlException x)
            {
                CodigoCliente = 0;
            }
            catch (Exception x)
            {
                CodigoCliente = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (CodigoCliente);
        }
        public bool DeshabilitarCliente(int _vcod)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspClienteStatus";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@vcod", SqlDbType.Int));
                cmd.Parameters["@vcod"].Value = _vcod;
                cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.Bit));
                cmd.Parameters["@status"].Value = 0;
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
        public bool HabilitarCliente(int _vcod)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspClienteStatus";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@vcod", SqlDbType.Int));
                cmd.Parameters["@vcod"].Value = _vcod;
                cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.Int));
                cmd.Parameters["@status"].Value = 1;
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
        public ClienteBE TraerCliente(int _Cliente_id)
        {
            SqlDataReader dtr = default(SqlDataReader);
            ClienteBE _ClienteBE = new ClienteBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspClienteTraer";
                cmd.Parameters.Add(new SqlParameter("@CodigoCliente", SqlDbType.Int));
                cmd.Parameters["@CodigoCliente"].Value = _Cliente_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _ClienteBE;
                    _with1.CodigoCliente = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("CodigoCliente")));
                    _with1.NombreCompleto = dtr.GetValue(dtr.GetOrdinal("NombreCompleto")).ToString();
                    _with1.CodigoTipoDocumento = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoTipoDocumento")));
                    _with1.CodigoAsociacion = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoAsociacion")));
                    _with1.CodigoTipoCliente = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoTipoCliente")));
                    _with1.CodigoGrado = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoGrado")));
                    _with1.CodigoInstitucion = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoInstitucion")));
                    _with1.CodigoPension = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoPension")));
                    _with1.NumeroDocumento = dtr.GetValue(dtr.GetOrdinal("NumeroDocumento")).ToString();
                    _with1.DirecccionCompleta = dtr.GetValue(dtr.GetOrdinal("DirecccionCompleta")).ToString();
                    _with1.CodigoDepartamento = (dtr.GetValue(dtr.GetOrdinal("CodigoDepartamento"))).ToString();
                    _with1.CodigoProvincia = (dtr.GetValue(dtr.GetOrdinal("CodigoProvincia"))).ToString();
                    _with1.CodigoDistrito = (dtr.GetValue(dtr.GetOrdinal("CodigoDistrito"))).ToString();
                    _with1.TelefonoFijo = dtr.GetValue(dtr.GetOrdinal("TelefonoFijo")).ToString();
                    _with1.TelefonoCelular1 = dtr.GetValue(dtr.GetOrdinal("TelefonoCelular1")).ToString();
                    _with1.TelefonoCelular1 = dtr.GetValue(dtr.GetOrdinal("TelefonoCelular1")).ToString();
                    _with1.Email = dtr.GetValue(dtr.GetOrdinal("Email")).ToString();
                    _with1.Activo = Convert.ToBoolean(dtr.GetValue(dtr.GetOrdinal("Activo")));
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
            return _ClienteBE;
        }


        public ClienteBE TraerInformacionCliente(int _Cliente_id)
        {
            SqlDataReader dtr = default(SqlDataReader);
            ClienteBE _ClienteBE = new ClienteBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspClienteTraerInformacion";
                cmd.Parameters.Add(new SqlParameter("@CodigoCliente", SqlDbType.Int));
                cmd.Parameters["@CodigoCliente"].Value = _Cliente_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _ClienteBE;
                    _with1.CodigoCliente = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("CodigoCliente")));
                    _with1.NombreCompleto = dtr.GetValue(dtr.GetOrdinal("NombreCompleto")).ToString();

                    _with1.NombreAsociaccion = dtr.GetValue(dtr.GetOrdinal("NombreAsociaccion")).ToString();
                    _with1.DescripcionGrado = dtr.GetValue(dtr.GetOrdinal("DescripcionGrado")).ToString();
                    _with1.DescripcionPension = dtr.GetValue(dtr.GetOrdinal("DescripcionPension")).ToString();
                    _with1.DescripcionInstitucion = dtr.GetValue(dtr.GetOrdinal("DescripcionInstitucion")).ToString();


                    _with1.DirecccionCompleta = dtr.GetValue(dtr.GetOrdinal("DirecccionCompleta")).ToString();
                    //_with1.CodigoDepartamento = (dtr.GetValue(dtr.GetOrdinal("CodigoDepartamento"))).ToString();
                    //_with1.CodigoProvincia = (dtr.GetValue(dtr.GetOrdinal("CodigoProvincia"))).ToString();
                    //_with1.CodigoDistrito = (dtr.GetValue(dtr.GetOrdinal("CodigoDistrito"))).ToString();
                    _with1.TelefonoFijo = dtr.GetValue(dtr.GetOrdinal("TelefonoFijo")).ToString();
                    _with1.TelefonoCelular1 = dtr.GetValue(dtr.GetOrdinal("TelefonoCelular1")).ToString();
                    _with1.TelefonoCelular1 = dtr.GetValue(dtr.GetOrdinal("TelefonoCelular1")).ToString();
                    //_with1.Email = dtr.GetValue(dtr.GetOrdinal("Email")).ToString();
                    //_with1.Activo = Convert.ToBoolean(dtr.GetValue(dtr.GetOrdinal("Activo")));
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
            return _ClienteBE;
        }
    }
}
