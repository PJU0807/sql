using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;
using static _230427_EX_SQL.Form1;

namespace _230427_EX_SQL
{
    public partial class Form1 : Form
    {

        public string connetionString = "Server=www.db4free.net;Database=wjddnd4682;Uid=wjddnd4682;pwd=123456789";


        public enum FormTypes
        {
            Book,
            Customer,
            Order
        }
        public FormTypes formtypes = FormTypes.Book;

        public Form1()
        {
            InitializeComponent();
        }

        private void SetBook()
        {
            dataGridView1.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn makeColumn = new DataGridViewTextBoxColumn();
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
        }

        private void SetCustomer()
        {
            dataGridView1.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn makeColumn = new DataGridViewTextBoxColumn();
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

        private void SetGridView(DataGridView thisGrid)
        {
            thisGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            thisGrid.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strQuery = "SELECT * FROM Book";
            DataTable dataTable = new DataTable();

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, connetionString))
            {
                adapter.Fill((dataTable));
            }

            dataGridView1.Columns.Clear();
            SetBook();
            SetGridView(dataGridView1);

            formtypes = FormTypes.Book;
            dataGridView1.DataSource = dataTable;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            string strQuery = "SELECT * FROM Customer";
            DataTable dataTable = new DataTable();

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, connetionString))
            {
                adapter.Fill((dataTable));
            }

            dataGridView1.Columns.Clear();
            SetCustomer();

            formtypes = FormTypes.Customer;
            dataGridView1.DataSource = dataTable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strQuery = "SELECT o.orderid, o.custid, c.name, c.address, c.phone, o.bookid, b.bookname, b.publisher, b.price, o.saleprice, o.orderdate from Orders o left outer join Customer c on o.custid = c.custid LEFT OUTER JOIN Book b on o.bookid = b.bookid";
            DataTable dataTable = new DataTable();

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, connetionString))
            {
                adapter.Fill((dataTable));
            }

            dataGridView1.Columns.Clear();
            SetOrders();
            SetGridView(dataGridView1);

            formtypes = FormTypes.Order;
            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string szMsg = "";

                switch (formtypes)
                {
                    case FormTypes.Book:
                        szMsg = string.Format("{0}\n{1}\n{2}\n{3}",
                            dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                            dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                            dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(),
                            dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                        MessageBox.Show(szMsg);

                        frmBook frmbook = new frmBook();
                        frmbook.szBookid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        frmbook.ShowDialog();
                        break;
                    case FormTypes.Customer:
                        szMsg = string.Format("{0}\n{1}\n{2}\n{3}",
                            dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                            dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                            dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(),
                            dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                        MessageBox.Show(szMsg);

                        frmCustomer frmcustomer = new frmCustomer();
                        frmcustomer.szCustid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        frmcustomer.ShowDialog();
                        break;
                    case FormTypes.Order:
                        szMsg = string.Format("{0}\n{1}\n{2}\n{3}",
                            dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                            dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                            dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(),
                            dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                        MessageBox.Show(szMsg);
                        frmOrder frmorder = new frmOrder();
                        frmorder.Text = "주문정보";
                        frmorder.szOrderid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        frmorder.ShowDialog();

                        break;


                }
            }

        }
    }
}
