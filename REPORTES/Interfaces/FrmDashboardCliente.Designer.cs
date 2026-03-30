namespace REPORTES.Interfaces
{
    partial class FrmDashboardCliente
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel cardMonto;
        private System.Windows.Forms.Panel cardBalance;
        private System.Windows.Forms.Panel cardEstado;
        private System.Windows.Forms.Panel cardProximoPago;

        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblNombre;

        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblProximoPago;

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgreso;

        private System.Windows.Forms.DataGridView dgvPagos;
        private System.Windows.Forms.Button btnPagar;

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox cmbPrestamos;

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.cmbPrestamos = new System.Windows.Forms.ComboBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.cardMonto = new System.Windows.Forms.Panel();
            this.lblMonto = new System.Windows.Forms.Label();
            this.cardBalance = new System.Windows.Forms.Panel();
            this.lblBalance = new System.Windows.Forms.Label();
            this.cardEstado = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cardProximoPago = new System.Windows.Forms.Panel();
            this.lblProximoPago = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgreso = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.dgvPagos = new System.Windows.Forms.DataGridView();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panelTop.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.cardMonto.SuspendLayout();
            this.cardBalance.SuspendLayout();
            this.cardEstado.SuspendLayout();
            this.cardProximoPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.lblBienvenida);
            this.panelTop.Controls.Add(this.lblNombre);
            this.panelTop.Controls.Add(this.cmbPrestamos);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1298, 80);
            this.panelTop.TabIndex = 1;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.ForeColor = System.Drawing.Color.Gray;
            this.lblBienvenida.Location = new System.Drawing.Point(20, 10);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(100, 23);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Bienvenido:";
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(20, 30);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(228, 47);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Cliente";
            // 
            // cmbPrestamos
            // 
            this.cmbPrestamos.Location = new System.Drawing.Point(400, 30);
            this.cmbPrestamos.Name = "cmbPrestamos";
            this.cmbPrestamos.Size = new System.Drawing.Size(400, 24);
            this.cmbPrestamos.TabIndex = 2;
            this.cmbPrestamos.SelectedIndexChanged += new System.EventHandler(this.cmbPrestamos_SelectedIndexChanged);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.cardMonto);
            this.panelMain.Controls.Add(this.cardBalance);
            this.panelMain.Controls.Add(this.cardEstado);
            this.panelMain.Controls.Add(this.cardProximoPago);
            this.panelMain.Controls.Add(this.progressBar1);
            this.panelMain.Controls.Add(this.lblProgreso);
            this.panelMain.Controls.Add(this.btnPagar);
            this.panelMain.Controls.Add(this.dgvPagos);
            this.panelMain.Controls.Add(this.reportViewer1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 80);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1298, 620);
            this.panelMain.TabIndex = 0;
            // 
            // cardMonto
            // 
            this.cardMonto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.cardMonto.Controls.Add(this.lblMonto);
            this.cardMonto.Location = new System.Drawing.Point(30, 30);
            this.cardMonto.Name = "cardMonto";
            this.cardMonto.Size = new System.Drawing.Size(250, 100);
            this.cardMonto.TabIndex = 0;
            // 
            // lblMonto
            // 
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMonto.ForeColor = System.Drawing.Color.Black;
            this.lblMonto.Location = new System.Drawing.Point(10, 40);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(100, 23);
            this.lblMonto.TabIndex = 0;
            this.lblMonto.Text = "RD$0.00";
            // 
            // cardBalance
            // 
            this.cardBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.cardBalance.Controls.Add(this.lblBalance);
            this.cardBalance.Location = new System.Drawing.Point(300, 30);
            this.cardBalance.Name = "cardBalance";
            this.cardBalance.Size = new System.Drawing.Size(250, 100);
            this.cardBalance.TabIndex = 1;
            // 
            // lblBalance
            // 
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBalance.ForeColor = System.Drawing.Color.Black;
            this.lblBalance.Location = new System.Drawing.Point(10, 40);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(100, 23);
            this.lblBalance.TabIndex = 0;
            this.lblBalance.Text = "RD$0.00";
            // 
            // cardEstado
            // 
            this.cardEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cardEstado.Controls.Add(this.lblEstado);
            this.cardEstado.Location = new System.Drawing.Point(570, 30);
            this.cardEstado.Name = "cardEstado";
            this.cardEstado.Size = new System.Drawing.Size(250, 100);
            this.cardEstado.TabIndex = 2;
            this.cardEstado.Paint += new System.Windows.Forms.PaintEventHandler(this.cardEstado_Paint);
            // 
            // lblEstado
            // 
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.Green;
            this.lblEstado.Location = new System.Drawing.Point(10, 40);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(100, 23);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.Text = "Al día";
            // 
            // cardProximoPago
            // 
            this.cardProximoPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.cardProximoPago.Controls.Add(this.lblProximoPago);
            this.cardProximoPago.Location = new System.Drawing.Point(840, 30);
            this.cardProximoPago.Name = "cardProximoPago";
            this.cardProximoPago.Size = new System.Drawing.Size(250, 100);
            this.cardProximoPago.TabIndex = 3;
            // 
            // lblProximoPago
            // 
            this.lblProximoPago.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblProximoPago.ForeColor = System.Drawing.Color.Black;
            this.lblProximoPago.Location = new System.Drawing.Point(10, 40);
            this.lblProximoPago.Name = "lblProximoPago";
            this.lblProximoPago.Size = new System.Drawing.Size(100, 23);
            this.lblProximoPago.TabIndex = 0;
            this.lblProximoPago.Text = "--/--/----";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(230)))), ((int)(((byte)(207)))));
            this.progressBar1.Location = new System.Drawing.Point(30, 150);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(600, 20);
            this.progressBar1.TabIndex = 4;
            // 
            // lblProgreso
            // 
            this.lblProgreso.ForeColor = System.Drawing.Color.Black;
            this.lblProgreso.Location = new System.Drawing.Point(650, 150);
            this.lblProgreso.Name = "lblProgreso";
            this.lblProgreso.Size = new System.Drawing.Size(100, 23);
            this.lblProgreso.TabIndex = 5;
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(230)))), ((int)(((byte)(207)))));
            this.btnPagar.FlatAppearance.BorderSize = 0;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPagar.ForeColor = System.Drawing.Color.Transparent;
            this.btnPagar.Location = new System.Drawing.Point(1110, 40);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(150, 60);
            this.btnPagar.TabIndex = 6;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = false;
            // 
            // dgvPagos
            // 
            this.dgvPagos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPagos.ColumnHeadersHeight = 29;
            this.dgvPagos.Location = new System.Drawing.Point(30, 200);
            this.dgvPagos.Name = "dgvPagos";
            this.dgvPagos.RowHeadersWidth = 51;
            this.dgvPagos.Size = new System.Drawing.Size(600, 380);
            this.dgvPagos.TabIndex = 7;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(650, 200);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(620, 380);
            this.reportViewer1.TabIndex = 8;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // FrmDashboardCliente
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1298, 700);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTop);
            this.Name = "FrmDashboardCliente";
            this.Text = "Dashboard Cliente";
            this.Load += new System.EventHandler(this.FrmDashboardCliente_Load);
            this.panelTop.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.cardMonto.ResumeLayout(false);
            this.cardBalance.ResumeLayout(false);
            this.cardEstado.ResumeLayout(false);
            this.cardProximoPago.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}