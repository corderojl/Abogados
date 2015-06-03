namespace VelayChuVIEW
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoContratoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaAsociacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaInstitucionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDocumentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDePensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expedientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contratoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.etapaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresarEmpleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarExpedienteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empleadoToolStripMenuItem,
            this.toolStripMenuItem2,
            this.archivoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(636, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoContratoToolStripMenuItem,
            this.nuevaAsociacionToolStripMenuItem,
            this.nuevaInstitucionToolStripMenuItem,
            this.gradoToolStripMenuItem,
            this.tipoClienteToolStripMenuItem,
            this.tipoDocumentoToolStripMenuItem,
            this.tipoDePensionToolStripMenuItem,
            this.expedientesToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.archivoToolStripMenuItem.Text = "Mantenimiento";
            // 
            // nuevoContratoToolStripMenuItem
            // 
            this.nuevoContratoToolStripMenuItem.Name = "nuevoContratoToolStripMenuItem";
            this.nuevoContratoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.nuevoContratoToolStripMenuItem.Text = "Usuario";
            this.nuevoContratoToolStripMenuItem.Click += new System.EventHandler(this.nuevoContratoToolStripMenuItem_Click);
            // 
            // nuevaAsociacionToolStripMenuItem
            // 
            this.nuevaAsociacionToolStripMenuItem.Name = "nuevaAsociacionToolStripMenuItem";
            this.nuevaAsociacionToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.nuevaAsociacionToolStripMenuItem.Text = "Asociacion";
            this.nuevaAsociacionToolStripMenuItem.Click += new System.EventHandler(this.nuevaAsociacionToolStripMenuItem_Click);
            // 
            // nuevaInstitucionToolStripMenuItem
            // 
            this.nuevaInstitucionToolStripMenuItem.Name = "nuevaInstitucionToolStripMenuItem";
            this.nuevaInstitucionToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.nuevaInstitucionToolStripMenuItem.Text = "Institucion";
            this.nuevaInstitucionToolStripMenuItem.Click += new System.EventHandler(this.nuevaInstitucionToolStripMenuItem_Click);
            // 
            // gradoToolStripMenuItem
            // 
            this.gradoToolStripMenuItem.Name = "gradoToolStripMenuItem";
            this.gradoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.gradoToolStripMenuItem.Text = "Grado";
            this.gradoToolStripMenuItem.Click += new System.EventHandler(this.gradoToolStripMenuItem_Click);
            // 
            // tipoClienteToolStripMenuItem
            // 
            this.tipoClienteToolStripMenuItem.Name = "tipoClienteToolStripMenuItem";
            this.tipoClienteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.tipoClienteToolStripMenuItem.Text = "Tipo Cliente";
            this.tipoClienteToolStripMenuItem.Click += new System.EventHandler(this.tipoClienteToolStripMenuItem_Click);
            // 
            // tipoDocumentoToolStripMenuItem
            // 
            this.tipoDocumentoToolStripMenuItem.Name = "tipoDocumentoToolStripMenuItem";
            this.tipoDocumentoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.tipoDocumentoToolStripMenuItem.Text = "Tipo Documento";
            this.tipoDocumentoToolStripMenuItem.Click += new System.EventHandler(this.tipoDocumentoToolStripMenuItem_Click);
            // 
            // tipoDePensionToolStripMenuItem
            // 
            this.tipoDePensionToolStripMenuItem.Name = "tipoDePensionToolStripMenuItem";
            this.tipoDePensionToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.tipoDePensionToolStripMenuItem.Text = "Tipo de Pension";
            this.tipoDePensionToolStripMenuItem.Click += new System.EventHandler(this.tipoDePensionToolStripMenuItem_Click);
            // 
            // expedientesToolStripMenuItem
            // 
            this.expedientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contratoToolStripMenuItem,
            this.eventoToolStripMenuItem,
            this.etapaToolStripMenuItem});
            this.expedientesToolStripMenuItem.Name = "expedientesToolStripMenuItem";
            this.expedientesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.expedientesToolStripMenuItem.Text = "Expedientes";
            // 
            // contratoToolStripMenuItem
            // 
            this.contratoToolStripMenuItem.Name = "contratoToolStripMenuItem";
            this.contratoToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.contratoToolStripMenuItem.Text = "Contrato";
            // 
            // eventoToolStripMenuItem
            // 
            this.eventoToolStripMenuItem.Name = "eventoToolStripMenuItem";
            this.eventoToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.eventoToolStripMenuItem.Text = "Evento";
            // 
            // etapaToolStripMenuItem
            // 
            this.etapaToolStripMenuItem.Name = "etapaToolStripMenuItem";
            this.etapaToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.etapaToolStripMenuItem.Text = "Etapa";
            this.etapaToolStripMenuItem.Click += new System.EventHandler(this.etapaToolStripMenuItem_Click);
            // 
            // empleadoToolStripMenuItem
            // 
            this.empleadoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresarEmpleadoToolStripMenuItem,
            this.toolStripMenuItem1});
            this.empleadoToolStripMenuItem.Name = "empleadoToolStripMenuItem";
            this.empleadoToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.empleadoToolStripMenuItem.Text = "Cliente";
            // 
            // ingresarEmpleadoToolStripMenuItem
            // 
            this.ingresarEmpleadoToolStripMenuItem.Name = "ingresarEmpleadoToolStripMenuItem";
            this.ingresarEmpleadoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.ingresarEmpleadoToolStripMenuItem.Text = "Registrar Cliente";
            this.ingresarEmpleadoToolStripMenuItem.Click += new System.EventHandler(this.ingresarEmpleadoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(157, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarExpedienteToolStripMenuItem1});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(81, 20);
            this.toolStripMenuItem2.Text = "Expedientes";
            // 
            // registrarExpedienteToolStripMenuItem1
            // 
            this.registrarExpedienteToolStripMenuItem1.Name = "registrarExpedienteToolStripMenuItem1";
            this.registrarExpedienteToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.registrarExpedienteToolStripMenuItem1.Text = "Registrar Expediente";
            this.registrarExpedienteToolStripMenuItem1.Click += new System.EventHandler(this.registrarExpedienteToolStripMenuItem1_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 517);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.Text = "Sisterma de Gestión de Clientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoContratoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresarEmpleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem registrarExpedienteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nuevaAsociacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaInstitucionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDocumentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDePensionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expedientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contratoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem etapaToolStripMenuItem;
    }
}