namespace REPORTES.Interfaces
{
    partial class FrmGestionPagosClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestionPagosClientes));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnRegistrarPago = new System.Windows.Forms.Button();
            this.btnCalcularPago = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalIntereses = new System.Windows.Forms.TextBox();
            this.txtMesesRestantes = new System.Windows.Forms.TextBox();
            this.txtNuevoMonto = new System.Windows.Forms.TextBox();
            this.txtCuota = new System.Windows.Forms.TextBox();
            this.txtInteres = new System.Windows.Forms.TextBox();
            this.txtMontoAnterior = new System.Windows.Forms.TextBox();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(50, 481);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(608, 134);
            this.dataGridView1.TabIndex = 37;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.BackgroundImage")));
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiar.Location = new System.Drawing.Point(607, 76);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(51, 35);
            this.btnLimpiar.TabIndex = 36;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnRegistrarPago
            // 
            this.btnRegistrarPago.BackColor = System.Drawing.Color.LightGreen;
            this.btnRegistrarPago.Location = new System.Drawing.Point(334, 439);
            this.btnRegistrarPago.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegistrarPago.Name = "btnRegistrarPago";
            this.btnRegistrarPago.Size = new System.Drawing.Size(272, 26);
            this.btnRegistrarPago.TabIndex = 35;
            this.btnRegistrarPago.Text = "Registrar Pago";
            this.btnRegistrarPago.UseVisualStyleBackColor = false;
            this.btnRegistrarPago.Click += new System.EventHandler(this.btnRegistrarPago_Click);
            // 
            // btnCalcularPago
            // 
            this.btnCalcularPago.BackColor = System.Drawing.Color.LightBlue;
            this.btnCalcularPago.Location = new System.Drawing.Point(49, 439);
            this.btnCalcularPago.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCalcularPago.Name = "btnCalcularPago";
            this.btnCalcularPago.Size = new System.Drawing.Size(272, 26);
            this.btnCalcularPago.TabIndex = 34;
            this.btnCalcularPago.Text = "Calcular Pago";
            this.btnCalcularPago.UseVisualStyleBackColor = false;
            this.btnCalcularPago.Click += new System.EventHandler(this.btnCalcularPago_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(93, 372);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 26);
            this.label8.TabIndex = 33;
            this.label8.Text = "Total Intereses:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(92, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 26);
            this.label7.TabIndex = 32;
            this.label7.Text = "Meses Restantes:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(92, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 26);
            this.label6.TabIndex = 31;
            this.label6.Text = "Nuevo Monto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(92, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 26);
            this.label5.TabIndex = 30;
            this.label5.Text = "Interés: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(86, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 26);
            this.label4.TabIndex = 29;
            this.label4.Text = "Cuota:   ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(86, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 26);
            this.label3.TabIndex = 28;
            this.label3.Text = "Monto Anterior: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(86, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 26);
            this.label2.TabIndex = 27;
            this.label2.Text = "Cliente:  ";
            // 
            // txtTotalIntereses
            // 
            this.txtTotalIntereses.Location = new System.Drawing.Point(272, 376);
            this.txtTotalIntereses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotalIntereses.Name = "txtTotalIntereses";
            this.txtTotalIntereses.ReadOnly = true;
            this.txtTotalIntereses.Size = new System.Drawing.Size(313, 22);
            this.txtTotalIntereses.TabIndex = 26;
            // 
            // txtMesesRestantes
            // 
            this.txtMesesRestantes.Location = new System.Drawing.Point(272, 334);
            this.txtMesesRestantes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMesesRestantes.Name = "txtMesesRestantes";
            this.txtMesesRestantes.Size = new System.Drawing.Size(313, 22);
            this.txtMesesRestantes.TabIndex = 25;
            // 
            // txtNuevoMonto
            // 
            this.txtNuevoMonto.Location = new System.Drawing.Point(272, 289);
            this.txtNuevoMonto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNuevoMonto.Name = "txtNuevoMonto";
            this.txtNuevoMonto.ReadOnly = true;
            this.txtNuevoMonto.Size = new System.Drawing.Size(313, 22);
            this.txtNuevoMonto.TabIndex = 24;
            // 
            // txtCuota
            // 
            this.txtCuota.Location = new System.Drawing.Point(272, 207);
            this.txtCuota.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCuota.Name = "txtCuota";
            this.txtCuota.Size = new System.Drawing.Size(313, 22);
            this.txtCuota.TabIndex = 23;
            // 
            // txtInteres
            // 
            this.txtInteres.Location = new System.Drawing.Point(272, 246);
            this.txtInteres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInteres.Name = "txtInteres";
            this.txtInteres.ReadOnly = true;
            this.txtInteres.Size = new System.Drawing.Size(313, 22);
            this.txtInteres.TabIndex = 22;
            // 
            // txtMontoAnterior
            // 
            this.txtMontoAnterior.Location = new System.Drawing.Point(272, 166);
            this.txtMontoAnterior.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMontoAnterior.Name = "txtMontoAnterior";
            this.txtMontoAnterior.Size = new System.Drawing.Size(313, 22);
            this.txtMontoAnterior.TabIndex = 21;
            // 
            // cmbCliente
            // 
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(272, 120);
            this.cmbCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(313, 24);
            this.cmbCliente.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bauhaus 93", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(191, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 34);
            this.label1.TabIndex = 19;
            this.label1.Text = "GESTIÓN DE PAGOS";
            // 
            // FrmGestionPagosClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 644);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnRegistrarPago);
            this.Controls.Add(this.btnCalcularPago);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalIntereses);
            this.Controls.Add(this.txtMesesRestantes);
            this.Controls.Add(this.txtNuevoMonto);
            this.Controls.Add(this.txtCuota);
            this.Controls.Add(this.txtInteres);
            this.Controls.Add(this.txtMontoAnterior);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.label1);
            this.Name = "FrmGestionPagosClientes";
            this.Text = "FrmGestionPagosClientes";
            this.Load += new System.EventHandler(this.FrmGestionPagosClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnRegistrarPago;
        private System.Windows.Forms.Button btnCalcularPago;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalIntereses;
        private System.Windows.Forms.TextBox txtMesesRestantes;
        private System.Windows.Forms.TextBox txtNuevoMonto;
        private System.Windows.Forms.TextBox txtCuota;
        private System.Windows.Forms.TextBox txtInteres;
        private System.Windows.Forms.TextBox txtMontoAnterior;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label label1;
    }
}