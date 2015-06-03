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
    public partial class FrmTipoClienteMan1 : Form
    {
        TipoClienteBL _TipoClienteBL = new TipoClienteBL();
        public FrmTipoClienteMan1()
        {
            InitializeComponent();
        }
        public void FiltrarDatos()
        {
            string _descripcion;

            _descripcion = "%" + txtTipoCliente.Text + "%";
            dgtTipoCliente.DataSource = _TipoClienteBL.BuscaTipoClienteByDescripcion(_descripcion);
            dgtTipoCliente.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgUsuario.Columns[0].Width = 40;
            //dtgUsuario.Columns[1].Width = 150;
            //dtgUsuario.Columns[8].Width = 200;
            dgtTipoCliente.Refresh();
        }

        private void FrmTipoClienteMan1_Load(object sender, EventArgs e)
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

        private void txtTipoCliente_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            FrmTipoClienteMan2 fFrmTipoClienteMan2 = new FrmTipoClienteMan2();
            fFrmTipoClienteMan2.MdiParent = this.MdiParent;
            fFrmTipoClienteMan2.Show(); 
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            FrmTipoClienteMan3 fFrmTipoClienteMan3 = new FrmTipoClienteMan3();
            fFrmTipoClienteMan3.MdiParent = this.MdiParent;
            fFrmTipoClienteMan3.Show(); 
        }
    }
}
