namespace Cliente.presentacion
{
    partial class Vista
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
            this.pcbSemaforo = new System.Windows.Forms.PictureBox();
            this.ckbApagado = new System.Windows.Forms.CheckBox();
            this.ckbRojo = new System.Windows.Forms.CheckBox();
            this.ckbRojoIntermitente = new System.Windows.Forms.CheckBox();
            this.ckbAmarillo = new System.Windows.Forms.CheckBox();
            this.ckbAmarilloIntermitente = new System.Windows.Forms.CheckBox();
            this.ckbVerde = new System.Windows.Forms.CheckBox();
            this.ckbVerdeIntermitente = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSemaforo)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbSemaforo
            // 
            this.pcbSemaforo.Location = new System.Drawing.Point(43, 29);
            this.pcbSemaforo.Name = "pcbSemaforo";
            this.pcbSemaforo.Size = new System.Drawing.Size(194, 337);
            this.pcbSemaforo.TabIndex = 8;
            this.pcbSemaforo.TabStop = false;
            // 
            // ckbApagado
            // 
            this.ckbApagado.AutoSize = true;
            this.ckbApagado.Location = new System.Drawing.Point(277, 59);
            this.ckbApagado.Name = "ckbApagado";
            this.ckbApagado.Size = new System.Drawing.Size(69, 17);
            this.ckbApagado.TabIndex = 9;
            this.ckbApagado.Text = "Apagado";
            this.ckbApagado.UseVisualStyleBackColor = true;
            // 
            // ckbRojo
            // 
            this.ckbRojo.AutoSize = true;
            this.ckbRojo.Location = new System.Drawing.Point(277, 95);
            this.ckbRojo.Name = "ckbRojo";
            this.ckbRojo.Size = new System.Drawing.Size(48, 17);
            this.ckbRojo.TabIndex = 10;
            this.ckbRojo.Text = "Rojo";
            this.ckbRojo.UseVisualStyleBackColor = true;
            // 
            // ckbRojoIntermitente
            // 
            this.ckbRojoIntermitente.AutoSize = true;
            this.ckbRojoIntermitente.Location = new System.Drawing.Point(360, 95);
            this.ckbRojoIntermitente.Name = "ckbRojoIntermitente";
            this.ckbRojoIntermitente.Size = new System.Drawing.Size(106, 17);
            this.ckbRojoIntermitente.TabIndex = 11;
            this.ckbRojoIntermitente.Text = "Rojo Intermitente";
            this.ckbRojoIntermitente.UseVisualStyleBackColor = true;
            // 
            // ckbAmarillo
            // 
            this.ckbAmarillo.AutoSize = true;
            this.ckbAmarillo.Location = new System.Drawing.Point(277, 133);
            this.ckbAmarillo.Name = "ckbAmarillo";
            this.ckbAmarillo.Size = new System.Drawing.Size(62, 17);
            this.ckbAmarillo.TabIndex = 12;
            this.ckbAmarillo.Text = "Amarillo";
            this.ckbAmarillo.UseVisualStyleBackColor = true;
            // 
            // ckbAmarilloIntermitente
            // 
            this.ckbAmarilloIntermitente.AutoSize = true;
            this.ckbAmarilloIntermitente.Location = new System.Drawing.Point(360, 133);
            this.ckbAmarilloIntermitente.Name = "ckbAmarilloIntermitente";
            this.ckbAmarilloIntermitente.Size = new System.Drawing.Size(120, 17);
            this.ckbAmarilloIntermitente.TabIndex = 13;
            this.ckbAmarilloIntermitente.Text = "Amarillo Intermitente";
            this.ckbAmarilloIntermitente.UseVisualStyleBackColor = true;
            // 
            // ckbVerde
            // 
            this.ckbVerde.AutoSize = true;
            this.ckbVerde.Location = new System.Drawing.Point(277, 172);
            this.ckbVerde.Name = "ckbVerde";
            this.ckbVerde.Size = new System.Drawing.Size(54, 17);
            this.ckbVerde.TabIndex = 14;
            this.ckbVerde.Text = "Verde";
            this.ckbVerde.UseVisualStyleBackColor = true;
            // 
            // ckbVerdeIntermitente
            // 
            this.ckbVerdeIntermitente.AutoSize = true;
            this.ckbVerdeIntermitente.Location = new System.Drawing.Point(360, 172);
            this.ckbVerdeIntermitente.Name = "ckbVerdeIntermitente";
            this.ckbVerdeIntermitente.Size = new System.Drawing.Size(112, 17);
            this.ckbVerdeIntermitente.TabIndex = 15;
            this.ckbVerdeIntermitente.Text = "Verde Intermitente";
            this.ckbVerdeIntermitente.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConectar);
            this.groupBox1.Controls.Add(this.txtServidor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(265, 206);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 160);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conexión";
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(77, 118);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(75, 23);
            this.btnConectar.TabIndex = 6;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(65, 92);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(136, 20);
            this.txtServidor.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Servidor";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(65, 56);
            this.txtNombre.MaxLength = 12;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(136, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(65, 19);
            this.txtID.MaxLength = 4;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(136, 20);
            this.txtID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(43, 393);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(437, 53);
            this.txtLog.TabIndex = 17;
            // 
            // Vista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 491);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ckbVerdeIntermitente);
            this.Controls.Add(this.ckbVerde);
            this.Controls.Add(this.ckbAmarilloIntermitente);
            this.Controls.Add(this.ckbAmarillo);
            this.Controls.Add(this.ckbRojoIntermitente);
            this.Controls.Add(this.ckbRojo);
            this.Controls.Add(this.ckbApagado);
            this.Controls.Add(this.pcbSemaforo);
            this.Name = "Vista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vista";
            ((System.ComponentModel.ISupportInitialize)(this.pcbSemaforo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pcbSemaforo;
        private System.Windows.Forms.CheckBox ckbApagado;
        private System.Windows.Forms.CheckBox ckbRojo;
        private System.Windows.Forms.CheckBox ckbRojoIntermitente;
        private System.Windows.Forms.CheckBox ckbAmarillo;
        private System.Windows.Forms.CheckBox ckbAmarilloIntermitente;
        private System.Windows.Forms.CheckBox ckbVerde;
        private System.Windows.Forms.CheckBox ckbVerdeIntermitente;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtLog;
    }
}