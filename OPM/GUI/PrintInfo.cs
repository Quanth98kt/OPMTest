using OPM.ExcelHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ExcelOffice = Microsoft.Office.Interop.Excel;
using WordOffice = Microsoft.Office.Interop.Word;
using System.Drawing.Printing;
using System.IO;

namespace OPM.GUI
{
    public partial class PrintInfo : Form
    {
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        public List<string> listSheets { get; set; } = new List<string>();
        public PrintInfo()
        {
            InitializeComponent();
            LoadSheet();
        }

        private void LoadSheet()
        {
            string[] listSheet = tbnSheet.Text.Split(',');

            listSheets = new List<string>(listSheet);
        }

        private void btnExcelPrint_Click(object sender, EventArgs e)
        {
            try
            {
                dgvName.Rows.Clear();

                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    List<string> list = new List<string>();

                    foreach (string f in Directory.GetFiles(fbd.SelectedPath))
                    {
                        if (f.ToLower().EndsWith(".xlsx") == true || f.ToLower().EndsWith(".xlsm") == true || f.ToLower().EndsWith(".xls") == true)
                        {
                            list.Add(f);

                        }
                    }
                    //Datagridview
                    foreach (string item in list)
                    {
                        //Datagridview
                        string Filename = Path.GetFileName(item);
                        this.dgvName.Rows.Add(Filename);
                    }

                    PrintDialog printDlg = new PrintDialog();
                    PrintDocument printDoc = new PrintDocument();
                    printDoc.DocumentName = "fileName";
                    printDlg.Document = printDoc;
                    printDlg.AllowSelection = true;
                    printDlg.AllowSomePages = true;
                    if (printDlg.ShowDialog() == DialogResult.OK)
                    {
                        //Print
                        foreach (string item in list)
                        {
                            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

                            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Open(item,
                                    Type.Missing, false, Type.Missing, Type.Missing, Type.Missing,
                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                            foreach (string a in listSheets)
                            {
                                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[int.Parse(a.ToString())];

                                ws.PageSetup.PrintHeadings = false;
                                ws.PageSetup.BlackAndWhite = false;
                                ws.PageSetup.PrintGridlines = false;

                                ws.PrintOut(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            }

                            app.Visible = false;

                            wb.Close(false, Type.Missing, Type.Missing);
                            app.Quit();
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi nguồn dữ liệu!");
            }
        }

        private void btnWordPrint_Click(object sender, EventArgs e)
        {
            try
            {
                dgvName.Rows.Clear();

                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    List<string> list = new List<string>();

                    foreach (string f in Directory.GetFiles(fbd.SelectedPath))
                    {
                        if (f.ToLower().EndsWith(".doc") == true || f.ToLower().EndsWith(".docx") == true)
                        {
                            list.Add(f);

                        }
                    }

                    //Datagridview
                    foreach (string item in list)
                    {
                        //Datagridview
                        string Filename = Path.GetFileName(item);
                        this.dgvName.Rows.Add(Filename);
                    }

                    PrintDialog printDlg = new PrintDialog();
                    PrintDocument printDoc = new PrintDocument();
                    printDoc.DocumentName = "fileName";
                    printDlg.Document = printDoc;
                    printDlg.AllowSelection = true;
                    printDlg.AllowSomePages = true;
                    if (printDlg.ShowDialog() == DialogResult.OK)
                    {
                        //Print
                        foreach (string item in list)
                        {
                            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();

                            Microsoft.Office.Interop.Word.Document wordDoc = app.Documents.Open(item, Type.Missing, true,
                                    Type.Missing, Type.Missing, Type.Missing,
                                    Type.Missing, Type.Missing, Type.Missing,
                                    Type.Missing, Type.Missing, Type.Missing,
                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                            Microsoft.Office.Interop.Word.Document ws = (Microsoft.Office.Interop.Word.Document)wordDoc;

                            wordDoc.PrintOut(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                            app.Visible = false;

                            wordDoc.Close(false, Type.Missing, Type.Missing);
                            app.Quit();
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi nguồn dữ liệu!");
            }
        }

        private void tbnSheet_TextChanged(object sender, EventArgs e)
        {
            string[] listSheet = tbnSheet.Text.Split(',');

            listSheets = new List<string>(listSheet);
        }

        
    }
}
