using OPM.ExcelHandler;
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
    public partial class POCreatDocInfo : Form
    {
        public string POId;
        public POCreatDocInfo()
        {
            InitializeComponent();
        }

        private void btnCreatDocument_Click(object sender, EventArgs e)
        {
            if (checkBoxTemp3_POConfirm.Checked == true)
            {
                WordHandler1.CreateWordDocument_3_POConfirm(POId, @"C:\OPM\Template\Mẫu 3. Văn bản xác nhận hiệu lực đơn hàng.docx");
            }
            if (checkBoxTemp4_POPerformanceGuarantee.Checked == true)
            {
                WordHandler1.CreateWordDocument_4_POPerformanceGuarantee(POId, @"C:\OPM\Template\Mẫu 4. Văn bản mở bảo lãnh thực hiện đơn hàng.docx");
            }
            if (checkBoxTemp5_POAdvanceGuarantee.Checked == true)
            {
                WordHandler1.CreateWordDocument_5_POAdvanceGuarantee(POId, @"C:\OPM\Template\Mẫu 5. Văn bản mở bảo lãnh tạm ứng đơn hàng.docx");
            }
            if (checkBoxTemp6_POAdvanceRequest.Checked == true)
            {
                WordHandler1.CreateWordDocument_6_POAdvanceRequest(POId, @"C:\OPM\Template\Mẫu 6. Văn bản đề nghị tạm ứng đơn hàng.docx");
            }
            if (checkBoxTemp7_PODistributionTable.Checked == true)
            {
                OpmExcelHandler1.CreateWordDocument_7_PODistributionTable(POId, @"C:\OPM\Template\Mẫu 7. Bảng phần bổ giá trị tạm ứng đơn hàng.xlsx");
            }
            if (checkBoxTemp23_POCNCL_TongHop.Checked == true)
            {
                WordHandler1.CreateWordDocument_23_POCNCL_TongHop(POId, @"C:\OPM\Template\Mẫu 23. Giấy chứng nhận chất lượng tổng hợp PO.docx");
            }
            if (checkBoxTemp24_POCNCLNMTongHop.Checked == true)
            {
                WordHandler1.CreateWordDocument_24_POCNCLNMTongHop(POId, @"C:\OPM\Template\Mẫu 24. Giấy chứng nhận chất lượng từ nhà máy tổng hợp PO.docx");
            }
            if (checkBoxTemp25_InvoicingRequestPO.Checked == true)
            {
                WordHandler1.CreateWordDocument_25_InvoicingRequestPO(POId, @"C:\OPM\Template\Mẫu 25. Đề nghị phát hoá đơn cho các viễn thông tỉnh theo PO.docx");
            }
            if (checkBoxTemp26_MinutesConfirmingDeliveryProgressPO.Checked == true)
            {
                WordHandler1.CreateWordDocument_26_MinutesConfirmingDeliveryProgressPO(POId, @"C:\OPM\Template\Mẫu 28. Biên bản nghiệm thu bàn giao hàng hóa.docx");
            }
            if (checkBoxTemp28_POReportOfAcceptanceAndHandlingOfGoods.Checked == true)
            {
                WordHandler1.CreateWordDocument_28_POReportOfAcceptanceAndHandlingOfGoods(POId, @"C:\OPM\Template\Mẫu 28. Biên bản nghiệm thu bàn giao hàng hóa.docx");
            }
            if (checkBoxTemp33_POOfferToGuaranteeWarranty.Checked == true)
            {
                WordHandler1.CreateWordDocument_33_POOfferToGuaranteeWarranty(POId, @"C:\OPM\Template\Mẫu 33. Văn bản đề nghị mở BLBH PO.docx");
            }
            if (checkBoxTemp36_POBBNTLicense.Checked == true)
            {
                WordHandler1.CreateWordDocument_36_POBBNTLicense(POId, @"C:\OPM\Template\Mẫu 36. Biên bản nghiệm thu License.docx");
            }
            if (checkBoxTemp37_POBBXNCDLicense.Checked == true)
            {
                WordHandler1.CreateWordDocument_37_POBBXNCDLicense(POId, @"C:\OPM\Template\Mẫu 37. Biên bản xác nhận cài đặt License vào hệ thống.docx");
            }
            if (checkBoxTemp39_POAdjustmentConfirmation.Checked == true)
            {
                WordHandler1.CreateWordDocument_39_POAdjustmentConfirmation(POId, @"C:\OPM\Template\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng.docx");
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "PO_" + POId;
        }

        private void POCreatDocInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
