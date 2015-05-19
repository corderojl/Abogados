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
            txtNumeroExpediente.Text = "";

            string _nombre_cliente;
            _nombre_cliente = "%" + txtNombreCliente.Text + "%";

            dtgExpediente.DataSource = oListarExpedientesBL.BuscarExpedienteByNombreCliente(_nombre_cliente);
            dtgExpediente.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgExpediente.Refresh();
        }


    }
}
