
namespace Compilador_sensor
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtConsola = new System.Windows.Forms.TextBox();
            this.TxtArchivo = new System.Windows.Forms.TextBox();
            this.BtnCarga = new System.Windows.Forms.Button();
            this.RbtnArchivo = new System.Windows.Forms.RadioButton();
            this.RbtnConsola = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtConsola);
            this.groupBox2.Controls.Add(this.TxtArchivo);
            this.groupBox2.Controls.Add(this.BtnCarga);
            this.groupBox2.Controls.Add(this.RbtnArchivo);
            this.groupBox2.Controls.Add(this.RbtnConsola);
            this.groupBox2.Location = new System.Drawing.Point(31, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(757, 228);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cargar destino";
            // 
            // txtConsola
            // 
            this.txtConsola.Location = new System.Drawing.Point(6, 72);
            this.txtConsola.Multiline = true;
            this.txtConsola.Name = "txtConsola";
            this.txtConsola.Size = new System.Drawing.Size(500, 98);
            this.txtConsola.TabIndex = 4;
            // 
            // TxtArchivo
            // 
            this.TxtArchivo.Location = new System.Drawing.Point(6, 46);
            this.TxtArchivo.Name = "TxtArchivo";
            this.TxtArchivo.Size = new System.Drawing.Size(500, 20);
            this.TxtArchivo.TabIndex = 2;
            // 
            // BtnCarga
            // 
            this.BtnCarga.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCarga.Location = new System.Drawing.Point(512, 43);
            this.BtnCarga.Name = "BtnCarga";
            this.BtnCarga.Size = new System.Drawing.Size(75, 23);
            this.BtnCarga.TabIndex = 3;
            this.BtnCarga.Text = "Cargar";
            this.BtnCarga.UseVisualStyleBackColor = true;
            this.BtnCarga.Click += new System.EventHandler(this.BtnCarga_Click);
            // 
            // RbtnArchivo
            // 
            this.RbtnArchivo.AutoSize = true;
            this.RbtnArchivo.Location = new System.Drawing.Point(33, 23);
            this.RbtnArchivo.Name = "RbtnArchivo";
            this.RbtnArchivo.Size = new System.Drawing.Size(61, 17);
            this.RbtnArchivo.TabIndex = 0;
            this.RbtnArchivo.TabStop = true;
            this.RbtnArchivo.Text = "Archivo";
            this.RbtnArchivo.UseVisualStyleBackColor = true;
            this.RbtnArchivo.CheckedChanged += new System.EventHandler(this.RbtnArchivo_CheckedChanged);
            // 
            // RbtnConsola
            // 
            this.RbtnConsola.AutoSize = true;
            this.RbtnConsola.Location = new System.Drawing.Point(149, 23);
            this.RbtnConsola.Name = "RbtnConsola";
            this.RbtnConsola.Size = new System.Drawing.Size(63, 17);
            this.RbtnConsola.TabIndex = 1;
            this.RbtnConsola.TabStop = true;
            this.RbtnConsola.Text = "Consola";
            this.RbtnConsola.UseVisualStyleBackColor = true;
            this.RbtnConsola.CheckedChanged += new System.EventHandler(this.RbtnConsola_CheckedChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(354, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Procesar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 333);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtConsola;
        private System.Windows.Forms.TextBox TxtArchivo;
        private System.Windows.Forms.Button BtnCarga;
        private System.Windows.Forms.RadioButton RbtnArchivo;
        private System.Windows.Forms.RadioButton RbtnConsola;
        private System.Windows.Forms.Button button1;
    }
}

