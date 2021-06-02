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
    public partial class Cours : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=MK\MOHAMED;Initial Catalog=gestion_club_sportif;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter Da;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        public Cours()
        {
            InitializeComponent();
            DataGrid();
            combo();


           
            

            Da = new SqlDataAdapter("select * from Espace", cn);
            Da.Fill(dt1);
            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "Id_espace";
            


            Da = new SqlDataAdapter("select * from Coach", cn);
            Da.Fill(dt2);
            comboBox3.DataSource = dt2;
            comboBox3.DisplayMember = "Id_Coach";




            Da = new SqlDataAdapter("select * from Discipline", cn);
            Da.Fill(dt3);
            comboBox4.DataSource = dt3;
            comboBox4.DisplayMember = "Id_Discipline";
        }
        public void DataGrid()
        {

            dt.Clear();
            cmd = new SqlCommand("selectCours", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }
        public void combo()
        {
            dt4.Clear();
            Da = new SqlDataAdapter("select * from Cours", cn);
            Da.Fill(dt4);
            comboBox1.DataSource = dt4;
            comboBox1.DisplayMember = "Id_Cours";
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (  textBox1.Text != "" && textBox2.Text != "" && dateTimePicker1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "")
                {
                    cmd = new SqlCommand("AjouterCours", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[6];

                    param[0] = new SqlParameter("@nom", SqlDbType.VarChar, 20);
                    param[0].Value = textBox1.Text;
                    param[1] = new SqlParameter("@des", SqlDbType.VarChar, 20);
                    param[1].Value = textBox2.Text;
                    param[2] = new SqlParameter("@date", SqlDbType.Date);
                    param[2].Value = dateTimePicker1.Value;
                    param[3] = new SqlParameter("@ide", SqlDbType.Int);
                    param[3].Value =comboBox2.Text;
                    param[4] = new SqlParameter("@idc", SqlDbType.Int);
                    param[4].Value = comboBox3.Text;

                    param[5] = new SqlParameter("@idd", SqlDbType.Int);
                    param[5].Value = comboBox4.Text;
                    
                    cmd.Parameters.AddRange(param);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Bien Ajouter", "add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                    combo();
                    DataGrid();
                   
                }
                else
                {
                    MessageBox.Show("Non  Ajouter", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Vous devez remplir tous les champs obligatoires", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Non Ajouter", "add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(ex.Message);
                cn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("supprimercours", cn);
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
                combo();
                DataGrid();
            }
            catch
            {
                MessageBox.Show(" Non Supprimer ", "del", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && dateTimePicker1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "")
                {
                    cmd = new SqlCommand("modicours", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[7];
                    param[0] = new SqlParameter("@id", SqlDbType.Int);
                    param[0].Value = comboBox1.Text;
                    param[1] = new SqlParameter("@nom", SqlDbType.VarChar, 20);
                    param[1].Value = textBox1.Text;
                    param[2] = new SqlParameter("@des", SqlDbType.VarChar, 20);
                    param[2].Value = textBox2.Text;
                    param[3] = new SqlParameter("@date", SqlDbType.Date);
                    param[3].Value = dateTimePicker1.Value;
                    param[4] = new SqlParameter("@ide", SqlDbType.Int);
                    param[4].Value = comboBox2.Text;
                    param[5] = new SqlParameter("@idc", SqlDbType.Int);
                    param[5].Value = comboBox3.Text;

                    param[6] = new SqlParameter("@idd", SqlDbType.Int);
                    param[6].Value = comboBox4.Text;

                    cmd.Parameters.AddRange(param);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Bien modifier", "modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                    DataGrid();
                    combo();
                }
                else
                {
                    MessageBox.Show("Non  modifier", "modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Vous devez remplir tous les champs obligatoires", "moddifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Non modifier", "modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(ex.Message);
                cn.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Cours";
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Text = dr[0].ToString();
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                dateTimePicker1.Text = dr[3].ToString();
                comboBox2.Text = dr[4].ToString();
                comboBox3.Text = dr[5].ToString();
                comboBox4.Text = dr[6].ToString();
            }
            cn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Cours";
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
                        textBox2.Text = dr[2].ToString();
                        dateTimePicker1.Text = dr[3].ToString();
                        comboBox2.Text = dr[4].ToString();
                        comboBox3.Text = dr[5].ToString();
                        comboBox4.Text = dr[6].ToString();
                    }
                    else
                    {
                        MessageBox.Show("vous etre sur le Dernier", "cours", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            cmd.CommandText = "select * from Cours";
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
                    MessageBox.Show("vous etre sur le premier", "cours", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                while (dr.Read())
                {
                    i++;

                    if (i == x - 1)
                    {
                        comboBox1.Text = dr[0].ToString();
                        textBox1.Text = dr[1].ToString();
                        textBox2.Text = dr[2].ToString();
                        dateTimePicker1.Text = dr[3].ToString();
                        comboBox2.Text = dr[4].ToString();
                        comboBox3.Text = dr[5].ToString();
                        comboBox4.Text = dr[6].ToString();
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
            cmd.CommandText = "select * from Cours ";
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();
            comboBox1.Text = dr[0].ToString();
            textBox1.Text = dr[1].ToString();
            textBox2.Text = dr[2].ToString();
            dateTimePicker1.Text = dr[3].ToString();
            comboBox2.Text = dr[4].ToString();
            comboBox3.Text = dr[5].ToString();
            comboBox4.Text = dr[6].ToString();
            cn.Close();
        }

        private void Cours_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pos = dataGridView1.CurrentRow.Index;
            comboBox1.Text = dataGridView1.Rows[pos].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[pos].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[pos].Cells[2].Value.ToString();
            dataGridView1.Text = dataGridView1.Rows[pos].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[pos].Cells[4].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[pos].Cells[5].Value.ToString();
            comboBox4.Text = dataGridView1.Rows[pos].Cells[6].Value.ToString();
           
        }
    }
}
