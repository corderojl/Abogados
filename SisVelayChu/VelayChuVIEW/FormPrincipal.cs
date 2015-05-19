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
    }
}
