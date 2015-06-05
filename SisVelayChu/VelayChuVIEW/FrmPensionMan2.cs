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
    public partial class FrmPensionMan2 : Form
    {
        PensionBE _PensionBE = new PensionBE();
        public FrmPensionMan2()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            PensionBL _PensionBL = new PensionBL();
            int _registro = -1;
            try
            {
                var _miempl = _PensionBE;
                //_miempl.Emp_id = "";
                _miempl.DescripcionPension = txtPension.Text;

                _registro = _PensionBL.InsertarPension(_PensionBE);
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
