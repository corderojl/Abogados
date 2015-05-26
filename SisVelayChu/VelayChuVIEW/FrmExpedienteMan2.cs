using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VelaychuBE;
using VelaychuBL;

namespace VelayChuVIEW
{
    public partial class FrmExpedienteMan2 : Form
    {


        
        public FrmExpedienteMan2()
        {
            InitializeComponent();  
        }

        private void FrmExpedienteMan2_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString="Data Source=.\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=db_velaychu" ;
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "Select nombrecompleto from cliente";
                SqlCommand cmd = new SqlCommand(query,con);
                SqlDataReader dr = cmd.ExecuteReader();
                AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();

                while (dr.Read())
                {
                    mycollection.Add(dr.GetString(0));
                }
                txtNombreCliente.AutoCompleteCustomSource = mycollection;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        

        }
    }
}
