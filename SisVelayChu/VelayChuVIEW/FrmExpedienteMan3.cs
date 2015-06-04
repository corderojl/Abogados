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
        DocumentoClienteBL _DocumentoClienteBL = new DocumentoClienteBL();
        ExpedienteContratoBL _ExpedienteContratoBL = new ExpedienteContratoBL();

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

                btnActualizar.Enabled = true;
                btnCancelar.Enabled = false;
                btnGuardar.Enabled = false;
                //llenarComboCliente(_ClienteBE.CodigoAsociacion);
                txtCliente.Text = _ClienteBE.NombreCompleto;
                //llenarComboMateria(_ClienteBE.CodigoTipoCliente);
                llenarComboJuzgado(_ExpedientesBE.CodigoJuzgado);
                llenarComboEspecialista(_ExpedientesBE.CodigoEspecialista);
                llenarComboSala(_ExpedientesBE.CodigoSala);
                txtExpediente.Text = _ExpedientesBE.NumeroExpediente;
                dtpFecha.Value = _ExpedientesBE.FechaRegistro;
                llenarGrillaContratos();
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.HeaderText = "";
                btnEliminar.Name = "btnEliminar";
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                dtgContrato.CellClick +=
            new DataGridViewCellEventHandler(dtgContrato_CellClick);
                dtgContrato.Columns.Add(btnEliminar);
                dtgContrato.Columns[1].Visible = false;
                cboContrato.DataSource = _ContratoBL.ListarCON_ContratoOAct();
                cboContrato.DisplayMember = "DescripcionContrato";
                cboContrato.ValueMember = "CodigoContrato";
                //DataGridViewComboBoxColumn cboContrato = new DataGridViewComboBoxColumn();
                //dtgContrato.Columns.Insert(3, cboContrato);
                //dtgContrato.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                //dtgExpediente.Columns[0].Width = 40;
                //dtgExpediente.Columns[1].Width = 150;
                //dtgExpediente.Columns[8].Width = 200;
                //llenarGrillas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dtgContrato_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex !=
                dtgContrato.Columns["btnEliminar"].Index) return;

            bool res;
            const string message = "¿Desea Eliminar el Contrato?";
            const string caption = "Eliminar Contrato";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // MessageBox.Show(dtgContrato.CurrentRow.Cells[2].Value.ToString());
                int _CodigoExpedienteContrato = Convert.ToInt32(dtgContrato.CurrentRow.Cells[2].Value);
                res = _ExpedienteContratoBL.EliminarExpedienteContrato(_CodigoExpedienteContrato);
                if (res)
                    llenarGrillaContratos();
            }

        }

        private void llenarGrillaContratos()
        {
            dtgContrato.DataSource = _ContratoBL.BuscarContratoByExpediente(_codigo);
            dtgContrato.Refresh();
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
            llenarGrillas();
        }

        private void llenarGrillas()
        {
            try
            {
                int _CodigoContrato = Convert.ToInt32(dtgContrato.CurrentRow.Cells[1].Value);
                int _CodigoExpedienteContrato = Convert.ToInt32(dtgContrato.CurrentRow.Cells[2].Value);
                llenarGrillaDetalles(_CodigoContrato);
                llenarGrillaDocumentos(_CodigoExpedienteContrato);
                
            }
            catch (Exception ex)
            {

            }
        }

        private void llenarGrillaDocumentos(int _CodigoExpedienteContrato)
        {

            dtgDocumento.DataSource = _DocumentoClienteBL.BuscarDocumentoClienteByExpedienteContrato(_CodigoExpedienteContrato);

            dtgDocumento.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgDocumento.Refresh();
        }

        private void llenarGrillaDetalles(int _CodigoContrato)
        {
            dtgDetalle.DataSource = _DetalleExpedienteBL.ListarDetalleExpedienteByContrato(_CodigoContrato);
            Pintarfilas();
            dtgDetalle.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgDetalle.Refresh();
        }

        private void Pintarfilas()
        {
            string val = "";
            for (int i = 0; i < dtgDetalle.Rows.Count; i++)
            {
                val = dtgDetalle.Rows[i].Cells[7].Value.ToString();
                if (val == "Rojo")
                    dtgDetalle.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                else if (val == "Amarillo")
                    dtgDetalle.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                else if (val == "Verde")
                    dtgDetalle.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                else if (val == "Lila")
                    dtgDetalle.Rows[i].DefaultCellStyle.BackColor = Color.Violet;
                else if (val == "Fucsia")
                    dtgDetalle.Rows[i].DefaultCellStyle.BackColor = Color.Fuchsia;
                else if (val == "Morado")
                    dtgDetalle.Rows[i].DefaultCellStyle.BackColor = Color.Purple;

            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            gpbCliente.Enabled = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnActualizar.Enabled = false;
            activarControles();
        }

        private void activarControles()
        {
            gpbCliente.Enabled = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnActualizar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            desactivarControles();
        }

        private void desactivarControles()
        {
            gpbCliente.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnActualizar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ExpedientesBE _ExpedientesBE = new ExpedientesBE();
            _ExpedientesBE.CodigoExpediente = _codigo;
            _ExpedientesBE.NumeroExpediente = txtExpediente.Text;
            //_ExpedientesBE.CodigoCliente=Convert.ToInt32(lblCodigoCliente.Text);
            _ExpedientesBE.FechaRegistro = dtpFecha.Value;
            _ExpedientesBE.CodigoJuzgado = Convert.ToInt32(cboJuzgado.SelectedValue);
            _ExpedientesBE.CodigoEspecialista = Convert.ToInt32(cboEspecialista.SelectedValue);
            _ExpedientesBE.CodigoSala = Convert.ToInt32(cboSala.SelectedValue);
            desactivarControles();

            if (_ExpedienteBL.ActualizarExpedientes(_ExpedientesBE))
            {
                MessageBox.Show("El Expediente se actualizo con exito");
            }
            else
            {
                MessageBox.Show("Error, compruebe los datos");
                desactivarControles();
            }

        }

        private void dtgDocumento_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int _CodigoDocumentoCliente = Convert.ToInt32(dtgDocumento.CurrentRow.Cells[0].Value);
            bool _Presento = Convert.ToBoolean(dtgDocumento.CurrentRow.Cells[2].Value);
            if (_DocumentoClienteBL.CambiarDocumentoCliente(_CodigoDocumentoCliente, _Presento))
            {
                int _CodigoExpedienteContrato = Convert.ToInt32(dtgContrato.CurrentRow.Cells[2].Value);

                llenarGrillaDocumentos(_CodigoExpedienteContrato);
                dtgDocumento.Refresh();
            }
            else
                MessageBox.Show("No se puede cambiar el estado");
        }


        private void btnAgregarContrato_Click(object sender, EventArgs e)
        {
            ExpedienteContratoBE _ExpedienteContratoBE = new ExpedienteContratoBE();
            _ExpedienteContratoBE.CodigoContrato = int.Parse(cboContrato.SelectedValue.ToString());
            _ExpedienteContratoBE.CodigoExpediente = _codigo;
            _ExpedienteContratoBL.InsertarExpedienteContrato(_ExpedienteContratoBE);
            llenarGrillaContratos();
        }

        private void dtgDetalle_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Pintarfilas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FrmDetalleExpedienteMan2 _FrmDetalleExpedienteMan2 = new FrmDetalleExpedienteMan2();
                _FrmDetalleExpedienteMan2.CodigoContrato = Convert.ToInt32(dtgContrato.CurrentRow.Cells[1].Value);
                _FrmDetalleExpedienteMan2.MdiParent = this.MdiParent;
                _FrmDetalleExpedienteMan2.Show();
                llenarGrillaDetalles(Convert.ToInt32(dtgContrato.CurrentRow.Cells[1].Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar un espediente");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FrmDetalleExpedienteMan3 _FrmDetalleExpedienteMan3 = new FrmDetalleExpedienteMan3();
                _FrmDetalleExpedienteMan3.CodigoDetalleExpediente = Convert.ToInt32(dtgDetalle.CurrentRow.Cells[0].Value);
                _FrmDetalleExpedienteMan3.MdiParent = this.MdiParent;
                _FrmDetalleExpedienteMan3.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar un espediente");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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
