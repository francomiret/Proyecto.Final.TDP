using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trivia.TDP.Controladores;
using Trivia.TDP.DTO;

namespace Trivia.TDP.Vistas
{
    public partial class RunTrivia : Form
    {
        private IFachada fachada;
        public RunTrivia()
        {
            InitializeComponent();
            fachada = new Fachada();

            var conjuntos = fachada.ObtenerConjuntoPreguntas();
            comboBoxConjuntos.DisplayMember = "Nombre";

            if (conjuntos != null)
            {
                foreach (var conjunto in conjuntos)
                {
                    comboBoxConjuntos.Items.Add(conjunto);
                }
            }
        }

        private void button6_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void button3_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void button1_Click( object sender, EventArgs e )
        {
            fachada = new Fachada();

            ExamenDTO examen = null;
            IList<PreguntaDTO> preguntas = new List<PreguntaDTO>();
            if (comboBoxConjuntos.SelectedItem != null)
            {
                ConjuntoPreguntasDTO conjunto = (ConjuntoPreguntasDTO)comboBoxConjuntos.SelectedItem;
                preguntas = fachada.ObtenerPreguntasPorCriterio(null, null, conjunto.Id);
                examen = fachada.iniciarExamen(conjunto, preguntas);
            }
            Vistas.QuestionTest exam = new Vistas.QuestionTest(examen, preguntas);
            this.Close();
            exam.Show();
        }
    }
}
