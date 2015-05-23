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
    public partial class FrmAsociacionMan1 : Form
    {
        AsociacionBL _AsociacionBL = new AsociacionBL();
        public FrmAsociacionMan1()
        {
            InitializeComponent();
        }

        private void FrmAsociacionMan1_Load(object sender, EventArgs e)
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
        public void FiltrarDatos()
        {
            string _descripcion;

            _descripcion = "%" + txtAsociacion.Text + "%";
            dtgAsociacion.DataSource = _AsociacionBL.BuscarAsociacionByDescripcion(_descripcion);
            dtgAsociacion.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgUsuario.Columns[0].Width = 40;
            //dtgUsuario.Columns[1].Width = 150;
            //dtgUsuario.Columns[8].Width = 200;
            dtgAsociacion.Refresh();
        }

        private void txtAsociacion_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

    }
}
