namespace Trivia.TDP.Vistas
{
    partial class Ranking
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dataGridViewRanking = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Puntaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadPreguntas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TiempoUsado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dificultad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRanking)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Trivia.TDP.Properties.Resources.FondoFinal;
            this.pictureBox2.Location = new System.Drawing.Point(-68, -25);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1024, 460);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // dataGridViewRanking
            // 
            this.dataGridViewRanking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRanking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Legajo,
            this.Nombre,
            this.Puntaje,
            this.CantidadPreguntas,
            this.TiempoUsado,
            this.Dificultad});
            this.dataGridViewRanking.Location = new System.Drawing.Point(16, 62);
            this.dataGridViewRanking.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewRanking.MultiSelect = false;
            this.dataGridViewRanking.Name = "dataGridViewRanking";
            this.dataGridViewRanking.ReadOnly = true;
            this.dataGridViewRanking.RowHeadersWidth = 51;
            this.dataGridViewRanking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRanking.Size = new System.Drawing.Size(871, 322);
            this.dataGridViewRanking.TabIndex = 47;
            this.dataGridViewRanking.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.IndianRed;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button6.Location = new System.Drawing.Point(851, 15);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(36, 28);
            this.button6.TabIndex = 51;
            this.button6.Text = "X";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label6.Location = new System.Drawing.Point(360, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 46);
            this.label6.TabIndex = 52;
            this.label6.Text = "RANKING";
            // 
            // Legajo
            // 
            this.Legajo.HeaderText = "Legajo";
            this.Legajo.MinimumWidth = 6;
            this.Legajo.Name = "Legajo";
            this.Legajo.ReadOnly = true;
            this.Legajo.Width = 80;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 80;
            // 
            // Puntaje
            // 
            this.Puntaje.HeaderText = "Puntaje";
            this.Puntaje.MinimumWidth = 6;
            this.Puntaje.Name = "Puntaje";
            this.Puntaje.ReadOnly = true;
            this.Puntaje.Width = 60;
            // 
            // CantidadPreguntas
            // 
            this.CantidadPreguntas.HeaderText = "Cantidad de Preguntas";
            this.CantidadPreguntas.MinimumWidth = 6;
            this.CantidadPreguntas.Name = "CantidadPreguntas";
            this.CantidadPreguntas.ReadOnly = true;
            this.CantidadPreguntas.Width = 120;
            // 
            // TiempoUsado
            // 
            this.TiempoUsado.HeaderText = "Tiempo Usado";
            this.TiempoUsado.MinimumWidth = 6;
            this.TiempoUsado.Name = "TiempoUsado";
            this.TiempoUsado.ReadOnly = true;
            // 
            // Dificultad
            // 
            this.Dificultad.HeaderText = "Dificultad";
            this.Dificultad.MinimumWidth = 6;
            this.Dificultad.Name = "Dificultad";
            this.Dificultad.ReadOnly = true;
            // 
            // Ranking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 412);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dataGridViewRanking);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Ranking";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRanking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dataGridViewRanking;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Puntaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadPreguntas;
        private System.Windows.Forms.DataGridViewTextBoxColumn TiempoUsado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dificultad;
    }
}