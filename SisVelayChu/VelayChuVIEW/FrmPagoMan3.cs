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
    public partial class FrmPagoMan3 : Form
    {
        PagoBL _PagoBL = new PagoBL();

        public FrmPagoMan3()
        {
            InitializeComponent();
        }
        private int _CodigoCliente;
        private int _CodigoExpediente;
        public int CodigoCliente
        {
            get { return _CodigoCliente; }
            set { _CodigoCliente = value; }
        }
        public int CodigoExpediente
        {
            get { return _CodigoExpediente; }
            set { _CodigoExpediente = value; }
        }
        private void FrmPagoMan3_Load(object sender, EventArgs e)
        {
            try
            {
                BuscarPagos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BuscarPagos()
        {
            
            dtgPago.DataSource = _PagoBL.BuscarPagoByClienteExpediente(CodigoCliente, CodigoExpediente);
            dtgPago.Columns[0].Visible = false;
            //dtgPago.Columns[1].Width = 100;
            //dtgPago.Columns[2].Width = 80;
            dtgPago.Columns[1].ReadOnly = true;
            dtgPago.Columns[2].ReadOnly = true;
            dtgPago.Columns[3].Width = 50;
            dtgPago.Columns[3].ReadOnly = false;
            dtgPago.Columns[4].Width = 50;
            dtgPago.Columns[4].ReadOnly = false;
        }
    }
}
