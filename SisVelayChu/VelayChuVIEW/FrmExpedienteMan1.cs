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
        }

        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {
            txtNumeroExpediente.Text = "";
        }
    }
}
