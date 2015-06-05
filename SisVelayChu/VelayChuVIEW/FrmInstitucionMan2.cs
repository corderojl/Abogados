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
    public partial class FrmInstitucionMan2 : Form
    {
        InstitucionBE _InstitucionBE = new InstitucionBE();
        public FrmInstitucionMan2()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            InstitucionBL _InstitucionBL = new InstitucionBL();
            int _registro = -1;
            try
            {
                var _miempl = _InstitucionBE;
                //_miempl.Emp_id = "";
                _miempl.DescripcionInstitucion = txtInstitucion.Text;

                _registro = _InstitucionBL.InsertarInstitucion(_InstitucionBE);
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
