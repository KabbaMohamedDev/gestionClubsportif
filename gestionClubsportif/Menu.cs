using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestionClubsportif
{
    public partial class Menu : Form
    {
        public Menu()
        {

            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            Les_Espaces es = new Les_Espaces();
            es.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            Coach ch = new Coach();
            ch.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
         
            Discipline di = new Discipline();
            di.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
            Adherent ad = new Adherent();
            ad.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
            Cours cr = new Cours();
            cr.ShowDialog();
            
        }

        private void Menu_Load(object sender, EventArgs e)
        {
          
        }
    }
}
