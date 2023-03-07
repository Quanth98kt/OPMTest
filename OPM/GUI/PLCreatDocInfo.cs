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
    public partial class PLCreatDocInfo : Form
    {
        public string PLId;
        public PLCreatDocInfo()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "PL_" + PLId;
        }

        private void btnCreatDocument_Click(object sender, EventArgs e)
        {
            if (checkBoxTemp18_PLGoodsDeliveryRecord.Checked == true)
            {
                WordHandler1.CreateWordDocument_18_PLGoodsDeliveryRecord(PLId, @"D:\OPMTest\Template\Mẫu 18.  Biên bản giao nhận hàng hóa.docx");
            }
            if (checkBoxTemp19_PLQualityInspectionCertificateInFactory.Checked == true)
            {
                WordHandler1.CreateWordDocument_19_PLQualityInspectionCertificateInFactory(PLId, @"D:\OPMTest\Template\Mẫu 19. Giấy chứng nhận chất lượng từ nhà máy gửi tỉnh.docx");
            }
            if (checkBoxTemp20_PLQualityInspectionCertificate.Checked == true)
            {
                WordHandler1.CreateWordDocument_20_PLQualityInspectionCertificate(PLId, @"D:\OPMTest\Template\Mẫu 20. Giấy chứng nhận chất lượng gửi tỉnh.docx");
            }
            if (checkBoxTemp22_PLWarranty.Checked == true)
            {
                WordHandler1.CreateWordDocument_22_PLWarranty(PLId, @"D:\OPMTest\Template\Mẫu 22. Mẫu phiếu bảo hành.docx");
            }
            if (checkBoxTemp27_PLReportForDelivery.Checked == true)
            {
                OpmExcelHandler1.CreateWordDocument_27_PLReportForDelivery(PLId, @"D:\OPMTest\Template\Mẫu 27. Biên bản bàn giao HH kho ANSV.xlsx");
            }
        }
    }
}
