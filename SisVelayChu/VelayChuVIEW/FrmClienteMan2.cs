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
    public partial class FrmClienteMan2 : Form
    {
        TipoDocumentoBL _TipoDocumentoBL = new TipoDocumentoBL();
        AsociacionBL _AsociacionBL = new AsociacionBL();
        TipoClienteBL _TipoClienteBL = new TipoClienteBL();
        GradoBL _GradoBL = new GradoBL();
        InstitucionBL _InstitucionBL = new InstitucionBL();
        PensionBL _PensionBL = new PensionBL();
        ContratoBL _ContratoBL = new ContratoBL();
        ExpedienteBL _ExpedienteBL = new ExpedienteBL();
        DepartamentoBL _DepartamentoBL = new DepartamentoBL();

        ClienteBE _ClienteBE = new ClienteBE();
        ExpedientesBE _ExpedientesBE = new ExpedientesBE();

        public FrmClienteMan2()
        {
            InitializeComponent();
        }

       
        private void llenarComboTipoDocumento()
        {
            cboTipoDocumento.Items.Insert(0,"Seleccionar");
            cboTipoDocumento.DataSource = _TipoDocumentoBL.ListTipoDocumento_All();

            cboTipoDocumento.DisplayMember = "DescripcionTipoDocumento";
            cboTipoDocumento.ValueMember = "CodigoTipoDocumento";
            
        }
        private void llenarComboAsociacion()
        {
            cboAsociacion.DataSource = _AsociacionBL.ListAsociacion_All();
            cboAsociacion.DisplayMember = "NombreAsociaccion";
            cboAsociacion.ValueMember = "CodigoAsociacion";
        }
        private void llenarComboTipoCliente()
        {
            cboTipoCliente.DataSource = _TipoClienteBL.ListTipoCliente_All();
            cboTipoCliente.DisplayMember = "DescripcionTipoCliente";
            cboTipoCliente.ValueMember = "CodigoTipoCliente";
        }
        private void llenarComboGrado()
        {
            cboGrado.DataSource = _GradoBL.ListGrado_All();
            cboGrado.DisplayMember = "DescripcionGrado";
            cboGrado.ValueMember = "CodigoGrado";
        }
        private void llenarComboInstitucion()
        {
            cboInstitucion.DataSource = _InstitucionBL.ListInstitucion_All();
            cboInstitucion.DisplayMember = "DescripcionInstitucion";
            cboInstitucion.ValueMember = "CodigoInstitucion";
        }
        private void llenarComboPension()
        {
            cboPension.DataSource = _PensionBL.ListPension_All();
            cboPension.DisplayMember = "DescripcionPension";
            cboPension.ValueMember = "CodigoPension";
        }

        private void FrmClienteMan2_Load(object sender, EventArgs e)
        {
            llenarComboTipoDocumento();
            llenarComboAsociacion();
            llenarComboTipoCliente();
            llenarComboGrado();
            llenarComboInstitucion();
            llenarComboPension();
            llenarComboDepartamento();
        }

        private void llenarComboDepartamento()
        {
            cboDepartamento.DataSource = _DepartamentoBL.ListarCON_DepartamentoOAct();
            cboDepartamento.DisplayMember = "Descripciondepartamento";
            cboDepartamento.ValueMember = "CodigoDepartamento";
            cboDepartamento.SelectedValue = "015";
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            ClienteBL _ClienteBL = new ClienteBL();
            int _registro = -1;
            try
            {
                var _miempl = _ClienteBE;
                //_miempl.Emp_id = "";
                _miempl.NombreCompleto = txtNombreCompleto.Text;
                _miempl.CodigoTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                _miempl.NumeroDocumento = txtNumeroDocumento.Text;
                _miempl.CodigoAsociacion = Convert.ToInt32(cboAsociacion.SelectedValue);
                _miempl.CodigoTipoCliente = Convert.ToInt32(cboTipoCliente.SelectedValue);
                _miempl.CodigoGrado = Convert.ToInt32(cboGrado.SelectedValue);
                _miempl.CodigoInstitucion = Convert.ToInt32(cboInstitucion.SelectedValue);
                _miempl.CodigoPension = Convert.ToInt32(cboPension.SelectedValue);
                _miempl.DirecccionCompleta = txtDireccionCompleta.Text;
                _miempl.CodigoDepartamento = cboDepartamento.SelectedValue.ToString();
                _miempl.TelefonoFijo = txtTelefonoFijo.Text;
                _miempl.TelefonoCelular1 = txtCelular1.Text;
                _miempl.TelefonoCelular2 = txtCelular2.Text;
                _miempl.Email = txtEmail.Text;
                _registro = _ClienteBL.InsertarCliente(_ClienteBE);
                //_registro = _ExpedienteBL.InsertarExpedientes(_ExpedientesBE);

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
