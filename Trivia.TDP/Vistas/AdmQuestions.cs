using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trivia.TDP.Controladores;
using Trivia.TDP.Controladores.Interfaz;

namespace Trivia.TDP.Vistas
{
    public partial class AdmQuestions : Form
    {
        private IDificultadControlador iDificultadControlador;

        private ICategoriaControlador iCategoriaControlador;

        private IConjuntoPreguntasControlador iConjuntoPreguntasControlador;

        private IPreguntaControlador iPreguntaControlador;
        public AdmQuestions(IList<Pregunta> preguntas)
        {
            InitializeComponent();
            this.Setup();

            if (preguntas != null)
            {
                foreach (Pregunta pregunta in preguntas)
                {
                    dataGridPreguntas.Rows.Add(pregunta.PreguntaId, 
                        pregunta.ConjuntoPreguntas.Nombre, 
                        pregunta.descripcion,
                        pregunta.listaRespuestas[0].descripcion,
                        pregunta.listaRespuestas[1].descripcion,
                        pregunta.listaRespuestas[2].descripcion,
                        pregunta.listaRespuestas[3].descripcion);
                }
            } else
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
            this.iConjuntoPreguntasControlador = new ConjuntoPreguntasControlador();
            this.iDificultadControlador = new DificultadControlador();
            this.iCategoriaControlador = new CategoriaControlador();
            this.iPreguntaControlador = new PreguntaControlador();
            var dificultades = iDificultadControlador.ObtenerDificultades();
            for (int i = 0; i < dificultades.Count; i++)
            {
                comboBoxDificultad.Items.Add(dificultades[i]);
            }
            comboBoxDificultad.DisplayMember = "descripcion";

            var categorias = iCategoriaControlador.ObtenerCategorias();

            for (int i = 0; i < categorias.Count; i++)
            {
                comboBoxCategorias.Items.Add(categorias[i]);
            }
            comboBoxCategorias.DisplayMember = "nombre";

            var conjuntos = iConjuntoPreguntasControlador.ObtenerConjuntos();
            conjuntoCombo.DisplayMember = "Nombre";

            if (conjuntos != null)
            {
                foreach (var conjunto in conjuntos)
                {
                    conjuntoCombo.Items.Add(conjunto);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Vistas.ImportQuestions importQuestions = new Vistas.ImportQuestions();
            this.Close();
            importQuestions.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdmQuestions_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridPreguntas.DataSource = null;
            Categoria categoriaSeleccionada = (Categoria)comboBoxCategorias.SelectedItem;
            Dificultad dificultadSeleccionada = (Dificultad)comboBoxDificultad.SelectedItem;
            ConjuntoPreguntas conjunto = (ConjuntoPreguntas)conjuntoCombo.SelectedItem;
            IList<Pregunta> preguntas = iPreguntaControlador.obtenerPreguntasPorCriterio(categoriaSeleccionada?.CategoriaId, dificultadSeleccionada?.DificultadId, conjunto?.Id);


            if (preguntas != null)
            {
                foreach (Pregunta pregunta in preguntas)
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

        private void button7_Click(object sender, EventArgs e)
        {
            comboBoxCategorias.Text = null;
            comboBoxDificultad.Text = null; ;
            conjuntoCombo.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridPreguntas.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridPreguntas.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridPreguntas.Rows[selectedrowindex];
                string preguntaId = selectedRow.Cells["id"].Value.ToString(); ;
                iPreguntaControlador.eliminarPregunta(Int32.Parse(preguntaId));
                MessageBox.Show("Pregunta eliminada.");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
