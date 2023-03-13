
namespace OPM.GUI
{
    partial class DeliveryAddendumInfo
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
            this.dtgAddendum = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbnSTT = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.btnImportNTKTDt = new System.Windows.Forms.Button();
            this.dtpEdDate = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.btnDeleteNTKTDetail = new System.Windows.Forms.Button();
            this.btnAddNTKTDetail = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSparegoods = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMainline = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ccbVNPTId = new System.Windows.Forms.ComboBox();
            this.tbID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAddendum)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgAddendum
            // 
            this.dtgAddendum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAddendum.Location = new System.Drawing.Point(4, 1);
            this.dtgAddendum.Name = "dtgAddendum";
            this.dtgAddendum.RowTemplate.Height = 25;
            this.dtgAddendum.Size = new System.Drawing.Size(1030, 798);
            this.dtgAddendum.TabIndex = 28;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbnSTT);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.tb_path);
            this.groupBox1.Controls.Add(this.btnImportNTKTDt);
            this.groupBox1.Controls.Add(this.dtpEdDate);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.btnDeleteNTKTDetail);
            this.groupBox1.Controls.Add(this.btnAddNTKTDetail);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtSparegoods);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtMainline);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.ccbVNPTId);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(1040, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 452);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phụ lục giao hàng cho các tỉnh";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 21);
            this.label1.TabIndex = 40;
            this.label1.Text = "Số thứ tự";
            // 
            // tbnSTT
            // 
            this.tbnSTT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbnSTT.Location = new System.Drawing.Point(6, 59);
            this.tbnSTT.Name = "tbnSTT";
            this.tbnSTT.Size = new System.Drawing.Size(305, 29);
            this.tbnSTT.TabIndex = 39;
            this.tbnSTT.TextChanged += new System.EventHandler(this.tbnSTT_TextChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label25.Location = new System.Drawing.Point(6, 319);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(80, 21);
            this.label25.TabIndex = 38;
            this.label25.Text = "File Name";
            // 
            // tb_path
            // 
            this.tb_path.Enabled = false;
            this.tb_path.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_path.Location = new System.Drawing.Point(6, 343);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(305, 29);
            this.tb_path.TabIndex = 37;
            // 
            // btnImportNTKTDt
            // 
            this.btnImportNTKTDt.BackColor = System.Drawing.Color.LightGreen;
            this.btnImportNTKTDt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnImportNTKTDt.Location = new System.Drawing.Point(220, 395);
            this.btnImportNTKTDt.Name = "btnImportNTKTDt";
            this.btnImportNTKTDt.Size = new System.Drawing.Size(91, 40);
            this.btnImportNTKTDt.TabIndex = 36;
            this.btnImportNTKTDt.Text = "Import";
            this.btnImportNTKTDt.UseVisualStyleBackColor = false;
            this.btnImportNTKTDt.Click += new System.EventHandler(this.btnImportNTKTDt_Click);
            // 
            // dtpEdDate
            // 
            this.dtpEdDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEdDate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpEdDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEdDate.Location = new System.Drawing.Point(6, 283);
            this.dtpEdDate.Name = "dtpEdDate";
            this.dtpEdDate.Size = new System.Drawing.Size(305, 33);
            this.dtpEdDate.TabIndex = 32;
            this.dtpEdDate.ValueChanged += new System.EventHandler(this.dtpEdDate_ValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label20.Location = new System.Drawing.Point(6, 259);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(175, 21);
            this.label20.TabIndex = 31;
            this.label20.Text = "Ngày giao hàng dự kiến";
            // 
            // btnDeleteNTKTDetail
            // 
            this.btnDeleteNTKTDetail.BackColor = System.Drawing.Color.Silver;
            this.btnDeleteNTKTDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteNTKTDetail.Location = new System.Drawing.Point(8, 395);
            this.btnDeleteNTKTDetail.Name = "btnDeleteNTKTDetail";
            this.btnDeleteNTKTDetail.Size = new System.Drawing.Size(91, 40);
            this.btnDeleteNTKTDetail.TabIndex = 35;
            this.btnDeleteNTKTDetail.Text = "Delete";
            this.btnDeleteNTKTDetail.UseVisualStyleBackColor = false;
            this.btnDeleteNTKTDetail.Click += new System.EventHandler(this.btnDeleteNTKTDetail_Click);
            // 
            // btnAddNTKTDetail
            // 
            this.btnAddNTKTDetail.BackColor = System.Drawing.Color.Salmon;
            this.btnAddNTKTDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddNTKTDetail.Location = new System.Drawing.Point(115, 395);
            this.btnAddNTKTDetail.Name = "btnAddNTKTDetail";
            this.btnAddNTKTDetail.Size = new System.Drawing.Size(91, 40);
            this.btnAddNTKTDetail.TabIndex = 34;
            this.btnAddNTKTDetail.Text = "Add";
            this.btnAddNTKTDetail.UseVisualStyleBackColor = false;
            this.btnAddNTKTDetail.Click += new System.EventHandler(this.btnAddNTKTDetail_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(6, 203);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(219, 21);
            this.label15.TabIndex = 33;
            this.label15.Text = "Số lượng hàng dự phòng (2%)";
            // 
            // txtSparegoods
            // 
            this.txtSparegoods.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSparegoods.Location = new System.Drawing.Point(6, 227);
            this.txtSparegoods.Name = "txtSparegoods";
            this.txtSparegoods.Size = new System.Drawing.Size(305, 29);
            this.txtSparegoods.TabIndex = 32;
            this.txtSparegoods.TextChanged += new System.EventHandler(this.txtSparegoods_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(6, 147);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(164, 21);
            this.label14.TabIndex = 31;
            this.label14.Text = "Số lượng (hàng chính)";
            // 
            // txtMainline
            // 
            this.txtMainline.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMainline.Location = new System.Drawing.Point(6, 171);
            this.txtMainline.Name = "txtMainline";
            this.txtMainline.Size = new System.Drawing.Size(305, 29);
            this.txtMainline.TabIndex = 30;
            this.txtMainline.TextChanged += new System.EventHandler(this.txtMainline_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(6, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 21);
            this.label11.TabIndex = 21;
            this.label11.Text = "VNPT ID";
            // 
            // ccbVNPTId
            // 
            this.ccbVNPTId.FormattingEnabled = true;
            this.ccbVNPTId.Location = new System.Drawing.Point(6, 115);
            this.ccbVNPTId.Name = "ccbVNPTId";
            this.ccbVNPTId.Size = new System.Drawing.Size(305, 29);
            this.ccbVNPTId.TabIndex = 0;
            this.ccbVNPTId.SelectedIndexChanged += new System.EventHandler(this.ccbVNPTId_SelectedIndexChanged);
            // 
            // tbID
            // 
            this.tbID.Enabled = false;
            this.tbID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbID.Location = new System.Drawing.Point(1040, 770);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(0, 29);
            this.tbID.TabIndex = 36;
            // 
            // DeliveryAddendumInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 803);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtgAddendum);
            this.Name = "DeliveryAddendumInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phụ lục giao hàng";
            this.Load += new System.EventHandler(this.DeliveryAddendumInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAddendum)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgAddendum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbnSTT;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.Button btnImportNTKTDt;
        private System.Windows.Forms.DateTimePicker dtpEdDate;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnDeleteNTKTDetail;
        private System.Windows.Forms.Button btnAddNTKTDetail;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSparegoods;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMainline;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ccbVNPTId;
        private System.Windows.Forms.TextBox tbID;
    }
}