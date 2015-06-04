using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VelaychuBL;

namespace VelayChuVIEW
{
    public partial class FrmExpedienteMan1 : Form
    {
        ListarExpedientesBL oListarExpedientesBL = new ListarExpedientesBL();
        public FrmExpedienteMan1()
        {
            InitializeComponent();
        }

        private void txtNumeroExpediente_TextChanged(object sender, EventArgs e)
        {
            txtNombreCliente.Text   = "";

            string _numero_expediente;
            _numero_expediente = "%" + txtNumeroExpediente.Text + "%";

            dtgExpediente.DataSource = oListarExpedientesBL.BuscarExpedienteByNumeroExpedient(_numero_expediente);
            dtgExpediente.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgExpediente.Refresh();
        }

        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {
            llenarData();
        }

        private void llenarData()
        {
            txtNumeroExpediente.Text = "";

            string _nombre_cliente;
            _nombre_cliente = "%" + txtNombreCliente.Text + "%";

            dtgExpediente.DataSource = oListarExpedientesBL.BuscarExpedienteByNombreCliente(_nombre_cliente);
            dtgExpediente.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgExpediente.Columns[1].Visible = false;

            dtgExpediente.Refresh();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmExpedienteMan3 fClienteMan3 = new FrmExpedienteMan3();
                fClienteMan3.Codigo = Convert.ToInt32(dtgExpediente.CurrentRow.Cells[0].Value);
                fClienteMan3.MdiParent = this.MdiParent;
                fClienteMan3.Show();
                llenarData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar un espediente");
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            FrmExpedienteMan2 fFrmClienteMan2 = new FrmExpedienteMan2();
            //fFrmClienteMan2.Codigo = Convert.ToInt32(dtgExpediente.CurrentRow.Cells[0].Value);
            fFrmClienteMan2.MdiParent = this.MdiParent;
            fFrmClienteMan2.Show();
           
        }

        private void FrmExpedienteMan1_Load(object sender, EventArgs e)
        {
            llenarData();
        }


    }
}
