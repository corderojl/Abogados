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
    public partial class FrmDetalleExpedienteMan3 : Form
    {
        EventoBL _EventoBL = new EventoBL();
        EtapaBL _EtapaBL = new EtapaBL();
        UsuarioBL _UsuarioBL = new UsuarioBL();
        DetalleExpedienteBL _DetalleExpedienteBL = new DetalleExpedienteBL();
        DetalleExpedienteBE _DetalleExpedienteBE = new DetalleExpedienteBE();
        public FrmDetalleExpedienteMan3()
        {
            InitializeComponent();
        }
        private int _CodigoDetalleExpediente;
        public int CodigoDetalleExpediente
        {
            get { return _CodigoDetalleExpediente; }
            set { _CodigoDetalleExpediente = value; }
        }

        private void FrmDetalleExpedienteMan3_Load(object sender, EventArgs e)
        {
           
            try
            {
                _DetalleExpedienteBE = _DetalleExpedienteBL.TraerExpediente(_CodigoDetalleExpediente);
                lblCodigoContrato.Text = _DetalleExpedienteBE.CodigoExpedienteContrato.ToString();
                LlenarComboEvento(_DetalleExpedienteBE.CodigoEvento);
                LlenarComboEtapa(_DetalleExpedienteBE.CodigoEtapa);
                LlenarComboEspecialista(_DetalleExpedienteBE.CodigoUsuario);
               // LlenarComboEspecialistaImpulso(_DetalleExpedienteBE.CodigoUsuarioImpulso);

                txtEstado.Text = _DetalleExpedienteBE.Estado;
                dtpFecha.Value = _DetalleExpedienteBE.Fecha;
                dtpFechaImpulso.Value = _DetalleExpedienteBE.FechaImpulso;
                txtDiasAlerta.Text = _DetalleExpedienteBE.CodigoExpedienteCliente.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void LlenarComboEvento(int _CodigoEvento)
        {
            cboEvento.DataSource = _EventoBL.ListarEventoObj();
            cboEvento.DisplayMember = "DescripcionEvento";
            cboEvento.ValueMember = "CodigoEvento";
            cboEvento.SelectedValue = _CodigoEvento;
        }

        private void LlenarComboEspecialista(int _CodigoUsuario)
        {
            cboUsuario.DataSource = _UsuarioBL.ListarUsuario_Act();
            cboUsuario.DisplayMember = "NombreCompleto";
            cboUsuario.ValueMember = "CodigoUsuario";
            cboUsuario.SelectedValue = _CodigoUsuario;
        }

        private void LlenarComboEtapa(int _CodigoEtapa)
        {
            cboEtapa.DataSource = _EtapaBL.ListarEtapaObj();
            cboEtapa.DisplayMember = "DescripcionEtapa";
            cboEtapa.ValueMember = "CodigoEtapa";
            cboEtapa.SelectedValue = _CodigoEtapa;
        }

        //private void LlenarComboEspecialistaImpulso(int _CodigoUsuario)
        //{
        //    cboUsuarioImpulso.DataSource = _UsuarioBL.ListarUsuario_Act();
        //    cboUsuarioImpulso.DisplayMember = "NombreCompleto";
        //    cboUsuarioImpulso.ValueMember = "CodigoUsuario";
        //    cboUsuarioImpulso.SelectedValue = _CodigoUsuario;
        //}

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                var _mi_DetalleExpediente = _DetalleExpedienteBE;
                //_miempl.Emp_id = "";
                _mi_DetalleExpediente.CodigoDetalleExpediente = _CodigoDetalleExpediente;
                _mi_DetalleExpediente.CodigoExpedienteContrato = Convert.ToInt32(lblCodigoContrato.Text);
                _mi_DetalleExpediente.CodigoEvento = Convert.ToInt32(cboEvento.SelectedValue);
                _mi_DetalleExpediente.CodigoEtapa = Convert.ToInt32(cboEtapa.SelectedValue);
                _mi_DetalleExpediente.Fecha = dtpFecha.Value;
                _mi_DetalleExpediente.Estado = txtEstado.Text;
                _mi_DetalleExpediente.CodigoUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
                _mi_DetalleExpediente.FechaImpulso = dtpFechaImpulso.Value;
                _mi_DetalleExpediente.CodigoUsuarioImpulso = 1;// Convert.ToInt32(cboUsuarioImpulso.SelectedValue);
                _mi_DetalleExpediente.CodigoExpedienteCliente = Convert.ToInt32(txtDiasAlerta.Text);
                if (_DetalleExpedienteBL.ActualizarDetalleExpediente(_DetalleExpedienteBE))
                {
                    MessageBox.Show("El Detalle se actualizó con exito");
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
