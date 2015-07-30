using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VelaychuBE;
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            List<PagoBE> ltPagoBE = new List<PagoBE>();
            PagoBE _PagoBE = null;

             foreach (DataGridViewRow row in dtgPago.Rows)
            {
                _PagoBE = new PagoBE();
                _PagoBE.CodigoPago = Convert.ToInt32(row.Cells[0].Value);
                _PagoBE.Porcentaje = float.Parse(row.Cells[3].Value.ToString());
                _PagoBE.Monto = Convert.ToDecimal(row.Cells[4].Value);
                ltPagoBE.Add(_PagoBE);
            }
            bool vexito = _PagoBL.ActualizarPago(ltPagoBE);
            if (vexito)
            {
                MessageBox.Show("La actualización se realizó con Éxito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Hubó un problema con la actualización", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
