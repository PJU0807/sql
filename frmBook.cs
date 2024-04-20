using K4os.Compression.LZ4.Streams.Frames;
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
    public partial class frmBook : Form
    {

        public string connetionString = "Server=www.db4free.net;Database=wjddnd4682;Uid=wjddnd4682;pwd=123456789";

        public string szBookid = string.Empty;

        public frmBook()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmBook_Load(object sender, EventArgs e)
        {
            /*MessageBox.Show(szBookid);*/
            
            string strQuery = "SELECT * FROM Book where bookid = " + szBookid;
            DataTable dataTable = new DataTable();

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, connetionString))
            {
                adapter.Fill((dataTable));
            }

            if (dataTable.Rows.Count > 0)
            {
                tbx_bookid.Text = dataTable.Rows[0]["bookid"].ToString();
                tbx_bookname.Text = dataTable.Rows[0]["bookname"].ToString();
                tbx_publisher.Text = dataTable.Rows[0]["publisher"].ToString();
                tbx_price.Text = dataTable.Rows[0]["price"].ToString();
            }

        }

        private void btn_update_Click(object sender, EventArgs e)
        {

            string strQuery = string.Format(@"update Book
set
    bookname = '{1}',
    publisher = '{2}',
    price = '{3}'
where bookid = {0}", tbx_bookid.Text, tbx_bookname.Text, tbx_publisher.Text, tbx_price.Text);

            MySqlConnection mySqlConnection = new MySqlConnection(connetionString);
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = mySqlConnection;
            mySqlCommand.CommandText = strQuery;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            MessageBox.Show("OK");

        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            string strQuery = string.Format(@"insert into Book (bookid, bookname, publisher, price)
values ('{0}', '{1}', '{2}', '{3}')", tbx_bookid.Text, tbx_bookname.Text, tbx_publisher.Text, tbx_price.Text);
            MySqlConnection mySqlConnection = new MySqlConnection(connetionString);
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = mySqlConnection;
            mySqlCommand.CommandText = strQuery;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            MessageBox.Show("OK");

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                string strQuery = string.Format(@"DELETE FROM Book
WHERE bookid = '{0}' AND bookname = '{1}' AND publisher = '{2}' AND price = '{3}'", tbx_bookid.Text, tbx_bookname.Text, tbx_publisher.Text, tbx_price.Text);
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
    }
}
