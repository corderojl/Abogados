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
    public partial class FrmUsuarioMan2 : Form
    {
        PerfilBL _PerfilBL = new PerfilBL();
        CargoBL _CargoBL = new CargoBL();
        TipoDocumentoBL _TipoDocumentoBL = new TipoDocumentoBL();

        UsuarioBE _UsuarioBE = new UsuarioBE();

        public FrmUsuarioMan2()
        {
            InitializeComponent();
        }

        private void FrmUsuarioMan2_Load(object sender, EventArgs e)
        {
            llenarComboCargo();
        }
        private void llenarComboCargo()
        {
            cboCargo.DataSource = _CargoBL.ListarCON_CargoOAct();
            cboCargo.DisplayMember = "DescripcionCargo";
            cboCargo.ValueMember = "CodigoCargo";
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            UsuarioBL _UsuarioBL = new UsuarioBL();
            int _registro = -1;
            try
            {
                var _miempl = _UsuarioBE;
                //_miempl.Emp_id = "";
                _miempl.NombreCompleto = txtNombre.Text;


                _miempl.CodigoCargo = Convert.ToInt32(cboCargo.SelectedValue);
                
                _miempl.Email = txtEmail.Text;
                _miempl.Login = txtLogin.Text;
                _registro = _UsuarioBL.InsertarUsuario(_UsuarioBE);
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
