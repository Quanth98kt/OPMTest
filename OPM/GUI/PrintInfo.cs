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
using System.Diagnostics;
using OPM.OPMEnginee;

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

        private void btnPrintPDF_Click(object sender, EventArgs e)
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
                        if (f.ToLower().EndsWith(".pdf") == true)
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

                    const string flagNoSplashScreen = "/s";
                    const string flagOpenMinimized = "/h";

                    if (printDlg.ShowDialog() == DialogResult.OK)
                    {
                        //Print
                        foreach (string item in list)
                        {
                            var flagPrintFileToPrinter = string.Format("/t \"{0}\" \"{1}\"", item, printDlg.PrinterSettings.PrinterName);
                            var args = string.Format("{0} {1} {2}", flagNoSplashScreen, flagOpenMinimized, flagPrintFileToPrinter);

                            string processFilename = Microsoft.Win32.Registry.LocalMachine
                                 .OpenSubKey("Software")
                                 .OpenSubKey("Microsoft")
                                 .OpenSubKey("Windows")
                                 .OpenSubKey("CurrentVersion")
                                 .OpenSubKey("App Paths")
                                 .OpenSubKey("AcroRd32.exe")
                                 .GetValue(String.Empty).ToString();

                            Process p = new Process();
                            p.StartInfo.UseShellExecute = false;
                            p.StartInfo.CreateNoWindow = true;
                            p.StartInfo.UseShellExecute = false;
                            p.StartInfo.FileName = processFilename;
                            p.StartInfo.RedirectStandardError = true;
                            p.StartInfo.Arguments = args;
                            p.Start();
                            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            p.EnableRaisingEvents = true;
                            p.CloseMainWindow();
                            p.Close();
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi nguồn dữ liệu!");
            }
        }

        private void btnPicturePrint_Click(object sender, EventArgs e)
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
                        if (f.ToLower().EndsWith(".jfif") == true || f.ToLower().EndsWith(".jpg") == true || f.ToLower().EndsWith(".jpeg") == true || f.ToLower().EndsWith(".png") == true || f.ToLower().EndsWith(".gif") == true || f.ToLower().EndsWith(".tiff") == true || f.ToLower().EndsWith(".raw") == true)
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
                            PrintDocument pd = new PrintDocument();
                            a = item;
                            pd.PrintPage += PrintPage;
                            pd.Print();
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

        string a;
        private void PrintPage(object o, PrintPageEventArgs e)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(a);
            Point loc = new Point(0, 0);
            e.Graphics.DrawImage(img, loc);
        }

        private void btnArrange_Click(object sender, EventArgs e)
        {
            SiteObj.SiteName_NonUnicode();
            DataTable table = SiteObj.SiteName_NonUnicode();
            DataRow row1 = table.NewRow();

            try
            {
                dgvName.Rows.Clear();

                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    List<string> list = new List<string>(files);

                    //Datagridview
                    foreach (string item in list)
                    {
                        //Datagridview
                        string Filename = Path.GetFileName(item);
                        this.dgvName.Rows.Add(Filename);
                    }

                    // Tạo Folder Hàng Chính, Folder Hàng dự phòng
                    string pathFolder = System.IO.Directory.GetParent(fbd.SelectedPath).ToString();
                    DirectoryInfo directory_HangChinh = new DirectoryInfo(pathFolder + @"\PL HANG CHINH");
                    DirectoryInfo directory_HangDuPhong = new DirectoryInfo(pathFolder + @"\PL HANG DU PHONG");
                    if (!directory_HangChinh.Exists)
                    {
                        directory_HangChinh.Create();
                    }
                    else
                    {
                        MessageBox.Show(String.Format("Đã tồn tại Folder PL HANG CHINH tại {0}.", pathFolder));
                        return;
                    }
                    if (!directory_HangDuPhong.Exists)
                    {
                        directory_HangDuPhong.Create();
                    }
                    else
                    {
                        MessageBox.Show(String.Format("Đã tồn tại Folder PL HANG DU PHONG tại {0}.", pathFolder));
                        return;
                    }

                    //Check
                    foreach (string item in list)
                    {
                        //Datagridview
                        string Filename = Path.GetFileName(item);

                        foreach (DataRow dataRow in table.Rows)
                        {
                            //this.dgvName.Rows.Add(dataRow[0]);
                            int index_TenTinh = Filename.IndexOf((string)dataRow[0]);
                            int index_2Percent = Filename.IndexOf("2%");
                            if (index_TenTinh >= 0 && index_2Percent < 0)
                            {
                                DirectoryInfo directory_HangChinh_Tinh = new DirectoryInfo(pathFolder + @"\PL HANG CHINH" + @"\" + (string)dataRow[0]);
                                directory_HangChinh_Tinh.Create();
                                string sourceFile = System.IO.Path.Combine(pathFolder + @"\PL HANG CHINH" + @"\" + (string)dataRow[0], Filename);
                                //string destFile = System.IO.Path.Combine(targetPath, fileName);
                                File.Copy(item.ToString(), pathFolder + @"\PL HANG CHINH" + @"\" + (string)dataRow[0] + @"\" + Filename, true);
                            }
                            if (index_TenTinh >= 0 && index_2Percent >= 0)
                            {
                                DirectoryInfo directory_HangDuPhong_Tinh = new DirectoryInfo(pathFolder + @"\PL HANG DU PHONG" + @"\" + (string)dataRow[0]);
                                directory_HangDuPhong_Tinh.Create();
                                File.Copy(item, pathFolder + @"\PL HANG DU PHONG" + @"\" + (string)dataRow[0] + @"\" + Filename, true);
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi nguồn dữ liệu!");
            }
        }
    }
}
