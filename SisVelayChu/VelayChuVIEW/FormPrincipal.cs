using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VelayChuVIEW
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }


        private void ingresarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClienteMan1 _EmpleadoMan1;
            _EmpleadoMan1 = new FrmClienteMan1();
            _EmpleadoMan1.MdiParent = this;
            _EmpleadoMan1.Show();
        }

        private void nuevoContratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarioMan1 _frmEmpMan01;
            _frmEmpMan01 = new FrmUsuarioMan1();
            _frmEmpMan01.MdiParent = this;
            _frmEmpMan01.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string message = "¿Desea salir del Programa?";
            const string caption = "Salir";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                // cancel the closure of the form.
                Application.Exit();
            }
        }



        private void registrarExpedienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmExpedienteMan1 FrmExpedienteMan1;
            FrmExpedienteMan1 = new FrmExpedienteMan1();
            FrmExpedienteMan1.MdiParent = this;
            FrmExpedienteMan1.Show();
        }

        private void nuevaAsociacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAsociacionMan1 FrmAsociacionMan1;
            FrmAsociacionMan1 = new FrmAsociacionMan1();
            FrmAsociacionMan1.MdiParent = this;
            FrmAsociacionMan1.Show();            
            
        }

        private void nuevaInstitucionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInstitucionMan1 FrmInstitucionMan1;
            FrmInstitucionMan1 = new FrmInstitucionMan1();
            FrmInstitucionMan1.MdiParent = this;
            FrmInstitucionMan1.Show();              
            
        }

        private void gradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGradoMan1 FrmGradoMan1;
            FrmGradoMan1 = new FrmGradoMan1();
            FrmGradoMan1.MdiParent = this;
            FrmGradoMan1.Show();               
            
        }

        private void tipoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoClienteMan1 FrmTipoClienteMan1;
            FrmTipoClienteMan1 = new FrmTipoClienteMan1();
            FrmTipoClienteMan1.MdiParent = this;
            FrmTipoClienteMan1.Show();   
            
        }

        private void tipoDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoDocumentoMan1 FrmTipoDocumentoMan1;
            FrmTipoDocumentoMan1 = new FrmTipoDocumentoMan1();
            FrmTipoDocumentoMan1.MdiParent = this;
            FrmTipoDocumentoMan1.Show();              
            
        }

        private void tipoDePensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPensionMan1 FrmPensionMan1;
            FrmPensionMan1 = new FrmPensionMan1();
            FrmPensionMan1.MdiParent = this;
            FrmPensionMan1.Show();   
        }

        private void etapaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEtapaMan1 FrmEtapaMan1;
            FrmEtapaMan1 = new FrmEtapaMan1();
            FrmEtapaMan1.MdiParent = this;
            FrmEtapaMan1.Show();   
        }
    }
}
