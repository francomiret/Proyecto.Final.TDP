using System;
using System.Windows.Forms;
using Trivia.TDP.Controladores;
using Trivia.TDP.DTO;

namespace Trivia.TDP.Vistas
{
    public partial class Login : Form
    {
        private IFachada fachada;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click( object sender, EventArgs e )
        {
            fachada = new Fachada();
            string legajo = textLegajo.Text;
            string contrasena = textContrasena.Text;
            try
            {
                UsuarioDTO usuario = fachada.Autenticar(legajo, contrasena);
                if (usuario != null)
                {

                    Vistas.Main main = new Vistas.Main();
                    Visible = !Visible;
                    main.ShowDialog();
                    this.Close();
                }
            }
            catch (ErrorUsuarioNoExiste)
            {
                MessageBox.Show("El usuario no existe en el sistema.");
            }
            catch (ErrorContrasenaIncorrecta)
            {
                MessageBox.Show("Contraseña incorrecta.");
            }
            catch
            {
                MessageBox.Show("Error en el sistema.");
            }
        }

        private void label1_Click( object sender, EventArgs e )
        {

        }

        private void label3_Click( object sender, EventArgs e )
        {

        }

        private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {

        }

        private void Login_Load( object sender, EventArgs e )
        {

        }

        private void button2_Click_1( object sender, EventArgs e )
        {
            Vistas.Register register = new Vistas.Register();
            register.ShowDialog();
        }

        private void button3_Click( object sender, EventArgs e )
        {
            Close();
        }

        private void textContrasena_TextChanged( object sender, EventArgs e )
        {

        }
    }
}
