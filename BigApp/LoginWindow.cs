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

namespace BigApp
{
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=WIN-K2G5IS9POD3\SQLEXPRESS;Initial Catalog=WatchDemoExam;Integrated Security=True");

        private void GuestButton_Click(object sender, EventArgs e)
        {
            var guestwindow = new GuestWindow();
            guestwindow.Show();
            this.Hide();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            String username, user_password;

            username = LoginTextbox.Text;
            user_password = PasswordTextbox.Text;

            try
            {
                String query = "SELECT * FROM Users WHERE UserLogin = '" + LoginTextbox.Text + "' AND UserPassword = '" + PasswordTextbox.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = LoginTextbox.Text;
                    user_password = PasswordTextbox.Text;


                    var adminwindow = new AdminWindow();
                    adminwindow.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Invalid(Инвалид?) blah blah blah", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoginTextbox.Clear();
                    PasswordTextbox.Clear();
                }
            }

            catch
            {
                MessageBox.Show("Error");
            }

            finally
            {
                conn.Close();
            }
        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {
            
        }
    }
}
