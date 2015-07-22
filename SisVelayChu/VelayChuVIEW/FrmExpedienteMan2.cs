using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
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
        ContratoBL _ContratoBL = new ContratoBL();
        AsociacionBL _AsociacionBL = new AsociacionBL();
        SalaBL _SalaBL = new SalaBL();
        JuzgadoBL _JuzgadoBL = new JuzgadoBL();
        EspecialistaBL _EspecialistaBL = new EspecialistaBL();
        ExpedienteBL _ExpedienteBL = new ExpedienteBL();
        ExpedientesBE _ExpedientesBE = new ExpedientesBE();
        ExpedienteClienteBL _ExpedienteClienteBL = new ExpedienteClienteBL();

        List<ExpedienteClienteBE> ltExpedienteClienteBE;

        public FrmExpedienteMan2()
        {
            InitializeComponent();
        }

        private void FrmExpedienteMan2_Load(object sender, EventArgs e)
        {
            try
            {

                llenarCombo();
                llenarComboAsociacion();
                llenarComboSala();
                llenarComboJuzgado();
                llenarComboEspecialista();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void llenarComboEspecialista()
        {
            cboEspecialista.DataSource = _EspecialistaBL.ListEspecialista_All();
            cboEspecialista.DisplayMember = "NombreEspecialista";
            cboEspecialista.ValueMember = "CodigoEspecialista";
        }

        private void llenarComboJuzgado()
        {
            cboJuzgado.DataSource = _JuzgadoBL.ListJuzgado_All();
            cboJuzgado.DisplayMember = "DescripcionJuzgado";
            cboJuzgado.ValueMember = "CodigoJuzgado";
        }

        private void llenarComboSala()
        {
            cboSala.DataSource = _SalaBL.ListarCON_SalaOAct();
            cboSala.DisplayMember = "DescripcionSalas";
            cboSala.ValueMember = "CodigoSala";
        }

        private void llenarComboAsociacion()
        {
            cboAsociacion.DataSource = _AsociacionBL.ListarDataTableAsociacon_All();
            cboAsociacion.DisplayMember = "NombreAsociaccion";
            cboAsociacion.ValueMember = "CodigoAsociacion";
        }

        private void llenarCombo()
        {
            List<ClienteBE> ltClienteBE;
            ltClienteBE = _ClienteBL.ListarClienteO_Act();
            cboClientes.DataSource = ltClienteBE;
            cboClientes.DisplayMember = "NombreCompleto";
            cboClientes.ValueMember = "CodigoCliente";

            //
            // cargo la lista de items para el autocomplete
            //
            cboClientes.AutoCompleteCustomSource = LoadAutoComplete();
            cboClientes.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboClientes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //cboClientes.Items.RemoveAt(0);
           // cboClientes.Rem(ClienteBE => ClienteBE.CodigoCliente == 0);
        }


        public static AutoCompleteStringCollection LoadAutoComplete()
        {
            ClienteBL _ClienteBL = new ClienteBL();
            DataTable dt = _ClienteBL.ListarCliente_All();

            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringCol.Add(Convert.ToString(row["NombreCompleto"]));
            }

            return stringCol;
        }


        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(cboClientes.SelectedValue.ToString());

            int codigo = Convert.ToInt32(cboClientes.SelectedValue.ToString());
            _ClienteBE = _ClienteBL.TraerInformacionCliente(codigo);

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Buscar(cboClientes.SelectedValue.ToString(), "CodigoCliente", dtgCliente))
                MessageBox.Show("El Cliente ya se encuentra registrado");
            else
            {
                string[] row1 = new string[] { cboClientes.SelectedValue.ToString(), cboClientes.Text.ToString(), cboAsociacion.SelectedValue.ToString(), cboAsociacion.Text.ToString(), "Quitar" };
                dtgCliente.Rows.Add(row1);
            }
        }

        private void dtgCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex !=
                    dtgCliente.Columns["btnQuitarCliente"].Index) return;

                bool res;
                const string message = "¿Desea Quitar Cliente de la lista?";
                const string caption = "Quitar Cliente";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int fil = dtgCliente.CurrentRow.Index;
                    dtgCliente.Rows.RemoveAt(fil);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ltExpedienteClienteBE = new List<ExpedienteClienteBE>();
            ExpedienteClienteBE _ExpedienteClienteBE = null;
            int _CodigoExpediente;
            _ExpedientesBE.NumeroExpediente = txtNumeroExpediente.Text;
            _ExpedientesBE.CodigoJuzgado = Convert.ToInt32(cboJuzgado.SelectedValue.ToString());
            _ExpedientesBE.CodigoSala = Convert.ToInt32(cboSala.SelectedValue.ToString());
            _ExpedientesBE.CodigoEspecialista = Convert.ToInt32(cboEspecialista.SelectedValue.ToString());
            _ExpedientesBE.FechaRegistro = dtpFecha.Value;
            _CodigoExpediente = _ExpedienteBL.InsertarExpedientes(_ExpedientesBE);

            ltExpedienteClienteBE.Add(new ExpedienteClienteBE() { CodigoCliente = 0, CodigoExpediente = _CodigoExpediente, CodigoAsociacion = Convert.ToInt32(cboAsociacion.SelectedValue.ToString()), CodigoExpedienteCliente = 1 });
            foreach (DataGridViewRow row in dtgCliente.Rows)
            {
                _ExpedienteClienteBE =new ExpedienteClienteBE();
                _ExpedienteClienteBE.CodigoCliente = Convert.ToInt32(row.Cells[0].Value);
                _ExpedienteClienteBE.CodigoExpediente = _CodigoExpediente;
                _ExpedienteClienteBE.CodigoAsociacion = Convert.ToInt32(row.Cells[2].Value);
                _ExpedienteClienteBE.CodigoExpedienteCliente = -1;
                ltExpedienteClienteBE.Add(_ExpedienteClienteBE);
            }
            int vexito=_ExpedienteClienteBL.InsertarExpedienteClientes(ltExpedienteClienteBE);
            if (vexito > 0)
            {
                MessageBox.Show("El Expediente se registro con Éxito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Hubó un problema al registrar el Expediente", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool Buscar(string TextoABuscar, string Columna, DataGridView grid)
        {
            bool encontrado = false;
            foreach (DataGridViewRow Row in grid.Rows)
            {
                String strFila = Row.Index.ToString();
                string Valor = Convert.ToString(Row.Cells[Columna].Value);

                if (Valor == TextoABuscar)                
                    encontrado= true;                
               
            }
            return encontrado;
        }
    }
}
