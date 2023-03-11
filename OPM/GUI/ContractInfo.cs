using OPM.OPMEnginee;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
namespace OPM.GUI
{
    public partial class ContractInfo : Form
    {
        public ContractInfo()
        {
            InitializeComponent();
        }
        public void State(bool state)
        {
            txtContractShoppingPlan.ReadOnly = state;
            txtContractId.ReadOnly = state;
            txtContractName.ReadOnly = state;
            txtAccoutingCode.ReadOnly = state;
            txtDuration.ReadOnly = state;
            txtType.ReadOnly = state;
            txtPOGuaranteeValidityPeriod.ReadOnly = state;
            txbGuaranteeValue.ReadOnly = state;
            txtGuaranteeDuration.ReadOnly = state;
            txtSiteId.ReadOnly = state;
            dtpContractValidityDate.Enabled = !state;
            dtpContractCreatedDate.Enabled = !state;
            dtpGuaranteeDateCreated.Enabled = !state;
        }
        //Tải các thông số ContractForm với Contract tương ứng
        private void LoadData()
        {
            ContractObj contract = (Tag as OPMDASHBOARDA).Contract;
            txtContractShoppingPlan.Text = contract.ContractShoppingPlan;
            txtContractId.Text = contract.ContractId;
            txtContractId.Tag = txtContractId.Text;
            txtContractName.Text = contract.ContractName;
            txtAccoutingCode.Text = contract.ContractAccoutingCode;
            dtpContractCreatedDate.Value = contract.ContractCreatedDate;
            dtpContractDeadline.Value = contract.ContractDeadline;
            txtType.Text = contract.ContractType;
            txtDuration.Text = contract.ContractPeriod.ToString();
            dtpContractValidityDate.Value = contract.ContractValidityDate;
            //txtValue.Text = Math.Round(contract.ContractValue).ToString();
            txtValue.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", contract.ContractValue);
            txtPOGuaranteeValidityPeriod.Text = contract.POGuaranteeValidityPeriod.ToString();
            txtSiteId.Text = contract.SiteId;
            
            //txtSiteId.Text = contract.SiteName;
            txtGuaranteeDuration.Text = (contract.ContractGuaranteeDeadline - contract.ContractGuaranteeCreatedDate).Days.ToString();
            txbGuaranteeValue.Text = contract.POGuaranteeRatio.ToString();
            dtpGuaranteeDateCreated.Value = contract.ContractGuaranteeCreatedDate;
            dateTimePickerContractReportOfConpletedVolumeDate.Value = contract.ContractReportOfConpletedVolumeDate;
            dateTimePickerContractLiquidationRecordsDate.Value = contract.ContractLiquidationRecordsDate;
            textBoxContractTotalAmountPaid.Text = contract.ContractTotalAmountPaid.ToString();

        }

        private void test()
        {
            if (MailSending.Notifi())
            {
                btnNotification.Image = new Bitmap(Application.StartupPath + "\\Resources\\topic_push_notification_30px.png"); ;
            }
            else
            {
                btnNotification.Image = new Bitmap(Application.StartupPath + "\\Resources\\notification_35px.png"); ;
            }
        }

        private void LoadSiteA()
        {
            List<SiteObj> sites = SiteObj.SiteGetList();
            SiteObj site = new SiteObj();
            ccb_siteA.DataSource = SiteObj.SiteGetList();
            ccb_siteA.DisplayMember = "SiteName";
            ccb_siteA.Text = (Tag as OPMDASHBOARDA).SiteA.SiteName;
        }

