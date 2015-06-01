namespace VelayChuVIEW
{
    partial class FrmExpedienteMan2
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cboClientes = new System.Windows.Forms.ComboBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.lstInformacionCliente = new System.Windows.Forms.ListBox();
            this.cboContratos = new System.Windows.Forms.ComboBox();
            this.btnAgregarContrato = new System.Windows.Forms.Button();
            this.dtgContrato = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgContrato)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.38461F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.07692F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.07692F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.07692F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.38461F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboClientes, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnBuscarCliente, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstInformacionCliente, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboContratos, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnAgregarContrato, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.dtgContrato, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.489576F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50899F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.14306F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.14306F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.14306F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.14306F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.14306F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.14306F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.14306F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(524, 465);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre del Cliente";
            // 
            // cboClientes
            // 
            this.cboClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.cboClientes, 3);
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(83, 11);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(354, 21);
            this.cboClientes.TabIndex = 5;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarCliente.Location = new System.Drawing.Point(443, 7);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(78, 29);
            this.btnBuscarCliente.TabIndex = 6;
            this.btnBuscarCliente.Text = "Buscar";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // lstInformacionCliente
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lstInformacionCliente, 3);
            this.lstInformacionCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstInformacionCliente.Enabled = false;
            this.lstInformacionCliente.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstInformacionCliente.FormattingEnabled = true;
            this.lstInformacionCliente.ItemHeight = 14;
            this.lstInformacionCliente.Location = new System.Drawing.Point(83, 47);
            this.lstInformacionCliente.Name = "lstInformacionCliente";
            this.tableLayoutPanel1.SetRowSpan(this.lstInformacionCliente, 3);
            this.lstInformacionCliente.Size = new System.Drawing.Size(354, 154);
            this.lstInformacionCliente.TabIndex = 7;
            // 
            // cboContratos
            // 
            this.cboContratos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.cboContratos, 2);
            this.cboContratos.FormattingEnabled = true;
            this.cboContratos.Location = new System.Drawing.Point(83, 219);
            this.cboContratos.Name = "cboContratos";
            this.cboContratos.Size = new System.Drawing.Size(234, 21);
            this.cboContratos.TabIndex = 8;
            // 
            // btnAgregarContrato
            // 
            this.btnAgregarContrato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarContrato.Location = new System.Drawing.Point(323, 218);
            this.btnAgregarContrato.Name = "btnAgregarContrato";
            this.btnAgregarContrato.Size = new System.Drawing.Size(114, 23);
            this.btnAgregarContrato.TabIndex = 9;
            this.btnAgregarContrato.Text = "Agregar Contrato";
            this.btnAgregarContrato.UseVisualStyleBackColor = true;
            this.btnAgregarContrato.Click += new System.EventHandler(this.btnAgregarContrato_Click);
            // 
            // dtgContrato
            // 
            this.dtgContrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dtgContrato, 3);
            this.dtgContrato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgContrato.Location = new System.Drawing.Point(83, 258);
            this.dtgContrato.Name = "dtgContrato";
            this.tableLayoutPanel1.SetRowSpan(this.dtgContrato, 3);
            this.dtgContrato.Size = new System.Drawing.Size(354, 147);
            this.dtgContrato.TabIndex = 10;
            // 
            // FrmExpedienteMan2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 465);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmExpedienteMan2";
            this.Text = "FrmExpedienteMan2";
            this.Load += new System.EventHandler(this.FrmExpedienteMan2_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgContrato)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboClientes;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.ListBox lstInformacionCliente;
        private System.Windows.Forms.ComboBox cboContratos;
        private System.Windows.Forms.Button btnAgregarContrato;
        private System.Windows.Forms.DataGridView dtgContrato;

    }
}