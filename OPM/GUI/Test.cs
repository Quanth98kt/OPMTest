using DGVPrinterHelper;
using OPM.ExcelHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ExcelOffice = Microsoft.Office.Interop.Excel;
using System.Drawing.Printing;

namespace OPM.GUI
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private OpenFileDialog ofd;

        String content = "";
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Font drawFont = new Font("Arial", 16);
            ev.Graphics.DrawString(content, drawFont, Brushes.Black,
                            ev.MarginBounds.Left, 0, new StringFormat());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog() /*{ Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", ValidateNames = true }*/;

            //ofd.ShowDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;

                var application = new Microsoft.Office.Interop.Excel.Application();
                //var document = application.Documents.Open(@"D:\ICT.docx");
                //read all text into content
                content = System.IO.File.ReadAllText(fileName);
                //var document = application.Documents.Open(@fileName);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "fileName";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            //Call ShowDialog
            if (printDlg.ShowDialog() == DialogResult.OK)
            {
                printDoc.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                printDoc.Print();
            }
        }
    }
}
