using System;
using System.Windows.Forms;
using Trivia.TDP.Controladores;
using Trivia.TDP.Controladores.Errores;
using Trivia.TDP.DTO;

namespace Trivia.TDP.Vistas
{
    public partial class Register : Form
    {
        private IFachada fachada;
        public Register()
        {
            InitializeComponent();
        }

        private void label1_Click( object sender, EventArgs e )
        {

        }

        private void button1_Click( object sender, EventArgs e )
        {
            fachada = new Fachada();
            if (textLegajo.Text != "" && textContrasena.Text != "" && textNombre.Text != "" && textApellido.Text != "")
            {
                if (textContrasena.Text == textRepetirContrasena.Text)
                {
                    UsuarioDTO user = new UsuarioDTO();
                    user.nombre = textNombre.Text;
                    user.apellido = textApellido.Text;
                    user.legajo = textLegajo.Text;
                    user.contrasena = textContrasena.Text;
                    user.active = true;
                    user.esAdministrador = false;
                    try
                    {
                        Boolean created = fachada.CrearUsuario(user);
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

        private void button3_Click( object sender, EventArgs e )
        {
            Close();
        }

        private void button2_Click( object sender, EventArgs e )
        {
            Close();
        }

        private void textContrasena_TextChanged( object sender, EventArgs e )
        {

        }

        private void Register_Load( object sender, EventArgs e )
        {

        }
    }
}