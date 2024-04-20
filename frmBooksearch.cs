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
    public partial class frmBooksearch : Form
    {
        public string connetionString = "Server=www.db4free.net;Database=wjddnd4682;Uid=wjddnd4682;pwd=123456789";
        public string szOrderid = string.Empty;
        public struct BookInfor
        {
            public string bookid { get; set; }
            public string bookname { get; set; }
            public string publisher { get; set; }
            public string price { get; set; }
        }
        public BookInfor bookInfor = new BookInfor();
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
        private void SetGridView(DataGridView thisGrid)
        {
            thisGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            thisGrid.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public frmBooksearch()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmBooksearch_Load(object sender, EventArgs e)
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
            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strQuery = string.Format("SELECT * FROM Book where bookname like '%{0}%'", tbx_bookname.Text);
            DataTable dataTable = new DataTable();

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, connetionString))
            {
                adapter.Fill((dataTable));
            }
            dataGridView1.Columns.Clear();
            SetBook();
            SetGridView(dataGridView1);
            dataGridView1.DataSource = dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int RowIndex = dataGridView1.CurrentRow.Index;
            string szMsg = string.Format("{0}\n{1}\n{2}\n{3}",
                            dataGridView1.Rows[RowIndex].Cells[0].Value.ToString(),
                            dataGridView1.Rows[RowIndex].Cells[1].Value.ToString(),
                            dataGridView1.Rows[RowIndex].Cells[2].Value.ToString(),
                            dataGridView1.Rows[RowIndex].Cells[3].Value.ToString());
            bookInfor.bookid = dataGridView1.Rows[RowIndex].Cells[0].Value.ToString();
            bookInfor.bookname = dataGridView1.Rows[RowIndex].Cells[1].Value.ToString();
            bookInfor.publisher = dataGridView1.Rows[RowIndex].Cells[2].Value.ToString();
            bookInfor.price = dataGridView1.Rows[RowIndex].Cells[3].Value.ToString();
            MessageBox.Show(szMsg);
            DialogResult = DialogResult.OK;
        }
    }
}
