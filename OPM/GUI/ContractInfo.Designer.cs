
using System.Drawing;

namespace OPM.GUI
{
    partial class ContractInfo
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
            this.btnIdSiteA = new System.Windows.Forms.Button();
            this.txtContractId = new System.Windows.Forms.TextBox();
            this.txtContractName = new System.Windows.Forms.TextBox();
            this.txtAccoutingCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtPOGuaranteeValidityPeriod = new System.Windows.Forms.TextBox();
            this.txtSiteId = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txbGuaranteeValue = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpContractDeadline = new System.Windows.Forms.DateTimePicker();
            this.dtpContractValidityDate = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.txtContractShoppingPlan = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dtpGuaranteeDeadline = new System.Windows.Forms.DateTimePicker();
            this.txtGuaranteeDuration = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.ccb_siteA = new System.Windows.Forms.ComboBox();
            this.dtpContractCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.dateTimePickerContractLiquidationRecordsDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerContractReportOfConpletedVolumeDate = new System.Windows.Forms.DateTimePicker();
            this.btnAnnex = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.textBoxContractTotalAmountPaidCurrency = new System.Windows.Forms.TextBox();
            this.textBoxContractTotalAmountPaid = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpGuaranteeDateCreated = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnCreatDocument = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnNewPO = new System.Windows.Forms.Button();
            this.btnNotification = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIdSiteA
            // 
            this.btnIdSiteA.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnIdSiteA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIdSiteA.Location = new System.Drawing.Point(1058, 334);
            this.btnIdSiteA.Name = "btnIdSiteA";
            this.btnIdSiteA.Size = new System.Drawing.Size(94, 34);
            this.btnIdSiteA.TabIndex = 10;
            this.btnIdSiteA.Text = "Chi tiết bên A";
            this.btnIdSiteA.UseVisualStyleBackColor = true;
            this.btnIdSiteA.Click += new System.EventHandler(this.btnIdSiteA_Click);
            // 
            // txtContractId
            // 
            this.txtContractId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContractId.BackColor = System.Drawing.SystemColors.Window;
            this.txtContractId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtContractId.Location = new System.Drawing.Point(271, 16);
            this.txtContractId.Name = "txtContractId";
            this.txtContractId.Size = new System.Drawing.Size(881, 29);
            this.txtContractId.TabIndex = 1;
            this.txtContractId.TextChanged += new System.EventHandler(this.txtContractId_TextChanged);
            // 
            // txtContractName
            // 
            this.txtContractName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContractName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtContractName.Location = new System.Drawing.Point(271, 100);
            this.txtContractName.Name = "txtContractName";
            this.txtContractName.Size = new System.Drawing.Size(881, 29);
            this.txtContractName.TabIndex = 3;
            this.txtContractName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtAccoutingCode
            // 
            this.txtAccoutingCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAccoutingCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAccoutingCode.Location = new System.Drawing.Point(271, 374);
            this.txtAccoutingCode.Name = "txtAccoutingCode";
            this.txtAccoutingCode.Size = new System.Drawing.Size(881, 29);
            this.txtAccoutingCode.TabIndex = 11;
            this.txtAccoutingCode.TextChanged += new System.EventHandler(this.txtAccountingCode_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Lavender;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(30, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Hợp Đồng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(30, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên Gói Thầu";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(30, 377);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã Kế Toán";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(30, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày Ký";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(30, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "Thời Hạn Thực Hiện";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(30, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "Loại Hợp Đồng";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(30, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 21);
            this.label7.TabIndex = 5;
            this.label7.Text = "Ngày Hiệu Lực";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(30, 297);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 21);
            this.label8.TabIndex = 8;
            this.label8.Text = "Giá trị trước VAT";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(25, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(200, 21);
            this.label9.TabIndex = 13;
            this.label9.Text = "Thời hạn hiệu lực đơn hàng";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(30, 339);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 21);
            this.label10.TabIndex = 9;
            this.label10.Text = "SiteA";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDuration
            // 
            this.txtDuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDuration.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDuration.Location = new System.Drawing.Point(271, 258);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(264, 29);
            this.txtDuration.TabIndex = 7;
            this.txtDuration.TextChanged += new System.EventHandler(this.txtDuration_TextChanged);
            // 
            // txtType
            // 
            this.txtType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtType.Location = new System.Drawing.Point(271, 177);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(881, 29);
            this.txtType.TabIndex = 5;
            this.txtType.TextChanged += new System.EventHandler(this.txtType_TextChanged);
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.BackColor = System.Drawing.SystemColors.Window;
            this.txtValue.Enabled = false;
            this.txtValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtValue.Location = new System.Drawing.Point(271, 296);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(688, 29);
            this.txtValue.TabIndex = 9;
            // 
            // txtPOGuaranteeValidityPeriod
            // 
            this.txtPOGuaranteeValidityPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPOGuaranteeValidityPeriod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPOGuaranteeValidityPeriod.Location = new System.Drawing.Point(281, 102);
            this.txtPOGuaranteeValidityPeriod.Name = "txtPOGuaranteeValidityPeriod";
            this.txtPOGuaranteeValidityPeriod.Size = new System.Drawing.Size(254, 29);
            this.txtPOGuaranteeValidityPeriod.TabIndex = 18;
            this.txtPOGuaranteeValidityPeriod.TextChanged += new System.EventHandler(this.txtDurationPO_TextChanged);
            // 
            // txtSiteId
            // 
            this.txtSiteId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSiteId.Enabled = false;
            this.txtSiteId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSiteId.Location = new System.Drawing.Point(271, 336);
            this.txtSiteId.Name = "txtSiteId";
            this.txtSiteId.Size = new System.Drawing.Size(113, 29);
            this.txtSiteId.TabIndex = 9;
            this.txtSiteId.TextChanged += new System.EventHandler(this.txtIdSiteA_TextChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelete.BackColor = System.Drawing.Color.Silver;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(368, 802);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 62);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.BackColor = System.Drawing.Color.Salmon;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(525, 802);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 62);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txbGuaranteeValue
            // 
            this.txbGuaranteeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbGuaranteeValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbGuaranteeValue.Location = new System.Drawing.Point(281, 57);
            this.txbGuaranteeValue.Name = "txbGuaranteeValue";
            this.txbGuaranteeValue.Size = new System.Drawing.Size(254, 29);
            this.txbGuaranteeValue.TabIndex = 17;
            this.txbGuaranteeValue.TextChanged += new System.EventHandler(this.txbGaranteeValue_TextChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(25, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(177, 21);
            this.label12.TabIndex = 12;
            this.label12.Text = "Tỷ lệ bảo lãnh đơn hàng";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(25, 157);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(167, 21);
            this.label13.TabIndex = 14;
            this.label13.Text = "Ngày hết hạn bảo lãnh";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(559, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(28, 25);
            this.label14.TabIndex = 3;
            this.label14.Text = "%";
            // 
            // dtpContractDeadline
            // 
            this.dtpContractDeadline.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dtpContractDeadline.CustomFormat = "dd/MM/yyyy";
            this.dtpContractDeadline.Enabled = false;
            this.dtpContractDeadline.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpContractDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpContractDeadline.Location = new System.Drawing.Point(695, 252);
            this.dtpContractDeadline.Name = "dtpContractDeadline";
            this.dtpContractDeadline.Size = new System.Drawing.Size(264, 33);
            this.dtpContractDeadline.TabIndex = 8;
            // 
            // dtpContractValidityDate
            // 
            this.dtpContractValidityDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpContractValidityDate.CustomFormat = "dd/MM/yyyy";
            this.dtpContractValidityDate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpContractValidityDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpContractValidityDate.Location = new System.Drawing.Point(271, 215);
            this.dtpContractValidityDate.Name = "dtpContractValidityDate";
            this.dtpContractValidityDate.Size = new System.Drawing.Size(264, 33);
            this.dtpContractValidityDate.TabIndex = 6;
            this.dtpContractValidityDate.ValueChanged += new System.EventHandler(this.dtpActiveDate_ValueChanged);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(30, 139);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(145, 21);
            this.label16.TabIndex = 0;
            this.label16.Text = "Kế Hoạch Mua Sắm";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtContractShoppingPlan
            // 
            this.txtContractShoppingPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContractShoppingPlan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtContractShoppingPlan.Location = new System.Drawing.Point(271, 139);
            this.txtContractShoppingPlan.Name = "txtContractShoppingPlan";
            this.txtContractShoppingPlan.Size = new System.Drawing.Size(881, 29);
            this.txtContractShoppingPlan.TabIndex = 4;
            this.txtContractShoppingPlan.TextChanged += new System.EventHandler(this.txtContractShoppingPlan_TextChanged);
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(965, 299);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 21);
            this.label17.TabIndex = 13;
            this.label17.Text = "VND";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label18.Location = new System.Drawing.Point(541, 261);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 21);
            this.label18.TabIndex = 14;
            this.label18.Text = "Ngày";
            // 
            // dtpGuaranteeDeadline
            // 
            this.dtpGuaranteeDeadline.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpGuaranteeDeadline.CustomFormat = "dd/MM/yyyy";
            this.dtpGuaranteeDeadline.Enabled = false;
            this.dtpGuaranteeDeadline.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpGuaranteeDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGuaranteeDeadline.Location = new System.Drawing.Point(636, 148);
            this.dtpGuaranteeDeadline.Name = "dtpGuaranteeDeadline";
            this.dtpGuaranteeDeadline.Size = new System.Drawing.Size(482, 33);
            this.dtpGuaranteeDeadline.TabIndex = 20;
            // 
            // txtGuaranteeDuration
            // 
            this.txtGuaranteeDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGuaranteeDuration.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtGuaranteeDuration.Location = new System.Drawing.Point(281, 151);
            this.txtGuaranteeDuration.Name = "txtGuaranteeDuration";
            this.txtGuaranteeDuration.Size = new System.Drawing.Size(254, 29);
            this.txtGuaranteeDuration.TabIndex = 19;
            this.txtGuaranteeDuration.TextChanged += new System.EventHandler(this.txtGuaranteeDuration_TextChanged);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(559, 154);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 21);
            this.label15.TabIndex = 14;
            this.label15.Text = "Ngày";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.ccb_siteA);
            this.panel1.Controls.Add(this.dtpContractCreatedDate);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.dtpContractDeadline);
            this.panel1.Controls.Add(this.dateTimePickerContractLiquidationRecordsDate);
            this.panel1.Controls.Add(this.dateTimePickerContractReportOfConpletedVolumeDate);
            this.panel1.Controls.Add(this.dtpContractValidityDate);
            this.panel1.Controls.Add(this.txtContractShoppingPlan);
            this.panel1.Controls.Add(this.btnAnnex);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxContractTotalAmountPaidCurrency);
            this.panel1.Controls.Add(this.textBoxContractTotalAmountPaid);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtContractName);
            this.panel1.Controls.Add(this.txtSiteId);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.btnIdSiteA);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtValue);
            this.panel1.Controls.Add(this.txtAccoutingCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtContractId);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtDuration);
            this.panel1.Controls.Add(this.txtType);
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1164, 548);
            this.panel1.TabIndex = 3;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label25.Location = new System.Drawing.Point(404, 339);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(81, 21);
            this.label25.TabIndex = 18;
            this.label25.Text = "Tên đơn vị";
            // 
            // ccb_siteA
            // 
            this.ccb_siteA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ccb_siteA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ccb_siteA.FormattingEnabled = true;
            this.ccb_siteA.IntegralHeight = false;
            this.ccb_siteA.Location = new System.Drawing.Point(491, 336);
            this.ccb_siteA.Name = "ccb_siteA";
            this.ccb_siteA.Size = new System.Drawing.Size(468, 29);
            this.ccb_siteA.TabIndex = 10;
            this.ccb_siteA.SelectedValueChanged += new System.EventHandler(this.ccb_siteA_SelectedValueChanged);
            // 
            // dtpContractCreatedDate
            // 
            this.dtpContractCreatedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpContractCreatedDate.CustomFormat = "dd/MM/yyyy";
            this.dtpContractCreatedDate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpContractCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpContractCreatedDate.Location = new System.Drawing.Point(271, 55);
            this.dtpContractCreatedDate.Name = "dtpContractCreatedDate";
            this.dtpContractCreatedDate.Size = new System.Drawing.Size(264, 33);
            this.dtpContractCreatedDate.TabIndex = 2;
            this.dtpContractCreatedDate.ValueChanged += new System.EventHandler(this.dtpContractCreatedDate_ValueChanged);
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label24.Location = new System.Drawing.Point(658, 505);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(25, 25);
            this.label24.TabIndex = 13;
            this.label24.Text = "=";
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label23.Location = new System.Drawing.Point(1086, 507);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(43, 21);
            this.label23.TabIndex = 13;
            this.label23.Text = "VND";
            // 
            // dateTimePickerContractLiquidationRecordsDate
            // 
            this.dateTimePickerContractLiquidationRecordsDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerContractLiquidationRecordsDate.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerContractLiquidationRecordsDate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerContractLiquidationRecordsDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerContractLiquidationRecordsDate.Location = new System.Drawing.Point(404, 454);
            this.dateTimePickerContractLiquidationRecordsDate.Name = "dateTimePickerContractLiquidationRecordsDate";
            this.dateTimePickerContractLiquidationRecordsDate.Size = new System.Drawing.Size(304, 33);
            this.dateTimePickerContractLiquidationRecordsDate.TabIndex = 13;
            this.dateTimePickerContractLiquidationRecordsDate.ValueChanged += new System.EventHandler(this.dateTimePickerContractLiquidationRecordsDate_ValueChanged);
            // 
            // dateTimePickerContractReportOfConpletedVolumeDate
            // 
            this.dateTimePickerContractReportOfConpletedVolumeDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerContractReportOfConpletedVolumeDate.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerContractReportOfConpletedVolumeDate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerContractReportOfConpletedVolumeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerContractReportOfConpletedVolumeDate.Location = new System.Drawing.Point(404, 412);
            this.dateTimePickerContractReportOfConpletedVolumeDate.Name = "dateTimePickerContractReportOfConpletedVolumeDate";
            this.dateTimePickerContractReportOfConpletedVolumeDate.Size = new System.Drawing.Size(304, 33);
            this.dateTimePickerContractReportOfConpletedVolumeDate.TabIndex = 12;
            this.dateTimePickerContractReportOfConpletedVolumeDate.ValueChanged += new System.EventHandler(this.dateTimePickerContractReportOfConpletedVolumeDate_ValueChanged);
            // 
            // btnAnnex
            // 
            this.btnAnnex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnex.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAnnex.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAnnex.Location = new System.Drawing.Point(1058, 292);
            this.btnAnnex.Name = "btnAnnex";
            this.btnAnnex.Size = new System.Drawing.Size(94, 34);
            this.btnAnnex.TabIndex = 9;
            this.btnAnnex.Text = "Bảng giá";
            this.btnAnnex.UseVisualStyleBackColor = true;
            this.btnAnnex.Click += new System.EventHandler(this.BtnAnnex_Click);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label22.Location = new System.Drawing.Point(30, 507);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(195, 21);
            this.label22.TabIndex = 0;
            this.label22.Text = "Tổng số tiền đã thanh toán";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxContractTotalAmountPaidCurrency
            // 
            this.textBoxContractTotalAmountPaidCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxContractTotalAmountPaidCurrency.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxContractTotalAmountPaidCurrency.Location = new System.Drawing.Point(708, 504);
            this.textBoxContractTotalAmountPaidCurrency.Name = "textBoxContractTotalAmountPaidCurrency";
            this.textBoxContractTotalAmountPaidCurrency.Size = new System.Drawing.Size(360, 29);
            this.textBoxContractTotalAmountPaidCurrency.TabIndex = 15;
            this.textBoxContractTotalAmountPaidCurrency.TextChanged += new System.EventHandler(this.textBoxContractTotalAmountPaid_TextChanged);
            // 
            // textBoxContractTotalAmountPaid
            // 
            this.textBoxContractTotalAmountPaid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxContractTotalAmountPaid.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxContractTotalAmountPaid.Location = new System.Drawing.Point(271, 504);
            this.textBoxContractTotalAmountPaid.Name = "textBoxContractTotalAmountPaid";
            this.textBoxContractTotalAmountPaid.Size = new System.Drawing.Size(381, 29);
            this.textBoxContractTotalAmountPaid.TabIndex = 14;
            this.textBoxContractTotalAmountPaid.TextChanged += new System.EventHandler(this.textBoxContractTotalAmountPaid_TextChanged);
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label21.Location = new System.Drawing.Point(30, 463);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(243, 21);
            this.label21.TabIndex = 5;
            this.label21.Text = "Ngày biên bản thanh lý hợp đồng";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(30, 421);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(338, 21);
            this.label11.TabIndex = 5;
            this.label11.Text = "Ngày biên bản xác nhận khối lượng hoàn thành";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.txtGuaranteeDuration);
            this.panel2.Controls.Add(this.dtpGuaranteeDateCreated);
            this.panel2.Controls.Add(this.dtpGuaranteeDeadline);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.txbGuaranteeValue);
            this.panel2.Controls.Add(this.txtPOGuaranteeValidityPeriod);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Location = new System.Drawing.Point(0, 574);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1164, 207);
            this.panel2.TabIndex = 4;
            // 
            // dtpGuaranteeDateCreated
            // 
            this.dtpGuaranteeDateCreated.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpGuaranteeDateCreated.CustomFormat = "dd/MM/yyyy";
            this.dtpGuaranteeDateCreated.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpGuaranteeDateCreated.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGuaranteeDateCreated.Location = new System.Drawing.Point(281, 7);
            this.dtpGuaranteeDateCreated.Name = "dtpGuaranteeDateCreated";
            this.dtpGuaranteeDateCreated.Size = new System.Drawing.Size(254, 33);
            this.dtpGuaranteeDateCreated.TabIndex = 16;
            this.dtpGuaranteeDateCreated.ValueChanged += new System.EventHandler(this.dtpGaranteeDateCreated_ValueChanged);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label20.Location = new System.Drawing.Point(25, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(137, 21);
            this.label20.TabIndex = 11;
            this.label20.Text = "Ngày tạo bảo lãnh";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label19.Location = new System.Drawing.Point(559, 105);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 21);
            this.label19.TabIndex = 13;
            this.label19.Text = "Ngày";
            // 
            // btnCreatDocument
            // 
            this.btnCreatDocument.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCreatDocument.BackColor = System.Drawing.Color.SkyBlue;
            this.btnCreatDocument.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCreatDocument.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreatDocument.Location = new System.Drawing.Point(686, 802);
            this.btnCreatDocument.Name = "btnCreatDocument";
            this.btnCreatDocument.Size = new System.Drawing.Size(90, 62);
            this.btnCreatDocument.TabIndex = 6;
            this.btnCreatDocument.Text = "CreateDoc";
            this.btnCreatDocument.UseVisualStyleBackColor = false;
            this.btnCreatDocument.Click += new System.EventHandler(this.btnCreatDocument_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.MistyRose;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(25, 802);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(90, 62);
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnNewPO
            // 
            this.btnNewPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewPO.BackColor = System.Drawing.Color.LightGreen;
            this.btnNewPO.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNewPO.Location = new System.Drawing.Point(1039, 802);
            this.btnNewPO.Name = "btnNewPO";
            this.btnNewPO.Size = new System.Drawing.Size(90, 62);
            this.btnNewPO.TabIndex = 7;
            this.btnNewPO.Text = "New PO";
            this.btnNewPO.UseVisualStyleBackColor = false;
            this.btnNewPO.Click += new System.EventHandler(this.btnNewPO_Click);
            // 
            // btnNotification
            // 
            this.btnNotification.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnNotification.Image = global::OPM.Properties.Resources.notification_35px;
            this.btnNotification.Location = new System.Drawing.Point(1058, -1);
            this.btnNotification.Name = "btnNotification";
            this.btnNotification.Size = new System.Drawing.Size(40, 40);
            this.btnNotification.TabIndex = 10;
            this.btnNotification.UseVisualStyleBackColor = false;
            this.btnNotification.Click += new System.EventHandler(this.btnNotification_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Khaki;
            this.btnSettings.Image = global::OPM.Properties.Resources.settings_35px;
            this.btnSettings.Location = new System.Drawing.Point(1112, -1);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(40, 40);
            this.btnSettings.TabIndex = 11;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPrint.Image = global::OPM.Properties.Resources.print_30px;
            this.btnPrint.Location = new System.Drawing.Point(1001, -1);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(40, 40);
            this.btnPrint.TabIndex = 12;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ContractInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Lavender;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1164, 888);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnNotification);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNewPO);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCreatDocument);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ContractInfo";
            this.Text = "ContractInfoChildForm";
            this.Load += new System.EventHandler(this.ContractInfoChildForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIdSiteA;
        private System.Windows.Forms.TextBox txtContractId;
        private System.Windows.Forms.TextBox txtContractName;
        private System.Windows.Forms.TextBox txtAccoutingCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtPOGuaranteeValidityPeriod;
        private System.Windows.Forms.TextBox txtSiteId;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txbGuaranteeValue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpContractDeadline;
        private System.Windows.Forms.DateTimePicker dtpContractValidityDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtContractShoppingPlan;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dtpGuaranteeDeadline;
        private System.Windows.Forms.TextBox txtGuaranteeDuration;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAnnex;
        private System.Windows.Forms.DateTimePicker dtpGuaranteeDateCreated;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnCreatDocument;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker dateTimePickerContractReportOfConpletedVolumeDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateTimePickerContractLiquidationRecordsDate;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBoxContractTotalAmountPaid;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBoxContractTotalAmountPaidCurrency;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DateTimePicker dtpContractCreatedDate;
        private System.Windows.Forms.ComboBox ccb_siteA;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnNewPO;
        private System.Windows.Forms.Button btnNotification;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnPrint;
    }
}