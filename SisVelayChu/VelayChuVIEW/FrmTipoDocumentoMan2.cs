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
    public partial class FrmTipoDocumentoMan2 : Form
    {
        TipoDocumentoBE _TipoDocumentoBE = new TipoDocumentoBE();
        public FrmTipoDocumentoMan2()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            TipoDocumentoBL _TipoDocumentoBL = new TipoDocumentoBL();
            int _registro = -1;
            try
            {
                var _miempl = _TipoDocumentoBE;
                //_miempl.Emp_id = "";
                _miempl.DescripcionTipoDocumento = txtDescripcionTipoDocumento.Text;
                _miempl.Abreviatura = txtAbreviatura.Text;

                _registro = _TipoDocumentoBL.InsertarTipoDocumento(_TipoDocumentoBE);
                if (_registro > -1)
                {
                    MessageBox.Show("Se registro con Exito");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error, verifique los Datos");
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Se a producido el siguiente error: " + ex.Message);
            }
        }
    }
}
