﻿using System;
using System.Windows.Forms;
using Trivia.TDP.Controladores;
using Trivia.TDP.DTO;

namespace Trivia.TDP.Vistas
{
    public partial class Main : Form
    {
        private IFachada fachada;

        ExamenDTO examen;
        public Main()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click( object sender, EventArgs e )
        {

        }

        private void groupBox1_Enter( object sender, EventArgs e )
        {

        }

        private void Main_Load( object sender, EventArgs e )
        {
            fachada = new Fachada();
            UsuarioDTO usuario = fachada.ObtenerUsuarioAutenticado();
            userData.Text = usuario.Nombre + " " + usuario.Apellido;
            examen = fachada.MejorExamenUsuario();
            if (examen != null)
            {
                labelMejorPuntaje.Text = examen.Puntaje.ToString();
                labelCantidad.Text = examen.CantidadPreguntas.ToString();
                labelTiempo.Text = examen.TiempoUsado.ToString();
            } else
            {
                labelMejorPuntaje.Text = "-";
                labelCantidad.Text = "-";
                labelTiempo.Text = "-";
            }
        }

        private void button4_Click( object sender, EventArgs e )
        {
            fachada = new Fachada();
            this.fachada.CerrarSesion();
            this.Close();
        }

        private void button1_Click( object sender, EventArgs e )
        {
            Vistas.ABMuser users = new Vistas.ABMuser();
            users.Show();
        }

        private void button2_Click( object sender, EventArgs e )
        {
            Vistas.AdmQuestions admQuestions = new Vistas.AdmQuestions();
            admQuestions.Show();
        }

        private void button5_Click( object sender, EventArgs e )
        {
            Vistas.RunTrivia runTrivia = new Vistas.RunTrivia();
            runTrivia.Show();
        }

        private void button3_Click( object sender, EventArgs e )
        {
            Vistas.Ranking ranking = new Vistas.Ranking();
            ranking.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
