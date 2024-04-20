namespace _230427_EX_SQL
{
    partial class frmBook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_insert = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_bookid = new System.Windows.Forms.TextBox();
            this.tbx_bookname = new System.Windows.Forms.TextBox();
            this.tbx_publisher = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_price = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_insert
            // 
            this.btn_insert.Location = new System.Drawing.Point(102, 204);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(120, 42);
            this.btn_insert.TabIndex = 0;
            this.btn_insert.Text = " 추가";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(257, 204);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(120, 42);
            this.btn_update.TabIndex = 1;
            this.btn_update.Text = "수정";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(410, 204);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(120, 42);
            this.btn_delete.TabIndex = 2;
            this.btn_delete.Text = "삭제";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "도서코드";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbx_bookid
            // 
            this.tbx_bookid.Location = new System.Drawing.Point(179, 56);
            this.tbx_bookid.Name = "tbx_bookid";
            this.tbx_bookid.Size = new System.Drawing.Size(351, 21);
            this.tbx_bookid.TabIndex = 4;
            this.tbx_bookid.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tbx_bookname
            // 
            this.tbx_bookname.Location = new System.Drawing.Point(179, 88);
            this.tbx_bookname.Name = "tbx_bookname";
            this.tbx_bookname.Size = new System.Drawing.Size(351, 21);
            this.tbx_bookname.TabIndex = 5;
            // 
            // tbx_publisher
            // 
            this.tbx_publisher.Location = new System.Drawing.Point(179, 123);
            this.tbx_publisher.Name = "tbx_publisher";
            this.tbx_publisher.Size = new System.Drawing.Size(351, 21);
            this.tbx_publisher.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "도서명";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "출판사";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "가격";
            // 
            // tbx_price
            // 
            this.tbx_price.Location = new System.Drawing.Point(179, 160);
            this.tbx_price.Name = "tbx_price";
            this.tbx_price.Size = new System.Drawing.Size(351, 21);
            this.tbx_price.TabIndex = 10;
            // 
            // frmBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 308);
            this.Controls.Add(this.tbx_price);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_publisher);
            this.Controls.Add(this.tbx_bookname);
            this.Controls.Add(this.tbx_bookid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_insert);
            this.Name = "frmBook";
            this.Text = "도서정보";
            this.Load += new System.EventHandler(this.frmBook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_bookid;
        private System.Windows.Forms.TextBox tbx_bookname;
        private System.Windows.Forms.TextBox tbx_publisher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_price;
    }
}