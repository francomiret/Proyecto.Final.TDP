using System;
using System.Windows.Forms;
using Trivia.TDP.Controladores;
using Trivia.TDP.DTO;

namespace Trivia.TDP.Vistas
{
    public partial class Main : Form
    {
        private Fachada fachada;

        public Main()
        {
            InitializeComponent();
            this.fachada = new Fachada();


        }

        private void pictureBox1_Click( object sender, EventArgs e )
        {

        }

        private void groupBox1_Enter( object sender, EventArgs e )
        {

        }

        private void Main_Load( object sender, EventArgs e )
        {
            UsuarioDTO usuario = fachada.ObtenerUsuarioAutenticado();
            userData.Text = usuario.nombre + " " + usuario.apellido;
            labelMejorPuntaje.Text = "-";
            labelCantidad.Text = "-";
            labelTiempo.Text = "-";

        }

        private void button4_Click( object sender, EventArgs e )
        {
            this.fachada.CerrarSesion();
            this.Close();
        }

        private void button1_Click( object sender, EventArgs e )
        {
            Vistas.ABMuser users = new Vistas.ABMuser();
            users.Show();
        }

        private void button2_Click( object sender, EventArgs e )
        {
            Vistas.AdmQuestions admQuestions = new Vistas.AdmQuestions();
            admQuestions.Show();
        }

        private void button5_Click( object sender, EventArgs e )
        {
            Vistas.RunTrivia runTrivia = new Vistas.RunTrivia();
            runTrivia.Show();
        }

        private void button3_Click( object sender, EventArgs e )
        {
            Vistas.Ranking ranking = new Vistas.Ranking();
            ranking.Show();
        }
    }
}
