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
    public partial class frmOrder : Form
    {

        public string connetionString = "Server=www.db4free.net;Database=wjddnd4682;Uid=wjddnd4682;pwd=123456789";

        public string szOrderid = string.Empty;
        public frmOrder()
        {
            InitializeComponent();
        }

        private void SetOrders()
        {
            dataGridView1.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn makeColumn = new DataGridViewTextBoxColumn();
            makeColumn.DataPropertyName = "orderid";
            makeColumn.HeaderText = "주문번호";
            dataGridView1.Columns.Add(makeColumn);

            makeColumn = new DataGridViewTextBoxColumn();
            makeColumn.DataPropertyName = "custid";
            makeColumn.HeaderText = "고객번호";
            dataGridView1.Columns.Add(makeColumn);

            makeColumn = new DataGridViewTextBoxColumn();
            makeColumn.DataPropertyName = "name";
            makeColumn.HeaderText = "회원명";
            dataGridView1.Columns.Add(makeColumn);

            makeColumn = new DataGridViewTextBoxColumn();
            makeColumn.DataPropertyName = "address";
            makeColumn.HeaderText = "주소";
            dataGridView1.Columns.Add(makeColumn);

            makeColumn = new DataGridViewTextBoxColumn();
            makeColumn.DataPropertyName = "phone";
            makeColumn.HeaderText = "전화번호";
            dataGridView1.Columns.Add(makeColumn);

            makeColumn = new DataGridViewTextBoxColumn();
            makeColumn.DataPropertyName = "bookid";
            makeColumn.HeaderText = "도서번호";
            dataGridView1.Columns.Add(makeColumn);

            makeColumn = new DataGridViewTextBoxColumn();
            makeColumn.DataPropertyName = "bookname";
            makeColumn.HeaderText = "도서명";
            dataGridView1.Columns.Add(makeColumn);

            makeColumn = new DataGridViewTextBoxColumn();
            makeColumn.DataPropertyName = "publisher";
            makeColumn.HeaderText = "출판사";
            dataGridView1.Columns.Add(makeColumn);

            makeColumn = new DataGridViewTextBoxColumn();
            makeColumn.DataPropertyName = "price";
            makeColumn.HeaderText = "금액";
            dataGridView1.Columns.Add(makeColumn);

            makeColumn = new DataGridViewTextBoxColumn();
            makeColumn.DataPropertyName = "saleprice";
            makeColumn.HeaderText = "판매금액";
            dataGridView1.Columns.Add(makeColumn);

            makeColumn = new DataGridViewTextBoxColumn();
            makeColumn.DataPropertyName = "orderdate";
            makeColumn.HeaderText = "주문날짜";
            dataGridView1.Columns.Add(makeColumn);
        }
        private void setComboBox_Customer()
        {
            string strQuery = "SELECT * FROM Customer";

            DataTable dataTable = new DataTable();
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, connetionString))
            {
                adapter.Fill((dataTable));
            }
            comboBox_customer.Items.Clear();
            comboBox_customer.Items.Add("None");
            foreach (DataRow thisRow in dataTable.Rows)
            {
                comboBox_customer.Items.Add(thisRow["name"].ToString());
            }

        }

        private void SetGridView(DataGridView thisGrid)
        {
            thisGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            thisGrid.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label732_Click(object sender, EventArgs e)
        {

        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            setComboBox_Customer();
            string strQuery = "SELECT o.orderid, o.custid, c.name, c.address, c.phone, o.bookid, b.bookname, b.publisher, b.price, o.saleprice, o.orderdate from Orders o left outer join Customer c on o.custid = c.custid LEFT OUTER JOIN Book b on o.bookid = b.bookid";
            DataTable dataTable = new DataTable();
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, connetionString))
            {
                adapter.Fill((dataTable));
            }

            dataGridView1.Columns.Clear();
            SetOrders();
            SetGridView(dataGridView1);
            dataGridView1.DataSource = dataTable;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strQuery = "";
            if (comboBox_customer.Text == "None")
            {
                strQuery = "select *from Orders_Customer_Books";
            }
            else
            {
                strQuery = string.Format("select *from Orders_Customer_Books where name = '{0}'", comboBox_customer.Text);
            }

            DataTable dataTable = new DataTable();
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, connetionString))
            {
                adapter.Fill((dataTable));
            }
            dataGridView1.DataSource = dataTable;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBooksearch frmbooksearch = new frmBooksearch();
            frmbooksearch.Text = "도서정보검색";
            if (frmbooksearch.ShowDialog() == DialogResult.OK)
            {
                tbx_bookid.Text = frmbooksearch.bookInfor.bookid;
                tbx_bookname.Text = frmbooksearch.bookInfor.bookname;
                tbx_publisher.Text = frmbooksearch.bookInfor.publisher;
                tbx_price.Text = frmbooksearch.bookInfor.price;
            }
            else
            {
                tbx_bookid.Text = "";
                tbx_bookname.Text = "";
                tbx_publisher.Text = "";
                tbx_price.Text = "";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCustomersearch frmcustomersearch = new frmCustomersearch();
            frmcustomersearch.Text = "회원정보검색";
            if (frmcustomersearch.ShowDialog() == DialogResult.OK)
            {
                tbx_custid.Text = frmcustomersearch.customerInfor.custid;
                tbx_name.Text = frmcustomersearch.customerInfor.name;
                tbx_address.Text = frmcustomersearch.customerInfor.address;
                tbx_phone.Text = frmcustomersearch.customerInfor.phone;
            }
            else
            {
                tbx_custid.Text = "";
                tbx_name.Text = "";
                tbx_address.Text = "";
                tbx_phone.Text = "";
            }
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            string strQuery = string.Format(@"call PROC_ORDERS_CUSTOMER_BOOK ({0}, {1}, {2}) ", tbx_custid.Text, tbx_bookid.Text, tbx_price.Text);

            MySqlConnection mySqlConnection = new MySqlConnection(connetionString);
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = mySqlConnection;
            mySqlCommand.CommandText = strQuery;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            MessageBox.Show("OK");

        }
    }
}
