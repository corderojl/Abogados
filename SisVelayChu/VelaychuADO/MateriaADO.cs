using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VelaychuBE; 

namespace VelaychuADO
{
    public class MateriaADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarDataTableMateria_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Listar_MateriaAll";
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

        public List<MateriaBE> ListMateria_All()
        {
            string conexion = MiConexion.GetCnx();
            List<MateriaBE> lMateriaBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Listar_MateriaAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lMateriaBE = new List<MateriaBE>();
                int posCodigoMateria = drd.GetOrdinal("CodigoMateria");
                int posDescripcionMateria = drd.GetOrdinal("DescripcionMateria");
                int posAbreviatura = drd.GetOrdinal("Abreviatura");
                //int posactivo = drd.GetOrdinal("activo");
                MateriaBE oMateriaBE = null;
                while (drd.Read())
                {
                    oMateriaBE = new MateriaBE();
                    oMateriaBE.CodigoMateria = drd.GetInt32(posCodigoMateria);
                    oMateriaBE.DescripcionMateria = drd.GetString(posDescripcionMateria);
                    oMateriaBE.Abreviatura = drd.GetString(posAbreviatura);
                    //obeEmpleadoBE.activo = drd.GetBoolean(posactivo);
                    lMateriaBE.Add(oMateriaBE);
                }
                drd.Close();
            }
            con.Close();
            return (lMateriaBE);
        }
    }
}
