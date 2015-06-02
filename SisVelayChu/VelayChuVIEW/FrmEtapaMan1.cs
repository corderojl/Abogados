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
    public partial class FrmEtapaMan1 : Form
    {
        EtapaBL _EtapaBL = new EtapaBL();

        public FrmEtapaMan1()
        {
            InitializeComponent();
        }

        public void FiltrarDatos()
        {
            string _descripcion;

            _descripcion = "%" + txtEtapa.Text + "%";
            C.DataSource = _EtapaBL.BuscaEtapaByDescripcion(_descripcion);
            C.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgUsuario.Columns[0].Width = 40;
            //dtgUsuario.Columns[1].Width = 150;
            //dtgUsuario.Columns[8].Width = 200;
            C.Refresh();
        }

        private void txtEtapa_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void FrmEtapaMan1_Load(object sender, EventArgs e)
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

    }
}
