using System;
using System.Windows.Forms;
using Trivia.TDP.DTO;

namespace Trivia.TDP.Vistas
{
    public partial class Result : Form
    {
        public Result( ExamenDTO examen )
        {
            InitializeComponent();
            labelPuntaje.Text = examen.Puntaje.ToString();
            labelTiempo.Text = examen.TiempoUsado.ToString();
        }

        private void button1_Click( object sender, EventArgs e )
        {
            this.Close();
        }
    }
}
