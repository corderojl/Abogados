namespace VelayChuVIEW
{
    partial class FrmExpedienteMan3
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
            this.gpbCliente = new System.Windows.Forms.GroupBox();
            this.lblCodigoCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboSala = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboEspecialista = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboJuzgado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExpediente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgContrato = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtgDocumento = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dtgDetalle = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cboContrato = new System.Windows.Forms.ComboBox();
            this.btnAgregarContrato = new System.Windows.Forms.Button();
            this.gpbCliente.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgContrato)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocumento)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalle)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbCliente
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gpbCliente, 4);
            this.gpbCliente.Controls.Add(this.lblCodigoCliente);
            this.gpbCliente.Controls.Add(this.txtCliente);
            this.gpbCliente.Controls.Add(this.label7);
            this.gpbCliente.Controls.Add(this.cboSala);
            this.gpbCliente.Controls.Add(this.label5);
            this.gpbCliente.Controls.Add(this.cboEspecialista);
            this.gpbCliente.Controls.Add(this.label6);
            this.gpbCliente.Controls.Add(this.cboJuzgado);
            this.gpbCliente.Controls.Add(this.label4);
            this.gpbCliente.Controls.Add(this.label2);
            this.gpbCliente.Controls.Add(this.txtExpediente);
            this.gpbCliente.Controls.Add(this.label1);
            this.gpbCliente.Controls.Add(this.dtpFecha);
            this.gpbCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbCliente.Enabled = false;
            this.gpbCliente.Location = new System.Drawing.Point(3, 3);
            this.gpbCliente.Name = "gpbCliente";
            this.tableLayoutPanel1.SetRowSpan(this.gpbCliente, 3);
            this.gpbCliente.Size = new System.Drawing.Size(798, 78);
            this.gpbCliente.TabIndex = 0;
            this.gpbCliente.TabStop = false;
            this.gpbCliente.Text = "Expediente";
            // 
            // lblCodigoCliente
            // 
            this.lblCodigoCliente.AutoSize = true;
            this.lblCodigoCliente.Location = new System.Drawing.Point(172, 19);
            this.lblCodigoCliente.Name = "lblCodigoCliente";
            this.lblCodigoCliente.Size = new System.Drawing.Size(0, 13);
            this.lblCodigoCliente.TabIndex = 15;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(295, 13);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(269, 20);
            this.txtCliente.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(626, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Fecha:";
            // 
            // cboSala
            // 
            this.cboSala.FormattingEnabled = true;
            this.cboSala.Location = new System.Drawing.Point(681, 42);
            this.cboSala.Name = "cboSala";
            this.cboSala.Size = new System.Drawing.Size(101, 21);
            this.cboSala.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(626, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Sala:";
            // 
            // cboEspecialista
            // 
            this.cboEspecialista.FormattingEnabled = true;
            this.cboEspecialista.Location = new System.Drawing.Point(295, 42);
            this.cboEspecialista.Name = "cboEspecialista";
            this.cboEspecialista.Size = new System.Drawing.Size(269, 21);
            this.cboEspecialista.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Especialista:";
            // 
            // cboJuzgado
            // 
            this.cboJuzgado.FormattingEnabled = true;
            this.cboJuzgado.Location = new System.Drawing.Point(62, 42);
            this.cboJuzgado.Name = "cboJuzgado";
            this.cboJuzgado.Size = new System.Drawing.Size(91, 21);
            this.cboJuzgado.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Juzgado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cliente:";
            // 
            // txtExpediente
            // 
            this.txtExpediente.Location = new System.Drawing.Point(91, 13);
            this.txtExpediente.Name = "txtExpediente";
            this.txtExpediente.Size = new System.Drawing.Size(65, 20);
            this.txtExpediente.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nº Expediente:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(681, 13);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(101, 20);
            this.dtpFecha.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 2);
            this.groupBox2.Controls.Add(this.dtgContrato);
            this.groupBox2.Location = new System.Drawing.Point(3, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 217);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contratos";
            // 
            // dtgContrato
            // 
            this.dtgContrato.AllowUserToAddRows = false;
            this.dtgContrato.AllowUserToDeleteRows = false;
            this.dtgContrato.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgContrato.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dtgContrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgContrato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgContrato.Location = new System.Drawing.Point(3, 16);
            this.dtgContrato.Name = "dtgContrato";
            this.dtgContrato.ReadOnly = true;
            this.dtgContrato.RowHeadersVisible = false;
            this.dtgContrato.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgContrato.Size = new System.Drawing.Size(444, 198);
            this.dtgContrato.TabIndex = 0;
            
            this.dtgContrato.Click += new System.EventHandler(this.dtgContrato_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox3, 2);
            this.groupBox3.Controls.Add(this.dtgDocumento);
            this.groupBox3.Location = new System.Drawing.Point(582, 115);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(423, 217);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Documentos";
            // 
            // dtgDocumento
            // 
            this.dtgDocumento.AllowUserToAddRows = false;
            this.dtgDocumento.AllowUserToDeleteRows = false;
            this.dtgDocumento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDocumento.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dtgDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDocumento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDocumento.Location = new System.Drawing.Point(3, 16);
            this.dtgDocumento.Name = "dtgDocumento";
            this.dtgDocumento.ReadOnly = true;
            this.dtgDocumento.RowHeadersVisible = false;
            this.dtgDocumento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDocumento.Size = new System.Drawing.Size(417, 198);
            this.dtgDocumento.TabIndex = 0;
            this.dtgDocumento.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDocumento_CellContentDoubleClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox5, 5);
            this.groupBox5.Controls.Add(this.dtgDetalle);
            this.groupBox5.Location = new System.Drawing.Point(3, 338);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1002, 221);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Detalles";
            // 
            // dtgDetalle
            // 
            this.dtgDetalle.AllowUserToAddRows = false;
            this.dtgDetalle.AllowUserToDeleteRows = false;
            this.dtgDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dtgDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDetalle.Location = new System.Drawing.Point(3, 16);
            this.dtgDetalle.Name = "dtgDetalle";
            this.dtgDetalle.ReadOnly = true;
            this.dtgDetalle.RowHeadersVisible = false;
            this.dtgDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalle.Size = new System.Drawing.Size(996, 202);
            this.dtgDetalle.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.29762F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.20238F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.32143F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.gpbCliente, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnActualizar, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGuardar, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.cboContrato, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAgregarContrato, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.102041F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.102041F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.102041F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.102041F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.79592F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.79592F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 562);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnActualizar.Location = new System.Drawing.Point(807, 3);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(198, 22);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGuardar.Location = new System.Drawing.Point(807, 31);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(198, 22);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelar.Location = new System.Drawing.Point(807, 59);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(198, 22);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cboContrato
            // 
            this.cboContrato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboContrato.FormattingEnabled = true;
            this.cboContrato.Location = new System.Drawing.Point(3, 87);
            this.cboContrato.Name = "cboContrato";
            this.cboContrato.Size = new System.Drawing.Size(195, 21);
            this.cboContrato.TabIndex = 7;
            // 
            // btnAgregarContrato
            // 
            this.btnAgregarContrato.Location = new System.Drawing.Point(204, 87);
            this.btnAgregarContrato.Name = "btnAgregarContrato";
            this.btnAgregarContrato.Size = new System.Drawing.Size(113, 22);
            this.btnAgregarContrato.TabIndex = 8;
            this.btnAgregarContrato.Text = "Agregar Contrato";
            this.btnAgregarContrato.UseVisualStyleBackColor = true;
            this.btnAgregarContrato.Click += new System.EventHandler(this.btnAgregarContrato_Click);
            // 
            // FrmExpedienteMan3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmExpedienteMan3";
            this.Text = "FrmExpedienteMan3";
            this.Load += new System.EventHandler(this.FrmExpedienteMan3_Load);
            this.gpbCliente.ResumeLayout(false);
            this.gpbCliente.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgContrato)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocumento)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalle)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExpediente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboSala;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboEspecialista;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboJuzgado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgContrato;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtgDocumento;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dtgDetalle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblCodigoCliente;
        private System.Windows.Forms.ComboBox cboContrato;
        private System.Windows.Forms.Button btnAgregarContrato;
    }
}