using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VelaychuBE;
using VelaychuBL;

namespace VelayChuVIEW
{
    public partial class FrmClienteMan1 : Form
    {
        ClienteBL oClienteBL = new ClienteBL();
        List<TmpClienteBE> lClienteBE;
        public FrmClienteMan1()
        {
            InitializeComponent();
        }
        public void FiltrarDatos()
        {
            string _apellidos;
            _apellidos = "%" + txtCliente.Text + "%";
            lClienteBE = oClienteBL.BuscarClienteByNombresO(_apellidos);
            dtgCliente.DataSource = lClienteBE;
            dtgCliente.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgCliente.Columns[0].Width = 40;
            //dtgUsuario.Columns[1].Width = 150;
            //dtgUsuario.Columns[8].Width = 200;
            dtgCliente.Refresh();
        }
        private bool buscarCliente(TmpClienteBE obeCliente)
        {
            return (obeCliente.NombreCompleto.ToLower().Contains(txtCliente.Text.ToLower()));
        }

        private void filtrarCliente()
        {
            Stopwatch oReloj = new Stopwatch();
            oReloj.Start();
            Predicate<TmpClienteBE> pred = new Predicate<TmpClienteBE>(buscarCliente);
            List<TmpClienteBE> lbeFiltro = lClienteBE.FindAll(pred);
            dtgCliente.DataSource = lbeFiltro;
            oReloj.Stop();
            this.Text = String.Format("Registros: {0} - Tiempo FindAll & Predicados: {1:n0} msg", lbeFiltro.Count, oReloj.Elapsed.TotalMilliseconds);
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            FrmClienteMan2 fFrmClienteMan2 = new FrmClienteMan2();
            fFrmClienteMan2.MdiParent = this.MdiParent;
            fFrmClienteMan2.Show();
            FiltrarDatos();
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            filtrarCliente();
        }

        private void FrmClienteMan1_Load(object sender, EventArgs e)
        {
            try
            {
                FiltrarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            FrmClienteMan3 fClienteMan3 = new FrmClienteMan3();
            try
            {
                fClienteMan3.Codigo = Convert.ToInt32(dtgCliente.CurrentRow.Cells[0].Value);
                fClienteMan3.MdiParent = this.MdiParent;
                fClienteMan3.Show();
                FiltrarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Selecciones un registro");
                //MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
