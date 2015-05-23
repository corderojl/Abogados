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
    public partial class FrmInstitucionMan1 : Form
    {
        InstitucionBL _InstitucionBL = new InstitucionBL();
        public FrmInstitucionMan1()
        {
            InitializeComponent();
        }
        public void FiltrarDatos()
        {
            string _descripcion;

            _descripcion = "%" + txtInstitucion.Text + "%";
            dtgInstitucion.DataSource = _InstitucionBL.BuscaInstitucionByDescripcion(_descripcion);
            dtgInstitucion.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgUsuario.Columns[0].Width = 40;
            //dtgUsuario.Columns[1].Width = 150;
            //dtgUsuario.Columns[8].Width = 200;
            dtgInstitucion.Refresh();
        }

        private void FrmInstitucionMan1_Load(object sender, EventArgs e)
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

        private void txtInstitucion_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }
    }
}
