using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trivia.TDP.Vistas
{
    public partial class AdmQuestions : Form
    {
        public AdmQuestions()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Vistas.ImportQuestions importQuestions = new Vistas.ImportQuestions();
            importQuestions.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdmQuestions_Load(object sender, EventArgs e)
        {

        }
    }
}
