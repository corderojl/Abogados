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
    public partial class FrmUsuarioMan3 : Form
    {
        UsuarioBE _UsuarioBE = new UsuarioBE();
        UsuarioBL _UsuarioBL = new UsuarioBL();
        TipoDocumentoBL _TipoDocumentoBL = new TipoDocumentoBL();
        PerfilBL _PerfilBL = new PerfilBL();
        CargoBL _CargoBL = new CargoBL();

        public FrmUsuarioMan3()
        {
            InitializeComponent();
        }
        private int _codigo;
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private void FrmUsuarioMan3_Load(object sender, EventArgs e)
        {
            try
            {
                _UsuarioBE = _UsuarioBL.TraerFnc_Usuario(_codigo);
                txtNombre.Text = _UsuarioBE.NombreCompleto;
                lblCodigoUsuario.Text = _UsuarioBE.CodigoUsuario.ToString();

                
                txtEmail.Text = _UsuarioBE.Email;
                txtLogin.Text = _UsuarioBE.Login;
                
                llenarComboCargo(_UsuarioBE.CodigoCargo);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void llenarComboCargo(int CodigoCargo)
        {
            cboCargo.DataSource = _CargoBL.ListarCON_CargoOAct();
            cboCargo.DisplayMember = "DescripcionCargo";
            cboCargo.ValueMember = "CodigoCargo";
            cboCargo.SelectedValue = CodigoCargo;
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                var _miempl = _UsuarioBE;
                _miempl.CodigoUsuario = int.Parse(lblCodigoUsuario.Text);

                _miempl.NombreCompleto = txtNombre.Text;


                _miempl.CodigoCargo = Convert.ToInt32(cboCargo.SelectedValue);

                _miempl.Email = txtEmail.Text;
                _miempl.Login = txtLogin.Text;
                if (_UsuarioBL.ActualizarUsuario(_UsuarioBE))
                {
                    MessageBox.Show("El Usuario se actualizó con exito");
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
