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
    public partial class GuestWindow : Form
    {
        public GuestWindow()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=WIN-K2G5IS9POD3\SQLEXPRESS;Initial Catalog=WatchDemoExam;Integrated Security=True");

        private void GuestWindow_Load(object sender, EventArgs e)
        {
           
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT Orders.Id, NameOfStatus, PickUpPointAddress, FName, Articul, Count1, Articul, Count2, DateOfOrder, DateOfDelivery, UniqueCode FROM Orders INNER JOIN Statuses ON Orders.StatusesId = Statuses.Id INNER JOIN PickUpPoints ON Orders.PickUpPointId = PickUpPoints.Id INNER JOIN Users ON Orders.ClientId = Users.Id INNER JOIN Products ON Orders.Articul1 = Products.Id", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();


           
            // TODO: данная строка кода позволяет загрузить данные в таблицу "watchDemoExamDataSet.Orders". При необходимости она может быть перемещена или удалена.
            //this.ordersTableAdapter.Fill(this.watchDemoExamDataSet.Orders);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT Orders.Id, NameOfStatus, PickUpPointAddress, FName, Articul, Count1, Articul, Count2, DateOfOrder, DateOfDelivery, UniqueCode FROM Orders INNER JOIN Statuses ON Orders.StatusesId = Statuses.Id INNER JOIN PickUpPoints ON Orders.PickUpPointId = PickUpPoints.Id INNER JOIN Users ON Orders.ClientId = Users.Id INNER JOIN Products ON Orders.Articul1 = Products.Id Where (Orders.Id Like '%" + SearchBox.Text + "%') or (NameOfStatus Like '%" + SearchBox.Text + "%') or (PickUpPointAddress Like '%" + SearchBox.Text + "%')  or (FName Like '%" + SearchBox.Text + "%')  or (Articul Like '%" + SearchBox.Text + "%') or (DateOfOrder Like '%" + SearchBox.Text + "%') or (DateOfDelivery Like '%" + SearchBox.Text + "%') or (UniqueCode Like '%" + SearchBox.Text + "%')", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

            conn.Close();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            var loginwindow = new LoginWindow();
            loginwindow.Show();
            this.Hide();
        }
    }
}