        //Mở Form thông tin Site A
        private void btnIdSiteA_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).backSiteFormStatus = 0;
            (Tag as OPMDASHBOARDA).OpenSiteAForm((Tag as OPMDASHBOARDA).SiteA.SiteId);
        }
        //Mở Form PO
        private void btnNewPO_Click(object sender, EventArgs e)
        {
            if ((Tag as OPMDASHBOARDA).Contract.ContractExist())
            {
                (Tag as OPMDASHBOARDA).CurrentNodeName = "PO_" + (new POObj()).POId;
            }
            else
            {
                MessageBox.Show(string.Format("Vẫn chưa lưu hợp đồng số {0}", (Tag as OPMDASHBOARDA).Contract.ContractId), "Thông báo");
            }
        }

        private void dtpActiveDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtDuration.Text.Trim()))
                {
                    dtpContractDeadline.Value = dtpContractValidityDate.Value.AddDays(double.Parse(txtDuration.Text.Trim()));
                    (Tag as OPMDASHBOARDA).Contract.ContractDeadline = dtpContractDeadline.Value;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn phải chọn đúng định dạng ngày bắt đầu hợp đồng có hiệu lực!", "Thông báo");
                return;
            }
            (Tag as OPMDASHBOARDA).Contract.ContractValidityDate = dtpContractValidityDate.Value;
        }
        private void txtDuration_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDuration.Text.Trim()))
                try
                {
                    dtpContractDeadline.Value = dtpContractValidityDate.Value.AddDays(double.Parse(txtDuration.Text.Trim()));
                    (Tag as OPMDASHBOARDA).Contract.ContractDeadline = dtpContractDeadline.Value;
                }
                catch (Exception)
                {
                    MessageBox.Show("Bạn phải nhập đúng số lượng (bằng số) ngày trong hợp đồng!", "Thông báo");
                    return;
                }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            State(false);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).DeleteSQLByNodeName();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtContractId.Text.Trim()) || txtContractId.Text.Trim() == (new ContractObj()).ContractId)
            {
                MessageBox.Show("Nhập đúng số hợp đồng!");
                return;
            }
            if (string.IsNullOrEmpty(txtValue.Text.Trim()))
            {
                MessageBox.Show("Nhập thông tin giá trị hợp đồng!");
                return;
            }
            if (string.IsNullOrEmpty(txtSiteId.Text.Trim()) || txtSiteId.Text.Trim() == (new SiteObj()).SiteId)
            {
                MessageBox.Show("Nhập đúng chi tiết SiteA!");
                return;
            }
            if (string.IsNullOrEmpty(txtType.Text.Trim()))
            {
                DialogResult dialogResult = MessageBox.Show("Loại HĐ đang trống, bạn muốn tiếp tục lưu?","Thông báo",MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            
            DayOfWeek day = dtpContractDeadline.Value.DayOfWeek;

            if ((day == DayOfWeek.Saturday) || (day == DayOfWeek.Sunday))
            {
                DialogResult dialogResult = MessageBox.Show("Ngày hiệu lực của hợp đồng là ngày cuối tuần, bạn muốn tiếp tục lưu?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            (Tag as OPMDASHBOARDA).SaveSQLByNodeName();
        }
        private void ContractInfoChildForm_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadSiteA();
            test();
        }

        private void BtnAnnex_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).OpenGoodsForm();
        }
        private void btnCreatDocument_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CreatDocumentByNodeName();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "Contract_" + (new ContractObj()).ContractId;
        }
        private void txtContractId_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeId = txtContractId.Text.Trim();
            (Tag as OPMDASHBOARDA).SetNameOfSelectNode(txtContractId.Text.Trim());
            if (ContractObj.ContractExist(txtContractId.Text.Trim()))
            {
                if (("Contract_" + txtContractId.Text.Trim()) != (Tag as OPMDASHBOARDA).CurrentNodeName)
                {
                    MessageBox.Show("Đã tồn tại hợp đồng số " + txtContractId.Text.Trim());
                }
                return;
            }
            (Tag as OPMDASHBOARDA).Contract.ContractId = txtContractId.Text.Trim();
        }
        private void txtContractShoppingPlan_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractShoppingPlan = txtContractShoppingPlan.Text.Trim();
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractName = txtContractName.Text.Trim();
        }
        private void txtAccountingCode_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractAccoutingCode = txtAccoutingCode.Text.Trim();
        }
        private void dtpDateSigned_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractCreatedDate = dtpContractCreatedDate.Value;
        }
        private void txtType_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractType = txtType.Text.Trim();
        }
        private void dtpGaranteeDateCreated_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractGuaranteeCreatedDate = dtpGuaranteeDateCreated.Value;
            try
            {
                if (!string.IsNullOrEmpty(txtGuaranteeDuration.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Contract.ContractGuaranteeDeadline = dtpGuaranteeDateCreated.Value.AddDays(int.Parse(txtGuaranteeDuration.Text.Trim()));
                    dtpGuaranteeDeadline.Value = dtpGuaranteeDateCreated.Value.AddDays(int.Parse(txtGuaranteeDuration.Text.Trim()));
                }
                else
                    dtpGuaranteeDeadline.Value = dtpGuaranteeDateCreated.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại dạng số thời hạn bảo lãnh!");
            }
        }
        private void txtDurationPO_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPOGuaranteeValidityPeriod.Text.Trim()))
                    (Tag as OPMDASHBOARDA).Contract.POGuaranteeValidityPeriod = Convert.ToInt32(txtPOGuaranteeValidityPeriod.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Cần nhập đúng định dạng số ngày bảo lãnh PO!");
                return;
            }
        }
        private void txbGaranteeValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txbGuaranteeValue.Text.Trim()) && Convert.ToInt32(txbGuaranteeValue.Text.Trim()) >= 0 && Convert.ToInt32(txbGuaranteeValue.Text.Trim()) <= 100)
                {
                    (Tag as OPMDASHBOARDA).Contract.POGuaranteeRatio = int.Parse(txbGuaranteeValue.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Giá trị không hợp lệ, vui lòng nhập lại!");
                }
            }
            catch
            {
                MessageBox.Show("Cần nhập đúng định dạng giá trị bảo lãnh!");
                return;
            }
        }
        private void txtGuaranteeDuration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtGuaranteeDuration.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Contract.ContractGuaranteeDeadline = dtpGuaranteeDateCreated.Value.AddDays(int.Parse(txtGuaranteeDuration.Text.Trim()));
                    dtpGuaranteeDeadline.Value = dtpGuaranteeDateCreated.Value.AddDays(int.Parse(txtGuaranteeDuration.Text.Trim()));
                }
                else
                    dtpGuaranteeDeadline.Value = dtpGuaranteeDateCreated.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại dạng số thời hạn bảo lãnh!");
            }
        }

        private void txtIdSiteA_TextChanged(object sender, EventArgs e)
        {
            //(Tag as OPMDASHBOARDA).Contract.SiteId = txtSiteId.Text.Trim();
            //(Tag as OPMDASHBOARDA).Contract.SetSiteA(new SiteObj(txtSiteId.Text.Trim()));
            //(Tag as OPMDASHBOARDA).SiteA = new SiteObj(txtSiteId.Text.Trim());
        }

        private void dateTimePickerContractReportOfConpletedVolumeDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractReportOfConpletedVolumeDate = dateTimePickerContractReportOfConpletedVolumeDate.Value;
        }

        private void dateTimePickerContractLiquidationRecordsDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractLiquidationRecordsDate = dateTimePickerContractLiquidationRecordsDate.Value;
        }

        private void textBoxContractTotalAmountPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxContractTotalAmountPaid.Text.Trim()))
                {
                    if(double.Parse(textBoxContractTotalAmountPaid.Text.Trim())<0) MessageBox.Show("Nhập lại dạng số Tổng số tiền bên A đã thanh toán trong hợp đồng phải >= 0!");
                    else (Tag as OPMDASHBOARDA).Contract.ContractTotalAmountPaid = double.Parse(textBoxContractTotalAmountPaid.Text.Trim());
                    textBoxContractTotalAmountPaidCurrency.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", double.Parse(textBoxContractTotalAmountPaid.Text.Trim()));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại dạng số Tổng số tiền bên A đã thanh toán trong hợp đồng!");
            }
        }

        private void ccb_siteA_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if(ccb_siteA.SelectedValue != null)
            {
                SiteObj siteName = cb.SelectedValue as SiteObj;
                txtSiteId.Text = siteName.SiteId.ToString();
                (Tag as OPMDASHBOARDA).SiteA.SiteId = siteName.SiteId.ToString();
                (Tag as OPMDASHBOARDA).Contract.SiteId = txtSiteId.Text.Trim();
            }
        }

        private void dtpContractCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractCreatedDate = dtpContractCreatedDate.Value;
        }

        private void btnNotification_Click(object sender, EventArgs e)
        {
            NotificationInfo f = new NotificationInfo();
            f.ShowDialog();
            this.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsInfo f = new SettingsInfo();
            f.ShowDialog();
            this.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintInfo f = new PrintInfo();
            f.ShowDialog();
            this.Show();
        }
    }
}
