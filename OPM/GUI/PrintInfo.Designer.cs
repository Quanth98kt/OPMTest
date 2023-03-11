
namespace OPM.GUI
{
    partial class PrintInfo
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
            this.dgvName = new System.Windows.Forms.DataGridView();
            this.FileNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExcelPrint = new System.Windows.Forms.Button();
            this.btnWordPrint = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbnSheet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrintPDF = new System.Windows.Forms.Button();
            this.btnPicturePrint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnArrange = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvName)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvName
            // 
            this.dgvName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvName.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileNames});
            this.dgvName.Location = new System.Drawing.Point(5, 12);
            this.dgvName.Name = "dgvName";
            this.dgvName.RowHeadersWidth = 50;
            this.dgvName.RowTemplate.Height = 25;
            this.dgvName.Size = new System.Drawing.Size(666, 280);
            this.dgvName.TabIndex = 0;
            // 
            // FileNames
            // 
            this.FileNames.HeaderText = "Tên tài liệu";
            this.FileNames.Name = "FileNames";
            this.FileNames.Width = 800;
            // 
            // btnExcelPrint
            // 
            this.btnExcelPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcelPrint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExcelPrint.Location = new System.Drawing.Point(63, 114);
            this.btnExcelPrint.Name = "btnExcelPrint";
            this.btnExcelPrint.Size = new System.Drawing.Size(101, 63);
            this.btnExcelPrint.TabIndex = 1;
            this.btnExcelPrint.Text = "Excel Print";
            this.btnExcelPrint.UseVisualStyleBackColor = false;
            this.btnExcelPrint.Click += new System.EventHandler(this.btnExcelPrint_Click);
            // 
            // btnWordPrint
            // 
            this.btnWordPrint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnWordPrint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnWordPrint.Location = new System.Drawing.Point(224, 114);
            this.btnWordPrint.Name = "btnWordPrint";
            this.btnWordPrint.Size = new System.Drawing.Size(101, 63);
            this.btnWordPrint.TabIndex = 2;
            this.btnWordPrint.Text = "Word Print";
            this.btnWordPrint.UseVisualStyleBackColor = false;
            this.btnWordPrint.Click += new System.EventHandler(this.btnWordPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbnSheet);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(690, 271);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Excel";
            // 
            // tbnSheet
            // 
            this.tbnSheet.Location = new System.Drawing.Point(7, 82);
            this.tbnSheet.Name = "tbnSheet";
            this.tbnSheet.Size = new System.Drawing.Size(318, 29);
            this.tbnSheet.TabIndex = 2;
            this.tbnSheet.Text = "1";
            this.tbnSheet.TextChanged += new System.EventHandler(this.tbnSheet_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(150, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngăn cách bởi dấu \",\"";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn Sheet cần in:";
            // 
            // btnPrintPDF
            // 
            this.btnPrintPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPrintPDF.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPrintPDF.Location = new System.Drawing.Point(224, 28);
            this.btnPrintPDF.Name = "btnPrintPDF";
            this.btnPrintPDF.Size = new System.Drawing.Size(101, 63);
            this.btnPrintPDF.TabIndex = 3;
            this.btnPrintPDF.Text = "PDF Print";
            this.btnPrintPDF.UseVisualStyleBackColor = false;
            this.btnPrintPDF.Click += new System.EventHandler(this.btnPrintPDF_Click);
            // 
            // btnPicturePrint
            // 
            this.btnPicturePrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnPicturePrint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPicturePrint.Location = new System.Drawing.Point(63, 28);
            this.btnPicturePrint.Name = "btnPicturePrint";
            this.btnPicturePrint.Size = new System.Drawing.Size(101, 63);
            this.btnPicturePrint.TabIndex = 4;
            this.btnPicturePrint.Text = "Picture Print";
            this.btnPicturePrint.UseVisualStyleBackColor = false;
            this.btnPicturePrint.Click += new System.EventHandler(this.btnPicturePrint_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(692, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 51);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lưu ý: \r\nCài đặt Adobe Reader trước khi Print PDF\r\nLink: https://get.adobe.com/re" +
    "ader/";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPicturePrint);
            this.groupBox2.Controls.Add(this.btnPrintPDF);
            this.groupBox2.Controls.Add(this.btnExcelPrint);
            this.groupBox2.Controls.Add(this.btnWordPrint);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(690, 459);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 183);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Print";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnArrange);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(690, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(335, 210);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PL";
            // 
            // btnArrange
            // 
            this.btnArrange.BackColor = System.Drawing.Color.Silver;
            this.btnArrange.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnArrange.Location = new System.Drawing.Point(63, 28);
            this.btnArrange.Name = "btnArrange";
            this.btnArrange.Size = new System.Drawing.Size(101, 63);
            this.btnArrange.TabIndex = 8;
            this.btnArrange.Text = "PL Arrange";
            this.btnArrange.UseVisualStyleBackColor = false;
            this.btnArrange.Click += new System.EventHandler(this.btnArrange_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 317);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(666, 179);
            this.dataGridView1.TabIndex = 8;
            // 
            // PrintInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 645);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvName);
            this.Name = "PrintInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Printer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvName)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvName;
        private System.Windows.Forms.Button btnExcelPrint;
        private System.Windows.Forms.Button btnWordPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileNames;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbnSheet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrintPDF;
        private System.Windows.Forms.Button btnPicturePrint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnArrange;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}