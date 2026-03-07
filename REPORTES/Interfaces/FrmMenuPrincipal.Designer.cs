namespace REPORTES.Interfaces
{
    partial class FrmMenuPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.préstamosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solicitarPréstamoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDePagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verInformaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sistemaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaDeAmortizaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónDeClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalPrestadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.morasAcumuladasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesMorososToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.préstamosToolStripMenuItem,
            this.pagosToolStripMenuItem,
            this.consultasToolStripMenuItem,
            this.sistemaToolStripMenuItem,
            this.sistemaToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(978, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bauhaus 93", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(850, 59);
            this.label1.TabIndex = 1;
            this.label1.Text = "SISTEMA DE GESTIÓN DE PRÉSTAMOS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 34);
            this.label2.TabIndex = 2;
            this.label2.Text = "Administración financiera";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarClienteToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(89, 29);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // registrarClienteToolStripMenuItem
            // 
            this.registrarClienteToolStripMenuItem.Name = "registrarClienteToolStripMenuItem";
            this.registrarClienteToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.registrarClienteToolStripMenuItem.Text = "Registrar Cliente";
            this.registrarClienteToolStripMenuItem.Click += new System.EventHandler(this.registrarClienteToolStripMenuItem_Click);
            // 
            // préstamosToolStripMenuItem
            // 
            this.préstamosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.solicitarPréstamoToolStripMenuItem});
            this.préstamosToolStripMenuItem.Name = "préstamosToolStripMenuItem";
            this.préstamosToolStripMenuItem.Size = new System.Drawing.Size(111, 29);
            this.préstamosToolStripMenuItem.Text = "Préstamos";
            // 
            // solicitarPréstamoToolStripMenuItem
            // 
            this.solicitarPréstamoToolStripMenuItem.Name = "solicitarPréstamoToolStripMenuItem";
            this.solicitarPréstamoToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.solicitarPréstamoToolStripMenuItem.Text = "Solicitar Préstamo";
            this.solicitarPréstamoToolStripMenuItem.Click += new System.EventHandler(this.solicitarPréstamoToolStripMenuItem_Click);
            // 
            // pagosToolStripMenuItem
            // 
            this.pagosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestiónDePagosToolStripMenuItem});
            this.pagosToolStripMenuItem.Name = "pagosToolStripMenuItem";
            this.pagosToolStripMenuItem.Size = new System.Drawing.Size(76, 29);
            this.pagosToolStripMenuItem.Text = "Pagos";
            // 
            // gestiónDePagosToolStripMenuItem
            // 
            this.gestiónDePagosToolStripMenuItem.Name = "gestiónDePagosToolStripMenuItem";
            this.gestiónDePagosToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.gestiónDePagosToolStripMenuItem.Text = "Gestión de Pagos";
            this.gestiónDePagosToolStripMenuItem.Click += new System.EventHandler(this.gestiónDePagosToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verInformaciónToolStripMenuItem});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // verInformaciónToolStripMenuItem
            // 
            this.verInformaciónToolStripMenuItem.Name = "verInformaciónToolStripMenuItem";
            this.verInformaciónToolStripMenuItem.Size = new System.Drawing.Size(270, 58);
            this.verInformaciónToolStripMenuItem.Text = "Ver Información\n";
            this.verInformaciónToolStripMenuItem.Click += new System.EventHandler(this.verInformaciónToolStripMenuItem_Click);
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tablaDeAmortizaciónToolStripMenuItem,
            this.informaciónDeClienteToolStripMenuItem,
            this.totalPrestadoToolStripMenuItem,
            this.morasAcumuladasToolStripMenuItem,
            this.clientesMorososToolStripMenuItem});
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.sistemaToolStripMenuItem.Text = "Reportes";
            // 
            // sistemaToolStripMenuItem1
            // 
            this.sistemaToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem1});
            this.sistemaToolStripMenuItem1.Name = "sistemaToolStripMenuItem1";
            this.sistemaToolStripMenuItem1.Size = new System.Drawing.Size(90, 29);
            this.sistemaToolStripMenuItem1.Text = "Sistema";
            // 
            // salirToolStripMenuItem1
            // 
            this.salirToolStripMenuItem1.Name = "salirToolStripMenuItem1";
            this.salirToolStripMenuItem1.Size = new System.Drawing.Size(270, 34);
            this.salirToolStripMenuItem1.Text = "Salir";
            // 
            // tablaDeAmortizaciónToolStripMenuItem
            // 
            this.tablaDeAmortizaciónToolStripMenuItem.Name = "tablaDeAmortizaciónToolStripMenuItem";
            this.tablaDeAmortizaciónToolStripMenuItem.Size = new System.Drawing.Size(290, 34);
            this.tablaDeAmortizaciónToolStripMenuItem.Text = "Tabla de amortización";
            // 
            // informaciónDeClienteToolStripMenuItem
            // 
            this.informaciónDeClienteToolStripMenuItem.Name = "informaciónDeClienteToolStripMenuItem";
            this.informaciónDeClienteToolStripMenuItem.Size = new System.Drawing.Size(290, 34);
            this.informaciónDeClienteToolStripMenuItem.Text = "Información de cliente";
            // 
            // totalPrestadoToolStripMenuItem
            // 
            this.totalPrestadoToolStripMenuItem.Name = "totalPrestadoToolStripMenuItem";
            this.totalPrestadoToolStripMenuItem.Size = new System.Drawing.Size(290, 34);
            this.totalPrestadoToolStripMenuItem.Text = "Total prestado";
            // 
            // morasAcumuladasToolStripMenuItem
            // 
            this.morasAcumuladasToolStripMenuItem.Name = "morasAcumuladasToolStripMenuItem";
            this.morasAcumuladasToolStripMenuItem.Size = new System.Drawing.Size(290, 34);
            this.morasAcumuladasToolStripMenuItem.Text = "Moras acumuladas";
            // 
            // clientesMorososToolStripMenuItem
            // 
            this.clientesMorososToolStripMenuItem.Name = "clientesMorososToolStripMenuItem";
            this.clientesMorososToolStripMenuItem.Size = new System.Drawing.Size(290, 34);
            this.clientesMorososToolStripMenuItem.Text = "Clientes morosos";
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(978, 544);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Reportes";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem préstamosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solicitarPréstamoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDePagosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verInformaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tablaDeAmortizaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informaciónDeClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem totalPrestadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem morasAcumuladasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesMorososToolStripMenuItem;
    }
}