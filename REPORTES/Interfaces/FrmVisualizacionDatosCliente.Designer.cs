namespace REPORTES.Interfaces
{
    partial class FrmVisualizacionDatosCliente
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnVerPrestamos = new System.Windows.Forms.Button();
            this.btnVerPagos = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bauhaus 93", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "INFORMACIÓN DEL SISTEMA";
            // 
            // btnVerPrestamos
            // 
            this.btnVerPrestamos.BackColor = System.Drawing.Color.LightGreen;
            this.btnVerPrestamos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnVerPrestamos.Location = new System.Drawing.Point(52, 337);
            this.btnVerPrestamos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVerPrestamos.Name = "btnVerPrestamos";
            this.btnVerPrestamos.Size = new System.Drawing.Size(214, 23);
            this.btnVerPrestamos.TabIndex = 2;
            this.btnVerPrestamos.Text = "Ver Préstamos";
            this.btnVerPrestamos.UseVisualStyleBackColor = false;
            this.btnVerPrestamos.Click += new System.EventHandler(this.btnVerPrestamos_Click);
            // 
            // btnVerPagos
            // 
            this.btnVerPagos.BackColor = System.Drawing.Color.Beige;
            this.btnVerPagos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnVerPagos.Location = new System.Drawing.Point(368, 337);
            this.btnVerPagos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVerPagos.Name = "btnVerPagos";
            this.btnVerPagos.Size = new System.Drawing.Size(239, 25);
            this.btnVerPagos.TabIndex = 3;
            this.btnVerPagos.Text = "Ver Pagos";
            this.btnVerPagos.UseVisualStyleBackColor = false;
            this.btnVerPagos.Click += new System.EventHandler(this.btnVerPagos_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(11, 91);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersWidth = 62;
            this.dgvDatos.RowTemplate.Height = 28;
            this.dgvDatos.Size = new System.Drawing.Size(670, 224);
            this.dgvDatos.TabIndex = 4;
            // 
            // FrmVisualizacionDatosCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(692, 371);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnVerPagos);
            this.Controls.Add(this.btnVerPrestamos);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmVisualizacionDatosCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualización de Información";
            this.Load += new System.EventHandler(this.FrmVisualizacionDatos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVerPrestamos;
        private System.Windows.Forms.Button btnVerPagos;
        private System.Windows.Forms.DataGridView dgvDatos;
    }
}