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
    public partial class FrmAsociacionMan2 : Form
    {
        AsociacionBE _AsociacionBE = new AsociacionBE();
        public FrmAsociacionMan2()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            AsociacionBL _AsociacionBL = new AsociacionBL();
            int _registro = -1;
            try
            {
                var _miempl = _AsociacionBE;
                //_miempl.Emp_id = "";
                _miempl.NombreAsociaccion = txtAsociacion.Text;

                _registro = _AsociacionBL.InsertarAsociacion(_AsociacionBE);
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
