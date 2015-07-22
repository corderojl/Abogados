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
    public partial class FrmExpedienteMan1 : Form
    {
        ListarExpedientesBL oListarExpedientesBL = new ListarExpedientesBL();
        int PageCount;
        int maxRec;
        int pageSize = 20;
        int currentPage;
        int recNo;
        DataTable dtSource;

        public FrmExpedienteMan1()
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
                dtgExpediente.DataSource = dtTemp;
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
        private void txtNumeroExpediente_TextChanged(object sender, EventArgs e)
        {
            txtNombreCliente.Text   = "";
            string _numero_expediente;
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
            _numero_expediente = "%" + txtNumeroExpediente.Text + "%";
            dtSource = oListarExpedientesBL.BuscarExpedienteByNumeroExpedient(_numero_expediente);
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
            
            dtgExpediente.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgExpediente.Refresh();
        }

        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {
            llenarData();
        }

        private void llenarData()
        {
            // Initial seeings
            currentPage = 1;
            recNo = 0;
            string _nombre_cliente;
            _nombre_cliente = "%" + txtNombreCliente.Text + "%";
            dtSource = oListarExpedientesBL.BuscarExpedienteByNombreCliente(_nombre_cliente);
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
            dtgExpediente.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgExpediente.Columns[0].Visible = false;
            dtgExpediente.Columns[1].Visible = false;
            dtgExpediente.Refresh();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            AbrirExpediente();
        }

        private void AbrirExpediente()
        {
            try
            {
                FrmExpedienteMan3 fClienteMan3 = new FrmExpedienteMan3();
                fClienteMan3.Codigo = Convert.ToInt32(dtgExpediente.CurrentRow.Cells[0].Value);
                fClienteMan3.MdiParent = this.MdiParent;
                fClienteMan3.Show();
                llenarData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar un espediente");
            }
        }


        private void FrmExpedienteMan1_Load(object sender, EventArgs e)
        {
            llenarData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmExpedienteMan2 fFrmClienteMan2 = new FrmExpedienteMan2();
            fFrmClienteMan2.MdiParent = this.MdiParent;
            fFrmClienteMan2.Show();
            llenarData();
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

        private void dtgExpediente_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirExpediente();
        }


    }
}
