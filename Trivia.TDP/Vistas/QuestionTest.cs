using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows.Forms;
using Trivia.TDP.Controladores;
using Trivia.TDP.DTO;
using Timer = System.Windows.Forms.Timer;

namespace Trivia.TDP.Vistas
{
    public partial class QuestionTest : Form
    {
        int pregActual = 0;

        IList<PreguntaDTO> listaPreguntas = null;

        ExamenDTO examen = new ExamenDTO();

        private IFachada fachada;

        int counter;

        private Timer timer1;

        System.Timers.Timer aTimer = new System.Timers.Timer();

        public QuestionTest( ExamenDTO pExamen, IList<PreguntaDTO> pPreguntas )
        {
            InitializeComponent();
            examen = pExamen;
            counter = (int)(examen.TiempoDeResolucion);
            SetTimer(examen.TiempoDeResolucion);

            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(GetRemaining);
            timer1.Interval = 1000; // 1 second
            timer1.Start();

            listaPreguntas = pPreguntas;
            groupBox1.Text = (pregActual + 1).ToString();
            cantidadPreguntas.Text = listaPreguntas.Count.ToString();
            time.Text = counter.ToString();

            descripcionPregunta.Text = listaPreguntas[pregActual].Descripcion;
            radioButton1.Text = listaPreguntas[pregActual].ListaRespuestas[0].Descripcion;
            radioButton2.Text = listaPreguntas[pregActual].ListaRespuestas[1].Descripcion;
            radioButton3.Text = listaPreguntas[pregActual].ListaRespuestas[2].Descripcion;
            radioButton4.Text = listaPreguntas[pregActual].ListaRespuestas[3].Descripcion;
        }

        public void OnTime( object source, ElapsedEventArgs e )
        {
            aTimer.Stop();
        }

        public void SetTimer( double tiempoResolucion )
        {
            aTimer.Elapsed += new ElapsedEventHandler(OnTime);
            aTimer.Interval = tiempoResolucion * 1000;
            aTimer.Enabled = true;
            DateTime timerEnd = DateTime.Now.AddMilliseconds(tiempoResolucion);
        }

        public void GetRemaining( object sender, EventArgs e )
        {
            fachada = new Fachada();
            counter--;
            if (counter == 0)
            {
                timer1.Stop();
                ExamenDTO examenDto = fachada.FinalizarExamen(examen);
                Vistas.Result result = new Vistas.Result(examenDto);
                this.Close();
                result.Show();
            }

            time.Text = counter.ToString();
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
                int selectedOp = selectedOption();
                if (selectedOp != -1)
                {
                    examen.Sesiones[index].RespuestaSeleccionadaId = listaPreguntas[pregActual].ListaRespuestas[selectedOp].RespuestaId;
                }
            }

            if (pregActual < listaPreguntas.Count - 1)
            {
                pregActual += 1;
                groupBox1.Text = (pregActual + 1).ToString();
                this.clearFields();
                descripcionPregunta.Text = listaPreguntas[pregActual].Descripcion;
                radioButton1.Text = listaPreguntas[pregActual].ListaRespuestas[0].Descripcion;
                radioButton2.Text = listaPreguntas[pregActual].ListaRespuestas[1].Descripcion;
                radioButton3.Text = listaPreguntas[pregActual].ListaRespuestas[2].Descripcion;
                radioButton4.Text = listaPreguntas[pregActual].ListaRespuestas[3].Descripcion;
            }
        }

        private void clearFields()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void button2_Click( object sender, EventArgs e )
        {
            int index = indexSesion(listaPreguntas[pregActual].PreguntaId);
            if (index != -1)
            {
                int selectedOp = selectedOption();
                if (selectedOp != -1)
                {
                    examen.Sesiones[index].RespuestaSeleccionadaId = listaPreguntas[pregActual].ListaRespuestas[selectedOp].RespuestaId;
                }
            }

            if (pregActual > 0)
            {
                pregActual -= 1;
                groupBox1.Text = (pregActual + 1).ToString();
                this.clearFields();
                descripcionPregunta.Text = listaPreguntas[pregActual].Descripcion;
                radioButton1.Text = listaPreguntas[pregActual].ListaRespuestas[0].Descripcion;
                radioButton2.Text = listaPreguntas[pregActual].ListaRespuestas[1].Descripcion;
                radioButton3.Text = listaPreguntas[pregActual].ListaRespuestas[2].Descripcion;
                radioButton4.Text = listaPreguntas[pregActual].ListaRespuestas[3].Descripcion;

            }
        }

        public int indexSesion( int preguntaId )
        {
            int res = -1;
            for (int i = 0; i < examen.Sesiones.Count; i++)
            {
                if (examen.Sesiones[i].PreguntaID == preguntaId)
                {
                    res = i;
                }
            }
            return res;
        }

        public int selectedOption()
        {
            int op = -1;
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

        private void button1_Click( object sender, EventArgs e )
        {
            fachada = new Fachada();
            int index = indexSesion(listaPreguntas[pregActual].PreguntaId);
            if (index != -1)
            {
                int selectedOp = selectedOption();
                if (selectedOp != -1)
                {
                    examen.Sesiones[index].RespuestaSeleccionadaId = listaPreguntas[pregActual].ListaRespuestas[selectedOp].RespuestaId;
                }
            }
            aTimer.Stop();
            ExamenDTO examenDto = fachada.FinalizarExamen(examen);
            Vistas.Result result = new Vistas.Result(examenDto);
            this.Close();
            result.Show();
        }
    }
}
