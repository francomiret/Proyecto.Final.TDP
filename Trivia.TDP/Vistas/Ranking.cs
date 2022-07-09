using System;
using System.Windows.Forms;

namespace Trivia.TDP.Vistas
{
    public partial class Ranking : Form
    {
        public Ranking()
        {
            InitializeComponent();
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
