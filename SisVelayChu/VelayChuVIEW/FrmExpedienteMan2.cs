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
        ClienteBL _ClienteBL = new ClienteBL();
        
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
                llenarCombo();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void llenarCombo()
        {
            comboBox1.DataSource = _ClienteBL.ListarClienteO_Act();
            comboBox1.DisplayMember = "NombreCompleto";
            comboBox1.ValueMember = "CodigoCliente";

            //
            // cargo la lista de items para el autocomplete
            //
            comboBox1.AutoCompleteCustomSource = LoadAutoComplete();
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        public static AutoCompleteStringCollection LoadAutoComplete()
        {
            ClienteBL _ClienteBL=new ClienteBL();
            DataTable dt = _ClienteBL.ListarCliente_All();

            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringCol.Add(Convert.ToString(row["NombreCompleto"]));
            }

            return stringCol;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox1.SelectedValue.ToString());
        }

    }
}
