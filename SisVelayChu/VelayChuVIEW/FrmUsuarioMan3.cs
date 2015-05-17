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
                txtNombre.Text = _UsuarioBE.Nombre;
                lblCodigoUsuario.Text = _UsuarioBE.CodigoUsuario.ToString();
                txtApellidoPaterno.Text = _UsuarioBE.ApellidoPaterno;
                txtApellidoMaterno.Text = _UsuarioBE.ApellidoMaterno;
                txtNumeroDocumento.Text = _UsuarioBE.NumeroDocumento;
                txtEmail.Text = _UsuarioBE.Email;
                txtLogin.Text = _UsuarioBE.Login;
                llenarComboTipoDocumento(_UsuarioBE.CodigoTipoDocumento);
                llenarComboCargo(_UsuarioBE.CodigoCargo);
                llenarComboPerfil(_UsuarioBE.CodigoPerfil);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void llenarComboPerfil(int CodigoPerfil)
        {
            cboPerfil.DataSource = _PerfilBL.ListPerfil_All();
            cboPerfil.DisplayMember = "DescripcionPerfil";
            cboPerfil.ValueMember = "CodigoPerfil";
            cboPerfil.SelectedValue = CodigoPerfil;
        }

        private void llenarComboCargo(int CodigoCargo)
        {
            cboCargo.DataSource = _CargoBL.ListarCON_CargoOAct();
            cboCargo.DisplayMember = "DescripcionCargo";
            cboCargo.ValueMember = "CodigoCargo";
            cboCargo.SelectedValue = CodigoCargo;
        }

        private void llenarComboTipoDocumento(int CodigoTipoDocumento)
        {
            cboTipoDocumento.DataSource = _TipoDocumentoBL.ListTipoDocumento_All();
            cboTipoDocumento.DisplayMember = "DescripcionTipoDocumento";
            cboTipoDocumento.ValueMember = "CodigoTipoDocumento";
            cboTipoDocumento.SelectedValue = CodigoTipoDocumento;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                var _miempl = _UsuarioBE;
                _miempl.CodigoUsuario = int.Parse(lblCodigoUsuario.Text);
               
                _miempl.Nombre = txtNombre.Text;
                _miempl.ApellidoPaterno = txtApellidoPaterno.Text;
                _miempl.ApellidoMaterno = txtApellidoMaterno.Text;
                _miempl.CodigoTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                _miempl.NumeroDocumento = txtNumeroDocumento.Text;
                _miempl.CodigoCargo = Convert.ToInt32(cboCargo.SelectedValue);
                _miempl.CodigoPerfil = Convert.ToInt32(cboPerfil.SelectedValue);
                _miempl.Email = txtEmail.Text;
                _miempl.Login = txtLogin.Text;
                if (_UsuarioBL.ActualizarUsuario(_UsuarioBE))
                {
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
