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
    public partial class NTKTCreatDocInfo : Form
    {
        public string NTKTId;
        public NTKTCreatDocInfo()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "NTKT_" + NTKTId;
        }

        private void btnCreatDocument_Click(object sender, EventArgs e)
        {
            if (checkBoxTemp08_NTKTRequest.Checked == true)
            {
                WordHandler1.CreateWordDocument_08_NTKTRequest(NTKTId, @"D:\OPMTest\Template\Mẫu 8. Đề nghị nghiệm thu kỹ thuật.docx");
            }
            if (checkBoxTemp09_NTKTBBKTKT.Checked == true)
            {
                WordHandler1.CreateWordDocument_09_NTKTBBKTKT(NTKTId, @"D:\OPMTest\Template\Mẫu 9. Biên bản kiểm tra kỹ thuật.docx");
            }
            if (checkBoxTemp10_NTKTCNBQPM.Checked == true)
            {
                WordHandler1.CreateWordDocument_10_NTKTCNBQPM(NTKTId, @"D:\OPMTest\Template\Mẫu 10. Chứng nhận bản quyền phần mềm.docx");
            }
            if (checkBoxTemp11_NTKTBBNTKT.Checked == true)
            {
                WordHandler1.CreateWordDocument_11_NTKTBBNTKT(NTKTId, @"D:\OPMTest\Template\Mẫu 11. Biên bản nghiệm thu kỹ thuật.docx");
            }
        }
    }
}
