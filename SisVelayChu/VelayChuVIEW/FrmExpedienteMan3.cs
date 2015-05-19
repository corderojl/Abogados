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
    public partial class FrmExpedienteMan3 : Form
    {
        ExpedientesBE _ExpedientesBE = new ExpedientesBE();

        ClienteBE _ClienteBE = new ClienteBE();
        ClienteBL _ClienteBL = new ClienteBL();

        AsociacionBL _AsociacionBL = new AsociacionBL();
        ExpedienteBL _ExpedienteBL = new ExpedienteBL();

        ContratoBL _ContratoBL = new ContratoBL();
        DocumentoBL _DocumentoBL = new DocumentoBL();

        SalaBL _TipoDocumentoBL = new TipoDocumentoBL();
        TipoClienteBL _TipoClienteBL = new TipoClienteBL();
        GradoBL _GradoBL = new GradoBL();
        InstitucionBL _InstitucionBL = new InstitucionBL();
        PensionBL _PensionBL = new PensionBL();

        public FrmExpedienteMan3()
        {
            InitializeComponent();
        }
        private int _codigo;
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private void FrmExpedienteMan3_Load(object sender, EventArgs e)
        {
            try
            {
                _ExpedientesBE = _ExpedienteBL.TraerExpediente(_codigo);
                _ClienteBE = _ClienteBL.TraerCliente(_ExpedientesBE.CodigoCliente);

                llenarComboCliente(_ClienteBE.CodigoAsociacion);
                llenarComboMateria(_ClienteBE.CodigoTipoCliente);
                llenarComboJuzgado(_ClienteBE.CodigoGrado);
                llenarComboEspecialista(_ClienteBE.CodigoInstitucion);
                llenarComboSala(_ClienteBE.CodigoPension);
                txtExpediente.Text = _ExpedientesBE.NumeroExpediente;
                dtgContrato.DataSource = _ExpedienteBL.BuscarExpedienteByCliente(_codigo);
                dtgContrato.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgExpediente.Columns[0].Width = 40;
                //dtgExpediente.Columns[1].Width = 150;
                //dtgExpediente.Columns[8].Width = 200;
                dtgContrato.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void llenarComboSala(int _CodigoSalas)
        {
            cboSala.DataSource = _sala.ListAsociacion_All();
            cboSala.DisplayMember = "DescripcionSalas";
            cboSala.ValueMember = "CodigoSalas";
            cboSala.SelectedValue = _CodigoSalas;
        }

        private void llenarComboEspecialista(int _CodigoEspecialista)
        {
            cboEspecialista.DataSource = _AsociacionBL.ListAsociacion_All();
            cboEspecialista.DisplayMember = "NombreEspecialista";
            cboEspecialista.ValueMember = "CodigoEspecialista";
            cboEspecialista.SelectedValue = _CodigoEspecialista;
        }

        private void llenarComboJuzgado(int _CodigoJuzgados)
        {
            cboJuzgado.DataSource = _AsociacionBL.ListAsociacion_All();
            cboJuzgado.DisplayMember = "DescripcionJuzgados";
            cboJuzgado.ValueMember = "CodigoJuzgados";
            cboJuzgado.SelectedValue = _CodigoJuzgados;
        }

        private void llenarComboMateria(int _CodigoMaterias)
        {
            cboMateria.DataSource = _AsociacionBL.ListAsociacion_All();
            cboMateria.DisplayMember = "DescripcionMaterias";
            cboMateria.ValueMember = "CodigoMaterias";
            cboMateria.SelectedValue = _CodigoMaterias;
        }

        private void llenarComboCliente(int _CodigoClientes)
        {
            cboCliente.DataSource = _AsociacionBL.ListAsociacion_All();
            cboCliente.DisplayMember = "NombreClientes";
            cboCliente.ValueMember = "CodigoClientes";
            cboCliente.SelectedValue = _CodigoClientes;
        }

       
    }
}
