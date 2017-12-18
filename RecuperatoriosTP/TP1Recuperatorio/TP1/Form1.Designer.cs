namespace TP1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnOperar = new System.Windows.Forms.Button();
            this.BtnCBinario = new System.Windows.Forms.Button();
            this.BtnCDecimal = new System.Windows.Forms.Button();
            this.LblResu = new System.Windows.Forms.Label();
            this.TxtBox1 = new System.Windows.Forms.TextBox();
            this.TxtBox2 = new System.Windows.Forms.TextBox();
            this.CmbBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Location = new System.Drawing.Point(278, 107);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(109, 32);
            this.BtnCerrar.TabIndex = 2;
            this.BtnCerrar.Text = "Cerrar";
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Location = new System.Drawing.Point(154, 107);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(109, 32);
            this.BtnLimpiar.TabIndex = 3;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnOperar
            // 
            this.BtnOperar.Location = new System.Drawing.Point(11, 107);
            this.BtnOperar.Name = "BtnOperar";
            this.BtnOperar.Size = new System.Drawing.Size(127, 32);
            this.BtnOperar.TabIndex = 4;
            this.BtnOperar.Text = "Operar";
            this.BtnOperar.UseVisualStyleBackColor = true;
            this.BtnOperar.Click += new System.EventHandler(this.BtnOperar_Click);
            // 
            // BtnCBinario
            // 
            this.BtnCBinario.Location = new System.Drawing.Point(11, 154);
            this.BtnCBinario.Name = "BtnCBinario";
            this.BtnCBinario.Size = new System.Drawing.Size(182, 32);
            this.BtnCBinario.TabIndex = 5;
            this.BtnCBinario.Text = "Convertir a Binario";
            this.BtnCBinario.UseVisualStyleBackColor = true;
            this.BtnCBinario.Click += new System.EventHandler(this.BtnCBinario_Click);
            // 
            // BtnCDecimal
            // 
            this.BtnCDecimal.Location = new System.Drawing.Point(205, 154);
            this.BtnCDecimal.Name = "BtnCDecimal";
            this.BtnCDecimal.Size = new System.Drawing.Size(182, 32);
            this.BtnCDecimal.TabIndex = 6;
            this.BtnCDecimal.Text = "Convertir a Decimal";
            this.BtnCDecimal.UseVisualStyleBackColor = true;
            this.BtnCDecimal.Click += new System.EventHandler(this.BtnCDecimal_Click);
            // 
            // LblResu
            // 
            this.LblResu.AutoSize = true;
            this.LblResu.Location = new System.Drawing.Point(249, 9);
            this.LblResu.Name = "LblResu";
            this.LblResu.Size = new System.Drawing.Size(0, 13);
            this.LblResu.TabIndex = 7;
            // 
            // TxtBox1
            // 
            this.TxtBox1.BackColor = System.Drawing.Color.White;
            this.TxtBox1.Location = new System.Drawing.Point(12, 58);
            this.TxtBox1.Name = "TxtBox1";
            this.TxtBox1.Size = new System.Drawing.Size(126, 20);
            this.TxtBox1.TabIndex = 8;
            // 
            // TxtBox2
            // 
            this.TxtBox2.Location = new System.Drawing.Point(278, 58);
            this.TxtBox2.Name = "TxtBox2";
            this.TxtBox2.Size = new System.Drawing.Size(109, 20);
            this.TxtBox2.TabIndex = 9;
            // 
            // CmbBox
            // 
            this.CmbBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbBox.FormattingEnabled = true;
            this.CmbBox.Items.AddRange(new object[] {
            "-",
            "+",
            "*",
            "/"});
            this.CmbBox.Location = new System.Drawing.Point(165, 58);
            this.CmbBox.Name = "CmbBox";
            this.CmbBox.Size = new System.Drawing.Size(84, 21);
            this.CmbBox.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 203);
            this.Controls.Add(this.CmbBox);
            this.Controls.Add(this.TxtBox2);
            this.Controls.Add(this.TxtBox1);
            this.Controls.Add(this.LblResu);
            this.Controls.Add(this.BtnCDecimal);
            this.Controls.Add(this.BtnCBinario);
            this.Controls.Add(this.BtnOperar);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.BtnCerrar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnOperar;
        private System.Windows.Forms.Button BtnCBinario;
        private System.Windows.Forms.Button BtnCDecimal;
        private System.Windows.Forms.Label LblResu;
        private System.Windows.Forms.TextBox TxtBox1;
        private System.Windows.Forms.TextBox TxtBox2;
        private System.Windows.Forms.ComboBox CmbBox;
    }
}

