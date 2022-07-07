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
    public partial class RunTrivia : Form
    {
        public RunTrivia()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vistas.QuestionTest exam = new Vistas.QuestionTest();
            this.Close();
            exam.Show();
            
        }
    }
}
