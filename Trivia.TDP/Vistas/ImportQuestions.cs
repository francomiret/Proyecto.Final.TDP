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
using Trivia.TDP.Controladores.OpentDB;

namespace Trivia.TDP.Vistas
{
    public partial class ImportQuestions : Form
    {
        private Estrategia estrategia;

        public ImportQuestions()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            estrategia.DescargarPreguntas(20, new ConjuntoPreguntas("preg", 10, new Dificultad(1, "desctipcion", 1), new Categoria(9, "General Knowledge")));
        }
    }
}
