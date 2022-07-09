using Trivia.TDP.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trivia.TDP.Controladores;

namespace Trivia.TDP.Vistas
{
    public partial class ABMuser : Form
    {
        private Fachada fachada;

        public ABMuser()
        {
            InitializeComponent();
            this.fachada = new Fachada();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioDTO usuario = new UsuarioDTO();
                usuario.legajo = textLegajo.Text;
                usuario.nombre = textNombre.Text;
                usuario.apellido = textApellido.Text;            
                if (radioInactive.Checked)
                {
                    usuario.active = false;
                }
                if (radioActive.Checked)
                {
                    usuario.active = true;
                }
                IList<UsuarioDTO> usuarios = this.fachada.BuscarUsuarios(usuario);
                if (usuarios != null)
                {
                    dataGridView1.DataSource = usuarios;
                    dataGridView1.Columns.Remove("listaExamenes");
                    dataGridView1.Columns.Remove("UsuarioId");
                    dataGridView1.Columns.Remove("contrasena");
                } else
                {
                    usuarios.Clear();
                }
            }
            catch (ErrorUsuarioNoExiste)
            {
                MessageBox.Show("El usuario no existe en el sistema.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsuarioDTO usuario = (UsuarioDTO)dataGridView1.CurrentRow.DataBoundItem;
            MessageBox.Show(this.fachada.ActivarUsuario(usuario));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textLegajo.Text = "";
            textNombre.Text = "";
            textApellido.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                MessageBox.Show(this.fachada.EliminarUsuario(selectedRow));
            }
            
        }
    }
}
