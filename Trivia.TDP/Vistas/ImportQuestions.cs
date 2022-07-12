using Dominio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trivia.TDP.Controladores;
using Trivia.TDP.DTO;

namespace Trivia.TDP.Vistas
{
    public partial class ImportQuestions : Form
    {
        private Fachada fachada;

        public ImportQuestions()
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

        private void button3_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void button6_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void button1_Click( object sender, EventArgs e )
        {
            IList<PreguntaDTO> preguntas = new List<PreguntaDTO>();
            if (comboBoxConjuntos.SelectedItem == null)
            {
                DificultadDTO dificultadSeleccionada = (DificultadDTO)comboBoxDificultad.SelectedItem;
                CategoriaDTO categoriaSeleccionada = (CategoriaDTO)comboBoxCategorias.SelectedItem;
                int cant = Int32.Parse(cantidadPreg.Text);
                IList<PreguntaDTO>  preguntasAgregadas = fachada.AgregarPreguntas(dificultadSeleccionada, categoriaSeleccionada, cant);
                int conjuntoCreado = preguntasAgregadas[0].ConjuntoPreguntas.Id;
                preguntas = this.fachada.ObtenerPreguntasPorCriterio(categoriaSeleccionada?.CategoriaId, dificultadSeleccionada?.DificultadId, conjuntoCreado);
            }
            else
            {
                ConjuntoPreguntasDTO conjunto = (ConjuntoPreguntasDTO)comboBoxConjuntos.SelectedItem;
                preguntas = fachada.AgregarPreguntas(conjunto);
            }
            Vistas.AdmQuestions admQuestions = new Vistas.AdmQuestions(preguntas);
            admQuestions.Show();
        }

        private void comboBox2_SelectedIndexChanged( object sender, EventArgs e )
        {

        }

        private void comboBoxCategorias_SelectedIndexChanged( object sender, EventArgs e )
        {

        }

        private void domainUpDown1_SelectedItemChanged( object sender, EventArgs e )
        {

        }

        private void ImportQuestions_Load(object sender, EventArgs e)
        {

        }
    }
}
