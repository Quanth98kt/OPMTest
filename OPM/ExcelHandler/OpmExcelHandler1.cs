using ExcelDataReader;
using Microsoft.Office.Interop.Excel;
using OPM.OPMEnginee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ExcelOffice = Microsoft.Office.Interop.Excel;
using Syncfusion.XlsIO;

namespace OPM.ExcelHandler
{
    class OpmExcelHandler1
    {
        // Mẫu 7: Bảng phần bổ giá trị tạm ứng đơn hàng.
        public static string CreateWordDocument_7_PODistributionTable(string poid, object filename)
        {
            POObj po = new POObj(poid);
            /*object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            object path = @"D:\OPMTest\Template\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng.docx";*/

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 7. Bảng phần bổ giá trị tạm ứng đơn hàng {2}.xlsx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));

            object m = Type.Missing;
            ExcelOffice.Range xlRange = null;
            ExcelOffice.Workbook xlWorkbook = null;
            ExcelOffice.Application xlApp = null;
            ExcelOffice._Worksheet xlWorksheet = null;


            try
            {

                xlApp = new ExcelOffice.Application();
                xlWorkbook = xlApp.Workbooks.Open(filename.ToString(), m, false, m, m, m, m, m, m, m, m, m, m, m, m);
                xlWorksheet = (ExcelOffice._Worksheet)xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;
                //Rellace theo từng cell
                bool success = (bool)xlRange.Replace("<POAdvanceRequestId>", po.POAdvanceRequestId.ToString(), XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success1 = (bool)xlRange.Replace("<Ngày tháng năm>", string.Format("Hà Nội, ngày {0} tháng {1} năm {2}", po.POAdvanceRequestCreatedDate.Day, po.POAdvanceRequestCreatedDate.Month, po.POAdvanceRequestCreatedDate.Year), XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                string temp = @"Hợp đồng: " + po.ContractId + " ngày " + po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")) + " giữa " + po.SiteId + " và Công ty TNHH Thiết bị Viễn thông ANSV";
                bool success2 = (bool)xlRange.Replace("<ghi chú>", temp, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);

                //Lấy bảng dữ liệu từ DataTable
                System.Data.DataTable dataTable = POObj.PODeliveryPlanQuantity(po.POId);
                int rowCount = dataTable.Rows.Count;
                double tongcong = 0;
                for (int i = 0; i < rowCount; i++)
                {
                    xlWorksheet.Cells[10 + i, 1] = i + 1;
                    xlWorksheet.Cells[10 + i, 2] = dataTable.Rows[i].ItemArray[0].ToString();
                    xlWorksheet.Cells[10 + i, 3] = dataTable.Rows[i].ItemArray[1];
                    xlWorksheet.Cells[10 + i, 4] = dataTable.Rows[i].ItemArray[2];
                    double tam = double.Parse(dataTable.Rows[i].ItemArray[1].ToString()) * int.Parse(dataTable.Rows[i].ItemArray[2].ToString());
                    xlWorksheet.Cells[10 + i, 5] = tam;
                    xlWorksheet.Cells[10 + i, 6] = tam / 2;
                    tongcong += tam;
                }
                xlWorksheet.Cells[10 + rowCount, 4] = "Tổng cộng:";
                xlWorksheet.Cells[10 + rowCount, 5] = tongcong;
                xlWorksheet.Cells[10 + rowCount, 6] = tongcong / 2;
                string folder = string.Format(@"D:\OPMTest\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                xlWorkbook.SaveAs(file_name, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", file_name.ToString()));
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  


                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                return file_name.ToString();
            }
            catch (Exception)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                return "Lỗi, không tạo được file Excel!";
            }
        }

        //Mẫu 12: DP do OPM tạo.
        public static string CreateWordDocument_12_DPCreatedbyOPM(string DPId, object filename)
        {
            DPObj dP = new DPObj(DPId);

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\DP{2}\Mẫu 12. DP do OPM tạo_{2}.xlsx", dP.ContractId.Trim().Replace('/', '-'), dP.POName.Replace('/', '-'), dP.DPId.Replace('/', '-'));

            object m = Type.Missing;
            ExcelOffice.Range xlRange = null;
            ExcelOffice.Workbook xlWorkbook = null;
            ExcelOffice.Application xlApp = null;
            ExcelOffice._Worksheet xlWorksheet = null;

            try
            {

                xlApp = new ExcelOffice.Application();
                xlWorkbook = xlApp.Workbooks.Open(filename.ToString(), m, false, m, m, m, m, m, m, m, m, m, m, m, m);
                xlWorksheet = (ExcelOffice._Worksheet)xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;
                //Rellace theo từng cell
                bool success0 = (bool)xlRange.Replace("<SiteName>", dP.SiteName, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success1 = (bool)xlRange.Replace("<SiteId>", dP.SiteId, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success2 = (bool)xlRange.Replace("<ContractId>", dP.ContractId, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success3 = (bool)xlRange.Replace("<DPId>", dP.DPId, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success4 = (bool)xlRange.Replace("<POName>", dP.POName, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success5 = (bool)xlRange.Replace("<ContractGoodsDesignation>", dP.ContractGoodsDesignation, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success6 = (bool)xlRange.Replace("<ContractGoodsCode>", dP.ContractGoodsCode, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success7 = (bool)xlRange.Replace("<ContractGoodsOrigin>", dP.ContractGoodsOrigin, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success8 = (bool)xlRange.Replace("<ContractGoodsManufacture>", dP.ContractGoodsManufacture, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success9 = (bool)xlRange.Replace("<DPQuantity>", dP.DPQuantity, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success10 = (bool)xlRange.Replace("<ContractGoodsDesignation1>", dP.ContractGoodsDesignation1, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success11 = (bool)xlRange.Replace("<ContractGoodsCode1>", dP.ContractGoodsCode1, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success12 = (bool)xlRange.Replace("<DPType>", dP.DPType, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success13 = (bool)xlRange.Replace("<DPRemarks>", dP.DPRemarks, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success14 = (bool)xlRange.Replace("<DPDate>", dP.DPDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);

                //Lấy bảng dữ liệu từ DataTable
                System.Data.DataTable dataTable = PLObj.GetDataTableByDPId(DPId);
                int rowCount = dataTable.Rows.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    xlWorksheet.Cells[16 + i, 1] = i + 1;
                    xlWorksheet.Cells[16 + i, 2] = dataTable.Rows[i].ItemArray[1].ToString();
                    xlWorksheet.Cells[16 + i, 3] = dataTable.Rows[i].ItemArray[2];
                    //xlWorksheet.Cells[1 + i, 4] = dataTable.Rows[i].ItemArray[2];
                    //double tam = double.Parse(dataTable.Rows[i].ItemArray[1].ToString()) * int.Parse(dataTable.Rows[i].ItemArray[2].ToString());
                    //xlWorksheet.Cells[10 + i, 5] = tam;
                    //xlWorksheet.Cells[10 + i, 6] = tam / 2;
                }
                xlWorksheet.Cells[16 + rowCount, 2] = "TỔNG CỘNG";
                xlWorksheet.Cells[16 + rowCount, 3] = dP.DPQuantity;
                string folder = string.Format(@"D:\OPMTest\{0}\{1}\DP{2}", dP.ContractId.Trim().Replace('/', '-'), dP.POName.Replace('/', '-'), dP.DPId).Replace('/', '-');
                Directory.CreateDirectory(folder);
                xlWorkbook.SaveAs(file_name, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", file_name.ToString()));
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                return file_name.ToString();
            }
            catch (Exception)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                return "Lỗi, không tạo được file Excel!";
            }
        }

        //Mẫu 13: Phiếu yêu cầu xuất kho ANSV.
        public static string CreateWordDocument_13_DPExportRequestForm_ANSV(string DPId, object filename)
        {
            DPObj dP = new DPObj(DPId);

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\DP{2}\Mẫu 13. Phiếu yêu cầu xuất kho ANSV_{2}.xlsx", dP.ContractId.Trim().Replace('/', '-'), dP.POName.Replace('/', '-'), dP.DPId.Replace('/', '-'));

            object m = Type.Missing;
            ExcelOffice.Range xlRange = null;
            ExcelOffice.Workbook xlWorkbook = null;
            ExcelOffice.Application xlApp = null;
            ExcelOffice._Worksheet xlWorksheet = null;

            try
            {

                xlApp = new ExcelOffice.Application();
                xlWorkbook = xlApp.Workbooks.Open(filename.ToString(), m, false, m, m, m, m, m, m, m, m, m, m, m, m);
                xlWorksheet = (ExcelOffice._Worksheet)xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;

                //Rellace theo từng cell
                bool success0 = (bool)xlRange.Replace("<DPId>", dP.DPId, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success1 = (bool)xlRange.Replace("<ContractId>", dP.ContractId, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success2 = (bool)xlRange.Replace("<SiteName>", dP.SiteName, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success3 = (bool)xlRange.Replace("<DPRequestDate>", dP.DPRequestDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success4 = (bool)xlRange.Replace("<DPResponseDate>", dP.DPResponseDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success5 = (bool)xlRange.Replace("<SiteAddress>", dP.SiteAddress, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                if (dP.DPRefundDate.ToString() != @"01/01/2000")
                {
                    bool success6 = (bool)xlRange.Replace("<DPRefundDate>", dP.DPRefundDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                }
                else
                {
                    bool success6 = (bool)xlRange.Replace("<DPRefundDate>", "", XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                }
                bool success7 = (bool)xlRange.Replace("<ContractAccoutingCode>", dP.ContractAccoutingCode, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success8 = (bool)xlRange.Replace("<ContractGoodsCode>", dP.ContractGoodsCode, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success9 = (bool)xlRange.Replace("<ContractGoodsDesignation>", dP.ContractGoodsDesignation, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success10 = (bool)xlRange.Replace("<ContractGoodsUnit>", dP.ContractGoodsUnit, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success11 = (bool)xlRange.Replace("<DPQuantity>", dP.DPQuantity, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success12 = (bool)xlRange.Replace("<DPQuantity1>", dP.DPQuantity1, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success13 = (bool)xlRange.Replace("<DPSpareQuantity>", Math.Round(dP.DPQuantity * 0.02), XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success14 = (bool)xlRange.Replace("<DPSpareQuantity1>", Math.Round(dP.DPQuantity1 * 0.02), XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success15 = (bool)xlRange.Replace("<DPRemarks>", dP.DPRemarks, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success16 = (bool)xlRange.Replace("<ContractGoodsDesignation1>", dP.ContractGoodsDesignation + @" Hàng dự phòng 2%", XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success17 = (bool)xlRange.Replace("<DPRemarks1>", dP.DPRemarks + @" Hàng dự phòng 2%", XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);

                string folder = string.Format(@"D:\OPMTest\{0}\{1}\DP{2}", dP.ContractId.Trim().Replace('/', '-'), dP.POName.Replace('/', '-'), dP.DPId).Replace('/', '-');
                Directory.CreateDirectory(folder);
                xlWorkbook.SaveAs(file_name, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", file_name.ToString()));
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                return file_name.ToString();
            }
            catch (Exception)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                return "Lỗi, không tạo được file Excel!";
            }
        }

        //Mẫu 14: DP do ANSV tạo.
        public static string CreateWordDocument_14_DPCreatedbyANSV(string DPId, object filename)
        {
            DPObj dP = new DPObj(DPId);

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\DP{2}\Mẫu 14. DP do ANSV tạo_{2}.xlsx", dP.ContractId.Trim().Replace('/', '-'), dP.POName.Replace('/', '-'), dP.DPId.Replace('/', '-'));

            object m = Type.Missing;
            ExcelOffice.Range xlRange = null;
            ExcelOffice.Workbook xlWorkbook = null;
            ExcelOffice.Application xlApp = null;
            ExcelOffice._Worksheet xlWorksheet = null;

            try
            {

                xlApp = new ExcelOffice.Application();
                xlWorkbook = xlApp.Workbooks.Open(filename.ToString(), m, false, m, m, m, m, m, m, m, m, m, m, m, m);
                xlWorksheet = (ExcelOffice._Worksheet)xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;
                //Rellace theo từng cell
                bool success0 = (bool)xlRange.Replace("<SiteName>", dP.SiteName, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success1 = (bool)xlRange.Replace("<SiteId>", dP.SiteId, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success2 = (bool)xlRange.Replace("<ContractId>", dP.ContractId, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success3 = (bool)xlRange.Replace("<DPId>", dP.DPId, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success4 = (bool)xlRange.Replace("<POName>", dP.POName, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success5 = (bool)xlRange.Replace("<ContractGoodsDesignation>", dP.ContractGoodsDesignation, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success6 = (bool)xlRange.Replace("<ContractGoodsCode>", dP.ContractGoodsCode, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success7 = (bool)xlRange.Replace("<ContractGoodsOrigin>", dP.ContractGoodsOrigin, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success8 = (bool)xlRange.Replace("<ContractGoodsManufacture>", dP.ContractGoodsManufacture, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success9 = (bool)xlRange.Replace("<DPQuantity>", dP.DPQuantity, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success10 = (bool)xlRange.Replace("<ContractGoodsDesignation1>", dP.ContractGoodsDesignation1, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success11 = (bool)xlRange.Replace("<ContractGoodsCode1>", dP.ContractGoodsCode1, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success12 = (bool)xlRange.Replace("<DPType>", dP.DPType, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success13 = (bool)xlRange.Replace("<DPRemarks>", dP.DPRemarks, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success14 = (bool)xlRange.Replace("<DPDate>", dP.DPDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);

                string folder = string.Format(@"D:\OPMTest\{0}\{1}\DP{2}", dP.ContractId.Trim().Replace('/', '-'), dP.POName.Replace('/', '-'), dP.DPId).Replace('/', '-');
                Directory.CreateDirectory(folder);
                xlWorkbook.SaveAs(file_name, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", file_name.ToString()));
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                return file_name.ToString();
            }
            catch (Exception)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                return "Lỗi, không tạo được file Excel!";
            }
        }

        //Mẫu 16: Phiếu yêu cầu xuất kho ANSV.
        public static string CreateWordDocument_16_DPExportRequestForm_VNPTTech(string DPId, object filename)
        {
            DPObj dP = new DPObj(DPId);

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\DP{2}\Mẫu 16. Phiếu yêu cầu xuất kho TECH_{2}.xlsx", dP.ContractId.Trim().Replace('/', '-'), dP.POName.Replace('/', '-'), dP.DPId.Replace('/', '-'));

            object m = Type.Missing;
            ExcelOffice.Range xlRange = null;
            ExcelOffice.Workbook xlWorkbook = null;
            ExcelOffice.Application xlApp = null;
            ExcelOffice._Worksheet xlWorksheet = null;

            try
            {

                xlApp = new ExcelOffice.Application();
                xlWorkbook = xlApp.Workbooks.Open(filename.ToString(), m, false, m, m, m, m, m, m, m, m, m, m, m, m);
                xlWorksheet = (ExcelOffice._Worksheet)xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;
                //Rellace theo từng cell
                bool success0 = (bool)xlRange.Replace("<DPId>", dP.DPId, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success1 = (bool)xlRange.Replace("<DPVNPTTechANSVContractNumber>", dP.DPVNPTTechANSVContractNumber, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success2 = (bool)xlRange.Replace("<SiteName>", dP.SiteName, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success3 = (bool)xlRange.Replace("<DPRequestDate>", dP.DPRequestDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success4 = (bool)xlRange.Replace("<DPResponseDate>", dP.DPResponseDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success5 = (bool)xlRange.Replace("<SiteAddress>", dP.SiteAddress, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                if (dP.DPRefundDate.ToString() != @"01/01/2000")
                {
                    bool success6 = (bool)xlRange.Replace("<DPRefundDate>", dP.DPRefundDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                }
                else
                {
                    bool success6 = (bool)xlRange.Replace("<DPRefundDate>", "", XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                }
                bool success7 = (bool)xlRange.Replace("<DPContractAccoutingCode>", dP.DPContractAccoutingCode, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success8 = (bool)xlRange.Replace("<ContractGoodsCode>", dP.ContractGoodsCode, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success9 = (bool)xlRange.Replace("<ContractGoodsDesignation>", dP.ContractGoodsDesignation, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success10 = (bool)xlRange.Replace("<ContractGoodsUnit>", dP.ContractGoodsUnit, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success11 = (bool)xlRange.Replace("<DPQuantity>", dP.DPQuantity, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success111 = (bool)xlRange.Replace("<DPQuantity1>", dP.DPQuantity1, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success12 = (bool)xlRange.Replace("<DPType>", dP.DPType, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success13 = (bool)xlRange.Replace("<DPSpareQuantity>", Math.Round(dP.DPQuantity * 0.02), XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success14 = (bool)xlRange.Replace("<DPSpareQuantity1>", Math.Round(dP.DPQuantity1 * 0.02), XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success15 = (bool)xlRange.Replace("<DPRemarks>", dP.DPRemarks, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success16 = (bool)xlRange.Replace("<DPDate>", dP.DPDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success17 = (bool)xlRange.Replace("<DPRemarks1>", dP.DPRemarks + @" Hàng dự phòng 2%", XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);

                string folder = string.Format(@"D:\OPMTest\{0}\{1}\DP{2}", dP.ContractId.Trim().Replace('/', '-'), dP.POName.Replace('/', '-'), dP.DPId).Replace('/', '-');
                Directory.CreateDirectory(folder);
                xlWorkbook.SaveAs(file_name, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", file_name.ToString()));
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                return file_name.ToString();
            }
            catch (Exception)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                return "Lỗi, không tạo được file Excel!";
            }
        }

        //Mẫu 27: Biên bản bàn giao hàng hoá PL.
        public static string CreateWordDocument_27_PLReportForDelivery(string PLId, object filename)
        {
            PLObj pl = new PLObj(PLId);

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\DP{2}\Mẫu 27. Biên bản bàn giao HH kho ANSV_{3}.xlsx", pl.ContractId.Trim().Replace('/', '-'), pl.POName.Replace('/', '-'), pl.DPId.Replace('/', '-'), pl.VNPTId);

            object m = Type.Missing;
            ExcelOffice.Range xlRange = null;
            ExcelOffice.Workbook xlWorkbook = null;
            ExcelOffice.Application xlApp = null;
            ExcelOffice._Worksheet xlWorksheet = null;

            try
            {

                xlApp = new ExcelOffice.Application();
                xlWorkbook = xlApp.Workbooks.Open(filename.ToString(), m, false, m, m, m, m, m, m, m, m, m, m, m, m);
                xlWorksheet = (ExcelOffice._Worksheet)xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;
                //Rellace theo từng cell
                bool success0 = (bool)xlRange.Replace("<PLReportForDeliveryNumber>", pl.PLReportForDeliveryNumber, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success1 = (bool)xlRange.Replace("<SiteName>", pl.SiteName, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success2 = (bool)xlRange.Replace("<ContractId>", pl.ContractId, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success3 = (bool)xlRange.Replace("<ContractGoodsDesignation>", pl.ContractGoodsDesignation, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success5 = (bool)xlRange.Replace("<ContractGoodsCode>", pl.ContractGoodsCode, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success7 = (bool)xlRange.Replace("<PLQuantity>", pl.PLQuantity, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success10 = (bool)xlRange.Replace("<ContractGoodsUnit>", pl.ContractGoodsUnit, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success111 = (bool)xlRange.Replace("<PLQuantity1>", Math.Round(pl.PLQuantity * 0.02), XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success12 = (bool)xlRange.Replace("<Số kiện>", Math.Ceiling(pl.PLQuantity * 0.05) + Math.Ceiling(pl.PLQuantity * 0.001), XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);

                string folder = string.Format(@"D:\OPMTest\{0}\{1}\DP{2}", pl.ContractId.Trim().Replace('/', '-'), pl.POName.Replace('/', '-'), pl.DPId).Replace('/', '-');
                Directory.CreateDirectory(folder);
                xlWorkbook.SaveAs(file_name, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", file_name.ToString()));
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                return file_name.ToString();
            }
            catch (Exception)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                return "Lỗi, không tạo được file Excel!";
            }
        }
    }
}
