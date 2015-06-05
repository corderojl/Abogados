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
    public partial class FrmGradoMan2 : Form
    {
        GradoBE _GradoBE = new GradoBE();
        public FrmGradoMan2()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            GradoBL _GradoBL = new GradoBL();
            int _registro = -1;
            try
            {
                var _miempl = _GradoBE;
                //_miempl.Emp_id = "";
                _miempl.DescripcionGrado = txtGrado.Text;

                _registro = _GradoBL.InsertarGrado(_GradoBE);
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
