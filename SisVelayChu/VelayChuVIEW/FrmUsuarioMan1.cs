using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VelaychuBL;

namespace VelayChuVIEW
{
    public partial class FrmUsuarioMan1 : Form
    {
        UsuarioBL _UsuarioBL = new UsuarioBL();

        public FrmUsuarioMan1()
        {
            InitializeComponent();
        }

        private void FrmUsuarioMan1_Load(object sender, EventArgs e)
        {
            try
            {
                FiltrarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        
        public void FiltrarDatos()
        {
            string  _nombres;
     
            _nombres = "%" + txtNombres.Text + "%";
            dtgUsuario.DataSource = _UsuarioBL.BuscarUsuarioByNombres(_nombres);
            dtgUsuario.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgUsuario.Columns[0].Width = 40;
            //dtgUsuario.Columns[1].Width = 150;
            //dtgUsuario.Columns[8].Width = 200;
            dtgUsuario.Refresh();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            FrmUsuarioMan2 _frmEmpMan02 = new FrmUsuarioMan2();
            _frmEmpMan02.ShowDialog();
            FiltrarDatos();
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            FrmUsuarioMan3 frmVenMan03 = new FrmUsuarioMan3();
            frmVenMan03.Codigo = Convert.ToInt32(dtgUsuario.CurrentRow.Cells[0].Value);
            frmVenMan03.ShowDialog();
            FiltrarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int vcod;
                vcod = Convert.ToInt32(dtgUsuario.CurrentRow.Cells[0].Value.ToString());
                DialogResult vrpta;
                vrpta = MessageBox.Show("Esta seguro de eliminar el Usuario?",
                    "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (vrpta == System.Windows.Forms.DialogResult.Yes)
                {
                    if (_UsuarioBL.DeshabilitarUsuario(vcod) == true)
                    {
                        MessageBox.Show("Contrato Eliminado");
                        FiltrarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Error, Verifique los Datos");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }
    }
}
