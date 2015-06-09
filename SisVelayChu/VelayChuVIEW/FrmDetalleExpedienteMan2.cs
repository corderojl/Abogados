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

        public FrmDetalleExpedienteMan2()
        {
            InitializeComponent();
        }
        private int _CodigoContrato;
        public int CodigoContrato
        {
            get { return _CodigoContrato; }
            set { _CodigoContrato = value; }
        }
        private void FrmDetalleExpedienteMan2_Load(object sender, EventArgs e)
        {
            LlenarComboEvento();
            LlenarComboEtapa();
            LlenarComboEspecialista();
            LlenarComboEspecialistaImpulso();
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

        private void LlenarComboEspecialistaImpulso()
        {
            cboUsuarioImpulso.DataSource = _UsuarioBL.ListarUsuario_Act();
            cboUsuarioImpulso.DisplayMember = "NombreCompleto";
            cboUsuarioImpulso.ValueMember = "CodigoUsuario";
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DetalleExpedienteBE _DetalleExpedienteBE = new DetalleExpedienteBE();

            int _registro = -1;
            try
            {
                var _mi_DetalleExpediente = _DetalleExpedienteBE;
                //_miempl.Emp_id = "";
                _mi_DetalleExpediente.CodigoExpedienteContrato = _CodigoContrato;
                _mi_DetalleExpediente.CodigoEvento = Convert.ToInt32(cboEvento.SelectedValue);
                _mi_DetalleExpediente.CodigoEtapa = Convert.ToInt32(cboEtapa.SelectedValue);
                _mi_DetalleExpediente.Fecha = dtpFecha.Value;
                _mi_DetalleExpediente.Estado = txtEstado.Text;
                _mi_DetalleExpediente.CodigoUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
                _mi_DetalleExpediente.FechaImpulso = dtpFechaImpulso.Value;
                _mi_DetalleExpediente.CodigoUsuarioImpulso = Convert.ToInt32(cboUsuarioImpulso.SelectedValue);
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
    }
}
