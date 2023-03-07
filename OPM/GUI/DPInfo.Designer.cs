
namespace OPM.GUI
{
    partial class DPInfo
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
            this.btnClose = new System.Windows.Forms.Button();
            this.textBoxVNPTIdTotalQuantity = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxDPType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPLDetail = new System.Windows.Forms.Button();
            this.btnDPNew = new System.Windows.Forms.Button();
            this.textBoxDPRemarks = new System.Windows.Forms.TextBox();
            this.btnDPDelete = new System.Windows.Forms.Button();
            this.btnDPSave = new System.Windows.Forms.Button();
            this.textBoxPLId = new System.Windows.Forms.TextBox();
            this.dateTimePickerDPDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxDPId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRemainingPOGoodsQuantity = new System.Windows.Forms.TextBox();
            this.txtPOGoodsQuantity = new System.Windows.Forms.TextBox();
            this.txtRemainingContractGoodsQuantity = new System.Windows.Forms.TextBox();
            this.txtContractGoodsQuantity = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtVNPTId = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonCreateDoc = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDPContractAccoutingCode = new System.Windows.Forms.TextBox();
            this.textBoxDPVNPTTechANSVContractNumber = new System.Windows.Forms.TextBox();
            this.textBoxDPQuantity1 = new System.Windows.Forms.TextBox();
            this.textBoxDPQuantity = new System.Windows.Forms.TextBox();
            this.dateTimePickerDPRefundDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDPResponseDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDPRequestDate = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtRemainingVNPTTotalQuantity = new System.Windows.Forms.TextBox();
            this.txtPLQuantity = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPLQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxVNPTId = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxRemainingDPQuantity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxRemainingVNPTTotalQuantity = new System.Windows.Forms.TextBox();
            this.btnPLAdd = new System.Windows.Forms.Button();
            this.btnPLDelete = new System.Windows.Forms.Button();
            this.dtgDP = new System.Windows.Forms.DataGridView();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDP)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Silver;
            this.btnClose.Location = new System.Drawing.Point(512, 818);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(124, 58);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Back";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // textBoxVNPTIdTotalQuantity
            // 
            this.textBoxVNPTIdTotalQuantity.Enabled = false;
            this.textBoxVNPTIdTotalQuantity.Location = new System.Drawing.Point(176, 540);
            this.textBoxVNPTIdTotalQuantity.Name = "textBoxVNPTIdTotalQuantity";
            this.textBoxVNPTIdTotalQuantity.Size = new System.Drawing.Size(485, 29);
            this.textBoxVNPTIdTotalQuantity.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 442);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 21);
            this.label10.TabIndex = 2;
            this.label10.Text = "Ghi chú";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 280);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 21);
            this.label9.TabIndex = 2;
            this.label9.Text = "Phân loại";
            // 
            // comboBoxDPType
            // 
            this.comboBoxDPType.FormattingEnabled = true;
            this.comboBoxDPType.Items.AddRange(new object[] {
            "Hàng chính",
            "Hàng dự phòng 2%"});
            this.comboBoxDPType.Location = new System.Drawing.Point(176, 277);
            this.comboBoxDPType.Name = "comboBoxDPType";
            this.comboBoxDPType.Size = new System.Drawing.Size(205, 29);
            this.comboBoxDPType.TabIndex = 4;
            this.comboBoxDPType.Text = "Hàng chính";
            this.comboBoxDPType.SelectedIndexChanged += new System.EventHandler(this.comboBoxDPType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 590);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "PLId";
            // 
            // btnPLDetail
            // 
            this.btnPLDetail.BackColor = System.Drawing.Color.Aquamarine;
            this.btnPLDetail.Location = new System.Drawing.Point(570, 575);
            this.btnPLDetail.Name = "btnPLDetail";
            this.btnPLDetail.Size = new System.Drawing.Size(91, 50);
            this.btnPLDetail.TabIndex = 1;
            this.btnPLDetail.Text = "PLDetail";
            this.btnPLDetail.UseVisualStyleBackColor = false;
            this.btnPLDetail.Click += new System.EventHandler(this.btnNewPL_Click);
            // 
            // btnDPNew
            // 
            this.btnDPNew.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDPNew.Location = new System.Drawing.Point(98, 633);
            this.btnDPNew.Name = "btnDPNew";
            this.btnDPNew.Size = new System.Drawing.Size(91, 51);
            this.btnDPNew.TabIndex = 1;
            this.btnDPNew.Text = "DP - New";
            this.btnDPNew.UseVisualStyleBackColor = false;
            this.btnDPNew.Click += new System.EventHandler(this.btnNewDP_Click);
            // 
            // textBoxDPRemarks
            // 
            this.textBoxDPRemarks.Location = new System.Drawing.Point(176, 439);
            this.textBoxDPRemarks.Name = "textBoxDPRemarks";
            this.textBoxDPRemarks.Size = new System.Drawing.Size(485, 29);
            this.textBoxDPRemarks.TabIndex = 3;
            this.textBoxDPRemarks.TextChanged += new System.EventHandler(this.textBoxDPRemarks_TextChanged);
            // 
            // btnDPDelete
            // 
            this.btnDPDelete.BackColor = System.Drawing.Color.Silver;
            this.btnDPDelete.Location = new System.Drawing.Point(236, 633);
            this.btnDPDelete.Name = "btnDPDelete";
            this.btnDPDelete.Size = new System.Drawing.Size(91, 51);
            this.btnDPDelete.TabIndex = 1;
            this.btnDPDelete.Text = "DP - Delete";
            this.btnDPDelete.UseVisualStyleBackColor = false;
            this.btnDPDelete.Click += new System.EventHandler(this.btnDeleteDP_Click);
            // 
            // btnDPSave
            // 
            this.btnDPSave.BackColor = System.Drawing.Color.Salmon;
            this.btnDPSave.Location = new System.Drawing.Point(371, 633);
            this.btnDPSave.Name = "btnDPSave";
            this.btnDPSave.Size = new System.Drawing.Size(91, 51);
            this.btnDPSave.TabIndex = 1;
            this.btnDPSave.Text = "DP - Save";
            this.btnDPSave.UseVisualStyleBackColor = false;
            this.btnDPSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBoxPLId
            // 
            this.textBoxPLId.Enabled = false;
            this.textBoxPLId.Location = new System.Drawing.Point(176, 587);
            this.textBoxPLId.Name = "textBoxPLId";
            this.textBoxPLId.Size = new System.Drawing.Size(385, 29);
            this.textBoxPLId.TabIndex = 3;
            // 
            // dateTimePickerDPDate
            // 
            this.dateTimePickerDPDate.CalendarFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDPDate.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerDPDate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDPDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDPDate.Location = new System.Drawing.Point(175, 129);
            this.dateTimePickerDPDate.Name = "dateTimePickerDPDate";
            this.dateTimePickerDPDate.Size = new System.Drawing.Size(206, 33);
            this.dateTimePickerDPDate.TabIndex = 4;
            this.dateTimePickerDPDate.ValueChanged += new System.EventHandler(this.dateTimePickerDPDate_ValueChanged);
            // 
            // textBoxDPId
            // 
            this.textBoxDPId.Location = new System.Drawing.Point(175, 96);
            this.textBoxDPId.Name = "textBoxDPId";
            this.textBoxDPId.Size = new System.Drawing.Size(486, 29);
            this.textBoxDPId.TabIndex = 3;
            this.textBoxDPId.TextChanged += new System.EventHandler(this.textBoxDPNumber_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 21);
            this.label6.TabIndex = 2;
            this.label6.Text = "Ngày DP";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(24, 35);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(108, 21);
            this.label17.TabIndex = 2;
            this.label17.Text = "Tổng Contract";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "DPId";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(392, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 21);
            this.label19.TabIndex = 2;
            this.label19.Text = "Còn lại";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(395, 66);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 21);
            this.label18.TabIndex = 2;
            this.label18.Text = "Còn lại";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 543);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 21);
            this.label7.TabIndex = 2;
            this.label7.Text = "Tổng số VNPT";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(25, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 21);
            this.label15.TabIndex = 2;
            this.label15.Text = "Tổng số PO";
            // 
            // txtRemainingPOGoodsQuantity
            // 
            this.txtRemainingPOGoodsQuantity.Enabled = false;
            this.txtRemainingPOGoodsQuantity.Location = new System.Drawing.Point(466, 63);
            this.txtRemainingPOGoodsQuantity.Name = "txtRemainingPOGoodsQuantity";
            this.txtRemainingPOGoodsQuantity.Size = new System.Drawing.Size(195, 29);
            this.txtRemainingPOGoodsQuantity.TabIndex = 3;
            // 
            // txtPOGoodsQuantity
            // 
            this.txtPOGoodsQuantity.Enabled = false;
            this.txtPOGoodsQuantity.Location = new System.Drawing.Point(176, 62);
            this.txtPOGoodsQuantity.Name = "txtPOGoodsQuantity";
            this.txtPOGoodsQuantity.Size = new System.Drawing.Size(205, 29);
            this.txtPOGoodsQuantity.TabIndex = 3;
            // 
            // txtRemainingContractGoodsQuantity
            // 
            this.txtRemainingContractGoodsQuantity.Enabled = false;
            this.txtRemainingContractGoodsQuantity.Location = new System.Drawing.Point(466, 31);
            this.txtRemainingContractGoodsQuantity.Name = "txtRemainingContractGoodsQuantity";
            this.txtRemainingContractGoodsQuantity.Size = new System.Drawing.Size(195, 29);
            this.txtRemainingContractGoodsQuantity.TabIndex = 3;
            // 
            // txtContractGoodsQuantity
            // 
            this.txtContractGoodsQuantity.Enabled = false;
            this.txtContractGoodsQuantity.Location = new System.Drawing.Point(175, 31);
            this.txtContractGoodsQuantity.Name = "txtContractGoodsQuantity";
            this.txtContractGoodsQuantity.Size = new System.Drawing.Size(206, 29);
            this.txtContractGoodsQuantity.TabIndex = 3;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtVNPTId);
            this.groupBox7.Controls.Add(this.label24);
            this.groupBox7.Controls.Add(this.label23);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.buttonCreateDoc);
            this.groupBox7.Controls.Add(this.comboBoxDPType);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.textBoxDPContractAccoutingCode);
            this.groupBox7.Controls.Add(this.textBoxDPVNPTTechANSVContractNumber);
            this.groupBox7.Controls.Add(this.btnPLDetail);
            this.groupBox7.Controls.Add(this.textBoxDPQuantity1);
            this.groupBox7.Controls.Add(this.textBoxDPQuantity);
            this.groupBox7.Controls.Add(this.btnDPNew);
            this.groupBox7.Controls.Add(this.textBoxDPRemarks);
            this.groupBox7.Controls.Add(this.btnDPDelete);
            this.groupBox7.Controls.Add(this.btnDPSave);
            this.groupBox7.Controls.Add(this.textBoxPLId);
            this.groupBox7.Controls.Add(this.dateTimePickerDPRefundDate);
            this.groupBox7.Controls.Add(this.dateTimePickerDPResponseDate);
            this.groupBox7.Controls.Add(this.dateTimePickerDPRequestDate);
            this.groupBox7.Controls.Add(this.dateTimePickerDPDate);
            this.groupBox7.Controls.Add(this.label22);
            this.groupBox7.Controls.Add(this.textBoxDPId);
            this.groupBox7.Controls.Add(this.label20);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.txtRemainingPOGoodsQuantity);
            this.groupBox7.Controls.Add(this.txtPOGoodsQuantity);
            this.groupBox7.Controls.Add(this.txtRemainingVNPTTotalQuantity);
            this.groupBox7.Controls.Add(this.txtRemainingContractGoodsQuantity);
            this.groupBox7.Controls.Add(this.txtPLQuantity);
            this.groupBox7.Controls.Add(this.textBoxVNPTIdTotalQuantity);
            this.groupBox7.Controls.Add(this.txtContractGoodsQuantity);
            this.groupBox7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox7.Location = new System.Drawing.Point(481, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(678, 690);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Thao tác với bảng DP";
            // 
            // txtVNPTId
            // 
            this.txtVNPTId.Enabled = false;
            this.txtVNPTId.Location = new System.Drawing.Point(175, 472);
            this.txtVNPTId.Name = "txtVNPTId";
            this.txtVNPTId.Size = new System.Drawing.Size(123, 29);
            this.txtVNPTId.TabIndex = 6;
            this.txtVNPTId.TextChanged += new System.EventHandler(this.txtVNPTId_TextChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(24, 409);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(87, 21);
            this.label24.TabIndex = 2;
            this.label24.Text = "Mã kế toán";
            this.label24.Click += new System.EventHandler(this.label24_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(24, 377);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(131, 21);
            this.label23.TabIndex = 2;
            this.label23.Text = "Số HĐ VNPT Tech";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 345);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(140, 21);
            this.label13.TabIndex = 2;
            this.label13.Text = "Số lượng thực xuất";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 313);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 21);
            this.label11.TabIndex = 2;
            this.label11.Text = "Số lượng yêu cầu";
            // 
            // buttonCreateDoc
            // 
            this.buttonCreateDoc.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonCreateDoc.Location = new System.Drawing.Point(508, 631);
            this.buttonCreateDoc.Name = "buttonCreateDoc";
            this.buttonCreateDoc.Size = new System.Drawing.Size(91, 51);
            this.buttonCreateDoc.TabIndex = 1;
            this.buttonCreateDoc.Text = "Create Doc";
            this.buttonCreateDoc.UseVisualStyleBackColor = false;
            this.buttonCreateDoc.Click += new System.EventHandler(this.buttonCreateDoc_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 475);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "VNPTId";
            // 
            // textBoxDPContractAccoutingCode
            // 
            this.textBoxDPContractAccoutingCode.Location = new System.Drawing.Point(176, 406);
            this.textBoxDPContractAccoutingCode.Name = "textBoxDPContractAccoutingCode";
            this.textBoxDPContractAccoutingCode.Size = new System.Drawing.Size(485, 29);
            this.textBoxDPContractAccoutingCode.TabIndex = 3;
            this.textBoxDPContractAccoutingCode.TextChanged += new System.EventHandler(this.textBoxDPContractAccoutingCode_TextChanged);
            // 
            // textBoxDPVNPTTechANSVContractNumber
            // 
            this.textBoxDPVNPTTechANSVContractNumber.Location = new System.Drawing.Point(176, 374);
            this.textBoxDPVNPTTechANSVContractNumber.Name = "textBoxDPVNPTTechANSVContractNumber";
            this.textBoxDPVNPTTechANSVContractNumber.Size = new System.Drawing.Size(485, 29);
            this.textBoxDPVNPTTechANSVContractNumber.TabIndex = 3;
            this.textBoxDPVNPTTechANSVContractNumber.TextChanged += new System.EventHandler(this.textBoxDPVNPTTechANSVContractNumber_TextChanged);
            // 
            // textBoxDPQuantity1
            // 
            this.textBoxDPQuantity1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxDPQuantity1.Location = new System.Drawing.Point(175, 342);
            this.textBoxDPQuantity1.Name = "textBoxDPQuantity1";
            this.textBoxDPQuantity1.Size = new System.Drawing.Size(486, 29);
            this.textBoxDPQuantity1.TabIndex = 3;
            this.textBoxDPQuantity1.TextChanged += new System.EventHandler(this.textBoxDPQuantity1_TextChanged);
            // 
            // textBoxDPQuantity
            // 
            this.textBoxDPQuantity.Location = new System.Drawing.Point(176, 310);
            this.textBoxDPQuantity.Name = "textBoxDPQuantity";
            this.textBoxDPQuantity.Size = new System.Drawing.Size(485, 29);
            this.textBoxDPQuantity.TabIndex = 3;
            this.textBoxDPQuantity.TextChanged += new System.EventHandler(this.textBoxDPQuantity_TextChanged);
            // 
            // dateTimePickerDPRefundDate
            // 
            this.dateTimePickerDPRefundDate.CalendarFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDPRefundDate.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerDPRefundDate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDPRefundDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDPRefundDate.Location = new System.Drawing.Point(176, 240);
            this.dateTimePickerDPRefundDate.Name = "dateTimePickerDPRefundDate";
            this.dateTimePickerDPRefundDate.Size = new System.Drawing.Size(205, 33);
            this.dateTimePickerDPRefundDate.TabIndex = 4;
            this.dateTimePickerDPRefundDate.ValueChanged += new System.EventHandler(this.dateTimePickerDPRefundDate_ValueChanged);
            // 
            // dateTimePickerDPResponseDate
            // 
            this.dateTimePickerDPResponseDate.CalendarFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDPResponseDate.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerDPResponseDate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDPResponseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDPResponseDate.Location = new System.Drawing.Point(175, 203);
            this.dateTimePickerDPResponseDate.Name = "dateTimePickerDPResponseDate";
            this.dateTimePickerDPResponseDate.Size = new System.Drawing.Size(206, 33);
            this.dateTimePickerDPResponseDate.TabIndex = 4;
            this.dateTimePickerDPResponseDate.ValueChanged += new System.EventHandler(this.dateTimePickerDPResponseDate_ValueChanged);
            // 
            // dateTimePickerDPRequestDate
            // 
            this.dateTimePickerDPRequestDate.CalendarFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDPRequestDate.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerDPRequestDate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerDPRequestDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDPRequestDate.Location = new System.Drawing.Point(175, 166);
            this.dateTimePickerDPRequestDate.Name = "dateTimePickerDPRequestDate";
            this.dateTimePickerDPRequestDate.Size = new System.Drawing.Size(206, 33);
            this.dateTimePickerDPRequestDate.TabIndex = 4;
            this.dateTimePickerDPRequestDate.ValueChanged += new System.EventHandler(this.dateTimePickerDPRequestDate_ValueChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(25, 245);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(109, 21);
            this.label22.TabIndex = 2;
            this.label22.Text = "Ngày hoàn trả";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(25, 210);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(112, 21);
            this.label20.TabIndex = 2;
            this.label20.Text = "Ngày Xuất kho";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 173);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(126, 21);
            this.label14.TabIndex = 2;
            this.label14.Text = "Ngày Yêu cầu XK";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(257, 508);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(208, 21);
            this.label21.TabIndex = 2;
            this.label21.Text = "Còn lại để hoàn thành KHGH";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(338, 475);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(127, 21);
            this.label16.TabIndex = 2;
            this.label16.Text = "SL giao trong DP";
            // 
            // txtRemainingVNPTTotalQuantity
            // 
            this.txtRemainingVNPTTotalQuantity.Enabled = false;
            this.txtRemainingVNPTTotalQuantity.Location = new System.Drawing.Point(471, 505);
            this.txtRemainingVNPTTotalQuantity.Name = "txtRemainingVNPTTotalQuantity";
            this.txtRemainingVNPTTotalQuantity.Size = new System.Drawing.Size(190, 29);
            this.txtRemainingVNPTTotalQuantity.TabIndex = 3;
            // 
            // txtPLQuantity
            // 
            this.txtPLQuantity.Enabled = false;
            this.txtPLQuantity.Location = new System.Drawing.Point(471, 472);
            this.txtPLQuantity.Name = "txtPLQuantity";
            this.txtPLQuantity.Size = new System.Drawing.Size(190, 29);
            this.txtPLQuantity.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxPLQuantity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxVNPTId);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBoxRemainingDPQuantity);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxRemainingVNPTTotalQuantity);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(481, 708);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(678, 104);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thao tác với bảng PL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số lượng";
            // 
            // textBoxPLQuantity
            // 
            this.textBoxPLQuantity.Location = new System.Drawing.Point(110, 65);
            this.textBoxPLQuantity.Name = "textBoxPLQuantity";
            this.textBoxPLQuantity.Size = new System.Drawing.Size(200, 29);
            this.textBoxPLQuantity.TabIndex = 3;
            this.textBoxPLQuantity.TextChanged += new System.EventHandler(this.textBoxPLQuantity_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "VNPTId";
            // 
            // comboBoxVNPTId
            // 
            this.comboBoxVNPTId.FormattingEnabled = true;
            this.comboBoxVNPTId.Location = new System.Drawing.Point(110, 28);
            this.comboBoxVNPTId.Name = "comboBoxVNPTId";
            this.comboBoxVNPTId.Size = new System.Drawing.Size(129, 29);
            this.comboBoxVNPTId.TabIndex = 4;
            this.comboBoxVNPTId.SelectedIndexChanged += new System.EventHandler(this.comboBoxVNPTId_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(338, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(142, 21);
            this.label12.TabIndex = 2;
            this.label12.Text = "SL còn lại trong DP";
            // 
            // textBoxRemainingDPQuantity
            // 
            this.textBoxRemainingDPQuantity.Enabled = false;
            this.textBoxRemainingDPQuantity.Location = new System.Drawing.Point(486, 65);
            this.textBoxRemainingDPQuantity.Name = "textBoxRemainingDPQuantity";
            this.textBoxRemainingDPQuantity.Size = new System.Drawing.Size(175, 29);
            this.textBoxRemainingDPQuantity.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(272, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(208, 21);
            this.label8.TabIndex = 2;
            this.label8.Text = "Còn lại để hoàn thành KHGH";
            // 
            // textBoxRemainingVNPTTotalQuantity
            // 
            this.textBoxRemainingVNPTTotalQuantity.Enabled = false;
            this.textBoxRemainingVNPTTotalQuantity.Location = new System.Drawing.Point(486, 28);
            this.textBoxRemainingVNPTTotalQuantity.Name = "textBoxRemainingVNPTTotalQuantity";
            this.textBoxRemainingVNPTTotalQuantity.Size = new System.Drawing.Size(175, 29);
            this.textBoxRemainingVNPTTotalQuantity.TabIndex = 3;
            // 
            // btnPLAdd
            // 
            this.btnPLAdd.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPLAdd.Location = new System.Drawing.Point(1018, 818);
            this.btnPLAdd.Name = "btnPLAdd";
            this.btnPLAdd.Size = new System.Drawing.Size(124, 58);
            this.btnPLAdd.TabIndex = 1;
            this.btnPLAdd.Text = "PL - Add";
            this.btnPLAdd.UseVisualStyleBackColor = false;
            this.btnPLAdd.Click += new System.EventHandler(this.btnPLAdd_Click);
            // 
            // btnPLDelete
            // 
            this.btnPLDelete.BackColor = System.Drawing.Color.Silver;
            this.btnPLDelete.Location = new System.Drawing.Point(776, 818);
            this.btnPLDelete.Name = "btnPLDelete";
            this.btnPLDelete.Size = new System.Drawing.Size(124, 58);
            this.btnPLDelete.TabIndex = 1;
            this.btnPLDelete.Text = "PL - Delete";
            this.btnPLDelete.UseVisualStyleBackColor = false;
            this.btnPLDelete.Click += new System.EventHandler(this.btnPLDelete_Click);
            // 
            // dtgDP
            // 
            this.dtgDP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDP.Location = new System.Drawing.Point(12, 12);
            this.dtgDP.Name = "dtgDP";
            this.dtgDP.RowHeadersWidth = 62;
            this.dtgDP.RowTemplate.Height = 25;
            this.dtgDP.Size = new System.Drawing.Size(463, 864);
            this.dtgDP.TabIndex = 0;
            // 
            // DPInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1172, 888);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnPLAdd);
            this.Controls.Add(this.dtgDP);
            this.Controls.Add(this.btnPLDelete);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DPInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DPInfo_Load);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox textBoxVNPTIdTotalQuantity;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRemainingContractGoodsQuantity;
        private System.Windows.Forms.TextBox txtContractGoodsQuantity;
        private System.Windows.Forms.TextBox txtRemainingPOGoodsQuantity;
        private System.Windows.Forms.TextBox txtPOGoodsQuantity;
        private System.Windows.Forms.TextBox textBoxPLId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDPId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerDPDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDPSave;
        private System.Windows.Forms.Button btnDPDelete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDPNew;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxDPType;
        private System.Windows.Forms.TextBox textBoxDPRemarks;
        private System.Windows.Forms.Button btnPLDetail;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPLAdd;
        private System.Windows.Forms.Button btnPLDelete;
        private System.Windows.Forms.DataGridView dtgDP;
        private System.Windows.Forms.TextBox txtVNPTId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtRemainingVNPTTotalQuantity;
        private System.Windows.Forms.TextBox txtPLQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPLQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxVNPTId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxRemainingVNPTTotalQuantity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxDPQuantity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxRemainingDPQuantity;
        private System.Windows.Forms.Button buttonCreateDoc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxDPQuantity1;
        private System.Windows.Forms.DateTimePicker dateTimePickerDPResponseDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDPRequestDate;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dateTimePickerDPRefundDate;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBoxDPVNPTTechANSVContractNumber;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBoxDPContractAccoutingCode;
    }
}