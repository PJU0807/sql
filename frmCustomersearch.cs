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
using static _230427_EX_SQL.frmBooksearch;
using static _230427_EX_SQL.frmCustomersearch;

namespace _230427_EX_SQL
{
    public partial class frmCustomersearch : Form
    {
        public string connetionString = "Server=www.db4free.net;Database=wjddnd4682;Uid=wjddnd4682;pwd=123456789";
        public string szOrderid = string.Empty;
        public struct CustomerInfor
        {
            public string custid { get; set; }
            public string name { get; set; }
            public string address { get; set; }
            public string phone { get; set; }
        }
        public CustomerInfor customerInfor = new CustomerInfor();

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
        private void SetGridView(DataGridView thisGrid)
        {
            thisGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            thisGrid.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public frmCustomersearch()
        {
            InitializeComponent();
        }

        private void frmCustomersearch_Load(object sender, EventArgs e)
        {
            string strQuery = "SELECT * FROM Customer";
            DataTable dataTable = new DataTable();

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, connetionString))
            {
                adapter.Fill((dataTable));
            }
            dataGridView1.Columns.Clear();
            SetCustomer();
            SetGridView(dataGridView1);
            dataGridView1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strQuery = string.Format("SELECT * FROM Customer where name like '%{0}%'", tbx_name.Text);
            DataTable dataTable = new DataTable();

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, connetionString))
            {
                adapter.Fill((dataTable));
            }
            dataGridView1.Columns.Clear();
            SetCustomer();
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
            customerInfor.custid = dataGridView1.Rows[RowIndex].Cells[0].Value.ToString();
            customerInfor.name = dataGridView1.Rows[RowIndex].Cells[1].Value.ToString();
            customerInfor.address = dataGridView1.Rows[RowIndex].Cells[2].Value.ToString();
            customerInfor.phone = dataGridView1.Rows[RowIndex].Cells[3].Value.ToString();
            MessageBox.Show(szMsg);
            DialogResult = DialogResult.OK;
        }
    }
}
