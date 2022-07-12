using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trivia.TDP.Controladores;
using Trivia.TDP.DTO;

namespace Trivia.TDP.Vistas
{
    public partial class Ranking : Form
    {
        private Fachada fachada;
        public Ranking()
        {
            InitializeComponent();
            this.fachada = new Fachada();
            IList<ExamenDTO> examenes = fachada.Mejores10Examenes();
            if (examenes != null)
            {
                foreach (ExamenDTO examen in examenes)
                {
                    dataGridViewRanking.Rows.Add(
                        examen.usuario.legajo,
                        examen.usuario.nombre,
                        examen.Puntaje,
                        examen.CantidadPreguntas,
                        examen.TiempoUsado,
                        examen.dificultad.descripcion);
                }
            }
        }

        private void button6_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick( object sender, DataGridViewCellEventArgs e )
        {

        }
    }
}
