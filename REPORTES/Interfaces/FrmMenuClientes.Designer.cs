namespace REPORTES.Interfaces
{
    partial class FrmMenuClientes
    {
        private System.ComponentModel.IContainer components = null;

        // 🔥 DECLARACIÓN DE CONTROLES (ESTO TE FALTABA)
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem préstamosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solicitarPréstamoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDePagosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verInformaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablaDeAmortizaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informaciónDeClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem totalPrestadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem morasAcumuladasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesMorososToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizacionDeMorasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el diseñador

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.préstamosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solicitarPréstamoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDePagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verInformaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.morasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vizualisarMorasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sistemaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.amortizacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaDeAmortizaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónDeClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalPrestadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.morasAcumuladasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesMorososToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizacionDeMorasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.informacionDelPropietarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.préstamosToolStripMenuItem,
            this.pagosToolStripMenuItem,
            this.consultasToolStripMenuItem,
            this.morasToolStripMenuItem,
            this.sistemaToolStripMenuItem1,
            this.amortizacionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(883, 28);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 0;
            // 
            // préstamosToolStripMenuItem
            // 
            this.préstamosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.solicitarPréstamoToolStripMenuItem});
            this.préstamosToolStripMenuItem.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.préstamosToolStripMenuItem.Name = "préstamosToolStripMenuItem";
            this.préstamosToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.préstamosToolStripMenuItem.Text = "Préstamos";
            // 
            // solicitarPréstamoToolStripMenuItem
            // 
            this.solicitarPréstamoToolStripMenuItem.Name = "solicitarPréstamoToolStripMenuItem";
            this.solicitarPréstamoToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.solicitarPréstamoToolStripMenuItem.Text = "Solicitar Préstamo";
            this.solicitarPréstamoToolStripMenuItem.Click += new System.EventHandler(this.solicitarPréstamoToolStripMenuItem_Click);
            // 
            // pagosToolStripMenuItem
            // 
            this.pagosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestiónDePagosToolStripMenuItem});
            this.pagosToolStripMenuItem.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagosToolStripMenuItem.Name = "pagosToolStripMenuItem";
            this.pagosToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.pagosToolStripMenuItem.Text = "Pagos";
            this.pagosToolStripMenuItem.Click += new System.EventHandler(this.pagosToolStripMenuItem_Click);
            // 
            // gestiónDePagosToolStripMenuItem
            // 
            this.gestiónDePagosToolStripMenuItem.Name = "gestiónDePagosToolStripMenuItem";
            this.gestiónDePagosToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.gestiónDePagosToolStripMenuItem.Text = "Gestión de Pagos";
            this.gestiónDePagosToolStripMenuItem.Click += new System.EventHandler(this.gestiónDePagosToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verInformaciónToolStripMenuItem});
            this.consultasToolStripMenuItem.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // verInformaciónToolStripMenuItem
            // 
            this.verInformaciónToolStripMenuItem.Name = "verInformaciónToolStripMenuItem";
            this.verInformaciónToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.verInformaciónToolStripMenuItem.Text = "Ver Información";
            this.verInformaciónToolStripMenuItem.Click += new System.EventHandler(this.verInformaciónToolStripMenuItem_Click);
            // 
            // morasToolStripMenuItem
            // 
            this.morasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vizualisarMorasToolStripMenuItem});
            this.morasToolStripMenuItem.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.morasToolStripMenuItem.Name = "morasToolStripMenuItem";
            this.morasToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.morasToolStripMenuItem.Text = "Moras";
            this.morasToolStripMenuItem.Click += new System.EventHandler(this.morasToolStripMenuItem_Click_1);
            // 
            // vizualisarMorasToolStripMenuItem
            // 
            this.vizualisarMorasToolStripMenuItem.Name = "vizualisarMorasToolStripMenuItem";
            this.vizualisarMorasToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.vizualisarMorasToolStripMenuItem.Text = "Vizualisar Moras";
            // 
            // sistemaToolStripMenuItem1
            // 
            this.sistemaToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sistemaToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem1});
            this.sistemaToolStripMenuItem1.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sistemaToolStripMenuItem1.Name = "sistemaToolStripMenuItem1";
            this.sistemaToolStripMenuItem1.Size = new System.Drawing.Size(77, 24);
            this.sistemaToolStripMenuItem1.Text = "Sistema";
            // 
            // salirToolStripMenuItem1
            // 
            this.salirToolStripMenuItem1.Name = "salirToolStripMenuItem1";
            this.salirToolStripMenuItem1.Size = new System.Drawing.Size(122, 26);
            this.salirToolStripMenuItem1.Text = "Salir";
            this.salirToolStripMenuItem1.Click += new System.EventHandler(this.salirToolStripMenuItem1_Click);
            // 
            // amortizacionesToolStripMenuItem
            // 
            this.amortizacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informacionDelPropietarioToolStripMenuItem});
            this.amortizacionesToolStripMenuItem.Name = "amortizacionesToolStripMenuItem";
            this.amortizacionesToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.amortizacionesToolStripMenuItem.Text = "Amortizaciones";
            this.amortizacionesToolStripMenuItem.Click += new System.EventHandler(this.amortizacionesToolStripMenuItem_Click);
            // 
            // tablaDeAmortizaciónToolStripMenuItem
            // 
            this.tablaDeAmortizaciónToolStripMenuItem.Name = "tablaDeAmortizaciónToolStripMenuItem";
            this.tablaDeAmortizaciónToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // informaciónDeClienteToolStripMenuItem
            // 
            this.informaciónDeClienteToolStripMenuItem.Name = "informaciónDeClienteToolStripMenuItem";
            this.informaciónDeClienteToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // totalPrestadoToolStripMenuItem
            // 
            this.totalPrestadoToolStripMenuItem.Name = "totalPrestadoToolStripMenuItem";
            this.totalPrestadoToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // morasAcumuladasToolStripMenuItem
            // 
            this.morasAcumuladasToolStripMenuItem.Name = "morasAcumuladasToolStripMenuItem";
            this.morasAcumuladasToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // clientesMorososToolStripMenuItem
            // 
            this.clientesMorososToolStripMenuItem.Name = "clientesMorososToolStripMenuItem";
            this.clientesMorososToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // visualizacionDeMorasToolStripMenuItem
            // 
            this.visualizacionDeMorasToolStripMenuItem.Name = "visualizacionDeMorasToolStripMenuItem";
            this.visualizacionDeMorasToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "SISTEMA DE GESTIÓN DE PRÉSTAMOS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Administración financiera";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Bauhaus 93", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label3.Location = new System.Drawing.Point(81, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(718, 50);
            this.label3.TabIndex = 4;
            this.label3.Text = "SISTEMA DE GESTIÓN DE PRÉSTAMOS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(311, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(253, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "Administración financiera";
            // 
            // informacionDelPropietarioToolStripMenuItem
            // 
            this.informacionDelPropietarioToolStripMenuItem.Name = "informacionDelPropietarioToolStripMenuItem";
            this.informacionDelPropietarioToolStripMenuItem.Size = new System.Drawing.Size(276, 26);
            this.informacionDelPropietarioToolStripMenuItem.Text = "Informacion del propietario";
            this.informacionDelPropietarioToolStripMenuItem.Click += new System.EventHandler(this.informacionDelPropietarioToolStripMenuItem_Click);
            // 
            // FrmMenuClientes
            // 
            this.ClientSize = new System.Drawing.Size(883, 253);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenuClientes";
            this.Text = "Sistema de Reportes";
            this.Load += new System.EventHandler(this.FrmMenuClientes_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem morasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vizualisarMorasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem amortizacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informacionDelPropietarioToolStripMenuItem;
    }
}