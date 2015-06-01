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
        ClienteBE _ClienteBE = new ClienteBE();
        ClienteBL _ClienteBL = new ClienteBL();
        
        public FrmExpedienteMan2()
        {
            InitializeComponent();  
        }

        private void FrmExpedienteMan2_Load(object sender, EventArgs e)
        {
            try
            {

                llenarCombo();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void llenarCombo()
        {
            cboClientes.DataSource = _ClienteBL.ListarClienteO_Act();
            cboClientes.DisplayMember = "NombreCompleto";
            cboClientes.ValueMember = "CodigoCliente";

            //
            // cargo la lista de items para el autocomplete
            //
            cboClientes.AutoCompleteCustomSource = LoadAutoComplete();
            cboClientes.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboClientes.AutoCompleteSource = AutoCompleteSource.CustomSource;
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



        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(cboClientes.SelectedValue.ToString());

            int codigo = Convert.ToInt32(cboClientes.SelectedValue.ToString());
            _ClienteBE = _ClienteBL.TraerInformacionCliente(codigo);

            lstInformacionCliente.Items.Add("Cliente: "+_ClienteBE.NombreCompleto);
            lstInformacionCliente.Items.Add("Dirección: " + _ClienteBE.DirecccionCompleta);
            lstInformacionCliente.Items.Add("Telefono: " + _ClienteBE.TelefonoFijo);
            lstInformacionCliente.Items.Add("Celular #1: " + _ClienteBE.TelefonoCelular1);
            lstInformacionCliente.Items.Add("Celular #2: " + _ClienteBE.TelefonoCelular2);
            lstInformacionCliente.Items.Add("Asociacion: " + _ClienteBE.NombreAsociaccion);
            lstInformacionCliente.Items.Add("Grado: " + _ClienteBE.DescripcionGrado);
            lstInformacionCliente.Items.Add("Pension: " + _ClienteBE.DescripcionPension);
            lstInformacionCliente.Items.Add("Institucion: " + _ClienteBE.DescripcionInstitucion);

        }

    }
}
