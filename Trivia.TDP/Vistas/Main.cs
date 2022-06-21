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
    public partial class Main : Form
    {
        private IUsuarioControlador iUsuarioControlador;
        public Main()
        {
            InitializeComponent();
            this.iUsuarioControlador = new UsuarioControlador();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            Usuario usuario = this.iUsuarioControlador.ObtenerUsuarioAutenticado();
            userData.Text = usuario.nombre + " " + usuario.apellido;
            labelMejorPuntaje.Text = "-";
            labelCantidad.Text = "-";
            labelTiempo.Text = "-"; 

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.iUsuarioControlador.CerrarSesion();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vistas.ABMuser users = new Vistas.ABMuser();
            users.Show();
        }
    }
}
