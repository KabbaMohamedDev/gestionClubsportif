using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace gestionClubsportif
{
    public partial class Login : Form
    {
        BL.login log = new BL.login();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = log.LOGIN(txtID.Text, txtPWD.Text);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("succès de connexion", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Bienvenu dans notre application", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                Menu m = new Menu();
                m.ShowDialog();
                

            }
            else
            {
                MessageBox.Show("échec de la connexion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

              
            }
        }
    }
}
