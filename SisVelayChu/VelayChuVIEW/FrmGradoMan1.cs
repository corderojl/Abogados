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
    public partial class FrmGradoMan1 : Form
    {
        GradoBL _GradoBL = new GradoBL();

        public FrmGradoMan1()
        {
            InitializeComponent();
        }
        public void FiltrarDatos()
        {
            string _descripcion;

            _descripcion = "%" + txtGrado.Text + "%";
            dtgGrado.DataSource = _GradoBL.BuscaGradoByDescripcion(_descripcion);
            dtgGrado.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgUsuario.Columns[0].Width = 40;
            //dtgUsuario.Columns[1].Width = 150;
            //dtgUsuario.Columns[8].Width = 200;
            dtgGrado.Refresh();
        }

        private void FrmGradoMan1_Load(object sender, EventArgs e)
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

        private void txtGrado_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            FrmGradoMan2 fFrmGradoMan2 = new FrmGradoMan2();
            fFrmGradoMan2.MdiParent = this.MdiParent;
            fFrmGradoMan2.Show();  
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            FrmGradoMan3 fFrmGradoMan3 = new FrmGradoMan3();
            fFrmGradoMan3.MdiParent = this.MdiParent;
            fFrmGradoMan3.Show();  
        }

    }
}
