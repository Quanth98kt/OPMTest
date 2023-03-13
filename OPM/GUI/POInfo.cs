using OPM.DBHandler;
using OPM.ExcelHandler;
using OPM.OPMEnginee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
namespace OPM.GUI
{
    public partial class POInfo : Form
    {
        int val;
        public POInfo()
        {
            InitializeComponent();
        }
        private void PurchaseOderInfor_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            POObj po = (Tag as OPMDASHBOARDA).Po;
            txtPOId.Text = po.POId;
            txtPOId.Tag = po.POId;     //Lưu lại Id khi cần vì txtIdPO.Text có thể thay đổi khi Edit
            txtPOName.Text = po.POName;
            txtPOName.Tag = po.POName;
            dtpPOCreatedDate.Value = po.POCreatedDate;
            txtPODuration.Text = (po.PODeadline.Date - po.POPerformDate.Date).TotalDays.ToString();
            txtPOGoodsQuantity.Text = po.POGoodsQuantity.ToString();
            txtContractGoodsQuantity.Text = po.ContractGoodsQuantity.ToString();
            txtRemainingContractGoodsQuantity.Text = (po.ContractGoodsQuantity - POObj.POGoodsQuantityTotalByContractId(po.ContractId)).ToString();
            val = int.Parse((po.ContractGoodsQuantity - POObj.POGoodsQuantityTotalByContractId(po.ContractId)).ToString());
            lblContractGoodsUnit.Text = po.ContractGoodsUnit;
            txtPOConfirmRequestDuration.Text = (po.POConfirmRequestDeadline.Date - po.POCreatedDate.Date).Days.ToString();
            dtpPODefaultPerformDate.Value = po.PODefaultPerformDate;
            txtPOTotalValue.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", po.POTotalValue);
            txtPOConfirmId.Text = po.POConfirmId.ToString();
            dtpPOConfirmCreatedDate.Value = po.POConfirmCreatedDate;
            dtpPOPerformDate.Value = po.POPerformDate;
            //dtpDeadline.Value = (Tag as OPMDASHBOARDA).PO.Deadline;
            txtPOAdvanceId.Text = po.POAdvanceId;
            txtPOAdvancePercentage.Text = po.POAdvancePercentage.ToString();
            dtpPOAdvanceCreatedDate.Value = po.POAdvanceCreatedDate;
            txtPOAdvanceGuaranteePercentage.Text = po.POAdvanceGuaranteePercentage.ToString();
            dtpPOAdvanceGuaranteeCreatedDate.Value = po.POAdvanceGuaranteeCreatedDate;
            txtPOAdvanceRequestId.Text = po.POAdvanceRequestId;
            dtpPOAdvanceRequestCreatedDate.Value = po.POAdvanceRequestCreatedDate;
            dtpPOGuaranteeDate.Value = po.POGuaranteeDate;
            txtPOGuaranteeRatio.Text = po.POGuaranteeRatio.ToString();
            dateTimePickerPOReportOfAcceptanceAndHandlingOfGoodsDate.Value = po.POReportOfAcceptanceAndHandlingOfGoodsDate;
            dateTimePickerPOOfferToGuaranteePOWarrantyDate.Value = po.POOfferToGuaranteePOWarrantyDate;
            /*if(textBoxPOAdjustmentConfirmationNumber.Text == "")
            {
                MessageBox.Show("Vui lòng nhập công văn xác nhận điều chỉnh PO");
                return;
            }
            else
            {
                
            }*/
            textBoxPOAdjustmentConfirmationNumber.Text = po.POAdjustmentConfirmationNumber;
            textBoxPOGoodQuantityAfterAdjustment.Text = po.POGoodQuantityAfterAdjustment.ToString();
            dateTimePickerPOAdjustmentConfirmationDate.Value = po.POAdjustmentConfirmationDate;
            textBoxPOValueAfterAdjustment.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", po.POTotalValueAfterAdjustment);
            dateTimePickerPOQualityCertificationDate.Value = po.POQualityCertificationDate;
            dateTimePickerPOFactoryQualityCertificationDate.Value = po.POFactoryQualityCertificationDate;
            dateTimePickerPOInstallLicenseDate.Value = po.POInstallLicenseDate;
            dateTimePickerPOAcceptanceLicenceDate.Value = po.POAcceptanceLicenceDate;
            dateTimePickerPOInvoicingRequestDate.Value = po.POInvoicingRequestDate;


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPOId.Text.Trim()) || txtPOId.Text.Trim() == (new POObj()).POId)
            {
                MessageBox.Show("Nhập đúng số PO!");
                return;
            }

            if (POObj.PONames((Tag as OPMDASHBOARDA).Po.ContractId, txtPOName.Text.Trim()) && txtPOName.Text.Trim() != txtPOName.Tag.ToString())
            {
                MessageBox.Show("Đã tồn tại PO Name " + txtPOName.Text.Trim());
                return;
            }


            if (!string.IsNullOrEmpty(txtPOGoodsQuantity.Text.Trim()) && int.Parse(txtPOGoodsQuantity.Text.Trim()) == 0)
            {
                MessageBox.Show("Nhập số lượng thiết bị trong PO khác 0!");
                return;
            }

            if (txtPOAdvanceRequestId.Text.Trim() == txtPOAdvanceId.Text.Trim() || txtPOAdvanceRequestId.Text.Trim() == textBoxPOAdjustmentConfirmationNumber.Text.Trim() || textBoxPOAdjustmentConfirmationNumber.Text.Trim() == txtPOAdvanceId.Text.Trim())
            {
                DialogResult dialogResult = MessageBox.Show("Công văn đề nghị tạm ứng, Công văn đề nghị thanh toán tạm ứng, Công văn xác nhận điều chỉnh PO đang trùng nhau. Bạn có chắc muốn lưu?","Thông báo",MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            if (!string.IsNullOrEmpty(txtPOGoodsQuantity.Text.Trim()) && (dtpPOCreatedDate.Value) < ((Tag as OPMDASHBOARDA).Contract.ContractCreatedDate))
            {
                MessageBox.Show("Ngày tạo PO không thể nhỏ hơn ngày tạo hợp đồng!");
                return;
            }

            /*if (textBoxPOAdjustmentConfirmationNumber.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số công văn xác nhận điều chỉnh PO!");
                return;
            }*/
            (Tag as OPMDASHBOARDA).SaveSQLByNodeName();
        }

        private void btnNewNTKT_Click(object sender, EventArgs e)
        {
            if ((Tag as OPMDASHBOARDA).Po.POExist())
            {
                (Tag as OPMDASHBOARDA).CurrentNodeName = "NTKT_" + (new NTKTObj()).NTKTId;
            }
            else
            {
                MessageBox.Show(string.Format("Vẫn chưa lưu PO số {0}", (Tag as OPMDASHBOARDA).Po.POId), "Thông báo");
            }
        }
        private void btnNewDP_Click(object sender, EventArgs e)
        {
            if ((Tag as OPMDASHBOARDA).Po.POExist())
            {
                if (DeliveryPlanObj.DeliveryPlanExist((Tag as OPMDASHBOARDA).Po.POId))
                {
                    (Tag as OPMDASHBOARDA).CurrentNodeName = "DP_" + (new DPObj()).DPId;
                }
                else
                {
                    MessageBox.Show(string.Format("Vẫn chưa tạo kế hoạch giao hàng của PO số {0}", (Tag as OPMDASHBOARDA).Po.POId), "Thông báo");
                }
            }
            else
            {
                MessageBox.Show(string.Format("Vẫn chưa lưu PO số {0}", (Tag as OPMDASHBOARDA).Po.POId), "Thông báo");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).DeleteSQLByNodeName();
        }

        public OpenFileDialog openFileExcel = new OpenFileDialog();
        public string sConnectionString = null;
        private void txtPOConfirmRequestDuration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPOConfirmRequestDuration.Text.Trim()))
                    dtpPOConfirmRequestDeadline.Value = dtpPOCreatedDate.Value.AddDays(int.Parse(txtPOConfirmRequestDuration.Text.Trim()));
                else
                    dtpPOConfirmRequestDeadline.Value = dtpPOCreatedDate.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại POConfirmRequestDuration dạng số!");
            }
            (Tag as OPMDASHBOARDA).Po.POConfirmRequestDeadline = dtpPOConfirmRequestDeadline.Value;
        }
        private void dtpPOCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POCreatedDate = dtpPOCreatedDate.Value;
            try
            {
                if (!string.IsNullOrEmpty(txtPOConfirmRequestDuration.Text.Trim()))
                    dtpPOConfirmRequestDeadline.Value = dtpPOCreatedDate.Value.AddDays(int.Parse(txtPOConfirmRequestDuration.Text.Trim()));
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại POConfirmRequestDuration dạng số!");
            }

            try
            {
                if ((dtpPOCreatedDate.Value) < ((Tag as OPMDASHBOARDA).Contract.ContractCreatedDate))
                {
                    MessageBox.Show("Ngày tạo PO không thể nhỏ hơn ngày tạo hợp đồng!");
                }
            }
            catch
            {

            }
        }
        private void txtPODuration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPODuration.Text.Trim()))
                    dtpPODeadline.Value = dtpPOPerformDate.Value.AddDays(int.Parse(txtPODuration.Text));
                else
                    dtpPODeadline.Value = dtpPOPerformDate.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại PODuration dạng số!");
            }
            (Tag as OPMDASHBOARDA).Po.PODeadline = dtpPODeadline.Value;
        }
        static public DataTable dt = new DataTable();
        static public DataTable dtkhgh = new DataTable();
        static public string IDVBXN = "";
        static public string IPPO = "";


        private void btnDeliveryPlan_Click(object sender, EventArgs e)
        {
            if (POObj.POExist((Tag as OPMDASHBOARDA).Po.POId))
            {
                (Tag as OPMDASHBOARDA).backSiteFormStatus = 1;
                (Tag as OPMDASHBOARDA).OpenDeliveryPlanForm();
            }
            else MessageBox.Show("Không tồn tại PO số: ", (Tag as OPMDASHBOARDA).Po.POId);
        }
        private void txtPOId_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeId = txtPOId.Text.Trim();

            if (POObj.POExist(txtPOId.Text.Trim()))
            {
                if (("PO_" + txtPOId.Text.Trim()) != (Tag as OPMDASHBOARDA).CurrentNodeName)
                {
                    MessageBox.Show("Đã tồn tại PO số " + txtPOId.Text.Trim());
                }
                return;
            }

            (Tag as OPMDASHBOARDA).Po.POId = txtPOId.Text.Trim();
        }
        private void TxtPOName_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POName = txtPOName.Text.Trim();
            (Tag as OPMDASHBOARDA).SetNameOfSelectNode(txtPOName.Text);

            if (POObj.PONames((Tag as OPMDASHBOARDA).Po.ContractId, txtPOName.Text.Trim()) && ("PO_XXXX/CUVT-KV") == (Tag as OPMDASHBOARDA).CurrentNodeName)
            {
                MessageBox.Show("Đã tồn tại PO Name " + txtPOName.Text.Trim());
            }
        }
        private void txtPOGoodsQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPOGoodsQuantity.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Po.POGoodsQuantity = int.Parse(txtPOGoodsQuantity.Text.Trim());
                    double value = (Tag as OPMDASHBOARDA).Po.POTotalValue;
                    txtPOTotalValue.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", value);
                    value = (0.01 * (Tag as OPMDASHBOARDA).Po.POAdvancePercentage * (Tag as OPMDASHBOARDA).Po.POTotalValue);
                    txtPOAdvanceValue.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", value);
                    txtRemainingContractGoodsQuantity.Text = (val - int.Parse(txtPOGoodsQuantity.Text.Trim())).ToString(); 
                }
                else
                { (Tag as OPMDASHBOARDA).Po.POGoodsQuantity = 0; };
                // MessageBox.Show("Không có giá trị");

                if (!string.IsNullOrEmpty(txtPOGoodsQuantity.Text.Trim()) && int.Parse(txtPOGoodsQuantity.Text.Trim()) > ((Tag as OPMDASHBOARDA).Po.ContractGoodsQuantity ))
                {
                    MessageBox.Show("Nhập số lượng thiết bị PO nhỏ hơn số lượng thiết bị trong hợp đồng!");
                }

                else if (!string.IsNullOrEmpty(txtPOGoodsQuantity.Text.Trim()) && int.Parse(txtPOGoodsQuantity.Text.Trim()) > ((Tag as OPMDASHBOARDA).Po.ContractGoodsQuantity - POObj.POGoodsQuantityTotalByContractId((Tag as OPMDASHBOARDA).Po.ContractId)) && ("PO_XXXX/CUVT-KV") == (Tag as OPMDASHBOARDA).CurrentNodeName)
                {
                    MessageBox.Show("Nhập số lượng thiết bị PO nhỏ hơn số lượng thiết bị còn lại trong hợp đồng!");
                }
            }
            catch
            {
                MessageBox.Show("Nhập lại POGoodsQuantity dạng số!");
            }
        }

        private void dtpPODefaultPerformDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.PODefaultPerformDate = dtpPODefaultPerformDate.Value;
        }
        private void txtPOConfirmId_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POConfirmId = txtPOConfirmId.Text.Trim();
        }
        private void dtpPOConfirmCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POConfirmCreatedDate = dtpPOConfirmCreatedDate.Value;
            try
            {
                if (!string.IsNullOrEmpty(txtPODuration.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Po.PODeadline = dtpPOPerformDate.Value.AddDays(int.Parse(txtPODuration.Text));
                    dtpPODeadline.Value = dtpPOPerformDate.Value.AddDays(int.Parse(txtPODuration.Text));
                }
                else
                    dtpPODeadline.Value = dtpPOPerformDate.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại ConfirmCreatedDate dạng số!");
            }
        }

        private void dtpPOPerformDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POPerformDate = dtpPOPerformDate.Value;
            try
            {
                if (!string.IsNullOrEmpty(txtPODuration.Text.Trim()))
                    dtpPODeadline.Value = dtpPOPerformDate.Value.AddDays(int.Parse(txtPODuration.Text));
                else
                    dtpPODeadline.Value = dtpPOPerformDate.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại PODuration dạng số!");
            }
            (Tag as OPMDASHBOARDA).Po.PODeadline = dtpPODeadline.Value;
        }

        private void txtPOAdvancePercentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPOAdvancePercentage.Text.Trim()))
                {
                    if (0 <= int.Parse(txtPOAdvancePercentage.Text.Trim()) && int.Parse(txtPOAdvancePercentage.Text.Trim()) <= 100)
                    {
                        (Tag as OPMDASHBOARDA).Po.POAdvancePercentage = int.Parse(txtPOAdvancePercentage.Text.Trim());
                        txtPOAdvanceValue.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", 0.01 * (Tag as OPMDASHBOARDA).Po.POAdvancePercentage * (Tag as OPMDASHBOARDA).Po.POTotalValue);
                    }
                    else
                    {
                        MessageBox.Show("Nhập lại POAdvancePercentage dạng số trong khoảng 0 đến 100!");
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nhập lại POAdvancePercentage dạng số!");
            }
        }

        private void dtpAdvanceCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAdvanceCreatedDate = dtpPOAdvanceCreatedDate.Value;
        }

        private void txtPOAdvanceGuaranteePercentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPOAdvanceGuaranteePercentage.Text.Trim()))
                {
                    if (0 <= int.Parse(txtPOAdvanceGuaranteePercentage.Text.Trim()) && int.Parse(txtPOAdvanceGuaranteePercentage.Text.Trim()) <= 100)
                        (Tag as OPMDASHBOARDA).Po.POAdvanceGuaranteePercentage = int.Parse(txtPOAdvanceGuaranteePercentage.Text.Trim());
                    else
                    {
                        MessageBox.Show("Nhập lại dạng số trong khoảng 0 đến 100!");
                        return;
                    }
                }
                else
                    (Tag as OPMDASHBOARDA).Po.POAdvanceGuaranteePercentage = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại POAdvanceGuaranteePercentage dạng số!");
            }
        }

        private void dtpAdvanceGuaranteeCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAdvanceGuaranteeCreatedDate = dtpPOAdvanceGuaranteeCreatedDate.Value;
        }

        private void txtIdAdvanceRequest_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAdvanceRequestId = txtPOAdvanceRequestId.Text.Trim();
        }

        private void dtpAdvanceRequestDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAdvanceRequestCreatedDate = dtpPOAdvanceRequestCreatedDate.Value;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "Contract_" + (Tag as OPMDASHBOARDA).Po.ContractId;
        }

        private void btnNewPO_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "PO_" + (new POObj()).POId;
        }

        private void btnCreatDoc_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CreatDocumentByNodeName();
        }

        private void txtPOAdvanceId_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAdvanceId = txtPOAdvanceId.Text.Trim();
        }

        private void dtpPOGuaranteeDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POGuaranteeDate = dtpPOGuaranteeDate.Value;
        }

        private void dateTimePickerPOReportOfAcceptanceAndHandlingOfGoodsDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POReportOfAcceptanceAndHandlingOfGoodsDate = dateTimePickerPOReportOfAcceptanceAndHandlingOfGoodsDate.Value;
        }

        private void dateTimePickerPOOfferToGuaranteePOWarrantyDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POOfferToGuaranteePOWarrantyDate = dateTimePickerPOOfferToGuaranteePOWarrantyDate.Value;
        }

        private void textBoxPOAdjustmentConfirmationNumber_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAdjustmentConfirmationNumber = textBoxPOAdjustmentConfirmationNumber.Text.Trim();
            if (string.IsNullOrEmpty(textBoxPOAdjustmentConfirmationNumber.Text.Trim()) || (textBoxPOAdjustmentConfirmationNumber.Text.Trim()) == "XXXX/ANSV-DO")
            {
                dateTimePickerPOAdjustmentConfirmationDate.Enabled = false;
                textBoxPOGoodQuantityAfterAdjustment.Text = string.Empty;
                textBoxPOGoodQuantityAfterAdjustment.Enabled = false;
                textBoxPOValueAfterAdjustment.Text = string.Empty;
                textBoxPOValueAfterAdjustment.Enabled = false;
            }
            else
            {
                textBoxPOGoodQuantityAfterAdjustment.Enabled = true;
                //textBoxPOValueAfterAdjustment.Enabled = true;
                dateTimePickerPOAdjustmentConfirmationDate.Enabled = true;
            }
        }

        private void textBoxPOQuantityAfterAdjustment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxPOAdjustmentConfirmationNumber.Text.Trim()) || (textBoxPOAdjustmentConfirmationNumber.Text.Trim()) == "XXXX/ANSV-DO")
                {
                    dateTimePickerPOAdjustmentConfirmationDate.Enabled = false;
                    textBoxPOGoodQuantityAfterAdjustment.Text = string.Empty;
                    textBoxPOGoodQuantityAfterAdjustment.Enabled = false;
                    textBoxPOValueAfterAdjustment.Text = string.Empty;
                    textBoxPOValueAfterAdjustment.Enabled = false;
                }
                else
                {
                    textBoxPOGoodQuantityAfterAdjustment.Enabled = true;
                    //textBoxPOValueAfterAdjustment.Enabled = true;
                    dateTimePickerPOAdjustmentConfirmationDate.Enabled = true;
                }

                if (!string.IsNullOrEmpty(textBoxPOGoodQuantityAfterAdjustment.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Po.POGoodQuantityAfterAdjustment = int.Parse(textBoxPOGoodQuantityAfterAdjustment.Text.Trim());
                    textBoxPOValueAfterAdjustment.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", (Tag as OPMDASHBOARDA).Po.POTotalValueAfterAdjustment);
                    (Tag as OPMDASHBOARDA).Po.POGoodsQuantity = (Tag as OPMDASHBOARDA).Po.POGoodQuantityAfterAdjustment;
                    txtPOGoodsQuantity.Text = (Tag as OPMDASHBOARDA).Po.POGoodsQuantity.ToString();
                }
                else
                    (Tag as OPMDASHBOARDA).Po.POGoodQuantityAfterAdjustment = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại POGoodQuantityAfterAdjustment dạng số!");
            }
        }

        private void dateTimePickerPOAdjustmentConfirmationDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAdjustmentConfirmationDate = dateTimePickerPOAdjustmentConfirmationDate.Value;
        }

        private void dateTimePickerPOQualityCertificationDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POQualityCertificationDate = dateTimePickerPOQualityCertificationDate.Value;
        }

        private void dateTimePickerPOFactoryQualityCertificationDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POFactoryQualityCertificationDate = dateTimePickerPOFactoryQualityCertificationDate.Value;
        }

        private void dateTimePickerPOAcceptanceLicenceDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAcceptanceLicenceDate = dateTimePickerPOAcceptanceLicenceDate.Value;
        }

        private void dateTimePickerPOInstallLicenseDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POInstallLicenseDate = dateTimePickerPOInstallLicenseDate.Value;
        }

        private void dateTimePickerPOInvoicingRequestDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POInvoicingRequestDate = dateTimePickerPOInvoicingRequestDate.Value;
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void dtpPODeadline_ValueChanged(object sender, EventArgs e)
        {
            if ((dtpPODeadline.Value) > ((Tag as OPMDASHBOARDA).Contract.ContractDeadline))
            {
                MessageBox.Show("Ngày giao hàng của PO phải trước ngày thời hạn thực đơn hàng!");
            }
        }

        private void btnPLGH_Click(object sender, EventArgs e)
        {
            DeliveryAddendumInfo f = new DeliveryAddendumInfo();
            f.Message = (Tag as OPMDASHBOARDA).Po.POId;
            f.ShowDialog();
            this.Show();
        }

        FolderBrowserDialog fbd = new FolderBrowserDialog();
        private void btnArrange_Click(object sender, EventArgs e)
        {
            SiteObj.SiteName_NonUnicode();
            DataTable table = SiteObj.SiteName_NonUnicode((Tag as OPMDASHBOARDA).Po.POId);
            DataRow row1 = table.NewRow();

            try
            {

                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))

                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    List<string> list = new List<string>(files);

                    // Tạo Folder Hàng Chính, Folder Hàng dự phòng
                    string pathFolder = System.IO.Directory.GetParent(fbd.SelectedPath).ToString();
                    DirectoryInfo directory_HangChinh = new DirectoryInfo(pathFolder + @"\PL HANG CHINH");
                    DirectoryInfo directory_HangDuPhong = new DirectoryInfo(pathFolder + @"\PL HANG DU PHONG");
                    if (!directory_HangChinh.Exists)
                    {
                        directory_HangChinh.Create();
                    }
                    else
                    {
                        MessageBox.Show(String.Format("Đã tồn tại Folder PL HANG CHINH tại {0}.", pathFolder));
                        return;
                    }
                    if (!directory_HangDuPhong.Exists)
                    {
                        directory_HangDuPhong.Create();
                    }
                    else
                    {
                        MessageBox.Show(String.Format("Đã tồn tại Folder PL HANG DU PHONG tại {0}.", pathFolder));
                        return;
                    }

                    //Check
                    foreach (string item in list)
                    {
                        //Datagridview
                        string Filename = Path.GetFileName(item);

                        foreach (DataRow dataRow in table.Rows)
                        {
                            //this.dgvName.Rows.Add(dataRow[0]);
                            int index_TenTinh = Filename.IndexOf((string)dataRow[0]);
                            int index_2Percent = Filename.IndexOf("2%");
                            if (index_TenTinh >= 0 && index_2Percent < 0)
                            {
                                DirectoryInfo directory_HangChinh_Tinh = new DirectoryInfo(pathFolder + @"\PL HANG CHINH" + @"\" + (int)dataRow[1]+ @" " + (string)dataRow[0]);
                                directory_HangChinh_Tinh.Create();
                                string sourceFile = System.IO.Path.Combine(pathFolder + @"\PL HANG CHINH" + @"\" + (int)dataRow[1] + @" " + (string)dataRow[0], Filename);
                                //string destFile = System.IO.Path.Combine(targetPath, fileName);
                                File.Copy(item.ToString(), pathFolder + @"\PL HANG CHINH" + @"\" + (int)dataRow[1] + @" " + (string)dataRow[0] + @"\" + Filename, true);
                            }
                            if (index_TenTinh >= 0 && index_2Percent >= 0)
                            {
                                DirectoryInfo directory_HangDuPhong_Tinh = new DirectoryInfo(pathFolder + @"\PL HANG DU PHONG" + @"\" + (int)dataRow[1] + @" " + (string)dataRow[0]);
                                directory_HangDuPhong_Tinh.Create();
                                File.Copy(item, pathFolder + @"\PL HANG DU PHONG" + @"\" + (int)dataRow[1] + @" " + (string)dataRow[0] + @"\" + Filename, true);
                            }
                        }
                    }
                }
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
    }
}
