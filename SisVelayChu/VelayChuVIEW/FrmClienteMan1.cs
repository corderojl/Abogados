using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VelaychuBE;
using VelaychuBL;

namespace VelayChuVIEW
{
    public partial class FrmClienteMan1 : Form
    {
        ClienteBL oClienteBL = new ClienteBL();
        int PageCount;
        int maxRec;
        int pageSize = 20;
        int currentPage;
        int recNo;
        DataTable dtSource;

        public FrmClienteMan1()
        {
            InitializeComponent();
        }
        private void LoadPage()
        {
            try
            {
                int i;
                int startRec;
                int endRec;
                DataTable dtTemp;

                //Clone the source table to create a temporary table.
                dtTemp = dtSource.Clone();

                if (currentPage == PageCount)
                {
                    endRec = maxRec;
                }
                else
                {
                    endRec = pageSize * currentPage;
                }
                startRec = recNo;

                //Copy rows from the source table to fill the temporary table.
                for (i = startRec; i < endRec; i++)
                {
                    dtTemp.ImportRow(dtSource.Rows[i]);
                    recNo += 1;
                }
                dtgCliente.DataSource = dtTemp;
                DisplayPageInfo();
            }
            catch (Exception ex)
            {
            }
        }
        private void DisplayPageInfo()
        {
            txtDisplayPageNo.Text = "Page " + currentPage.ToString() + "/ " + PageCount.ToString();
        }

        private bool CheckFillButton()
        {
            // Check if the user clicks the "Fill Grid" button.
            if (pageSize == 0)
            {
                MessageBox.Show("Set the Page Size, and then click the Fill Grid button!");
                return false;
            }
            else
            {
                return true;
            }
        }
        public void FiltrarDatos()
        {
            string _apellidos;
            _apellidos = "%" + txtCliente.Text + "%";
            dtSource = oClienteBL.BuscarClienteByNombres(_apellidos);
            //pageSize = Convert.ToInt32(txtPageSize.Text);
            maxRec = dtSource.Rows.Count;
            PageCount = maxRec / pageSize;

            //Adjust the page number if the last page contains a partial page.
            if ((maxRec % pageSize) > 0)
            {
                PageCount += 1;
            }
            // Initial seeings
            currentPage = 1;
            recNo = 0;
            LoadPage();
            //dtgCliente.DataSource = lClienteBE;
            dtgCliente.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgCliente.Columns[0].Visible = false;
            //dtgUsuario.Columns[1].Width = 150;
            //dtgUsuario.Columns[8].Width = 200;
            dtgCliente.Refresh();
        }
        private bool buscarCliente(TmpClienteBE obeCliente)
        {
            return (obeCliente.NombreCompleto.ToLower().Contains(txtCliente.Text.ToLower()));
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            FrmClienteMan2 fFrmClienteMan2 = new FrmClienteMan2();
            fFrmClienteMan2.MdiParent = this.MdiParent;
            fFrmClienteMan2.Show();
            FiltrarDatos();
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            //pageSize = Convert.ToInt32(txtPageSize.Text);
            maxRec = dtSource.Rows.Count;
            PageCount = maxRec / pageSize;

            //Adjust the page number if the last page contains a partial page.
            if ((maxRec % pageSize) > 0)
            {
                PageCount += 1;
            }

            // Initial seeings
            currentPage = 1;
            recNo = 0;
            //filtrarCliente();
            FiltrarDatos();
            

            // Display the content of the current page.
            //LoadPage();
            //FiltrarDatos();
        }

        private void FrmClienteMan1_Load(object sender, EventArgs e)
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            AbrirClienteMan3();
           
        }

        private void AbrirClienteMan3()
        {
            FrmClienteMan3 fClienteMan3 = new FrmClienteMan3();
            try
            {
                fClienteMan3.Codigo = Convert.ToInt32(dtgCliente.CurrentRow.Cells[0].Value);
                fClienteMan3.MdiParent = this.MdiParent;
                fClienteMan3.Show();
                FiltrarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Selecciones un registro");
                //MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnNuevoExpediente_Click(object sender, EventArgs e)
        {
            FrmExpedienteMan2 fFrmClienteMan2 = new FrmExpedienteMan2();
            fFrmClienteMan2.MdiParent = this.MdiParent;
            fFrmClienteMan2.Show();
        }
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            if (CheckFillButton() == false)
            {
                return;
            }

            //Check if you are already at the first page.
            if (currentPage == 1)
            {
                MessageBox.Show("¡Se encuentra en la primera página!");
                return;
            }

            currentPage = 1;
            recNo = 0;
            LoadPage();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            //If the user did not click the "Fill Grid" button, then return.
            if (CheckFillButton() == false)
            {
                return;
            }

            //Check if the user clicks the "Fill Grid" button.
            if (pageSize == 0)
            {
                MessageBox.Show("¡Ingrese el número de páginas!");
                return;
            }

            currentPage += 1;
            if (currentPage > PageCount)
            {
                currentPage = PageCount;
                //Check if you are already at the last page.
                if (recNo == maxRec)
                {
                    MessageBox.Show("¡Se encuentra en la última página!");
                    return;
                }
            }
            LoadPage();
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (CheckFillButton() == false)
            {
                return;
            }

            if (currentPage == PageCount)
            {
                recNo = pageSize * (currentPage - 2);
            }

            currentPage -= 1;
            //Check if you are already at the first page.
            if (currentPage < 1)
            {
                MessageBox.Show("¡Se encuentra en la primera página!");
                currentPage = 1;
                return;
            }
            else
            {
                recNo = pageSize * (currentPage - 1);
            }
            LoadPage();
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            if (CheckFillButton() == false)
            {
                return;
            }

            //Check if you are already at the last page.
            if (recNo == maxRec)
            {
                MessageBox.Show("¡Se encuentra en la última página!");
                return;
            }
            currentPage = PageCount;
            recNo = pageSize * (currentPage - 1);
            LoadPage();
        }

        private void dtgCliente_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirClienteMan3();
        }
    }
}
