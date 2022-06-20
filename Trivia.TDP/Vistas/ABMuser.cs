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
                IList<Usuario> usuarios = this.iUsuarioControlador.buscarUsuario(textLegajo.Text, textNombre.Text);
                if (usuarios != null)
                {
                    dataGridView1.DataSource = usuarios;
                    dataGridView1.Columns.Remove("listaExamenes");
                    dataGridView1.Columns.Remove("UsuarioId");
                }
            }
            catch (ErrorLegajoNoExiste)
            {
                MessageBox.Show("El usuario no existe en el sistema.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
