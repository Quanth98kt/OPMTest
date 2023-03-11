using OPM.DBHandler;
using OPM.ExcelHandler;
using OPM.OPMEnginee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class NTKTInfo : Form
    {
        public string val;
        public NTKTInfo()
        {
            InitializeComponent();
        }

        private void NTKTInfor_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData(string VNPTId = "")
        {
            LoadSiteA();
            LoadTodtgNTKT(VNPTId);
            LoadSum();
            txtNTKTId.Text = (Tag as OPMDASHBOARDA).Ntkt.NTKTId;
            txtNTKTId.Tag = txtNTKTId.Text;
            dtpNTKTCreatedDate.Value = (Tag as OPMDASHBOARDA).Ntkt.NTKTCreatedDate;
            txtNTKTPhase.Text = (Tag as OPMDASHBOARDA).Ntkt.NTKTPhase.ToString();
            dtpNTKTTestExpectedDate.Value = (Tag as OPMDASHBOARDA).Ntkt.NTKTTestExpectedDate;
            dtpCQDate.Value = (Tag as OPMDASHBOARDA).Ntkt.CQDate;
            dtpEsATPDate.Value = (Tag as OPMDASHBOARDA).Ntkt.EsATPDate;
            dtpATPDate.Value = (Tag as OPMDASHBOARDA).Ntkt.ATPDate;
            dtpTechnicalInspectionReportDate.Value = (Tag as OPMDASHBOARDA).Ntkt.TechnicalInspectionReportDate;
            dtpTechnicalAcceptanceReportDate.Value = (Tag as OPMDASHBOARDA).Ntkt.TechnicalAcceptanceReportDate;
            dtpNTKTLicenseCertificateDate.Value = (Tag as OPMDASHBOARDA).Ntkt.NTKTLicenseCertificateDate;
            txtNTKTQuantity.Text = (Tag as OPMDASHBOARDA).Ntkt.NTKTQuantity.ToString();
            lblContractGoodsUnit.Text = (Tag as OPMDASHBOARDA).Ntkt.ContractGoodsUnit;
            lblContractGoodsUnit1.Text = (Tag as OPMDASHBOARDA).Ntkt.ContractGoodsUnit;
            lblContractGoodsUnit2.Text = (Tag as OPMDASHBOARDA).Ntkt.ContractGoodsUnit;
            txtPOGoodsQuantity.Text = (Tag as OPMDASHBOARDA).Ntkt.POGoodsQuantity.ToString();
            txtRemainingNTKTGoodsQuantity.Text = ((Tag as OPMDASHBOARDA).Ntkt.POGoodsQuantity - NTKTObj.NTKTGoodsQuantityTotalByPOId((Tag as OPMDASHBOARDA).Ntkt.POId)).ToString();
            txtNTKTExtraQuantity.Text = (Tag as OPMDASHBOARDA).Ntkt.NTKTExtraQuantity.ToString();
            tb_SUMQuantity.Text = ((Tag as OPMDASHBOARDA).Ntkt.NTKTQuantity + (Tag as OPMDASHBOARDA).Ntkt.NTKTExtraQuantity).ToString();
        }
        void LoadSum()
        {
            tbSUM_ID.Text = NTKTDetailsObj.SUMID((Tag as OPMDASHBOARDA).Ntkt.NTKTId).ToString();
            tbNTKTMainline.Text = NTKTDetailsObj.SUMNTKTMainline((Tag as OPMDASHBOARDA).Ntkt.NTKTId).ToString();
            tbSUM_NTKTSparegoods.Text = NTKTDetailsObj.SUMNTKTSparegoods((Tag as OPMDASHBOARDA).Ntkt.NTKTId).ToString();
        }

        private void LoadSiteA()
        {
            List<SiteObj> sites = SiteObj.SiteGetList();
            SiteObj site = new SiteObj();
            ccbVNPTId.DataSource = SiteObj.SiteGetList();
            ccbVNPTId.DisplayMember = "SiteId";
            ccbVNPTId.Text = (Tag as OPMDASHBOARDA).SiteA.SiteId;
        }

        void AddNTKTBinding()
        {
            tbID.DataBindings.Clear();
            tbID.DataBindings.Add(new Binding("Text", dtgNTKT.DataSource, "id"));
            ccbVNPTId.DataBindings.Clear();
            ccbVNPTId.DataBindings.Add(new Binding("Text", dtgNTKT.DataSource, "VNPTId"));
            txtNTKTMainline.DataBindings.Clear();
            txtNTKTMainline.DataBindings.Add(new Binding("Text", dtgNTKT.DataSource, "NTKTMainline"));
            txtNTKTSparegoods.DataBindings.Clear();
            txtNTKTSparegoods.DataBindings.Add(new Binding("Text", dtgNTKT.DataSource, "NTKTSparegoods"));
            dtpNTKTEdDate.DataBindings.Clear();
            dtpNTKTEdDate.DataBindings.Add(new Binding("Value", dtgNTKT.DataSource, "NTKTEdDate"));
        }

        private void LoadTodtgNTKT(string VNPTId)
        {
            List<NTKTDetailsObj> NTKTDetails = NTKTDetailsObj.NTKTDetailListByNTKTId((Tag as OPMDASHBOARDA).Ntkt.NTKTId);
            //SiteInfoId = (Tag as OPMDASHBOARDA).Contract.SiteId;
            NTKTDetailsObj NTKTDetail = new NTKTDetailsObj();
            if (!NTKTDetailsObj.NTKTDetailsByNTKTId((Tag as OPMDASHBOARDA).Ntkt.NTKTId))
            {
                NTKTDetails.Insert(0, NTKTDetail);
            }
            dtgNTKT.DataSource = NTKTDetails;
            dtgNTKT.Columns["id"].Visible = false;
            dtgNTKT.Columns["NTKTId"].Visible = false;
            dtgNTKT.Columns["VNPTId"].HeaderText = @"VNPT ID";
            dtgNTKT.Columns["SiteName"].HeaderText = @"VNPT Name";
            dtgNTKT.Columns["NTKTMainline"].HeaderText = @"Hàng chính";
            dtgNTKT.Columns["NTKTSparegoods"].HeaderText = @"Hàng dự phòng";
            dtgNTKT.Columns["NTKTEdDate"].HeaderText = @"Ngày giao hàng dự kiến";
            foreach (DataGridViewRow row in dtgNTKT.Rows)
            {
                if (row.Cells["VNPTId"].Value.ToString() == VNPTId)
                {
                    dtgNTKT.CurrentCell = row.Cells["VNPTId"];
                    return;
                }
            }
            AddNTKTBinding();
            LoadSum();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNTKTId.Text.Trim()) || txtNTKTId.Text.Trim() == (new NTKTObj()).NTKTId)
            {
                MessageBox.Show("Nhập đúng số công văn đề nghị Nghiệm thu kỹ thuật!");
                return;
            }
            (Tag as OPMDASHBOARDA).SaveSQLByNodeName();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "PO_" + (Tag as OPMDASHBOARDA).Po.POId;
        }
        private void txbNTKTQuantity_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNTKTQuantity.Text.Trim()) )
            {
                try
                {
                    val = (Tag as OPMDASHBOARDA).Ntkt.NTKTQuantity.ToString();
                    if (!string.IsNullOrEmpty(txtNTKTQuantity.Text.Trim()) && txtNTKTQuantity.Text.Trim() != val)
                    {
                        (Tag as OPMDASHBOARDA).Ntkt.NTKTQuantity = double.Parse(txtNTKTQuantity.Text.Trim());
                        txtNTKTExtraQuantity.Text = Math.Round(double.Parse(txtNTKTQuantity.Text.Trim()) / 50, 0, MidpointRounding.AwayFromZero).ToString();
                        txtRemainingNTKTGoodsQuantity.Text = (double.Parse(txtNTKTQuantity.Text.Trim()) - NTKTObj.NTKTGoodsQuantityTotalByPOId((Tag as OPMDASHBOARDA).Ntkt.POId)).ToString();
                        tb_SUMQuantity.Text = (int.Parse(txtNTKTQuantity.Text.Trim()) + int.Parse(txtNTKTExtraQuantity.Text.Trim())).ToString();
                    }
                }
                catch
                {
                    MessageBox.Show("Nhập đúng Số lượng hàng chính dạng số!");
                }
            }
        }
        private void txtNTKTExtraQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNTKTExtraQuantity.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Ntkt.NTKTExtraQuantity = double.Parse(txtNTKTExtraQuantity.Text.Trim());
                    tb_SUMQuantity.Text = (int.Parse(txtNTKTQuantity.Text.Trim()) + int.Parse(txtNTKTExtraQuantity.Text.Trim())).ToString();
                }
            }
            catch
            {
                MessageBox.Show("Nhập đúng Số lượng hàng dự phòng dạng số!");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).DeleteSQLByNodeName();
        }

        private void buttonCreatDocument_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CreatDocumentByNodeName();
        }

        private void txtNTKTId_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeId = txtNTKTId.Text.Trim();
            if (NTKTObj.NTKTExist(txtNTKTId.Text.Trim()))
            {
                if (("NTKT_" + txtNTKTId.Text.Trim()) != (Tag as OPMDASHBOARDA).CurrentNodeName)
                {
                    MessageBox.Show("Đã tồn tại NTKT số " + txtNTKTId.Text.Trim());
                }
                return;
            }
            (Tag as OPMDASHBOARDA).Ntkt.NTKTId = txtNTKTId.Text.Trim();
        }

        private void txtNTKTPhase_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Ntkt.NTKTPhase = txtNTKTPhase.Text.Trim();
            (Tag as OPMDASHBOARDA).SetNameOfSelectNode("NTKT " + txtNTKTPhase.Text.Trim());

            var isNumeric = int.TryParse(txtNTKTPhase.Text.Trim(), out int n);

            if (isNumeric || txtNTKTPhase.Text.Trim() == "X")
            {

            }
            else
            {
                MessageBox.Show("Nhập đúng Đợt nghiệm thu kỹ thuật dạng số!");
            }

        }

        private void dtpNTKTCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Ntkt.NTKTCreatedDate = dtpNTKTCreatedDate.Value;
        }

        private void dtpNTKTTestExpectedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Ntkt.NTKTTestExpectedDate = dtpNTKTTestExpectedDate.Value;
        }

        private void dtpTechnicalInspectionReportDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Ntkt.TechnicalInspectionReportDate = dtpTechnicalInspectionReportDate.Value;
        }

        private void dtpNTKTLicenseCertificateDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Ntkt.NTKTLicenseCertificateDate = dtpNTKTLicenseCertificateDate.Value;
        }

        private void dtpTechnicalAcceptanceReportDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Ntkt.TechnicalAcceptanceReportDate = dtpTechnicalAcceptanceReportDate.Value;
        }

        private void btnNewNTKT_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "NTKT_" + (new NTKTObj()).NTKTId;
        }

        private void dtpCQDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Ntkt.CQDate = dtpCQDate.Value;
        }

        private void dtpEsATPDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Ntkt.EsATPDate = dtpEsATPDate.Value;
        }

        private void dtpATPDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Ntkt.ATPDate = dtpATPDate.Value;
        }

        private void ccbVNPTId_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (ccbVNPTId.SelectedValue != null)
            {
                SiteObj siteName = cb.SelectedValue as SiteObj;
                //txtSiteId.Text = siteName.SiteId.ToString();
                //(Tag as OPMDASHBOARDA).SiteA.SiteId = siteName.SiteId.ToString();
                //(Tag as OPMDASHBOARDA).Contract.SiteId = txtSiteId.Text.Trim();
            }
        }

        private void btnAddNTKTDetail_Click(object sender, EventArgs e)
        {
            var NTKTDetail = new OPMEnginee.NTKTDetailsObj
            {
                VNPTId = (ccbVNPTId.SelectedItem as SiteObj).SiteId,
                NTKTId = (Tag as OPMDASHBOARDA).Ntkt.NTKTId,
                NTKTMainline = int.Parse(txtNTKTMainline.Text.Trim()),
                NTKTSparegoods = int.Parse(txtNTKTSparegoods.Text.Trim()),
                NTKTEdDate = dtpNTKTEdDate.Value
            };
            if (!NTKTDetailsObj.NTKTDetailsExist(tbID.Text.Trim(), (ccbVNPTId.SelectedItem as SiteObj).SiteId))
            {
                NTKTDetail.NTKTDetailsInsert((Tag as OPMDASHBOARDA).Ntkt.NTKTId + "_" + (Tag as OPMDASHBOARDA).Ntkt.NTKTPhase.ToString() + "_" + (ccbVNPTId.SelectedItem as SiteObj).SiteId, (ccbVNPTId.SelectedItem as SiteObj).SiteId);
            }
            else
            {
                NTKTDetail.NTKTDetailsUpdate(tbID.Text.Trim());
            }

            NTKTDetailsObj NTKTdt = new NTKTDetailsObj();
            NTKTdt.VNPTId = (ccbVNPTId.SelectedItem as SiteObj).SiteId;
            LoadTodtgNTKT(NTKTdt.VNPTId);
            AddNTKTBinding();
            LoadSum();
        }

        private void txtNTKTMainline_TextChanged(object sender, EventArgs e)
        {
            //int.Parse(txtNTKTSparegoods.Text.Trim()) = int.Parse(txtNTKTMainline.Text.Trim()) * 50;
            if (!string.IsNullOrEmpty(txtNTKTMainline.Text.Trim()))
                try
                {
                    if (!string.IsNullOrEmpty(txtNTKTMainline.Text.Trim()))
                    {
                        (Tag as OPMDASHBOARDA).NTKTDt.NTKTMainline = double.Parse(txtNTKTMainline.Text.Trim());
                        txtNTKTSparegoods.Text = Math.Round(double.Parse(txtNTKTMainline.Text.Trim()) / 50, 0, MidpointRounding.AwayFromZero).ToString();
                        //txtRemainingNTKTGoodsQuantity.Text = (double.Parse(txtNTKTQuantity.Text.Trim()) - NTKTObj.NTKTGoodsQuantityTotalByPOId((Tag as OPMDASHBOARDA).Ntkt.POId)).ToString();
                    }
                }
                catch
                {
                    MessageBox.Show("Nhập đúng NTKTQuantity dạng số!");
                }
        }

        private void btnDeleteNTKTDetail_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(string.Format("Bạn có chắc muốn xóa NTKT cho {0}", (ccbVNPTId.SelectedItem as SiteObj).SiteId), "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                NTKTDetailsObj.NTKTDetailDelete(tbID.Text.Trim());
                MessageBox.Show("Bạn đã xóa thành công!");
            }
            (Tag as OPMDASHBOARDA).Load_treeview();
            NTKTDetailsObj NTKTdt = new NTKTDetailsObj();
            NTKTdt.VNPTId = (ccbVNPTId.SelectedItem as SiteObj).SiteId;
            LoadTodtgNTKT(NTKTdt.VNPTId);
            AddNTKTBinding();
            //LoadData(txtVNPTId.Text.Trim());
        }

        private OpenFileDialog ofd;
        private void btnImportNTKTDt_Click(object sender, EventArgs e)
        {
            int val1 = (int.Parse((Tag as OPMDASHBOARDA).Ntkt.NTKTPhase.ToString()) + 3) * 3 - 1;
            int val2 = val1 + 1;
            int val3 = val1 + 2;

            List<NTKTDetailsObj> userList = new List<NTKTDetailsObj>();

            ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", ValidateNames = true };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!NTKTDetailsObj.NTKTDetailsByNTKTId((Tag as OPMDASHBOARDA).Ntkt.NTKTId))
                {
                    tb_path.Text = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);

                    string path = ofd.FileName;
                    //string substr = path[^4..];

                    DataTable plTable = OpmExcelHandler.DataTableNTKTDetailsFromExcelFile(path, 1, 2, 1);

                    int pLTableCount = plTable.Rows.Count;

                    string NTKTId = (Tag as OPMDASHBOARDA).Ntkt.NTKTId;

                    try
                    {
                        for (int i = 0; i < pLTableCount; i++)
                        {
                            int tem = 1;
                            int min = Math.Min(tem, pLTableCount);

                            string SiteName = (plTable.Rows[i].ItemArray[1].ToString() != null) ? "VNPT Name" : plTable.Rows[i].ItemArray[1].ToString();
                            double NTKTMainline = (string.IsNullOrEmpty(plTable.Rows[i].ItemArray[val1].ToString())) ? 0 : int.Parse(plTable.Rows[i].ItemArray[val1].ToString());
                            double NTKTSparegoods = (string.IsNullOrEmpty(plTable.Rows[i].ItemArray[val2].ToString())) ? 0 : int.Parse(plTable.Rows[i].ItemArray[val2].ToString());
                            DateTime NTKTEdDate = (string.IsNullOrEmpty(plTable.Rows[i].ItemArray[val3].ToString())) ? DateTime.Now : DateTime.Parse(plTable.Rows[i].ItemArray[val3].ToString());
                            string VNPTId = SiteObj.VNPT_ID(plTable.Rows[i].ItemArray[1].ToString()).ToString();

                            for (int j = tem; j < min; j++)
                            {
                                SiteName += (string.IsNullOrEmpty(plTable.Rows[j].ItemArray[1].ToString())) ? "VNPT Name" : plTable.Rows[j].ItemArray[1].ToString();
                                NTKTMainline += (string.IsNullOrEmpty(plTable.Rows[j].ItemArray[val1].ToString())) ? 0 : int.Parse(plTable.Rows[j].ItemArray[val1].ToString());
                                NTKTSparegoods += (string.IsNullOrEmpty(plTable.Rows[j].ItemArray[val2].ToString())) ? 0 : int.Parse(plTable.Rows[j].ItemArray[val2].ToString());
                                NTKTEdDate = (string.IsNullOrEmpty(plTable.Rows[j].ItemArray[val3].ToString())) ? DateTime.Now : DateTime.Parse(plTable.Rows[i].ItemArray[val3].ToString());
                                VNPTId += SiteObj.VNPT_ID(plTable.Rows[i].ItemArray[1].ToString()).ToString();
                            }

                            if (!NTKTDetailsObj.NTKTDetailsExist((Tag as OPMDASHBOARDA).Ntkt.NTKTId + "_" + (Tag as OPMDASHBOARDA).Ntkt.NTKTPhase.ToString() + "_" + VNPTId, VNPTId))
                            {
                                string query = string.Format("INSERT INTO dbo.NTKTDetails(id, NTKTId, VNPTId, NTKTMainline, NTKTSparegoods, NTKTEdDate)VALUES(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')", (Tag as OPMDASHBOARDA).Ntkt.NTKTId + "_" + (Tag as OPMDASHBOARDA).Ntkt.NTKTPhase.ToString() + "_"+ VNPTId, NTKTId, VNPTId, NTKTMainline, NTKTSparegoods, NTKTEdDate);
                                OPMDBHandler.ExecuteNonQuery(query);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.StackTrace, "Cảnh báo!");
                    }
                    
                    LoadTodtgNTKT(NTKTId);
                    AddNTKTBinding();
                }
                else
                {
                    MessageBox.Show("NTKT cho các tỉnh đã tồn tại, nếu bạn muốn thay đổi thì xoá NTKT này đi và tạo lại mới!", "Cảnh báo!");
                }
            }
        }
    }
}
