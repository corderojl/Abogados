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
        DetalleExpedienteBL _DetalleExpedienteBL = new DetalleExpedienteBL();

        SalaBL _SalaBL = new SalaBL();
        JuzgadoBL _JuzgadoBL = new JuzgadoBL();
        MateriaBL _MateriaBL = new MateriaBL();
        EspecialistaBL _EspecialistaBL = new EspecialistaBL();
        

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

                //llenarComboCliente(_ClienteBE.CodigoAsociacion);
                txtCliente.Text = _ClienteBE.NombreCompleto;
               //llenarComboMateria(_ClienteBE.CodigoTipoCliente);
                llenarComboJuzgado(_ClienteBE.CodigoGrado);
                llenarComboEspecialista(_ClienteBE.CodigoInstitucion);
                llenarComboSala(_ClienteBE.CodigoPension);
                txtExpediente.Text = _ExpedientesBE.NumeroExpediente;
                dtgContrato.DataSource = _ContratoBL.BuscarContratoByExpediente(_codigo);
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
            cboSala.DataSource = _SalaBL.ListarCON_SalaOAct();
            cboSala.DisplayMember = "DescripcionSala";
            cboSala.ValueMember = "CodigoSala";
            cboSala.SelectedValue = _CodigoSalas;
        }

        private void llenarComboEspecialista(int _CodigoEspecialista)
        {
            cboEspecialista.DataSource = _EspecialistaBL.ListEspecialista_All();
            cboEspecialista.DisplayMember = "NombreEspecialista";
            cboEspecialista.ValueMember = "CodigoEspecialista";
            cboEspecialista.SelectedValue = _CodigoEspecialista;
        }

        private void llenarComboJuzgado(int _CodigoJuzgados)
        {
            cboJuzgado.DataSource = _JuzgadoBL.ListJuzgado_All();
            cboJuzgado.DisplayMember = "DescripcionJuzgado";
            cboJuzgado.ValueMember = "CodigoJuzgado";
            cboJuzgado.SelectedValue = _CodigoJuzgados;
        }

        private void dtgContrato_Click(object sender, EventArgs e)
        {
            try
            {
                int _CodigoContrato = Convert.ToInt32(dtgContrato.CurrentRow.Cells[0].Value);
                llenarGrillaDetalles(_CodigoContrato);
                llenarGrillaDocumentos(_CodigoContrato);
            }
            catch (Exception ex)
            {
                
            }

        }

        private void llenarGrillaDocumentos(int _CodigoContrato)
        {
            dtgDocumento.DataSource = _DocumentoBL.ListarDocumentoByContrato(_CodigoContrato);
            dtgDocumento.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgExpediente.Columns[0].Width = 40;
            //dtgExpediente.Columns[1].Width = 150;
            //dtgExpediente.Columns[8].Width = 200;
            dtgDocumento.Refresh();
        }

        private void llenarGrillaDetalles(int _CodigoContrato)
        {
            dtgDetalle.DataSource = _DetalleExpedienteBL.ListarDetalleExpedienteByContrato(_CodigoContrato);
            dtgDetalle.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgExpediente.Columns[0].Width = 40;
            //dtgExpediente.Columns[1].Width = 150;
            //dtgExpediente.Columns[8].Width = 200;
            dtgDetalle.Refresh();
        }

        //private void llenarComboMateria(int _CodigoMaterias)
        //{
        //    cboMateria.DataSource = _MateriaBL.ListMateria_All();
        //    cboMateria.DisplayMember = "DescripcionMateria";
        //    cboMateria.ValueMember = "CodigoMateria";
        //    cboMateria.SelectedValue = _CodigoMaterias;
        //}

        //private void llenarComboCliente(int _CodigoCliente)
        //{
        //    cboCliente.DataSource = _ClienteBL.ListarClienteO_Act();
        //    cboCliente.DisplayMember = "NombreCompleto";
        //    cboCliente.ValueMember = "CodigoCliente";
        //    cboCliente.SelectedValue = _CodigoCliente;
        //}

       
    }
}
