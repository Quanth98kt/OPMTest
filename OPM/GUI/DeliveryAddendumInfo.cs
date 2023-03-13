using OPM.OPMEnginee;
using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPM.ExcelHandler;

namespace OPM.GUI
{
    public partial class DeliveryAddendumInfo : Form
    {
        private string _message;
        public DeliveryAddendumObj DA { get; set; } = new DeliveryAddendumObj();
        public List<DeliveryAddendumObj> DAs { get; set; } = new List<DeliveryAddendumObj>();
        public DeliveryAddendumInfo()
        {
            InitializeComponent();
        }
        private void DeliveryAddendumInfo_Load(object sender, EventArgs e)
        {
            LoadSiteA();
            LoadTodtg();
            AddBinding();
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        private void LoadSiteA()
        {
            List<SiteObj> sites = SiteObj.SiteGetList();
            SiteObj site = new SiteObj();
            ccbVNPTId.DataSource = SiteObj.SiteGetList();
            ccbVNPTId.DisplayMember = "SiteId";
            //ccbVNPTId.Text = (Tag as OPMDASHBOARDA).SiteA.SiteId;
        }

        private void LoadTodtg(int STT = 0)
        {
            List<DeliveryAddendumObj> Addendums = DeliveryAddendumObj.DetailListByPOId(_message);
            //SiteInfoId = (Tag as OPMDASHBOARDA).Contract.SiteId;
            DeliveryAddendumObj Addendum = new DeliveryAddendumObj();
            if (!DeliveryAddendumObj.DeliveryAddendumByPOId(_message))
            {
                Addendums.Insert(0, Addendum);
            }
            dtgAddendum.DataSource = Addendums;
            dtgAddendum.Columns["id"].Visible = false;
            dtgAddendum.Columns["POId"].Visible = false;
            dtgAddendum.Columns["VNPTId"].Visible = false;
            dtgAddendum.Columns["VNPTId"].HeaderText = @"VNPT ID";
            dtgAddendum.Columns["SiteName"].HeaderText = @"VNPT Name";
            dtgAddendum.Columns["Mainline"].HeaderText = @"Hàng chính";
            dtgAddendum.Columns["Sparegoods"].HeaderText = @"Hàng dự phòng";
            dtgAddendum.Columns["EdDate"].HeaderText = @"Ngày giao hàng dự kiến";
            foreach (DataGridViewRow row in dtgAddendum.Rows)
            {
                if (row.Cells["VNPTId"].Value.ToString() == STT.ToString())
                {
                    dtgAddendum.CurrentCell = row.Cells["VNPTId"];
                    return;
                }
            }
            AddBinding();
        }
        void AddBinding()
        {
            tbID.DataBindings.Clear();
            tbID.DataBindings.Add(new Binding("Tag", dtgAddendum.DataSource, "id"));
            tbID.DataBindings.Add(new Binding("Text", dtgAddendum.DataSource, "id"));
            tbnSTT.DataBindings.Clear();
            tbnSTT.DataBindings.Add(new Binding("Tag", dtgAddendum.DataSource, "STT"));
            tbnSTT.DataBindings.Add(new Binding("Text", dtgAddendum.DataSource, "STT"));
            ccbVNPTId.DataBindings.Clear();
            ccbVNPTId.DataBindings.Add(new Binding("Text", dtgAddendum.DataSource, "VNPTId"));
            txtMainline.DataBindings.Clear();
            txtMainline.DataBindings.Add(new Binding("Text", dtgAddendum.DataSource, "Mainline"));
            txtSparegoods.DataBindings.Clear();
            txtSparegoods.DataBindings.Add(new Binding("Text", dtgAddendum.DataSource, "Sparegoods"));
            dtpEdDate.DataBindings.Clear();
            dtpEdDate.DataBindings.Add(new Binding("Value", dtgAddendum.DataSource, "EdDate"));
        }

        private void tbnSTT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbnSTT.Text.Trim()) && tbnSTT.Text.Trim() != tbnSTT.Tag.ToString())
                {
                    if (!DeliveryAddendumObj.DeliveryAddendumSTTExist(int.Parse(tbnSTT.Text.Trim()), _message))
                    {
                        DA.STT = int.Parse(tbnSTT.Text.Trim());
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Đã tồn tại Số thứ tự {0}!", tbnSTT.Text.Trim()));
                    }
                }
            }
            catch
            {
                MessageBox.Show(string.Format("Nhập Số thứ tự dạng số!", tbnSTT.Text.Trim()));
            }
        }

        private void ccbVNPTId_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (ccbVNPTId.SelectedValue != null)
            {
                SiteObj siteName = cb.SelectedValue as SiteObj;
            }
        }

        private void txtMainline_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtMainline.Text.Trim()) )
                {
                    DA.Mainline = int.Parse(txtMainline.Text.Trim());
                    txtSparegoods.Text = Math.Round(double.Parse(txtMainline.Text.Trim()) / 50, 0, MidpointRounding.AwayFromZero).ToString();
                }
            }
            catch
            {
                MessageBox.Show(string.Format("Nhập Số lượng hàng chính dạng số!", tbnSTT.Text.Trim()));
            }
        }

        private void txtSparegoods_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSparegoods.Text.Trim()))
                {
                    DA.Sparegoods = int.Parse(txtSparegoods.Text.Trim());
                }
            }
            catch
            {
                MessageBox.Show(string.Format("Nhập Số lượng hàng dự phòng dạng số!", tbnSTT.Text.Trim()));
            }
        }

        private void dtpEdDate_ValueChanged(object sender, EventArgs e)
        {
            DA.EdDate = dtpEdDate.Value;
        }

        private void btnAddNTKTDetail_Click(object sender, EventArgs e)
        {
            var DeliveryAddendumObj = new OPMEnginee.DeliveryAddendumObj
            {
                id = _message + "_" + (ccbVNPTId.SelectedItem as SiteObj).SiteId,
                STT = int.Parse(tbnSTT.Text.Trim()),
                VNPTId = (ccbVNPTId.SelectedItem as SiteObj).SiteId,
                POId = _message,
                Mainline = int.Parse(txtMainline.Text.Trim()),
                Sparegoods = int.Parse(txtSparegoods.Text.Trim()),
                EdDate = dtpEdDate.Value
            };
            
            if (!DeliveryAddendumObj.DeliveryAddendumExist(_message + "_" + (ccbVNPTId.SelectedItem as SiteObj).SiteId))
            {
                if (!DeliveryAddendumObj.DeliveryAddendumExist(_message, (ccbVNPTId.SelectedItem as SiteObj).SiteId))
                {
                    if (!DeliveryAddendumObj.DeliveryAddendumSTTExist(int.Parse(tbnSTT.Text.Trim()), _message))
                    {
                        DeliveryAddendumObj.DeliveryAddendumInsert();
                    }
                    else
                    {
                        MessageBox.Show("Đã tồn tại Số thứ tự, vui lòng chọn lại!");
                    }
                }
                else
                {
                    MessageBox.Show("Đã tồn tại VNPT Name, vui lòng chọn lại!");
                }
            }
            else
            {
                DeliveryAddendumObj.DeliveryAddendumUpdate(_message + "_" + (ccbVNPTId.SelectedItem as SiteObj).SiteId);
                MessageBox.Show(string.Format("Cập nhật thành công thông tin cho {0}", (ccbVNPTId.SelectedItem as SiteObj).SiteId));
            }

                DeliveryAddendumObj NTKTdt = new DeliveryAddendumObj();
            NTKTdt.VNPTId = (ccbVNPTId.SelectedItem as SiteObj).SiteId;
            LoadTodtg();
            AddBinding();
        }

        private void btnDeleteNTKTDetail_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(string.Format("Bạn có chắc muốn xóa thông tin cho {0}", (ccbVNPTId.SelectedItem as SiteObj).SiteId), "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeliveryAddendumObj.DeliveryAddendumDelete(tbID.Text.Trim());
                MessageBox.Show("Bạn đã xóa thành công!");
            }
            NTKTDetailsObj NTKTdt = new NTKTDetailsObj();
            NTKTdt.VNPTId = (ccbVNPTId.SelectedItem as SiteObj).SiteId;
            LoadTodtg();
            AddBinding();
            //LoadData(txtVNPTId.Text.Trim());
        }
        private OpenFileDialog ofd;
        private void btnImportNTKTDt_Click(object sender, EventArgs e)
        {
            try
            {

                ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", ValidateNames = true };

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    tb_path.Text = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);

                    string path = ofd.FileName;
                    //string substr = path[^4..];

                    DataTable plTable = OpmExcelHandler.DataTableNTKTDetailsFromExcelFile(path, 1, 2, 1);

                    int pLTableCount = plTable.Rows.Count;

                    try
                    {
                        for (int i = 0; i < pLTableCount; i++)
                        {
                            int tem = 1;
                            int min = Math.Min(tem, pLTableCount);

                            int STT = (string.IsNullOrEmpty(plTable.Rows[i].ItemArray[0].ToString())) ? 0 : int.Parse(plTable.Rows[i].ItemArray[0].ToString());
                            string SiteName = (plTable.Rows[i].ItemArray[1].ToString() != null) ? "VNPT Name" : plTable.Rows[i].ItemArray[1].ToString();
                            double Mainline = (string.IsNullOrEmpty(plTable.Rows[i].ItemArray[2].ToString())) ? 0 : int.Parse(plTable.Rows[i].ItemArray[2].ToString());
                            double Sparegoods = (string.IsNullOrEmpty(plTable.Rows[i].ItemArray[3].ToString())) ? 0 : int.Parse(plTable.Rows[i].ItemArray[3].ToString());
                            DateTime EdDate = (string.IsNullOrEmpty(plTable.Rows[i].ItemArray[4].ToString())) ? DateTime.Now : DateTime.Parse(plTable.Rows[i].ItemArray[4].ToString());
                            string VNPTId = SiteObj.VNPT_ID(plTable.Rows[i].ItemArray[1].ToString()).ToString();

                            for (int j = tem; j < min; j++)
                            {
                                STT += (string.IsNullOrEmpty(plTable.Rows[j].ItemArray[0].ToString())) ? 0 : int.Parse(plTable.Rows[j].ItemArray[0].ToString());
                                SiteName += (string.IsNullOrEmpty(plTable.Rows[j].ItemArray[1].ToString())) ? "VNPT Name" : plTable.Rows[j].ItemArray[1].ToString();
                                Mainline += (string.IsNullOrEmpty(plTable.Rows[j].ItemArray[2].ToString())) ? 0 : int.Parse(plTable.Rows[j].ItemArray[2].ToString());
                                Sparegoods += (string.IsNullOrEmpty(plTable.Rows[j].ItemArray[3].ToString())) ? 0 : int.Parse(plTable.Rows[j].ItemArray[3].ToString());
                                EdDate = (string.IsNullOrEmpty(plTable.Rows[j].ItemArray[4].ToString())) ? DateTime.Now : DateTime.Parse(plTable.Rows[i].ItemArray[4].ToString());
                                VNPTId += SiteObj.VNPT_ID(plTable.Rows[i].ItemArray[1].ToString()).ToString();
                            }

                            if (!DeliveryAddendumObj.DeliveryAddendumExist(_message, VNPTId))
                            {
                                string query = string.Format("INSERT INTO dbo.DeliveryAddendum(id, STT, POId, VNPTId, Mainline, Sparegoods, EdDate)VALUES(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}')", _message + "_" + VNPTId, STT, _message, VNPTId, Mainline, Sparegoods, EdDate);
                                OPMDBHandler.ExecuteNonQuery(query);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.StackTrace, "Cảnh báo!");
                    }

                    LoadTodtg();
                    AddBinding();
                }
            }
            catch
            {
                
            }
        }
    }
}
