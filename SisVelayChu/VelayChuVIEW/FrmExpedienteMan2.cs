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
    public partial class FrmExpedienteMan2 : Form
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


        public FrmExpedienteMan2()
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
                txtNombreCliente.Text = _ClienteBE.NombreCompleto;
                dtgExpediente.DataSource = _ExpedienteBL.BuscarExpedienteByCliente(_codigo);
                dtgExpediente.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgExpediente.Columns[0].Width = 40;
                //dtgExpediente.Columns[1].Width = 150;
                //dtgExpediente.Columns[8].Width = 200;
                dtgExpediente.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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

        private void FrmExpedienteMan2_Load(object sender, EventArgs e)
        {

        }
    }
}
