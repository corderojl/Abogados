namespace VelaychuReportes
{
    partial class frmRPTCargos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.CargoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsVelayChu = new VelaychuReportes.dsVelayChu();
            this.rptCargo = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CargoTableAdapter = new VelaychuReportes.dsVelayChuTableAdapters.CargoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CargoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsVelayChu)).BeginInit();
            this.SuspendLayout();
            // 
            // CargoBindingSource
            // 
            this.CargoBindingSource.DataMember = "Cargo";
            this.CargoBindingSource.DataSource = this.dsVelayChu;
            // 
            // dsVelayChu
            // 
            this.dsVelayChu.DataSetName = "dsVelayChu";
            this.dsVelayChu.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rptCargo
            // 
            this.rptCargo.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.CargoBindingSource;
            this.rptCargo.LocalReport.DataSources.Add(reportDataSource1);
            this.rptCargo.LocalReport.ReportEmbeddedResource = "VelaychuReportes.rptCargos.rdlc";
            this.rptCargo.Location = new System.Drawing.Point(0, 0);
            this.rptCargo.Name = "rptCargo";
            this.rptCargo.Size = new System.Drawing.Size(628, 355);
            this.rptCargo.TabIndex = 0;
            // 
            // CargoTableAdapter
            // 
            this.CargoTableAdapter.ClearBeforeFill = true;
            // 
            // frmRPTCargos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 355);
            this.Controls.Add(this.rptCargo);
            this.Name = "frmRPTCargos";
            this.Text = "Reporte de Cargos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CargoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsVelayChu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptCargo;
        private System.Windows.Forms.BindingSource CargoBindingSource;
        private dsVelayChu dsVelayChu;
        private dsVelayChuTableAdapters.CargoTableAdapter CargoTableAdapter;
    }
}