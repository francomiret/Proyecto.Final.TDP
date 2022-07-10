using Dominio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trivia.TDP.Controladores;
using Trivia.TDP.DTO;

namespace Trivia.TDP.Vistas
{
    public partial class RunTrivia : Form
    {
        private Fachada fachada;
        public RunTrivia()
        {
            this.fachada = new Fachada();

            InitializeComponent();
            var dificultades = fachada.ObtenerDificultades();
            for (int i = 0; i < dificultades.Count; i++)
            {
                comboBoxDificultad.Items.Add(dificultades[i]);
            }
            comboBoxDificultad.DisplayMember = "descripcion";

            var categorias = fachada.ObtenerCategorias();

            for (int i = 0; i < categorias.Count; i++)
            {
                comboBoxCategorias.Items.Add(categorias[i]);
            }
            comboBoxCategorias.DisplayMember = "nombre";

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
            ExamenDTO examen = null;
            if (comboBoxConjuntos.SelectedItem != null)
            {
                ConjuntoPreguntasDTO conjunto = (ConjuntoPreguntasDTO)comboBoxConjuntos.SelectedItem;
                examen = fachada.iniciarExamen(conjunto);
            }


            Vistas.QuestionTest exam = new Vistas.QuestionTest(examen);
            this.Close();
            exam.Show();

        }
    }
}
