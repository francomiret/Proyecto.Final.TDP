using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trivia.TDP.Controladores;
using Trivia.TDP.Controladores.Interfaz;

namespace Trivia.TDP.Vistas
{
    public partial class ABMuser : Form
    {
        private IUsuarioControlador iUsuarioControlador;
        public ABMuser()
        {
            InitializeComponent();
            this.iUsuarioControlador = new UsuarioControlador();
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
                Usuario usuario = new Usuario();
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
                IList<Usuario> usuarios = this.iUsuarioControlador.buscarUsuario(usuario);
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
            catch (ErrorLegajoNoExiste)
            {
                MessageBox.Show("El usuario no existe en el sistema.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)dataGridView1.CurrentRow.DataBoundItem;
            if (usuario.active == false)
            {
                usuario.active = true;
                iUsuarioControlador.actualizarUsuario(usuario);
                MessageBox.Show("Usuario activado.");
            }
            else
            {
                MessageBox.Show("El usuario ya existe en el sistema.");
            }
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
                string cellValue = Convert.ToString(selectedRow.Cells["legajo"].Value);
                iUsuarioControlador.eliminarUsuario(cellValue);
                MessageBox.Show("Usuario eliminado.");
            }
            
        }
    }
}
