using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE;

namespace VelaychuADO
{
    public class UsuarioADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;
        Boolean _vcod = false;

        public DataTable ListarUsuario_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarUsuario_All";
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
        public List<UsuarioBE> ListarUsuarioO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<UsuarioBE> lUsuarioBE = null;
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarUsuario_Act", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (drd != null)
                {
                    lUsuarioBE = new List<UsuarioBE>();

                    UsuarioBE obeUsuarioBE = null;
                    while (drd.Read())
                    {
                        ReadSingleRow((IDataRecord)drd);
                        obeUsuarioBE = new UsuarioBE();
                        obeUsuarioBE.CodigoCargo = Convert.ToInt32(drd[0]);
                        obeUsuarioBE.NombreCompleto = drd[1].ToString();
       
                        obeUsuarioBE.CodigoTipoDocumento = Convert.ToInt32(drd[4]);
                        obeUsuarioBE.NumeroDocumento = drd[5].ToString();
                        obeUsuarioBE.Email = drd[6].ToString();
                        obeUsuarioBE.CodigoCargo = Convert.ToInt32(drd[7]);
                        obeUsuarioBE.CodigoPerfil = Convert.ToInt32(drd[8]);
                        obeUsuarioBE.Activo = Convert.ToBoolean(drd[9]);
                        lUsuarioBE.Add(obeUsuarioBE);
                    }
                    drd.Close();
                }
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex)
            {

            }
            return (lUsuarioBE);
        }
        private static void ReadSingleRow(IDataRecord record)
        {
            Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
        }
        public DataTable ListarUsuario_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarUsuario_Act";
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
        public bool DeshabilitarUsuario(int _vcod)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspUsuarioStatus";

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
        public bool HabilitarUsuario(int _vcod)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspUsuarioStatus";

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
        public DataTable BuscarUsuarioByNombre(string vnom)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_BuscarUsuarioByNombre";
                //Agregamos el parametro para el SP
                cmd.Parameters.Add(new SqlParameter("@texto", SqlDbType.VarChar, 200));
                cmd.Parameters["@texto"].Value = vnom;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Turno");
                dtv = dts.Tables["Turno"].DefaultView;
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
            return dts.Tables["Turno"];
        }
        public UsuarioBE LoguearUsuario(string vusuario, string vpass)
        {
            SqlDataReader dtr = default(SqlDataReader);
            UsuarioBE _UsuarioBE = new UsuarioBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_LoguearUsuario";
                cmd.Parameters.Add(new SqlParameter("@vusuario", SqlDbType.VarChar, 20));
                cmd.Parameters["@vusuario"].Value = vusuario;
                cmd.Parameters.Add(new SqlParameter("@vpass", SqlDbType.VarChar, 20));
                cmd.Parameters["@vpass"].Value = vpass;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _UsuarioBE;
                    _with1.CodigoUsuario = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Usuario_Id")));
                    _with1.NombreCompleto = dtr.GetValue(dtr.GetOrdinal("Usuario_Nome")).ToString();

                    _with1.Email = dtr.GetValue(dtr.GetOrdinal("ApellidoMaterno")).ToString();
                    _with1.CodigoPerfil = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoPerfil")));
                    _with1.CodigoCargo = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoCargo")));
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
            return _UsuarioBE;
        }
        public UsuarioBE TraerUsuario(int _Usuario_id)
        {
            SqlDataReader dtr = default(SqlDataReader);
            UsuarioBE _UsuarioBE = new UsuarioBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspUsuarioTraer";
                cmd.Parameters.Add(new SqlParameter("@CodigoUsuario", SqlDbType.Int));
                cmd.Parameters["@CodigoUsuario"].Value = _Usuario_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _UsuarioBE;
                    _with1.CodigoUsuario = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("CodigoUsuario")));
                    _with1.NombreCompleto = dtr.GetValue(dtr.GetOrdinal("NombreCompleto")).ToString();

                    _with1.CodigoTipoDocumento = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoTipoDocumento")));
                    _with1.NumeroDocumento = dtr.GetValue(dtr.GetOrdinal("NumeroDocumento")).ToString();
                    _with1.Email = dtr.GetValue(dtr.GetOrdinal("Email")).ToString();
                    _with1.Login = dtr.GetValue(dtr.GetOrdinal("Login")).ToString();
                    _with1.CodigoCargo = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoCargo")));
                    _with1.CodigoPerfil = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("CodigoPerfil")));
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
            return _UsuarioBE;
        }

        public DataTable BuscarUsuarioByNombres(string _nombres)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspUsuarioBuscarByNombres";

                par1 = cmd.Parameters.Add(new SqlParameter("@NombreCompleto", SqlDbType.VarChar, 30));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@NombreCompleto"].Value = _nombres;

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

        public int InsertarUsuario(UsuarioBE _UsuarioBE)
        {
            SqlParameter par1;
            int IdEmpleado = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspUsuarioAdicionar";
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 150));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Nombre"].Value = _UsuarioBE.NombreCompleto;

                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoTipoDocumento", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoTipoDocumento"].Value = _UsuarioBE.CodigoTipoDocumento;
                par1 = cmd.Parameters.Add(new SqlParameter("@NumeroDocumento", SqlDbType.VarChar, 50));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@NumeroDocumento"].Value = _UsuarioBE.NumeroDocumento;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoCargo", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoCargo"].Value = _UsuarioBE.CodigoCargo;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoPerfil", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoPerfil"].Value = _UsuarioBE.CodigoPerfil;
                par1 = cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 50));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Email"].Value = _UsuarioBE.Email;
                par1 = cmd.Parameters.Add(new SqlParameter("@Login", SqlDbType.VarChar, 50));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Login"].Value = _UsuarioBE.Login;
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
        public bool ActualizarUsuario(UsuarioBE _UsuarioBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspUsuarioActualizar";
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoUsuario", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoUsuario"].Value = _UsuarioBE.CodigoUsuario;

                par1 = cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 150));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Nombre"].Value = _UsuarioBE.NombreCompleto;

                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoTipoDocumento", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoTipoDocumento"].Value = _UsuarioBE.CodigoTipoDocumento;

                par1 = cmd.Parameters.Add(new SqlParameter("@NumeroDocumento", SqlDbType.VarChar, 50));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@NumeroDocumento"].Value = _UsuarioBE.NumeroDocumento;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoCargo", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoCargo"].Value = _UsuarioBE.CodigoCargo;
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoPerfil", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoPerfil"].Value = _UsuarioBE.CodigoPerfil;
                par1 = cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 50));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Email"].Value = _UsuarioBE.Email;
                par1 = cmd.Parameters.Add(new SqlParameter("@Login", SqlDbType.VarChar, 50));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Login"].Value = _UsuarioBE.Login;
                cnx.Open();
                cmd.ExecuteNonQuery();
                _vcod = true;

            }
            catch (SqlException x)
            {
                _vcod = false;
            }
            catch (Exception x)
            {
                _vcod = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }

            return _vcod;

        }
    }
}
