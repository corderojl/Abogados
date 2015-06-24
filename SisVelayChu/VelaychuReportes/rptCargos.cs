using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VelaychuReportes
{
    public partial class frmRPTCargos : Form
    {
        public frmRPTCargos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsVelayChu.Cargo' table. You can move, or remove it, as needed.
            this.CargoTableAdapter.Fill(this.dsVelayChu.Cargo);

            this.rptCargo.RefreshReport();
           
        }
    }
}
