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
    public partial class AdminWindow : Form
    {
        public bool Tab1 = true;
        public bool Tab2 = false;

        public AdminWindow()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=WIN-K2G5IS9POD3\SQLEXPRESS;Initial Catalog=WatchDemoExam;Integrated Security=True");

        public void tabchange()
        {
            Tab1 = !Tab1;
            Tab2 = !Tab2;
        }


        private void InsertButton_Click(object sender, EventArgs e)
        {
            var manipulatewindow = new ManipulateWindow();
            manipulatewindow.Show();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT Orders.Id, NameOfStatus, PickUpPointAddress, FName, Articul, Count1, Articul, Count2, DateOfOrder, DateOfDelivery, UniqueCode FROM Orders INNER JOIN Statuses ON Orders.StatusesId = Statuses.Id INNER JOIN PickUpPoints ON Orders.PickUpPointId = PickUpPoints.Id INNER JOIN Users ON Orders.ClientId = Users.Id INNER JOIN Products ON Orders.Articul1 = Products.Id", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

            conn.Open();
            SqlDataAdapter adapter1 = new SqlDataAdapter($"select Users.Id, NameOfRole, FName, SName, TName, UserLogin, UserPassword from Users inner join Roles on Users.RoleId = Roles.Id", conn);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            dataGridView3.DataSource = dt1;
            conn.Close();

            dataGridView1.Refresh();
            dataGridView3.Refresh();
        }

        private void AdminWindow_Load_1(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "watchDemoExamDataSet.Users". При необходимости она может быть перемещена или удалена.
            

            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT Orders.Id, NameOfStatus, PickUpPointAddress, FName, Articul, Count1, Articul, Count2, DateOfOrder, DateOfDelivery, UniqueCode FROM Orders INNER JOIN Statuses ON Orders.StatusesId = Statuses.Id INNER JOIN PickUpPoints ON Orders.PickUpPointId = PickUpPoints.Id INNER JOIN Users ON Orders.ClientId = Users.Id INNER JOIN Products ON Orders.Articul1 = Products.Id", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();


            // TODO: данная строка кода позволяет загрузить данные в таблицу "watchDemoExamDataSet.Orders". При необходимости она может быть перемещена или удалена.
            //this.ordersTableAdapter.Fill(this.watchDemoExamDataSet.Orders);

        }

        private void AdminWindow_Load_2(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "watchDemoExamDataSet.Users". При необходимости она может быть перемещена или удалена.


            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter($"select Users.Id, NameOfRole, FName, SName, TName, UserLogin, UserPassword from Users inner join Roles on Users.RoleId = Roles.Id", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView3.DataSource = dt;
            conn.Close();


            // TODO: данная строка кода позволяет загрузить данные в таблицу "watchDemoExamDataSet.Orders". При необходимости она может быть перемещена или удалена.
            //this.ordersTableAdapter.Fill(this.watchDemoExamDataSet.Orders);

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            var loginwindow = new LoginWindow();
            loginwindow.Show();
            this.Hide();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == 1)
            {
                SqlDataAdapter adapter = new SqlDataAdapter($"select Users.Id, NameOfRole, FName, SName, TName, UserLogin, UserPassword from Users inner join Roles on Users.RoleId = Roles.Id WHERE Users.FName LIKE '%"+SearchBox.Text+"%'", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView3.DataSource = dt;

                conn.Close();
            }
            else
            {
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT Orders.Id, NameOfStatus, PickUpPointAddress, FName, Articul, Count1, Articul, Count2, DateOfOrder, DateOfDelivery, UniqueCode FROM Orders INNER JOIN Statuses ON Orders.StatusesId = Statuses.Id INNER JOIN PickUpPoints ON Orders.PickUpPointId = PickUpPoints.Id INNER JOIN Users ON Orders.ClientId = Users.Id INNER JOIN Products ON Orders.Articul1 = Products.Id Where (Orders.Id Like '%" + SearchBox.Text + "%') or (NameOfStatus Like '%" + SearchBox.Text + "%') or (PickUpPointAddress Like '%" + SearchBox.Text + "%')  or (FName Like '%" + SearchBox.Text + "%')  or (Articul Like '%" + SearchBox.Text + "%') or (DateOfOrder Like '%" + SearchBox.Text + "%') or (DateOfDelivery Like '%" + SearchBox.Text + "%') or (UniqueCode Like '%" + SearchBox.Text + "%')", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                conn.Close();
            }
            
        }
    }
}
