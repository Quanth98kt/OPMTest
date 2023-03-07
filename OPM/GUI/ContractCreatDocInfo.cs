using OPM.OPMWordHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class ContractCreatDocInfo : Form
    {
        public string ContractId;
        public ContractCreatDocInfo()
        {
            InitializeComponent();
        }

        private void btnCreatDocument_Click(object sender, EventArgs e)
        {
            if (checkBoxTemp1_ContractGuarantee.Checked == true)
            {
                WordHandler1.CreateWordDocument_1_ContractGuarantee(ContractId, @"D:\OPMTest\Template\Mẫu 1. Đề nghị mở bảo lãnh thực hiện hợp đồng.docx");
            }
            if (checkBoxTemp29_ContractReportOfConpletedVolume.Checked == true)
            {
                WordHandler1.CreateWordDocument_29_ContractReportOfConpletedVolume(ContractId, @"D:\OPMTest\Template\Mẫu 29. Biên bản xác nhận khối lượng hoàn thành.docx");
            }
            if (checkBoxTemp30_ContractLiquidationRecords.Checked == true)
            {
                WordHandler1.CreateWordDocument_30_ContractLiquidationRecords(ContractId, @"D:\OPMTest\Template\Mẫu 30. Biên bản thanh lý hợp đồng.docx");
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "Contract_" + ContractId;
        }
    }
}
