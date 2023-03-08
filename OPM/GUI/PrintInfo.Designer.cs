
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvName)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.dgvName.Size = new System.Drawing.Size(666, 621);
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
            this.btnExcelPrint.Location = new System.Drawing.Point(791, 570);
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
            this.btnWordPrint.Location = new System.Drawing.Point(916, 570);
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
            this.groupBox1.Location = new System.Drawing.Point(692, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 131);
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
            // PrintInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 645);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnWordPrint);
            this.Controls.Add(this.btnExcelPrint);
            this.Controls.Add(this.dgvName);
            this.Name = "PrintInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test";
            ((System.ComponentModel.ISupportInitialize)(this.dgvName)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

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
    }
}