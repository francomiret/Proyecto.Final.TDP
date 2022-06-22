using Dominio;
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
using Trivia.TDP.Controladores.Errores;
using Trivia.TDP.Controladores.Interfaz;

namespace Trivia.TDP.Vistas
{
    public partial class Register : Form
    {
        private IUsuarioControlador iUsuarioControlador;
        public Register()
        {
            InitializeComponent();
            this.iUsuarioControlador = new UsuarioControlador();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textLegajo.Text != "" && textContrasena.Text != "" && textNombre.Text != "" && textApellido.Text != "")
            {
                if (textContrasena.Text == textRepetirContrasena.Text)
                {
                    Usuario user = new Usuario();
                    user.nombre = textNombre.Text;
                    user.apellido = textApellido.Text;
                    user.legajo = textLegajo.Text;
                    user.contrasena = textContrasena.Text;
                    user.active = true;
                    user.esAdministrador = false;
                    try
                    {
                        Boolean created = iUsuarioControlador.crearUsuario(user);
                        if (created)
                            MessageBox.Show("Usuario registrado existosamente.");
                    }
                    catch (ErrorUsuarioYaExiste)
                    {
                        MessageBox.Show("El usuario ya existe en el sistema.");
                    }
                    catch
                    {
                        MessageBox.Show("Error en el sistema.");
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden.");
                }

            } 
            else
            {
                MessageBox.Show("Completar campos obligatorios.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}