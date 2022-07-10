using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trivia.TDP.DTO;

namespace Trivia.TDP.Vistas
{
    public partial class QuestionTest : Form
    {
        int pregActual = 0;
        IList<PreguntaDTO> listaPreguntas = null;
        ExamenDTO examen = new ExamenDTO();
        public QuestionTest(ExamenDTO pExamen, IList<PreguntaDTO> pPreguntas)
        {
            InitializeComponent();
            examen = pExamen;
            listaPreguntas = pPreguntas;
            groupBox1.Text = (pregActual + 1).ToString();
            cantidadPreguntas.Text = listaPreguntas.Count.ToString();
            time.Text = examen.tiempoDeResolucion.ToString();            

            descripcionPregunta.Text = listaPreguntas[pregActual].descripcion;
            radioButton1.Text = listaPreguntas[pregActual].listaRespuestas[0].descripcion;
            radioButton2.Text = listaPreguntas[pregActual].listaRespuestas[1].descripcion;
            radioButton3.Text = listaPreguntas[pregActual].listaRespuestas[2].descripcion;
            radioButton4.Text = listaPreguntas[pregActual].listaRespuestas[3].descripcion;
        }

        private void label2_Click( object sender, EventArgs e )
        {

        }

        private void groupBox1_Enter( object sender, EventArgs e )
        {

        }

        private void button3_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void button4_Click( object sender, EventArgs e )
        {
            int index = indexSesion(listaPreguntas[pregActual].PreguntaId);
            if (index != -1)
            {
                int? selectedOp = selectedOption();
                if (selectedOp != null)
                {
                    examen.sesiones[index].RespuestaSeleccionadaId = selectedOp;
                }
            }

            if (pregActual < listaPreguntas.Count - 1)
            {
                pregActual += 1;
                groupBox1.Text = (pregActual + 1).ToString();
                this.clearFields();
                descripcionPregunta.Text = listaPreguntas[pregActual].descripcion;
                radioButton1.Text = listaPreguntas[pregActual].listaRespuestas[0].descripcion;
                radioButton2.Text = listaPreguntas[pregActual].listaRespuestas[1].descripcion;
                radioButton3.Text = listaPreguntas[pregActual].listaRespuestas[2].descripcion;
                radioButton4.Text = listaPreguntas[pregActual].listaRespuestas[3].descripcion;
                
            }
        }

        private void clearFields()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = indexSesion(listaPreguntas[pregActual].PreguntaId);
            if (index != -1)
            {
                int? selectedOp = selectedOption();
                if (selectedOp != null)
                {
                    examen.sesiones[index].RespuestaSeleccionadaId = selectedOp;
                }
            }
                        
            if (pregActual > 0)
            {
                pregActual -= 1;
                groupBox1.Text = (pregActual + 1).ToString();
                this.clearFields();
                descripcionPregunta.Text = listaPreguntas[pregActual].descripcion;
                radioButton1.Text = listaPreguntas[pregActual].listaRespuestas[0].descripcion;
                radioButton2.Text = listaPreguntas[pregActual].listaRespuestas[1].descripcion;
                radioButton3.Text = listaPreguntas[pregActual].listaRespuestas[2].descripcion;
                radioButton4.Text = listaPreguntas[pregActual].listaRespuestas[3].descripcion;
            
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {

            }
            
            
        }

        public int indexSesion(int preguntaId)
        {
            int res = -1;
            for (int i = 0; i < examen.sesiones.Count; i++)
            {
                if (examen.sesiones[i].PreguntaID == preguntaId)
                {
                    res = i;
                }
            }
            return res;
        }

        public int? selectedOption()
        {
            int? op = null;
            if (radioButton1.Checked == true)
                op = 0;
            if (radioButton2.Checked == true)
                op = 1;
            if (radioButton3.Checked == true)
                op = 2;
            if (radioButton4.Checked == true)
                op = 3;
            return op;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // finalizar examen
        }
    }
}
