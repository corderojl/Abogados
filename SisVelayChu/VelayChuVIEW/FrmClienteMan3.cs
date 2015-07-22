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
    public partial class FrmClienteMan3 : Form
    {
        ClienteBE _ClienteBE = new ClienteBE();
        ClienteBL _ClienteBL = new ClienteBL();

        AsociacionBL _AsociacionBL = new AsociacionBL();
        ExpedienteBL _ExpedienteBL = new ExpedienteBL();

        TipoDocumentoBL _TipoDocumentoBL = new TipoDocumentoBL();
        TipoClienteBL _TipoClienteBL = new TipoClienteBL();
        GradoBL _GradoBL = new GradoBL();
        InstitucionBL _InstitucionBL = new InstitucionBL();
        PensionBL _PensionBL = new PensionBL();
        DepartamentoBL _DepartamentoBL = new DepartamentoBL();
        

        public FrmClienteMan3()
        {
            InitializeComponent();
        }
        private int _codigo;
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private void FrmClienteMan3_Load(object sender, EventArgs e)
        {
            try
            {
                _ClienteBE = _ClienteBL.TraerCliente(_codigo);
                llenarComboAsociacion(_ClienteBE.CodigoAsociacion);
                llenarComboTipoCliente(_ClienteBE.CodigoTipoCliente);
                llenarComboGrado(_ClienteBE.CodigoGrado);
                llenarComboInstitucion(_ClienteBE.CodigoInstitucion);
                llenarComboPension(_ClienteBE.CodigoPension);
                llenarComboDepartamento(_ClienteBE.CodigoDepartamento);
                llenarComboTipoDocumento(_ClienteBE.CodigoTipoDocumento);
                txtNombreCompleto.Text = _ClienteBE.NombreCompleto;
                txtNumeroDocumento.Text = _ClienteBE.NumeroDocumento;
                txtDireccionCompleta.Text = _ClienteBE.DirecccionCompleta;
                txtTelefonoFijo.Text = _ClienteBE.TelefonoFijo;
                txtCelular1.Text = _ClienteBE.TelefonoCelular1;
                txtCelular2.Text = _ClienteBE.TelefonoCelular2;
                txtEmail.Text = _ClienteBE.Email;
                lblCodigo.Text = _codigo.ToString();
                //dtgExpediente.Columns[0].Width = 40;
                //dtgExpediente.Columns[1].Width = 150;
                //dtgExpediente.Columns[8].Width = 200;
     

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void llenarComboTipoDocumento(int _CodigoTipoDocumento)
        {
            cboTipoDocumento.Items.Insert(0, "Seleccionar");
            cboTipoDocumento.DataSource = _TipoDocumentoBL.ListTipoDocumento_All();

            cboTipoDocumento.DisplayMember = "DescripcionTipoDocumento";
            cboTipoDocumento.ValueMember = "CodigoTipoDocumento";
            cboTipoDocumento.SelectedValue = _CodigoTipoDocumento;
        }

        private void llenarComboDepartamento(string _CodigoDepartamento)
        {
           
            cboDepartamento.DataSource = _DepartamentoBL.ListarCON_DepartamentoOAct();
            cboDepartamento.DisplayMember = "Descripciondepartamento";
            cboDepartamento.ValueMember = "CodigoDepartamento";
            cboDepartamento.SelectedValue = _CodigoDepartamento;
       
        }
        private void llenarComboAsociacion(int _CodigoAsociacion)
        {
            cboAsociacion.DataSource = _AsociacionBL.ListAsociacion_All();
            cboAsociacion.DisplayMember = "NombreAsociaccion";
            cboAsociacion.ValueMember = "CodigoAsociacion";
            cboAsociacion.SelectedValue = _CodigoAsociacion;
        }
        private void llenarComboTipoCliente(int _CodigoTipoCliente)
        {
            cboTipoCliente.DataSource = _TipoClienteBL.ListTipoCliente_All();
            cboTipoCliente.DisplayMember = "DescripcionTipoCliente";
            cboTipoCliente.ValueMember = "CodigoTipoCliente";
            cboTipoCliente.SelectedValue = _CodigoTipoCliente;
        }
        private void llenarComboGrado(int _CodigoGrado)
        {
            cboGrado.DataSource = _GradoBL.ListGrado_All();
            cboGrado.DisplayMember = "DescripcionGrado";
            cboGrado.ValueMember = "CodigoGrado";
            cboGrado.SelectedValue = _CodigoGrado;
        }
        private void llenarComboInstitucion(int _CodigoInstitucion)
        {
            cboInstitucion.DataSource = _InstitucionBL.ListInstitucion_All();
            cboInstitucion.DisplayMember = "DescripcionInstitucion";
            cboInstitucion.ValueMember = "CodigoInstitucion";
            cboInstitucion.SelectedValue = _CodigoInstitucion;
        }
        private void llenarComboPension(int _CodigoPension)
        {
            cboPension.DataSource = _PensionBL.ListPension_All();
            cboPension.DisplayMember = "DescripcionPension";
            cboPension.ValueMember = "CodigoPension";
            cboPension.SelectedValue = _CodigoPension;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            ClienteBL _ClienteBL = new ClienteBL();
            bool _registro = false;
            try
            {
                var _miempl = _ClienteBE;
                _miempl.CodigoCliente = int.Parse(lblCodigo.Text);
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
                _registro = _ClienteBL.ActualizarCliente(_ClienteBE);
                //_registro = _ExpedienteBL.InsertarExpedientes(_ExpedientesBE);

                if (_registro)
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
