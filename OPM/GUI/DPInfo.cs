using OPM.DBHandler;
using OPM.OPMEnginee;
using System;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class DPInfo : Form
    {
        public DPInfo()
        {
            InitializeComponent();
        }
        void LoadData(string VNPTId = "ANSV")
        {
            (Tag as OPMDASHBOARDA).Pl.DPId = (Tag as OPMDASHBOARDA).Dp.DPId;
            LoadToComboBoxVNPIId();
            LoadToDtgDP(VNPTId);
            DataBindingsFromDtgDPToTextBoxs();
            if ((Tag as OPMDASHBOARDA).Dp.DPType == 0)
            {
                txtContractGoodsQuantity.Text = (Tag as OPMDASHBOARDA).Po.ContractGoodsQuantity.ToString();
                txtRemainingContractGoodsQuantity.Text = ((Tag as OPMDASHBOARDA).Po.ContractGoodsQuantity - POObj.POGoodsQuantityTotalByContractId((Tag as OPMDASHBOARDA).Po.ContractId)).ToString();
                txtPOGoodsQuantity.Text = (Tag as OPMDASHBOARDA).Po.POGoodsQuantity.ToString();
                txtRemainingPOGoodsQuantity.Text = ((Tag as OPMDASHBOARDA).Po.POGoodsQuantity - DPObj.DPGetTotalQuantityByPOId((Tag as OPMDASHBOARDA).Po.POId)).ToString();
                textBoxVNPTIdTotalQuantity.Text = DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text).ToString();
                //txtRemainingVNPTTotalQuantity.Text = (DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text) - DPsObj.DPTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text)).ToString();
            }
            else
            {
                txtContractGoodsQuantity.Text = (Tag as OPMDASHBOARDA).Po.ContractSpareGoodsQuantity.ToString();
                txtRemainingContractGoodsQuantity.Text = ((Tag as OPMDASHBOARDA).Po.ContractSpareGoodsQuantity - POObj.POSpareGoodsQuantityTotalByContractId((Tag as OPMDASHBOARDA).Po.ContractId)).ToString();
                txtPOGoodsQuantity.Text = (Tag as OPMDASHBOARDA).Po.POSpareGoodsQuantity.ToString();
                txtRemainingPOGoodsQuantity.Text = ((Tag as OPMDASHBOARDA).Po.POSpareGoodsQuantity - DPObj.DPGetTotalSpareQuantityByPOId((Tag as OPMDASHBOARDA).Po.POId)).ToString();
                textBoxVNPTIdTotalQuantity.Text = DeliveryPlanObj.DeliveryPlanTotalSpareQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text).ToString();
                //txtRemainingVNPTTotalQuantity.Text = (DeliveryPlanObj.DeliveryPlanTotalSpareQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text) - DPsObj.DPTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text, 1)).ToString();
            }
        }
        private void LoadToDtgDP(string VNPTId = "ANSV")
        {
            (Tag as OPMDASHBOARDA).Pls = PLObj.PLGetListByDPId((Tag as OPMDASHBOARDA).Pl.DPId);
            if ((Tag as OPMDASHBOARDA).Pls.Count == 0)
            {
                //(Tag as OPMDASHBOARDA).Pl.VNPTId = comboBoxVNPTId.Text;
                (Tag as OPMDASHBOARDA).Pls.Insert(0, (Tag as OPMDASHBOARDA).Pl);
            }
            dtgDP.DataSource = (Tag as OPMDASHBOARDA).Pls;

            foreach (DataGridViewColumn Column in dtgDP.Columns)
            {
                Column.Visible = false;
            }

            dtgDP.Columns["PLId"].HeaderText = @"ID";
            dtgDP.Columns["VNPTId"].Visible = true;
            dtgDP.Columns["PLCheckMainLine_"].Visible = true;
            dtgDP.Columns["PLCheckMainLine_"].Width = 170;
            dtgDP.Columns["PLQuantity"].Visible = true;
            dtgDP.Columns["VNPTId"].HeaderText = @"Mã tỉnh";
            dtgDP.Columns["PLCheckMainLine_"].HeaderText = @"Loại hàng";
            dtgDP.Columns["PLQuantity"].HeaderText = @"Số lượng";
            foreach (DataGridViewRow row in dtgDP.Rows)
            {
                if (row.Cells["VNPTId"].Value.ToString() == VNPTId)
                {
                    dtgDP.CurrentCell = row.Cells["VNPTId"];
                    return;
                }
            }
        }

        private void DataBindingsFromDtgDPToTextBoxs()
        {
            textBoxDPId.DataBindings.Clear();
            textBoxDPId.DataBindings.Add(new Binding("Tag", dtgDP.DataSource, "DPId"));
            textBoxDPId.DataBindings.Add(new Binding("Text", dtgDP.DataSource, "DPId"));
            dateTimePickerDPDate.DataBindings.Clear();
            dateTimePickerDPDate.DataBindings.Add(new Binding("Value", dtgDP.DataSource, "DPDate"));
            dateTimePickerDPRequestDate.DataBindings.Clear();
            dateTimePickerDPRequestDate.DataBindings.Add(new Binding("Value", dtgDP.DataSource, "DPRequestDate"));
            dateTimePickerDPResponseDate.DataBindings.Clear();
            dateTimePickerDPResponseDate.DataBindings.Add(new Binding("Value", dtgDP.DataSource, "DPResponseDate"));
            dateTimePickerDPRefundDate.DataBindings.Clear();
            dateTimePickerDPRefundDate.DataBindings.Add(new Binding("Value", dtgDP.DataSource, "DPRefundDate"));
            textBoxDPRemarks.DataBindings.Clear();
            textBoxDPRemarks.DataBindings.Add(new Binding("Text", dtgDP.DataSource, "DPRemarks"));
            comboBoxDPType.DataBindings.Clear();
            comboBoxDPType.DataBindings.Add(new Binding("SelectedIndex", dtgDP.DataSource, "DPType"));
            textBoxDPQuantity.DataBindings.Clear();
            textBoxDPQuantity.DataBindings.Add(new Binding("Text", dtgDP.DataSource, "DPQuantity"));
            textBoxDPQuantity1.DataBindings.Clear();
            textBoxDPQuantity1.DataBindings.Add(new Binding("Text", dtgDP.DataSource, "DPQuantity1"));
            txtVNPTId.DataBindings.Clear();
            txtVNPTId.DataBindings.Add(new Binding("Text", dtgDP.DataSource, "VNPTId"));
            textBoxPLId.DataBindings.Clear();
            textBoxPLId.DataBindings.Add(new Binding("Text", dtgDP.DataSource, "PLId"));
            txtPLQuantity.DataBindings.Clear();
            txtPLQuantity.DataBindings.Add(new Binding("Text", dtgDP.DataSource, "PLQuantity"));
            textBoxDPVNPTTechANSVContractNumber.DataBindings.Clear();
            textBoxDPVNPTTechANSVContractNumber.DataBindings.Add(new Binding("Text", dtgDP.DataSource, "DPVNPTTechANSVContractNumber"));
            textBoxDPVNPTTechANSVContractNumber.DataBindings.Add(new Binding("Tag", dtgDP.DataSource, "DPVNPTTechANSVContractNumber"));
            textBoxDPContractAccoutingCode.DataBindings.Clear();
            textBoxDPContractAccoutingCode.DataBindings.Add(new Binding("Text", dtgDP.DataSource, "DPContractAccoutingCode"));
        }

        bool a = false;

        private void LoadToComboBoxVNPIId()
        {
            (Tag as OPMDASHBOARDA).Sites = SiteObj.SiteGetListProvince((Tag as OPMDASHBOARDA).Po.POId, (Tag as OPMDASHBOARDA).Dp.DPId);
            if(((Tag as OPMDASHBOARDA).Sites.Count == 1)&&(DPObj.DPExist((Tag as OPMDASHBOARDA).Dp.DPId)) && a == true)
            {
                PLObj pl = new PLObj();
                pl.DPId = (Tag as OPMDASHBOARDA).Dp.DPId;
                pl.VNPTId = (Tag as OPMDASHBOARDA).Sites[0].SiteId;
                //pl.PLId = pl.DPId + "_" + pl.VNPTId;
                pl.PLQuantity = (Tag as OPMDASHBOARDA).Dp.DPQuantity1 - PLObj.PLGetTotalQuantityByDPIddAndNotEqualVNPTId((Tag as OPMDASHBOARDA).Dp.DPId, (Tag as OPMDASHBOARDA).Sites[0].SiteId);
                pl.PLInsert(pl.DPId + "_" + pl.VNPTId + "_HC", 1);
                pl.PLInsert_(pl.DPId + "_" + pl.VNPTId + "_HDP", 0);
                (Tag as OPMDASHBOARDA).Sites = SiteObj.SiteGetListProvince((Tag as OPMDASHBOARDA).Po.POId, (Tag as OPMDASHBOARDA).Dp.DPId);
                a = false;
            }
            comboBoxVNPTId.DataSource = (Tag as OPMDASHBOARDA).Sites;
            comboBoxVNPTId.DisplayMember = "SiteId";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).OpenPOForm();
        }

        private void DPInfo_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void textBoxDPNumber_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeId = textBoxDPId.Text.Trim();
            (Tag as OPMDASHBOARDA).SetNameOfSelectNode(textBoxDPId.Text);

            if (DPObj.DP_ID((textBoxDPId.Text.Trim()), (Tag as OPMDASHBOARDA).Dp.POId) && textBoxDPId.Text.Trim() != textBoxDPId.Tag.ToString())
            {
                MessageBox.Show("Đã tồn tại DP số " + textBoxDPId.Text.Trim() +" thuộc " + (Tag as OPMDASHBOARDA).Po.POName);
            }
            (Tag as OPMDASHBOARDA).Dp.DPId = textBoxDPId.Text.Trim();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxDPId.Text.Trim()) || textBoxDPId.Text.Trim() == (new DPObj()).DPId)
            {
                MessageBox.Show("Nhập đúng số DP!");
                return;
            }

            if (string.IsNullOrEmpty(textBoxDPVNPTTechANSVContractNumber.Text.Trim()))
            {
                MessageBox.Show("Nhập số HĐ VNPT Tech!");
                return;
            }

            if (!string.IsNullOrEmpty(textBoxDPId.Text.Trim()) && DPObj.DPVNPTTechANSVContractNb(textBoxDPVNPTTechANSVContractNumber.Text.Trim()) && textBoxDPVNPTTechANSVContractNumber.Text.Trim() != textBoxDPVNPTTechANSVContractNumber.Tag.ToString())
            {
                MessageBox.Show("Số HĐ VNPT Tech đã tồn tại!");
                return;
            }
            
            (Tag as OPMDASHBOARDA).SaveSQLByNodeName();
        }

        private void dateTimePickerDPDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Dp.DPDate = dateTimePickerDPDate.Value;
        }

        private void btnNewDP_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "DP_" + (new DPObj()).DPId;
        }

        private void btnDeleteDP_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).DeleteSQLByNodeName();
        }

        private void btnPLAdd_Click(object sender, EventArgs e)
        {
            if (!DPObj.DPExist(textBoxDPId.Text.Trim()))
            {
                MessageBox.Show(string.Format("Không tồn tại DP số {0}!", textBoxDPId.Text.Trim()));
                return;
            }

            if (!string.IsNullOrEmpty(textBoxRemainingVNPTTotalQuantity.Text.Trim()) && double.Parse(textBoxRemainingVNPTTotalQuantity.Text.Trim()) < 0)
            {
                MessageBox.Show("Số lượng thiết bị phân bổ vượt quá số lượng cho phép!");
                return;
            }

            a = true;

            PLObj pl = new PLObj();
            pl.DPId = textBoxDPId.Text.Trim();
            pl.VNPTId = (comboBoxVNPTId.SelectedItem as SiteObj).SiteId;
            //pl.PLId = pl.DPId + "_" + pl.VNPTId;
            pl.PLQuantity = int.Parse(textBoxPLQuantity.Text.Trim());
            pl.PLInsert(pl.DPId + "_" + pl.VNPTId + "_HC", 1);
            pl.PLInsert_(pl.DPId + "_" + pl.VNPTId + "_HDP", 0);
            //txtRemainingPOGoodsQuantity.Text = (deliveryPlan.POGoodsQuantity - DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail(deliveryPlan.POId)).ToString();
            LoadData(pl.VNPTId);
            (Tag as OPMDASHBOARDA).Load_treeview();
        }

        private void btnPLDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(string.Format("Bạn có chắc muốn xóa PL {0}", textBoxPLId.Text.Trim()),"Thông báo", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                PLObj.PLDelete(textBoxPLId.Text.Trim());
                MessageBox.Show("Bạn đã xóa thành công PL đã chọn!");
            }
            (Tag as OPMDASHBOARDA).Load_treeview();
            LoadData(txtVNPTId.Text.Trim());
        }

        private void txtVNPTId_TextChanged(object sender, EventArgs e)
        {
            if ((Tag as OPMDASHBOARDA).Dp.DPType == 0)
            {
                textBoxVNPTIdTotalQuantity.Text = DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text).ToString();
                txtRemainingVNPTTotalQuantity.Text = (DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text) - PLObj.PLGetTotalQuantityByPOIdAndVNPTId((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text)).ToString();
            }
            else
            {
                textBoxVNPTIdTotalQuantity.Text = DeliveryPlanObj.DeliveryPlanTotalSpareQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text).ToString();
                txtRemainingVNPTTotalQuantity.Text = (DeliveryPlanObj.DeliveryPlanTotalSpareQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text) -PLObj.PLGetTotalSpareQuantityByPOIdAndVNPTId((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text)).ToString();
            }
        }

        private void comboBoxVNPTId_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (comboBoxVNPTId.SelectedValue != null)
            {
                SiteObj siteName = cb.SelectedValue as SiteObj;
                txtVNPTId.Text = siteName.SiteId.ToString();
                //(Tag as OPMDASHBOARDA).SiteA.SiteId = siteName.SiteId.ToString();
                //(Tag as OPMDASHBOARDA).Contract.SiteId = txtSiteId.Text.Trim();
            }

            //MessageBox.Show((comboBoxVNPTId.SelectedItem as SiteObj).SiteId);
            if ((Tag as OPMDASHBOARDA).Dp.DPType == 0)
            {
                textBoxRemainingVNPTTotalQuantity.Text = (DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId) - PLObj.PLGetTotalQuantityByPOIdAndVNPTId((Tag as OPMDASHBOARDA).Po.POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId)).ToString();
            }
            else
            {
                textBoxRemainingVNPTTotalQuantity.Text = (DeliveryPlanObj.DeliveryPlanTotalSpareQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId) - PLObj.PLGetTotalSpareQuantityByPOIdAndVNPTId((Tag as OPMDASHBOARDA).Po.POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId)).ToString();
            }
            textBoxRemainingDPQuantity.Text = ((Tag as OPMDASHBOARDA).Dp.DPQuantity1 - PLObj.PLGetTotalQuantityByDPIddAndNotEqualVNPTId((Tag as OPMDASHBOARDA).Dp.DPId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId)).ToString();
        }
        private void textBoxDPQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxDPQuantity.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Dp.DPQuantity = int.Parse(textBoxDPQuantity.Text.Trim());
                }
                else
                    (Tag as OPMDASHBOARDA).Dp.DPQuantity = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại DPQuantity dạng số!");
            }
        }

        private void textBoxDPRemarks_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Dp.DPRemarks = textBoxDPRemarks.Text;
        }

        private void comboBoxDPType_SelectedIndexChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Dp.DPType = comboBoxDPType.SelectedIndex;
        }

        private void btnNewPL_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "PL_" + textBoxPLId.Text;
        }

        private void textBoxPLQuantity_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxDPId.Tag.ToString()) && textBoxDPId.Tag.ToString() == "XXXX/" + DateTime.Now.ToString("yyyy"))
            {
                MessageBox.Show("Bạn chưa lưu DP mới tạo!");
            }
            else
            {
                double tem = 0;
                try
                {
                    if (!string.IsNullOrEmpty(textBoxPLQuantity.Text.Trim()))
                    {
                        tem = double.Parse(textBoxPLQuantity.Text.Trim());
                        if (tem > double.Parse((DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId) - PLObj.PLGetTotalQuantityByPOIdAndVNPTId((Tag as OPMDASHBOARDA).Po.POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId)).ToString()))
                        {
                            MessageBox.Show(string.Format("Nhập giá trị nằm trong khoảng từ 1 đến {0}", (DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId) - PLObj.PLGetTotalQuantityByPOIdAndVNPTId((Tag as OPMDASHBOARDA).Po.POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId)).ToString()));
                        }
                        else if (tem > double.Parse(textBoxRemainingDPQuantity.Text))
                        {
                            MessageBox.Show(string.Format("Nhập giá trị nằm trong khoảng từ 1 đến {0}", double.Parse(textBoxRemainingDPQuantity.Text)));
                        }
                    }
                    else
                    {
                        tem = 0;
                    }
                }
                catch
                {
                    MessageBox.Show("Nhập lại DPQuantity dạng số!");
                    return;
                }

                if ((Tag as OPMDASHBOARDA).Dp.DPType == 0)
                {
                    textBoxRemainingVNPTTotalQuantity.Text = (DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId) - tem - PLObj.PLGetTotalQuantityByPOIdAndVNPTId((Tag as OPMDASHBOARDA).Po.POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId)).ToString();
                }
                else
                {
                    textBoxRemainingVNPTTotalQuantity.Text = (DeliveryPlanObj.DeliveryPlanTotalSpareQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId) - tem - PLObj.PLGetTotalSpareQuantityByPOIdAndVNPTId((Tag as OPMDASHBOARDA).Po.POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId)).ToString();
                }

                textBoxRemainingDPQuantity.Text = ((Tag as OPMDASHBOARDA).Dp.DPQuantity1 - PLObj.PLGetTotalQuantityByDPIddAndNotEqualVNPTId((Tag as OPMDASHBOARDA).Dp.DPId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId) - tem).ToString();
            }
            
            

        }

        private void buttonCreateDoc_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CreatDocumentByNodeName();
        }

        private void textBoxDPQuantity1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxDPQuantity1.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Dp.DPQuantity1 = int.Parse(textBoxDPQuantity1.Text.Trim());
                }
                else
                    (Tag as OPMDASHBOARDA).Dp.DPQuantity1 = 0;

                if (!string.IsNullOrEmpty(textBoxDPQuantity1.Text.Trim()))
                {
                    if ((Tag as OPMDASHBOARDA).Dp.DPType == 0)
                    {

                        txtRemainingPOGoodsQuantity.Text = ((Tag as OPMDASHBOARDA).Po.POGoodsQuantity - DPObj.DPGetTotalQuantityByPOId((Tag as OPMDASHBOARDA).Po.POId) - int.Parse(textBoxDPQuantity1.Text.Trim())).ToString();
                    }
                    else
                    {
                        txtRemainingPOGoodsQuantity.Text = ((Tag as OPMDASHBOARDA).Po.POSpareGoodsQuantity - DPObj.DPGetTotalSpareQuantityByPOId((Tag as OPMDASHBOARDA).Po.POId) - int.Parse(textBoxDPQuantity1.Text.Trim())).ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nhập lại DPQuantity dạng số!");
            }
        }

        private void dateTimePickerDPRequestDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Dp.DPRequestDate = dateTimePickerDPRequestDate.Value;
        }

        private void dateTimePickerDPResponseDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Dp.DPResponseDate = dateTimePickerDPResponseDate.Value;
        }

        private void dateTimePickerDPRefundDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Dp.DPRefundDate = dateTimePickerDPRefundDate.Value;
        }

        private void textBoxDPVNPTTechANSVContractNumber_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Dp.DPVNPTTechANSVContractNumber = textBoxDPVNPTTechANSVContractNumber.Text.Trim();
        }

        private void textBoxDPContractAccoutingCode_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Dp.DPContractAccoutingCode = textBoxDPContractAccoutingCode.Text.Trim();
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
    }
}
