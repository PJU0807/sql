using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _230427_EX_SQL
{
    public partial class frmCustomer : Form
    {

        public string connetionString = "Server=www.db4free.net;Database=wjddnd4682;Uid=wjddnd4682;pwd=123456789";

        public string szCustid = string.Empty;
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            try
            {
                string strQuery = string.Format(@"insert into Customer (custid, name, address, phone)
values ('{0}', '{1}', '{2}', '{3}')", tbx_custid.Text, tbx_name.Text, tbx_address.Text, tbx_phone.Text);
                MySqlConnection mySqlConnection = new MySqlConnection(connetionString);
                MySqlCommand mySqlCommand = new MySqlCommand();
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = strQuery;
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();

                MessageBox.Show("OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                string strQuery = string.Format(@"update Customer
set
    name = '{1}',
    address = '{2}',
    phone = '{3}'
where custid = {0}", tbx_custid.Text, tbx_name.Text, tbx_address.Text, tbx_phone.Text);

                MySqlConnection mySqlConnection = new MySqlConnection(connetionString);
                MySqlCommand mySqlCommand = new MySqlCommand();
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = strQuery;
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();

                MessageBox.Show("OK");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                string strQuery = string.Format(@"DELETE FROM Customer
WHERE custid = '{0}' AND name = '{1}' AND address = '{2}' AND phone = '{3}'", tbx_custid.Text, tbx_name.Text, tbx_address.Text, tbx_phone.Text);
                MySqlConnection mySqlConnection = new MySqlConnection(connetionString);
                MySqlCommand mySqlCommand = new MySqlCommand();
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = strQuery;
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();

                MessageBox.Show("OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { }
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            string strQuery = "SELECT * FROM Customer where custid = " + szCustid;
            DataTable dataTable = new DataTable();

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, connetionString))
            {
                adapter.Fill((dataTable));
            }

            if (dataTable.Rows.Count > 0)
            {
                tbx_custid.Text = dataTable.Rows[0]["custid"].ToString();
                tbx_name.Text = dataTable.Rows[0]["name"].ToString();
                tbx_address.Text = dataTable.Rows[0]["address"].ToString();
                tbx_phone.Text = dataTable.Rows[0]["phone"].ToString();
            }
        }
    }
}
