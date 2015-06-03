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
    public partial class FrmPensionMan1 : Form
    {
        PensionBL _PensionBL = new PensionBL();

        public FrmPensionMan1()
        {
            InitializeComponent();
        }
        public void FiltrarDatos()
        {
            string _descripcion;

            _descripcion = "%" + txtPension.Text + "%";
            dtgPension.DataSource = _PensionBL.BuscaPensionByDescripcion(_descripcion);
            dtgPension.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgUsuario.Columns[0].Width = 40;
            //dtgUsuario.Columns[1].Width = 150;
            //dtgUsuario.Columns[8].Width = 200;
            dtgPension.Refresh();
        }

        private void FrmPensionMan1_Load(object sender, EventArgs e)
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

        private void txtPension_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            FrmPensionMan2 fFrmPensionMan2 = new FrmPensionMan2();
            fFrmPensionMan2.MdiParent = this.MdiParent;
            fFrmPensionMan2.Show(); 
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            FrmPensionMan3 fFrmPensionMan3 = new FrmPensionMan3();
            fFrmPensionMan3.MdiParent = this.MdiParent;
            fFrmPensionMan3.Show(); 
        }
    }
}
