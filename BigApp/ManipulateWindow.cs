using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BigApp
{
    public partial class ManipulateWindow : Form
    {
        public ManipulateWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=WIN-K2G5IS9POD3\SQLEXPRESS;Initial Catalog=WatchDemoExam;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Users values(@Id, @RoleId, @FName, @SName, @TName, @UserLogin, @UserPassword)",conn);
            cmd.Parameters.AddWithValue("@Id", int.Parse(IdBox.Text));
            cmd.Parameters.AddWithValue("@RoleId", int.Parse(RoleIdBox.Text));
            cmd.Parameters.AddWithValue("@FName", FNameBox.Text);
            cmd.Parameters.AddWithValue("@SName", SNameBox.Text);
            cmd.Parameters.AddWithValue("@TName", TNameBox.Text);
            cmd.Parameters.AddWithValue("@UserLogin", UsernameBox.Text);
            cmd.Parameters.AddWithValue("@UserPassword", PasswordBox.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Success", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
