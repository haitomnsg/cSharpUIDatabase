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

namespace CompanyNew
{
    public partial class Form1: Form
    {
        static string connectionString;
        static SqlConnection conn;
        static SqlCommand sqlCommand;
        static SqlDataReader reader;

        public Form1()
        {
            InitializeComponent();
        }

        private void connectionButton_Click(object sender, EventArgs e)
        {
            connectionString = @"Data Source=BLUGE;Initial Catalog=company;Integrated Security=True";

            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                MessageBox.Show("Database Connection Successful.");
            }
            catch
            {
                MessageBox.Show("Database Connection Failed.");
            }
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            String Username = usernameInput.Text;
            String Password = passwordInput.Text;

            sqlCommand = new SqlCommand("insert into login(username, password) values('" + Username + "', '" + Password + "')", conn);
            sqlCommand.ExecuteNonQuery();

            sqlCommand.Dispose();

            MessageBox.Show("Data Inserted Successfully.");
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            sqlCommand = new SqlCommand("select * from login", conn);
            reader = sqlCommand.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            String id;
            id = idInput.Text;
            sqlCommand = new SqlCommand("delete from login where id = " + id, conn);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            MessageBox.Show("Record Deleted Successfully.");
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            String idupdate = idUpdate.Text;
            String usernameupdate = usernameUpdate.Text;
            String passwordupdate = passwordUpdate.Text;

            sqlCommand = new SqlCommand(
                "update login set username = '" + usernameupdate + "', password = '" + passwordupdate + "' where id = " + idupdate, conn);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            MessageBox.Show("Record Updated Successfully.");
        }
    }
}
