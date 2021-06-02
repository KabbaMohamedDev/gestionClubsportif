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
    public partial class Adherent : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=MK\MOHAMED;Initial Catalog=gestion_club_sportif;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter Da;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();


        public Adherent()
        {
            


            InitializeComponent();
            DataGrid();
            combo();






            Da = new SqlDataAdapter("select * from Cours ", cn);
            Da.Fill(dt1);
            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "Id_cours";


        }
        public void DataGrid()
        {

            dt.Clear();
            cmd = new SqlCommand("selectad", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }
        public void combo()
        {
            dt2.Clear();
            Da = new SqlDataAdapter("select * from Adherent", cn);
            Da.Fill(dt2);
            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "Id_Adherent";
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnajouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && comboBox2.Text != "")
                {
                    cmd = new SqlCommand("ajouteadherent", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[7];

                    param[0] = new SqlParameter("@nom", SqlDbType.VarChar, 20);
                    param[0].Value = textBox1.Text;
                    param[1] = new SqlParameter("@prenom", SqlDbType.VarChar, 20);
                    param[1].Value = textBox2.Text;
                    param[2] = new SqlParameter("@age", SqlDbType.Int);
                    param[2].Value = textBox3.Text;
                    param[3] = new SqlParameter("@email", SqlDbType.VarChar,20);
                    param[3].Value = textBox4.Text;
                    param[4] = new SqlParameter("@tele", SqlDbType.Int);
                    param[4].Value = textBox5.Text;
                    param[5] = new SqlParameter("@adresse", SqlDbType.NVarChar,20);
                    param[5].Value = textBox6.Text;
                    param[6] = new SqlParameter("@idc", SqlDbType.Int);
                    param[6].Value = comboBox2.Text;
                    cmd.Parameters.AddRange(param);
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

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && comboBox2.Text != "")
                {
                    cmd = new SqlCommand("modiadhe", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[8];
                    param[0] = new SqlParameter("@id", SqlDbType.Int);
                    param[0].Value = comboBox1.Text;
                    param[1] = new SqlParameter("@nom", SqlDbType.VarChar, 20);
                    param[1].Value = textBox1.Text;
                    param[2] = new SqlParameter("@prenom", SqlDbType.VarChar, 20);
                    param[2].Value = textBox2.Text;
                    param[3] = new SqlParameter("@age", SqlDbType.Int);
                    param[3].Value = textBox3.Text;
                    param[4] = new SqlParameter("@email", SqlDbType.VarChar, 20);
                    param[4].Value = textBox4.Text;
                    param[5] = new SqlParameter("@tele", SqlDbType.Int);
                    param[5].Value = textBox5.Text;
                    param[6] = new SqlParameter("@adresse", SqlDbType.NVarChar, 20);
                    param[6].Value = textBox6.Text;
                    param[7] = new SqlParameter("@idc", SqlDbType.Int);
                    param[7].Value = comboBox2.Text;
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
                    MessageBox.Show("Non  Modifier", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Vous devez remplir tous les champs obligatoires", "modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSup_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("suprrimeraD", cn);
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

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Adherent";
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Text = dr[0].ToString();
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                textBox6.Text = dr[6].ToString();
                comboBox2.Text = dr[7].ToString();


            }
            cn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Adherent";
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
                        textBox3.Text = dr[3].ToString();
                        textBox4.Text = dr[4].ToString();
                        textBox5.Text = dr[5].ToString();
                        textBox6.Text = dr[6].ToString();
                        comboBox2.Text = dr[7].ToString();
                    }
                    else
                    {
                        MessageBox.Show("vous etre sur le Dernier", "adherent", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            cmd.CommandText = "select * from Adherent";
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
                    MessageBox.Show("vous etre sur le premier", "adherent", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                while (dr.Read())
                {
                    i++;

                    if (i == x - 1)
                    {
                        comboBox1.Text = dr[0].ToString();
                        textBox1.Text = dr[1].ToString();
                        textBox2.Text = dr[2].ToString();
                        textBox3.Text = dr[3].ToString();
                        textBox4.Text = dr[4].ToString();
                        textBox5.Text = dr[5].ToString();
                        textBox6.Text = dr[6].ToString();
                        comboBox2.Text = dr[7].ToString();
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
            cmd.CommandText = "select * from Adherent ";
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();
            comboBox1.Text = dr[0].ToString();
            textBox1.Text = dr[1].ToString();
            textBox2.Text = dr[2].ToString();
            textBox3.Text = dr[3].ToString();
            textBox4.Text = dr[4].ToString();
            textBox5.Text = dr[5].ToString();
            textBox6.Text = dr[6].ToString();
            comboBox2.Text = dr[7].ToString();
            cn.Close();
        }

        private void Adherent_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pos = dataGridView1.CurrentRow.Index;
            comboBox1.Text = dataGridView1.Rows[pos].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[pos].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[pos].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[pos].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[pos].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[pos].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[pos].Cells[6].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[pos].Cells[7].Value.ToString();
        }
    }
}
