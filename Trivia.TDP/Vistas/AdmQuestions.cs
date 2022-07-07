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
        public AdmQuestions(IList<Pregunta> preguntas)
        {
            InitializeComponent();
            this.Setup();

            dataGridPreguntas.AutoGenerateColumns = false;
            dataGridPreguntas.AutoSize = true;
            dataGridPreguntas.DataSource = preguntas;

            DataGridViewColumn columnId = new DataGridViewTextBoxColumn();
            columnId.DataPropertyName = "PreguntaId";
            columnId.Name = "Id";
            dataGridPreguntas.Columns.Add(columnId);

            DataGridViewColumn columnDesc = new DataGridViewTextBoxColumn();
            columnDesc.DataPropertyName = "descripcion";
            columnDesc.Name = "Pregunta";
            dataGridPreguntas.Columns.Add(columnDesc);

            //DataGridViewColumn columnConjunto = new DataGridViewTextBoxColumn();
            //columnConjunto.DataPropertyName = "ConjuntoPreguntas.Nombre";
            //columnConjunto.Name = "Nombre Conjunto";
            //dataGridPreguntas.Columns.Add(columnConjunto);
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

        //private void dataGridPreguntas_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    if ((dataGridPreguntas.Rows[e.RowIndex].DataBoundItem != null) &&
        //        (dataGridPreguntas.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
        //    {
        //        e.Value = BindProperty(dataGridPreguntas.Rows[e.RowIndex].DataBoundItem,
        //        dataGridPreguntas.Columns[e.ColumnIndex].DataPropertyName);
        //    }
        //}
        private string BindProperty(object property, string propertyName)
        {
            string retValue = "";

            if (propertyName.Contains("."))
            {
                PropertyInfo[] arrayProperties;
                string leftPropertyName;

                leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."));
                arrayProperties = property.GetType().GetProperties();

                foreach (PropertyInfo propertyInfo in arrayProperties)
                {
                    if (propertyInfo.Name == leftPropertyName)
                    {
                        retValue = this.BindProperty(
                          propertyInfo.GetValue(property, null),
                          propertyName.Substring(propertyName.IndexOf(".") + 1));
                        break;
                    }
                }
            }
            else
            {
                Type propertyType;
                PropertyInfo propertyInfo;

                propertyType = property.GetType();
                propertyInfo = propertyType.GetProperty(propertyName);
                retValue = propertyInfo.GetValue(property, null).ToString();
            }

            return retValue;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
