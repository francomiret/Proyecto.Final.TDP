namespace Trivia.TDP.Vistas
{
    partial class Main
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.userData = new System.Windows.Forms.GroupBox();
            this.labelTiempo = new System.Windows.Forms.Label();
            this.labelCantidad = new System.Windows.Forms.Label();
            this.labelMejorPuntaje = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.userData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 338);
            this.panel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(1, 149);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(153, 33);
            this.button3.TabIndex = 3;
            this.button3.Text = "SESIONES";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Location = new System.Drawing.Point(3, 294);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(148, 32);
            this.button4.TabIndex = 4;
            this.button4.Text = "CERRAR SESION";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(0, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 33);
            this.button2.TabIndex = 2;
            this.button2.Text = "PREGUNTAS";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(0, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "USUARIOS";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LimeGreen;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button5.Location = new System.Drawing.Point(472, 285);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(154, 38);
            this.button5.TabIndex = 5;
            this.button5.Text = "INICIAR EXAMEN";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // userData
            // 
            this.userData.BackColor = System.Drawing.Color.Transparent;
            this.userData.Controls.Add(this.labelTiempo);
            this.userData.Controls.Add(this.labelCantidad);
            this.userData.Controls.Add(this.labelMejorPuntaje);
            this.userData.Controls.Add(this.label3);
            this.userData.Controls.Add(this.label2);
            this.userData.Controls.Add(this.label1);
            this.userData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userData.Location = new System.Drawing.Point(211, 66);
            this.userData.Name = "userData";
            this.userData.Size = new System.Drawing.Size(415, 181);
            this.userData.TabIndex = 6;
            this.userData.TabStop = false;
            this.userData.Text = "Rodrigo Mignola";
            this.userData.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // labelTiempo
            // 
            this.labelTiempo.AutoSize = true;
            this.labelTiempo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTiempo.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelTiempo.Location = new System.Drawing.Point(215, 112);
            this.labelTiempo.Name = "labelTiempo";
            this.labelTiempo.Size = new System.Drawing.Size(95, 17);
            this.labelTiempo.TabIndex = 30;
            this.labelTiempo.Text = "30 SEGUNDOS";
            this.labelTiempo.UseWaitCursor = true;
            // 
            // labelCantidad
            // 
            this.labelCantidad.AutoSize = true;
            this.labelCantidad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCantidad.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelCantidad.Location = new System.Drawing.Point(215, 83);
            this.labelCantidad.Name = "labelCantidad";
            this.labelCantidad.Size = new System.Drawing.Size(100, 17);
            this.labelCantidad.TabIndex = 29;
            this.labelCantidad.Text = "10 PREGUNTAS";
            this.labelCantidad.UseWaitCursor = true;
            // 
            // labelMejorPuntaje
            // 
            this.labelMejorPuntaje.AutoSize = true;
            this.labelMejorPuntaje.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMejorPuntaje.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelMejorPuntaje.Location = new System.Drawing.Point(215, 54);
            this.labelMejorPuntaje.Name = "labelMejorPuntaje";
            this.labelMejorPuntaje.Size = new System.Drawing.Size(85, 17);
            this.labelMejorPuntaje.TabIndex = 28;
            this.labelMejorPuntaje.Text = "200 PUNTOS";
            this.labelMejorPuntaje.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Tiempo :";
            this.label3.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Cantidad :";
            this.label2.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Mejor Puntaje :";
            this.label1.UseWaitCursor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Trivia.TDP.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(154, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 330);
            this.Controls.Add(this.userData);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.userData.ResumeLayout(false);
            this.userData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox userData;
        private System.Windows.Forms.Label labelTiempo;
        private System.Windows.Forms.Label labelCantidad;
        private System.Windows.Forms.Label labelMejorPuntaje;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}