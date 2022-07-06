﻿using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trivia.TDP.Controladores;
using Trivia.TDP.Controladores.Interfaz;
using Trivia.TDP.Controladores.OpentDB;

namespace Trivia.TDP.Vistas
{
    public partial class ImportQuestions : Form
    {
        private ImportadorDataOpentDB estrategia = new ImportadorDataOpentDB();

        private IDificultadControlador iDificultadControlador;

        private ICategoriaControlador iCategoriaControlador;

        private IConjuntoPreguntasControlador iConjuntoPreguntasControlador;
        public ImportQuestions()
        {
            this.iConjuntoPreguntasControlador = new ConjuntoPreguntasControlador();
            this.iDificultadControlador = new DificultadControlador();
            this.iCategoriaControlador = new CategoriaControlador();
            InitializeComponent();
            var dificultades = iDificultadControlador.obtenerDificultades();
            for (int i = 0; i < dificultades.Count; i++)
            {
                comboBoxDificultad.Items.Add(dificultades[i]);
            }
            comboBoxDificultad.DisplayMember = "descripcion";

            var categorias = iCategoriaControlador.obtenerCategorias();

            for (int i = 0; i < categorias.Count; i++)
            {
                comboBoxCategorias.Items.Add(categorias[i]);
            }
            comboBoxCategorias.DisplayMember = "nombre";



        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dificultad dificultadSeleccionada = (Dificultad)comboBoxDificultad.SelectedItem;
            Categoria categoriaSeleccionada = (Categoria)comboBoxCategorias.SelectedItem;
            int cant = Int32.Parse(cantidadPreg.Text);
            ConjuntoPreguntas conjunto = new ConjuntoPreguntas("preg", dificultadSeleccionada, categoriaSeleccionada);
            IEnumerable<Pregunta> preguntas = estrategia.DescargarPreguntas(cant, conjunto);
            conjunto.setPreguntas(preguntas);
            this.iConjuntoPreguntasControlador.agregarConjunto(conjunto);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}
