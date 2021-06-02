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
    public partial class Discipline : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=MK\MOHAMED;Initial Catalog=gestion_club_sportif;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter Da;
        DataTable dt = new DataTable();
        DataTable dts = new DataTable();

        public Discipline()
        {
            InitializeComponent();
            DataGrid();
            combo();    }
        public void DataGrid()
        {

            dt.Clear();
            cmd = new SqlCommand("selectDiscipline", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }
        public void combo()
        {

            dts.Clear();
            Da = new SqlDataAdapter("select * from Discipline", cn);
            Da.Fill(dts);
            comboBox1.DataSource = dts;
            comboBox1.DisplayMember = "Id_Discipline";
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    cmd = new SqlCommand("ajouterDiscipline", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter();
                    param = new SqlParameter("type", SqlDbType.VarChar, 20);
                    param.Value = textBox1.Text;
                    cmd.Parameters.Add(param);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Bien Ajouter", "add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                    DataGrid();
                    combo();

                }
                else
                {
                    MessageBox.Show("Non Ajouter", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Vous devez remplir tous les champs obligatoires", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Non Ajouter", "add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("supprimerDiscipline", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param = new SqlParameter("@id", SqlDbType.Int);
                param.Value = comboBox1.Text;
                cmd.Parameters.Add(param);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Supprimer ", "del", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
                DataGrid();
                combo();
            }
            catch
            {
                MessageBox.Show(" Non Supprimer ", "del", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    cmd = new SqlCommand("modifierDiscipline", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@id", SqlDbType.Int);
                    param[0].Value = comboBox1.Text;
                    param[1] = new SqlParameter("@type", SqlDbType.VarChar, 20);
                    param[1].Value = textBox1.Text;
                    cmd.Parameters.AddRange(param);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Bien Modifier", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                    DataGrid();
                    combo();
                }
                else
                {
                    MessageBox.Show("Non Modifier", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Vous devez remplir tous les champs obligatoires", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Non Modifier", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Discipline";
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Text = dr[0].ToString();
                textBox1.Text = dr[1].ToString();
               
            }
            cn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Discipline";
            SqlDataReader dr;
            bool tr = false;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr[0].ToString() == comboBox1.Text)
                {
                    if (dr.Read() == true)
                    {
                        comboBox1.Text = dr[0].ToString();
                        textBox1.Text = dr[1].ToString();
                     
                    }
                    else
                    {
                        MessageBox.Show("vous etre sur le Dernier", "Discipline", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }

            cn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int x = 0;
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Discipline";
            SqlDataReader dr;
            bool tr = false;
            dr = cmd.ExecuteReader();
            int i = -1;
            while (dr.Read())
            {
                i++;
                if (dr[0].ToString() == comboBox1.Text)
                {
                    x = i;
                    tr = false;
                }
            }
            if (tr == false)
            {
                dr.Close();
                dr = cmd.ExecuteReader();
                i = -1;
                if (x == 0)
                {
                    MessageBox.Show("vous etre sur le premier", "discipline", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                while (dr.Read())
                {
                    i++;

                    if (i == x - 1)
                    {
                        comboBox1.Text = dr[0].ToString();
                        textBox1.Text = dr[1].ToString();
                       
                    }
                }

            }

            cn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Discipline ";
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();
            comboBox1.Text = dr[0].ToString();
            textBox1.Text = dr[1].ToString();
            cn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int pos = dataGridView1.CurrentRow.Index;
            comboBox1.Text = dataGridView1.Rows[pos].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[pos].Cells[1].Value.ToString();
            
        }
    }
    }

