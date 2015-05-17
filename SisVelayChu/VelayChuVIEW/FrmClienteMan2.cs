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

        }
    }
}
