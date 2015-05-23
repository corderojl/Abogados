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
    public partial class FrmTipoDocumentoMan1 : Form
    {
        TipoDocumentoBL _TipoDocumentoBL = new TipoDocumentoBL();
        public FrmTipoDocumentoMan1()
        {
            InitializeComponent();
        }
        public void FiltrarDatos()
        {
            string _descripcion;

            _descripcion = "%" + txtTipoDocumento.Text + "%";
            dgtTipoDocumento.DataSource = _TipoDocumentoBL.BuscaTipoDocumentoByDescripcion(_descripcion);
            dgtTipoDocumento.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgUsuario.Columns[0].Width = 40;
            //dtgUsuario.Columns[1].Width = 150;
            //dtgUsuario.Columns[8].Width = 200;
            dgtTipoDocumento.Refresh();
        }

        private void FrmTipoDocumentoMan1_Load(object sender, EventArgs e)
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

        private void txtTipoDocumento_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }
    }
}
