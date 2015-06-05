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
    public partial class FrmTipoClienteMan2 : Form
    {
        TipoClienteBE _TipoClienteBE = new TipoClienteBE();
        public FrmTipoClienteMan2()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            TipoClienteBL _TipoClienteBL = new TipoClienteBL();
            int _registro = -1;
            try
            {
                var _miempl = _TipoClienteBE;
                //_miempl.Emp_id = "";
                _miempl.DescripcionTipoCliente = txtDescripcionTipoCliente.Text;
                _miempl.Abreviatura = txtAbreviatura.Text;

                _registro = _TipoClienteBL.InsertarTipoCliente(_TipoClienteBE);
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
