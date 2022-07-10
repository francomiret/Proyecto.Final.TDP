using Dominio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trivia.TDP.Controladores;
using Trivia.TDP.DTO;

namespace Trivia.TDP.Vistas
{
    public partial class AdmQuestions : Form
    {
        private Fachada fachada;

        public AdmQuestions(IList<PreguntaDTO> preguntas)
        {
            InitializeComponent();
            this.Setup();

            if (preguntas != null)
            {
                foreach (PreguntaDTO pregunta in preguntas)
                {
                    dataGridPreguntas.Rows.Add(pregunta.PreguntaId,
                        pregunta.ConjuntoPreguntas.Nombre,
                        pregunta.descripcion,
                        pregunta.listaRespuestas[0].descripcion,
                        pregunta.listaRespuestas[1].descripcion,
                        pregunta.listaRespuestas[2].descripcion,
                        pregunta.listaRespuestas[3].descripcion);
                }
            }
            else
            {
                MessageBox.Show("Preguntas no encontradas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public AdmQuestions()
        {
             InitializeComponent();
            this.Setup();
        }

        private void Setup()
        {
            this.fachada = new Fachada();

            var dificultades = this.fachada.ObtenerDificultades();
            for (int i = 0; i < dificultades.Count; i++)
            {
                comboBoxDificultad.Items.Add(dificultades[i]);
            }
            comboBoxDificultad.DisplayMember = "descripcion";

            var categorias = this.fachada.ObtenerCategorias();

            for (int i = 0; i < categorias.Count; i++)
            {
                comboBoxCategorias.Items.Add(categorias[i]);
            }
            comboBoxCategorias.DisplayMember = "nombre";

            var conjuntos = this.fachada.ObtenerConjuntoPreguntas();
            conjuntoCombo.DisplayMember = "Nombre";

            if (conjuntos != null)
            {
                foreach (var conjunto in conjuntos)
                {
                    conjuntoCombo.Items.Add(conjunto);
                }
            }
        }


        private void button3_Click( object sender, EventArgs e )
        {
            Vistas.ImportQuestions importQuestions = new Vistas.ImportQuestions();
            this.Close();
            importQuestions.Show();
        }

        private void button6_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void AdmQuestions_Load( object sender, EventArgs e )
        {

        }

        private void dataGridView1_CellContentClick( object sender, DataGridViewCellEventArgs e )
        {

        }



        private void comboBox1_SelectedIndexChanged( object sender, EventArgs e )
        {

        }

        private void button4_Click( object sender, EventArgs e )
        {
            dataGridPreguntas.DataSource = null;
            CategoriaDTO categoriaSeleccionada = (CategoriaDTO)comboBoxCategorias.SelectedItem;
            DificultadDTO dificultadSeleccionada = (DificultadDTO)comboBoxDificultad.SelectedItem;
            ConjuntoPreguntasDTO conjunto = (ConjuntoPreguntasDTO)conjuntoCombo.SelectedItem;
            IList<PreguntaDTO> preguntas = this.fachada.ObtenerPreguntasPorCriterio(categoriaSeleccionada?.CategoriaId, dificultadSeleccionada?.DificultadId, conjunto?.Id);


            if (preguntas != null)
            {
                foreach (PreguntaDTO pregunta in preguntas)
                {
                    dataGridPreguntas.Rows.Add(pregunta.PreguntaId,
                        pregunta.ConjuntoPreguntas.Nombre,
                        pregunta.descripcion,
                        pregunta.listaRespuestas[0].descripcion,
                        pregunta.listaRespuestas[1].descripcion,
                        pregunta.listaRespuestas[2].descripcion,
                        pregunta.listaRespuestas[3].descripcion);
                }
            }
            else
            {
                MessageBox.Show("Preguntas no encontradas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void button7_Click( object sender, EventArgs e )
        {
            comboBoxCategorias.Text = null;
            comboBoxDificultad.Text = null; ;
            conjuntoCombo.Text = null;
        }

        private void button1_Click( object sender, EventArgs e )
        {
            if (dataGridPreguntas.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridPreguntas.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridPreguntas.Rows[selectedrowindex];
                string preguntaId = selectedRow.Cells["Id"].Value.ToString(); ;
                this.fachada.EliminarPregunta(preguntaId);
                MessageBox.Show("Pregunta eliminada.");
            }
        }

        private void groupBox1_Enter( object sender, EventArgs e )
        {

        }
    }
}
