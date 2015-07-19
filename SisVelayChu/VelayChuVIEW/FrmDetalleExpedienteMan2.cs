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
    public partial class FrmDetalleExpedienteMan2 : Form
    {
        EventoBL _EventoBL = new EventoBL();
        EtapaBL _EtapaBL = new EtapaBL();
        UsuarioBL _UsuarioBL = new UsuarioBL();
        DetalleExpedienteBL _DetalleExpedienteBL = new DetalleExpedienteBL();
        ClienteBL _ClienteBL = new ClienteBL();

        public FrmDetalleExpedienteMan2()
        {
            InitializeComponent();
        }
        private int _CodigoExpedienteContrato;
        private int _CodigoExpediente;
        public int CodigoExpedienteContrato
        {
            get { return _CodigoExpedienteContrato; }
            set { _CodigoExpedienteContrato = value; }
        }
        public int CodigoExpediente
        {
            get { return _CodigoExpediente; }
            set { _CodigoExpediente = value; }
        }
        private void FrmDetalleExpedienteMan2_Load(object sender, EventArgs e)
        {
            LlenarComboEvento();
            LlenarComboEtapa();
            LlenarComboEspecialista();
            llenarComboCliente();
            //LlenarComboEspecialistaImpulso();
        }

        private void LlenarComboEvento()
        {
            cboEvento.DataSource = _EventoBL.ListarEventoObj();
            cboEvento.DisplayMember = "DescripcionEvento";
            cboEvento.ValueMember = "CodigoEvento";
        }

        private void LlenarComboEspecialista()
        {
            cboUsuario.DataSource = _UsuarioBL.ListarUsuario_Act();
            cboUsuario.DisplayMember = "NombreCompleto";
            cboUsuario.ValueMember = "CodigoUsuario";
        }

        private void LlenarComboEtapa()
        {
            cboEtapa.DataSource = _EtapaBL.ListarEtapaObj();
            cboEtapa.DisplayMember = "DescripcionEtapa";
            cboEtapa.ValueMember = "CodigoEtapa";
        }

       
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DetalleExpedienteBE _DetalleExpedienteBE = new DetalleExpedienteBE();

            int _registro = -1;
            try
            {
                var _mi_DetalleExpediente = _DetalleExpedienteBE;
                
                _mi_DetalleExpediente.CodigoExpedienteContrato = _CodigoExpedienteContrato;
                _mi_DetalleExpediente.CodigoEvento = Convert.ToInt32(cboEvento.SelectedValue);
                _mi_DetalleExpediente.CodigoEtapa = Convert.ToInt32(cboEtapa.SelectedValue);
                _mi_DetalleExpediente.Fecha = dtpFecha.Value;
                _mi_DetalleExpediente.Estado = txtEstado.Text;
                _mi_DetalleExpediente.CodigoUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
                _mi_DetalleExpediente.FechaImpulso = dtpFechaImpulso.Value;
                _mi_DetalleExpediente.CodigoUsuarioImpulso = 1;//Convert.ToInt32(cboUsuarioImpulso.SelectedValue);
                _mi_DetalleExpediente.CodigoExpedienteCliente = Convert.ToInt32(cboCliente.SelectedValue);
                _registro = _DetalleExpedienteBL.InsertarDetalleExpediente(_DetalleExpedienteBE);
                if (_registro > -1)
                {
                    MessageBox.Show("Se registro con Detalle");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error, verifique los Datos");
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Se produjo el siguiente error: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDiasAlerta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
               // MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void llenarComboCliente()
        {
            cboCliente.DataSource = _ClienteBL.BuscarClienteByExpediente(CodigoExpediente); 
            cboCliente.DisplayMember = "NombreCompleto";
            cboCliente.ValueMember = "CodigoExpedienteCliente";
           
            //
            // cargo la lista de items para el autocomplete
            //
            cboCliente.AutoCompleteCustomSource = LoadAutoComplete(CodigoExpediente);
            cboCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }


        public static AutoCompleteStringCollection LoadAutoComplete(int CodigoExpediente)
        {
            ClienteBL _ClienteBL = new ClienteBL();
            DataTable dt = _ClienteBL.BuscarClienteByExpediente(CodigoExpediente);

            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringCol.Add(Convert.ToString(row["NombreCompleto"]));
            }

            return stringCol;
        }
    }
}
