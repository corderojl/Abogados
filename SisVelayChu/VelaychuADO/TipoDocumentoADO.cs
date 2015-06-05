using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE;

namespace VelaychuADO
{
    public class TipoDocumentoADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableTipoDocumento_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_TipoDocumentoAll";
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
        public List<TipoDocumentoBE> ListTipoDocumento_All()
        {

            string conexion = MiConexion.GetCnx();
            List<TipoDocumentoBE> lTipoDocumentoBE = null;
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar_TipoDocumentoAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (drd != null)
                {
                    lTipoDocumentoBE = new List<TipoDocumentoBE>();
                    int posCodigoTipoDocumento = drd.GetOrdinal("CodigoTipoDocumento");
                    int posDescripcionTipoDocumento = drd.GetOrdinal("DescripcionTipoDocumento");
                    int posAbreviatura = drd.GetOrdinal("Abreviatura");
                    //int posactivo = drd.GetOrdinal("activo");
                    TipoDocumentoBE oTipoDocumentoBE = null;
                    while (drd.Read())
                    {
                        oTipoDocumentoBE = new TipoDocumentoBE();
                        oTipoDocumentoBE.CodigoTipoDocumento = drd.GetInt32(posCodigoTipoDocumento);
                        oTipoDocumentoBE.DescripcionTipoDocumento = drd.GetString(posDescripcionTipoDocumento);
                        oTipoDocumentoBE.Abreviatura = drd.GetString(posAbreviatura);
                        //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                        lTipoDocumentoBE.Add(oTipoDocumentoBE);
                    }
                    drd.Close();
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return (lTipoDocumentoBE);
        }

        public DataTable BuscarTipoDocumentoByDescripcion(string _descripcion)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TipoDocuemntoeBuscarByNombres";

                par1 = cmd.Parameters.Add(new SqlParameter("@DescripcionTipoDocumento", SqlDbType.VarChar, 150));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@DescripcionTipoDocumento"].Value = _descripcion;

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

        public int InsertarTipoDocumento(TipoDocumentoBE _TipoDocumentoBE)
        {
            SqlParameter par1;
            int IdTipoDocumento = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspTipoDocumentoAdicionar";
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@DescripcionTipoDocumento", SqlDbType.VarChar, 150));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@DescripcionTipoDocumento"].Value = _TipoDocumentoBE.DescripcionTipoDocumento;

                par1 = cmd.Parameters.Add(new SqlParameter("@Abraviatura", SqlDbType.VarChar, 20));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Abraviatura"].Value = _TipoDocumentoBE.Abreviatura;

                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdTipoDocumento = (int)par4.Value;
            }
            catch (SqlException x)
            {
                IdTipoDocumento = 0;
            }
            catch (Exception x)
            {
                IdTipoDocumento = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdTipoDocumento);
        }
    }
}
