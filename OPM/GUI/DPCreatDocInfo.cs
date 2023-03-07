using OPM.ExcelHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class DPCreatDocInfo : Form
    {
        public string DPId;
        public DPCreatDocInfo()
        {
            InitializeComponent();
        }

        private void btnCreatDocument_Click(object sender, EventArgs e)
        {
            if (checkBoxTemp12_DPCreatedbyOPM.Checked == true)
            {
                OpmExcelHandler1.CreateWordDocument_12_DPCreatedbyOPM(DPId, @"D:\OPMTest\Template\Mẫu 12. DP do OPM tạo.xlsx");
            }
            if (checkBoxTemp13_DPExportRequestForm_ANSV.Checked == true)
            {
                OpmExcelHandler1.CreateWordDocument_13_DPExportRequestForm_ANSV(DPId, @"D:\OPMTest\Template\Mẫu 13. Phiếu yêu cầu xuất kho ANSV.xlsx");
            }
            if (checkBoxTemp14_DPCreatedbyANSV.Checked == true)
            {
                OpmExcelHandler1.CreateWordDocument_14_DPCreatedbyANSV(DPId, @"D:\OPMTest\Template\Mẫu 14. DP do ANSV tạo.xlsx");
            }
            if (checkBoxTemp16_DPExportRequestForm_VNPTTech.Checked == true)
            {
                OpmExcelHandler1.CreateWordDocument_16_DPExportRequestForm_VNPTTech(DPId, @"D:\OPMTest\Template\Mẫu 16. Phiếu yêu cầu xuất kho TECH.xlsx");
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "DP_" + DPId;
        }
    }
}