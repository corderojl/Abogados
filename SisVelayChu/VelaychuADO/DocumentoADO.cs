using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE; 

namespace VelaychuADO
{
    public class DocumentoADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableDocumento_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_DocumentoAll";
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

        public List<DocumentoBE> ListDocumento_All()
        {
            string conexion = MiConexion.GetCnx();
            List<DocumentoBE> lDocumentoBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Listar_DocumentoAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lDocumentoBE = new List<DocumentoBE>();
                int posCodigoDocumento = drd.GetOrdinal("CodigoDocumento");
                int posDescripcionDocumento = drd.GetOrdinal("DescripcionDocumento");

                //int posactivo = drd.GetOrdinal("activo");
                DocumentoBE oDocumentoBE = null;
                while (drd.Read())
                {
                    oDocumentoBE = new DocumentoBE();
                    oDocumentoBE.CodigoDocumento = drd.GetInt32(posCodigoDocumento);
                    oDocumentoBE.DescripcionDocumento = drd.GetString(posDescripcionDocumento);

                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lDocumentoBE.Add(oDocumentoBE);
                }
                drd.Close();
            }
            con.Close();
            return (lDocumentoBE);
        }
        public DataTable ListarDocumentoByContrato(int CodigoContrato)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspListarDocumentoByContrato";
                par1 = cmd.Parameters.Add(new SqlParameter("@CodigoContrato", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CodigoContrato"].Value = CodigoContrato;
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
    }
}
