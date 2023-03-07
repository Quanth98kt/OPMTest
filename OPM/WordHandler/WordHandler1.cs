using OPM.DBHandler;
using OPM.OPMEnginee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace OPM.OPMWordHandler
{
    class WordHandler1
    {

        private static void FindAndReplace(Microsoft.Office.Interop.Word.Application wordApp, object findText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref findText,
                        ref matchCase, ref matchWholeWord,
                        ref matchWildCards, ref matchSoundLike,
                        ref nmatchAllForms, ref forward,
                        ref wrap, ref format, ref replaceWithText,
                        ref replace, ref matchKashida,
                        ref matchDiactitics, ref matchAlefHamza,
                        ref matchControl);
        }



        // Mẫu 39: Công văn xác nhận điều chỉnh đơn hàng.
        public static void CreateWordDocument_39_POAdjustmentConfirmation(string poid, object filename)
        {
            POObj po = new POObj(poid);
            /*object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            object path = @"D:\OPMTest\Template\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng.docx";*/

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                WordHandler1.FindAndReplace(wordApp, "<Ngày tháng năm 1>", string.Format("ngày {0} tháng {1} năm {2}", po.POAdjustmentConfirmationDate.Day, po.POAdjustmentConfirmationDate.Month, po.POAdjustmentConfirmationDate.Year));
                WordHandler1.FindAndReplace(wordApp, "<POAdjustmentConfirmationNumber>", po.POAdjustmentConfirmationNumber);
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<SiteName>", po.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<ContractName>", po.ContractName);
                WordHandler1.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                WordHandler1.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<POId>", po.POId);
                WordHandler1.FindAndReplace(wordApp, "<POName>", po.POName);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsDesignation>", po.ContractGoodsDesignation);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsUnit>", po.ContractGoodsUnit);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsQuantity>", po.ContractGoodsQuantity);
                WordHandler1.FindAndReplace(wordApp, "<POGoodQuantityAfterAdjustment>", po.POGoodQuantityAfterAdjustment);
                WordHandler1.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate);

            }
            else
            {
                MessageBox.Show("Error File!");
            }

            /*myWordDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
            MessageBox.Show("File Created!");*/


            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }

        // Mẫu 37: Biên bản xác nhận cài đặt License vào hệ thống.
        public static void CreateWordDocument_37_POBBXNCDLicense(string poid, object filename)
        {
            POObj po = new POObj(poid);
            /*object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            object path = @"D:\OPMTest\Template\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng.docx";*/
            ContractObj contract = new ContractObj(po.ContractId);
            SiteObj site = new SiteObj(contract.SiteId);

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 37. Biên bản xác nhận cài đặt License vào hệ thống {2}.docx", contract.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                WordHandler1.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", po.POInstallLicenseDate.Day, po.POInstallLicenseDate.Month, po.POInstallLicenseDate.Year));
                WordHandler1.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                WordHandler1.FindAndReplace(wordApp, "<ContractName>", po.ContractName);
                WordHandler1.FindAndReplace(wordApp, "<SiteName>", po.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<POName>", po.POName);
                WordHandler1.FindAndReplace(wordApp, "<POId>", po.POId);
                WordHandler1.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<POConfirmCreatedDate>", po.POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<POConfirmId>", po.POConfirmId);
                WordHandler1.FindAndReplace(wordApp, "<POGoodsQuantity>", po.POGoodsQuantity);
                WordHandler1.FindAndReplace(wordApp, "<POGoodsQuantity1>", Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));
                WordHandler1.FindAndReplace(wordApp, "<POQualityCertificationDate>", po.POQualityCertificationDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<POInstallLicenseDate>", po.POInstallLicenseDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<po.Total>", po.POGoodsQuantity + Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));

            }
            else
            {
                MessageBox.Show("Error Created File!");
            }

            /*myWordDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
            MessageBox.Show("File Created!");*/


            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}\{1}", contract.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();


        }


        //Mẫu 36: Biên bản nghiệm thu License.
        public static void CreateWordDocument_36_POBBNTLicense(string poid, object filename)
        {
            POObj po = new POObj(poid);
            /*object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            object path = @"D:\OPMTest\Template\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng.docx";*/

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 36. Biên bản nghiệm thu License {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                WordHandler1.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                WordHandler1.FindAndReplace(wordApp, "<ContractName>", po.ContractName);
                WordHandler1.FindAndReplace(wordApp, "<SiteName>", po.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<POName>", po.POName);
                WordHandler1.FindAndReplace(wordApp, "<POId>", po.POId);
                WordHandler1.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<POConfirmCreatedDate>", po.POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<POConfirmId>", po.POConfirmId);
                WordHandler1.FindAndReplace(wordApp, "<POGoodsQuantity>", po.POGoodsQuantity);
                WordHandler1.FindAndReplace(wordApp, "<POGoodsQuantity1>", Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));
                WordHandler1.FindAndReplace(wordApp, "<POQualityCertificationDate>", po.POQualityCertificationDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<POInstallLicenseDate>", po.POInstallLicenseDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<po.Total>", po.POGoodsQuantity + Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));
                WordHandler1.FindAndReplace(wordApp, "<SitePhonenumber>", po.SitePhonenumber);
                WordHandler1.FindAndReplace(wordApp, "<SiteRepresentative1>", po.SiteRepresentative1);
                WordHandler1.FindAndReplace(wordApp, "<SiteFaxNumber>", po.SiteFaxNumber);
                WordHandler1.FindAndReplace(wordApp, "<SitePosition1>", po.SitePosition1);
                WordHandler1.FindAndReplace(wordApp, "<SiteAddress>", po.SiteAddress);

            }
            else
            {
                MessageBox.Show("Error File!");
            }

            /*myWordDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
            MessageBox.Show("File Created!");*/


            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }


        // Mẫu 33: Văn bản đề nghị mở BLBH PO.
        public static void CreateWordDocument_33_POOfferToGuaranteeWarranty(string poid, object filename)
        {
            POObj po = new POObj(poid);
            /*object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            object path = @"D:\OPMTest\Template\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng.docx";*/

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 33. Văn bản đề nghị mở BLBH PO {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<ContractName>", po.ContractName);
                WordHandler1.FindAndReplace(wordApp, "<SiteName>", po.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<POName>", po.POName);
                WordHandler1.FindAndReplace(wordApp, "<POOfferToGuaranteePOWarrantyDate>", po.POOfferToGuaranteePOWarrantyDate);
                WordHandler1.FindAndReplace(wordApp, "<POReportOfAcceptanceAndHandlingOfGoodsDate>", po.POReportOfAcceptanceAndHandlingOfGoodsDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));


            }
            else
            {
                MessageBox.Show("Error File!");
            }

            /*myWordDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
            MessageBox.Show("File Created!");*/


            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }

        // Mẫu 30: Biên bản thanh lý hợp đồng.
        public static void CreateWordDocument_30_ContractLiquidationRecords(string contractId, object filename)
        {
            ContractObj contract = new ContractObj(contractId);

            object file_name = string.Format(@"D:\OPMTest\{0}\Mẫu 30. Biên bản thanh lý hợp đồng {0}.docx", contract.ContractId.Trim().Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", contract.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<ContractCreatedDate>", contract.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", contract.ContractReportOfConpletedVolumeDate.Day, contract.ContractReportOfConpletedVolumeDate.Month, contract.ContractReportOfConpletedVolumeDate.Year));
                WordHandler1.FindAndReplace(wordApp, "<ContractShoppingPlan>", contract.ContractShoppingPlan);
                //OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                WordHandler1.FindAndReplace(wordApp, "<SiteName>", contract.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<SiteAddress>", contract.SiteAddress);
                WordHandler1.FindAndReplace(wordApp, "<SitePhonenumber>", contract.SitePhonenumber);
                WordHandler1.FindAndReplace(wordApp, "<SiteFaxNumber>", contract.SiteFaxNumber);
                WordHandler1.FindAndReplace(wordApp, "<SiteRepresentative1>", contract.SiteRepresentative1);
                WordHandler1.FindAndReplace(wordApp, "<SitePosition1>", contract.SitePosition1);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsCode>", contract.ContractGoodsCode);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsDesignation>", contract.ContractGoodsDesignation);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsManufacture>", contract.ContractGoodsManufacture);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsOrigin>", contract.ContractGoodsOrigin);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsUnit>", contract.ContractGoodsUnit);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsNote>", contract.ContractGoodsNote);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsQuantity>", contract.ContractGoodsQuantity);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsUnitPrice>", contract.ContractGoodsUnitPrice);
                WordHandler1.FindAndReplace(wordApp, "<ContractValue>", contract.ContractValue);
                WordHandler1.FindAndReplace(wordApp, "<ContractVAT>", Math.Round(contract.ContractValue * 0.1));
                WordHandler1.FindAndReplace(wordApp, "<ContractAfterVATValue>", Math.Round(contract.ContractValue * 1.1));
                WordHandler1.FindAndReplace(wordApp, "<Số tiền bằng chữ 1>", NumberToString(Math.Round(contract.ContractValue * 1.1)));
                WordHandler1.FindAndReplace(wordApp, "<SiteBankAccount>", contract.SiteBankAccount);
                WordHandler1.FindAndReplace(wordApp, "<SiteNameOfBank>", contract.SiteNameOfBank);
                WordHandler1.FindAndReplace(wordApp, "<ContractTotalAmountPaid>", contract.ContractTotalAmountPaid);
                WordHandler1.FindAndReplace(wordApp, "<Số tiền còn lại>", NumberToString(Math.Round(contract.ContractValue * 1.1)));
                WordHandler1.FindAndReplace(wordApp, "<SiteTaxCode>", contract.SiteTaxCode);

            }
            else
            {
                MessageBox.Show("Error File!");
            }

            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}", contract.ContractId.Trim().Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }

        // Mẫu 29: Biên bản xác nhận khối lượng hoàn thành.
        public static void CreateWordDocument_29_ContractReportOfConpletedVolume(string contractId, object filename)
        {
            ContractObj contract = new ContractObj(contractId);

            object file_name = string.Format(@"D:\OPMTest\{0}\Mẫu 29. Biên bản xác nhận khối lượng hoàn thành {0}.docx", contractId.Trim().Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", contract.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<ContractCreatedDate>", contract.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", contract.ContractReportOfConpletedVolumeDate.Day, contract.ContractReportOfConpletedVolumeDate.Month, contract.ContractReportOfConpletedVolumeDate.Year));
                WordHandler1.FindAndReplace(wordApp, "<ContractShoppingPlan>", contract.ContractShoppingPlan);
                //OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                WordHandler1.FindAndReplace(wordApp, "<SiteName>", contract.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<SiteAddress>", contract.SiteAddress);
                WordHandler1.FindAndReplace(wordApp, "<SitePhonenumber>", contract.SitePhonenumber);
                WordHandler1.FindAndReplace(wordApp, "<SiteFaxNumber>", contract.SiteFaxNumber);
                WordHandler1.FindAndReplace(wordApp, "<SiteRepresentative1>", contract.SiteRepresentative1);
                WordHandler1.FindAndReplace(wordApp, "<SitePosition1>", contract.SitePosition1);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsCode>", contract.ContractGoodsCode);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsDesignation>", contract.ContractGoodsDesignation);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsManufacture>", contract.ContractGoodsManufacture);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsOrigin>", contract.ContractGoodsOrigin);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsUnit>", contract.ContractGoodsUnit);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsNote>", contract.ContractGoodsNote);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsQuantity>", contract.ContractGoodsQuantity);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsUnitPrice>", contract.ContractGoodsUnitPrice);
                WordHandler1.FindAndReplace(wordApp, "<ContractValue>", contract.ContractValue);
                WordHandler1.FindAndReplace(wordApp, "<ContractVAT>", Math.Round(contract.ContractValue * 0.1));
                WordHandler1.FindAndReplace(wordApp, "<ContractAfterVATValue>", Math.Round(contract.ContractValue * 1.1));
                WordHandler1.FindAndReplace(wordApp, "<Số tiền bằng chữ>", NumberToString(Math.Round(contract.ContractValue * 1.1)));

            }
            else
            {
                MessageBox.Show("Error File!");
            }

            /*myWordDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
            MessageBox.Show("File Created!");*/


            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}", contract.ContractId.Trim().Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }

        // Mẫu 28: Biên bản nghiệm thu bàn giao hàng hóa.
        public static void CreateWordDocument_28_POReportOfAcceptanceAndHandlingOfGoods(string poid, object filename)
        {
            POObj po = new POObj(poid);
            /*object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            object path = @"D:\OPMTest\Template\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng.docx";*/

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 28. Biên bản nghiệm thu bàn giao hàng hóa {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                WordHandler1.FindAndReplace(wordApp, "<SiteName>", po.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<POName>", po.POName);
                WordHandler1.FindAndReplace(wordApp, "<SiteAddress>", po.SiteAddress);
                WordHandler1.FindAndReplace(wordApp, "<SitePhonenumber>", po.SitePhonenumber);
                WordHandler1.FindAndReplace(wordApp, "<SiteFaxNumber>", po.SiteFaxNumber);
                WordHandler1.FindAndReplace(wordApp, "<SiteRepresentative1>", po.SiteRepresentative1);
                WordHandler1.FindAndReplace(wordApp, "<SitePosition1>", po.SitePosition1);
                WordHandler1.FindAndReplace(wordApp, "<POId>", po.POId);
                WordHandler1.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<POGoodsQuantity>", po.POGoodsQuantity);
                WordHandler1.FindAndReplace(wordApp, "<POGoodsQuantity1>", Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));
                WordHandler1.FindAndReplace(wordApp, "<po.Total>", po.POGoodsQuantity + Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsCode>", po.ContractGoodsCode);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsDesignation>", po.ContractGoodsDesignation);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsManufacture>", po.ContractGoodsManufacture);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsOrigin>", po.ContractGoodsOrigin);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsUnit>", po.ContractGoodsUnit);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsNote>", po.ContractGoodsNote);
                WordHandler1.FindAndReplace(wordApp, "<POReportOfAcceptanceAndHandlingOfGoodsDate>", po.POReportOfAcceptanceAndHandlingOfGoodsDate);

            }
            else
            {
                MessageBox.Show("Error File!");
            }

            /*myWordDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
            MessageBox.Show("File Created!");*/


            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }


        // Mẫu 26: Biên bản xác nhận tiến độ_Đúng hạn.
        public static void CreateWordDocument_26_MinutesConfirmingDeliveryProgressPO(string poid, object filename)
        {
            POObj po = new POObj(poid);
            /*object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            object path = @"D:\OPMTest\Template\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng.docx";*/
            List<PODeliveryProgressObj> list = PODeliveryProgressObj.PODeliveryProgressGetListByPOId(poid);

            //object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 26. Biên bản xác nhận tiến độ_Đúng hạn {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), list[n].PODeliveryProgressVNPTName.Replace('/', '-'));


            for (int n = 0; n < list.Count; n++)
            {
                object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 26. Biên bản xác nhận tiến độ_Đúng hạn {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), list[n].PODeliveryProgressVNPTName.Replace('/', '-'));

                if (list[n].PODeliveryProgressRemainingQuantity == 0)
                {
                    if (list[n].PODeliveryProgressLastDeliveredDate <= list[n].PODeadline)
                    {

                        Word.Application wordApp = new Word.Application();
                        object missing = Missing.Value;
                        Word.Document myWordDoc = null;


                        if (File.Exists((string)filename))
                        {
                            object readOnly = false; //default
                            object isVisible = false;
                            wordApp.Visible = false;

                            myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing, ref missing);
                            myWordDoc.Activate();
                            WordHandler1.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                            WordHandler1.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                            WordHandler1.FindAndReplace(wordApp, "<SiteName>", po.SiteName);
                            WordHandler1.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                            WordHandler1.FindAndReplace(wordApp, "<POName>", po.POName);
                            WordHandler1.FindAndReplace(wordApp, "<POId>", po.POId);
                            WordHandler1.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                            WordHandler1.FindAndReplace(wordApp, "<POPerformDate>", po.POPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                            WordHandler1.FindAndReplace(wordApp, "<PODeadline>", po.PODeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                            SiteObj vnpt = new SiteObj(list[n].PODeliveryProgressVNPTId);
                            WordHandler1.FindAndReplace(wordApp, "<vnpt.SiteName>", vnpt.SiteName);
                            WordHandler1.FindAndReplace(wordApp, "<vnpt.SiteAddress>", vnpt.SiteAddress);
                            WordHandler1.FindAndReplace(wordApp, "<vnpt.SitePhonenumber>", vnpt.SitePhonenumber);
                            WordHandler1.FindAndReplace(wordApp, "<vnpt.SiteFaxNumber>", vnpt.SiteFaxNumber);
                            WordHandler1.FindAndReplace(wordApp, "<vnpt.SiteRepresentative1>", vnpt.SiteRepresentative1);
                            WordHandler1.FindAndReplace(wordApp, "<vnpt.SitePosition1>", vnpt.SitePosition1);
                            WordHandler1.FindAndReplace(wordApp, "<PODeliveryProgressLastDeliveredDate>", list[n].PODeliveryProgressLastDeliveredDate);

                        }
                        else
                        {
                            MessageBox.Show("Error File!");
                        }

                        /*myWordDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);

                        myWordDoc.Close();
                        wordApp.Quit();
                        MessageBox.Show("File Created!");*/


                        try
                        {
                            string folder = string.Format(@"D:\OPMTest\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                            Directory.CreateDirectory(folder);
                            myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                               ref missing, ref missing, ref missing,
                               ref missing, ref missing, ref missing,
                               ref missing, ref missing, ref missing,
                               ref missing, ref missing, ref missing);
                            MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
                        }
                        myWordDoc.Close();
                        wordApp.Quit();

                    }

                    else
                    {

                        Word.Application wordApp = new Word.Application();
                        object missing = Missing.Value;
                        Word.Document myWordDoc = null;


                        if (File.Exists((string)filename))
                        {
                            object readOnly = false; //default
                            object isVisible = false;
                            wordApp.Visible = false;

                            myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing, ref missing);
                            myWordDoc.Activate();
                            WordHandler1.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                            WordHandler1.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                            WordHandler1.FindAndReplace(wordApp, "<SiteName>", po.SiteName);
                            WordHandler1.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                            WordHandler1.FindAndReplace(wordApp, "<POName>", po.POName);
                            WordHandler1.FindAndReplace(wordApp, "<POId>", po.POId);
                            WordHandler1.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                            WordHandler1.FindAndReplace(wordApp, "<POPerformDate>", po.POPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                            WordHandler1.FindAndReplace(wordApp, "<PODeadline>", po.PODeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                            WordHandler1.FindAndReplace(wordApp, "<ContractGoodsDesignation>", po.ContractGoodsDesignation);
                            WordHandler1.FindAndReplace(wordApp, "<PODeliveryProgressDeliveryQuantity>", list[n].PODeliveryProgressDeliveryQuantity);
                            WordHandler1.FindAndReplace(wordApp, "<ContractGoodsNote>", po.ContractGoodsNote);
                            SiteObj vnpt = new SiteObj(list[n].PODeliveryProgressVNPTId);
                            WordHandler1.FindAndReplace(wordApp, "<vnpt.SiteName>", vnpt.SiteName);
                            WordHandler1.FindAndReplace(wordApp, "<vnpt.SiteAddress>", vnpt.SiteAddress);
                            WordHandler1.FindAndReplace(wordApp, "<vnpt.SitePhonenumber>", vnpt.SitePhonenumber);
                            WordHandler1.FindAndReplace(wordApp, "<vnpt.SiteFaxNumber>", vnpt.SiteFaxNumber);
                            WordHandler1.FindAndReplace(wordApp, "<vnpt.SiteRepresentative1>", vnpt.SiteRepresentative1);
                            WordHandler1.FindAndReplace(wordApp, "<vnpt.SitePosition1>", vnpt.SitePosition1);
                            WordHandler1.FindAndReplace(wordApp, "<PODeliveryProgressLastDeliveredDate>", list[n].PODeliveryProgressLastDeliveredDate);


                            System.Data.DataTable dataTable = PLObj.GetDataTableByPOIdAndVNPTId(poid, list[n].PODeliveryProgressVNPTId);
                            int rowCount = dataTable.Rows.Count;
                            int columnCount = dataTable.Columns.Count;
                            int i;
                            Word.Table table = myWordDoc.Tables[5];
                            for (i = 0; i < rowCount; i++)
                            {
                                table.Rows.Add();
                                table.Cell(i + 2, 1).Range.Text = (i + 1).ToString();
                                table.Cell(i + 2, 2).Range.Text = po.ContractGoodsDesignation;
                                table.Cell(i + 2, 3).Range.Text = dataTable.Rows[i].ItemArray[3].ToString(); ;
                                DateTime temp = (DateTime)dataTable.Rows[i].ItemArray[4];
                                table.Cell(i + 2, 4).Range.Text = temp.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ"));
                                if (temp <= po.PODeadline)
                                {
                                    table.Cell(i + 2, 5).Range.Text = "0";
                                }
                                else
                                {
                                    TimeSpan t = temp - po.PODeadline;
                                    table.Cell(i + 2, 5).Range.Text = t.TotalDays.ToString();
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("Error File!");
                        }

                        /*myWordDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);

                        myWordDoc.Close();
                        wordApp.Quit();
                        MessageBox.Show("File Created!");*/


                        try
                        {
                            string folder = string.Format(@"D:\OPMTest\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                            Directory.CreateDirectory(folder);
                            myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                               ref missing, ref missing, ref missing,
                               ref missing, ref missing, ref missing,
                               ref missing, ref missing, ref missing,
                               ref missing, ref missing, ref missing);
                            MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
                        }
                        myWordDoc.Close();
                        wordApp.Quit();

                    }

                }
                else
                {
                    MessageBox.Show(string.Format("Vẫn chưa giao hết số lượng của đơn hàng {0}, {1} yêu cầu giao {2}, đã giao {3} tính đến ngày {4}", po.POName, list[n].PODeliveryProgressVNPTName, list[n].PODeliveryProgressDeliveryQuantity, list[n].PODeliveryProgressDeliveredQuantity, list[n].PODeliveryProgressLastDeliveredDate));

                }
            }

        }

        //Tạo mẫu 25: Đề nghị phát hoá đơn cho các viễn thông tỉnh theo PO.
        public static void CreateWordDocument_25_InvoicingRequestPO(string poid, object filename)
        {
            POObj po = new POObj(poid);
            /*object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            object path = @"D:\OPMTest\Template\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng.docx";*/

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 25. Đề nghị phát hoá đơn cho các viễn thông tỉnh theo PO {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                //find and replace
                WordHandler1.FindAndReplace(wordApp, "<POInvoicingRequestDate>", po.POInvoicingRequestDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<POName>", po.POName);
                WordHandler1.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate);

                //Tạo bảng phụ lục yêu cầu phát hoá đơn
                DataTable dataTable = DeliveryPlanObj.InvoicingRequestDataTable(poid);
                int rowCount = dataTable.Rows.Count;
                int columnCount = dataTable.Columns.Count;
                int i;
                Word.Table table = myWordDoc.Tables[3];
                for (i = 0; i < rowCount; i++)
                {
                    table.Rows.Add();
                    table.Cell(i + 2, 1).Range.Text = (i + 1).ToString();
                    table.Cell(i + 2, 2).Range.Text = dataTable.Rows[i].ItemArray[0].ToString();
                    string temp = dataTable.Rows[i].ItemArray[1].ToString();
                    double temp1 = double.Parse(temp);
                    table.Cell(i + 2, 3).Range.Text = temp;
                    table.Cell(i + 2, 4).Range.Text = (Math.Round(temp1 * 0.02, 0, MidpointRounding.AwayFromZero)).ToString();
                    table.Cell(i + 2, 5).Range.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", po.ContractGoodsUnitPrice);
                    table.Cell(i + 2, 6).Range.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", temp1 * po.ContractGoodsUnitPrice);
                    table.Cell(i + 2, 7).Range.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", temp1 * 0.02 * po.ContractGoodsUnitPrice);
                    DateTime temp2 = (DateTime)dataTable.Rows[i].ItemArray[2];
                    table.Cell(i + 2, 8).Range.Text = temp2.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ"));
                }

            }
            else
            {
                MessageBox.Show("Error File!");
            }

            /*myWordDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
            MessageBox.Show("File Created!");*/


            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }

        //Tạo mẫu 24: Giấy chứng nhận chất lượng từ nhà máy tổng hợp PO.
        public static void CreateWordDocument_24_POCNCLNMTongHop(string poid, object filename)
        {
            POObj po = new POObj(poid);
            /*object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            object path = @"D:\OPMTest\Template\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng.docx";*/

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 24. Giấy chứng nhận chất lượng từ nhà máy tổng hợp PO {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                WordHandler1.FindAndReplace(wordApp, "<Ngày tháng năm 1>", string.Format("ngày {0} tháng {1} năm {2}", po.POAdjustmentConfirmationDate.Day, po.POAdjustmentConfirmationDate.Month, po.POAdjustmentConfirmationDate.Year));
                WordHandler1.FindAndReplace(wordApp, "<POAdjustmentConfirmationNumber>", po.POAdjustmentConfirmationNumber);
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<SiteName>", po.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<ContractName>", po.ContractName);
                WordHandler1.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                WordHandler1.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<POId>", po.POId);
                WordHandler1.FindAndReplace(wordApp, "<POName>", po.POName);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsDesignation>", po.ContractGoodsDesignation);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsUnit>", po.ContractGoodsUnit);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsQuantity>", po.ContractGoodsQuantity);
                WordHandler1.FindAndReplace(wordApp, "<POGoodQuantityAfterAdjustment>", po.POGoodQuantityAfterAdjustment);

            }
            else
            {
                MessageBox.Show("Error File!");
            }

            /*myWordDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
            MessageBox.Show("File Created!");*/


            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }

        //Tạo mẫu 23: Giấy chứng nhận chất lượng tổng hợp PO.
        public static void CreateWordDocument_23_POCNCL_TongHop(string poid, object filename)
        {
            POObj po = new POObj(poid);
            /*object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            object path = @"D:\OPMTest\Template\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng.docx";*/

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 23. Giấy chứng nhận chất lượng tổng hợp PO {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<POName>", po.POName);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsDesignation>", po.ContractGoodsDesignation);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsCode>", po.ContractGoodsCode);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsUnit>", po.ContractGoodsUnit);
                WordHandler1.FindAndReplace(wordApp, "<POGoodsQuantity>", po.POGoodsQuantity);
                WordHandler1.FindAndReplace(wordApp, "<POGoodsQuantity1>", Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));
                WordHandler1.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", po.POFactoryQualityCertificationDate.Day, po.POFactoryQualityCertificationDate.Month, po.POFactoryQualityCertificationDate.Year));
                WordHandler1.FindAndReplace(wordApp, "<po.Total>", po.POGoodsQuantity + Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));


            }
            else
            {
                MessageBox.Show("Error File!");
            }

            /*myWordDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
            MessageBox.Show("File Created!");*/


            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }

        // Mẫu 22: Mẫu phiếu bảo hành
        public static void CreateWordDocument_22_PLWarranty(string PLId, object filename)
        {
            PLObj pl = new PLObj(PLId);
            SiteObj vnpt = new SiteObj(pl.VNPTId);
            /*object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            object path = @"D:\OPMTest\Template\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng.docx";*/

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\DP{2}\Mẫu 22. Mẫu phiếu bảo hành_{3}.docx", pl.ContractId.Trim().Replace('/', '-'), pl.POName.Replace('/', '-'), pl.DPId.Replace('/', '-'), pl.VNPTId.Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", pl.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<POName>", pl.POName);
                WordHandler1.FindAndReplace(wordApp, "<vnpt.SiteName>", vnpt.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsDesignation>", pl.ContractGoodsDesignation);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsUnit>", pl.ContractGoodsUnit);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsCode>", pl.ContractGoodsCode);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsManufacture>", pl.ContractGoodsManufacture);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsOrigin>", pl.ContractGoodsOrigin);
                WordHandler1.FindAndReplace(wordApp, "<PLQuantity>", pl.PLQuantity);

            }
            else
            {
                MessageBox.Show("Error File!");
            }

            /*myWordDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
            MessageBox.Show("File Created!");*/


            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}\{1}\DP{2}", pl.ContractId.Trim().Replace('/', '-'), pl.POName.Replace('/', '-'), pl.DPId.Replace('/', '-'), pl.VNPTId.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }

        // Tạo mẫu 20: Giấy chứng nhận chất lượng.
        public static void CreateWordDocument_20_PLQualityInspectionCertificate(string PLId, object filename)
        {
            PLObj pl = new PLObj(PLId);
            SiteObj vnpt = new SiteObj(pl.VNPTId);
            /*object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            object path = @"D:\OPMTest\Template\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng.docx";*/

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\DP{2}\Mẫu 20. Giấy chứng nhận chất lượng gửi tỉnh_{3}.docx", pl.ContractId.Trim().Replace('/', '-'), pl.POName.Replace('/', '-'), pl.DPId.Replace('/', '-'), pl.VNPTId.Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                //find and replace
                WordHandler1.FindAndReplace(wordApp, "<DPVNPTTechANSVContractNumber>", pl.DPVNPTTechANSVContractNumber);
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", pl.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<SiteName>", pl.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<POName>", pl.POName);
                WordHandler1.FindAndReplace(wordApp, "<vnpt.SiteName>", vnpt.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsDesignation>", pl.ContractGoodsDesignation);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsUnit>", pl.ContractGoodsUnit);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsCode>", pl.ContractGoodsCode);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsManufacture>", pl.ContractGoodsManufacture);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsOrigin>", pl.ContractGoodsOrigin);
                WordHandler1.FindAndReplace(wordApp, "<PLQuantity>", pl.PLQuantity);
                WordHandler1.FindAndReplace(wordApp, "<PLQuantity1>", Math.Round(pl.PLQuantity * 0.02));
                WordHandler1.FindAndReplace(wordApp, "<PLQuantityTotal>", pl.PLQuantity + Math.Round(pl.PLQuantity * 0.02));
                WordHandler1.FindAndReplace(wordApp, "<PLQualityInspectionCertificateDate>", pl.PLQualityInspectionCertificateDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));

            }
            else
            {
                MessageBox.Show("Error File!");
            }



            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}\{1}\DP{2}", pl.ContractId.Trim().Replace('/', '-'), pl.POName.Replace('/', '-'), pl.DPId.Replace('/', '-'), pl.VNPTId.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }

        //Tạo mẫu 19: Giấy chứng nhận chất lượng từ nhà máy
        public static void CreateWordDocument_19_PLQualityInspectionCertificateInFactory(string PLId, object filename)
        {
            PLObj pl = new PLObj(PLId);
            SiteObj vnpt = new SiteObj(pl.VNPTId);

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\DP{2}\Mẫu 19. Giấy chứng nhận chất lượng từ nhà máy gửi tỉnh_{3}.docx", pl.ContractId.Trim().Replace('/', '-'), pl.POName.Replace('/', '-'), pl.DPId.Replace('/', '-'), pl.VNPTId.Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                //find and replace
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", pl.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<SiteName>", pl.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<vnpt.SiteName>", vnpt.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsDesignation1>", pl.ContractGoodsDesignation1);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsDesignation>", pl.ContractGoodsDesignation);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsUnit>", pl.ContractGoodsUnit);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsCode>", pl.ContractGoodsCode);
                WordHandler1.FindAndReplace(wordApp, "<PLQuantity>", pl.PLQuantity);
                WordHandler1.FindAndReplace(wordApp, "<PLQuantity1>", Math.Round(pl.PLQuantity * 0.02));
                WordHandler1.FindAndReplace(wordApp, "<DPId>", pl.DPId);
                WordHandler1.FindAndReplace(wordApp, "<DeviceCaseNumberRange>", DeviceObj.DeviceCaseNumberRange(PLId));
                WordHandler1.FindAndReplace(wordApp, "<PLQualityInspectionCertificateInFactoryDate>", pl.PLQualityInspectionCertificateInFactoryDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));

            }
            else
            {
                MessageBox.Show("Error File!");
            }



            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}\{1}\DP{2}", pl.ContractId.Trim().Replace('/', '-'), pl.POName.Replace('/', '-'), pl.DPId.Replace('/', '-'), pl.VNPTId.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }

        //Tạo mẫu 18: Biên bản giao nhận hàng hoá
        public static void CreateWordDocument_18_PLGoodsDeliveryRecord(string PLId, object filename)
        {
            PLObj pl = new PLObj(PLId);
            SiteObj vnpt = new SiteObj(pl.VNPTId);

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\DP{2}\Mẫu 18. Biên bản giao nhận hàng hóa_{3}.docx", pl.ContractId.Trim().Replace('/', '-'), pl.POName.Replace('/', '-'), pl.DPId.Replace('/', '-'), pl.VNPTId.Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                //find and replace
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", pl.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<ContractCreatedDate>", pl.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<SiteName>", pl.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<ContractShoppingPlan>", pl.ContractShoppingPlan);
                WordHandler1.FindAndReplace(wordApp, "<POName>", pl.POName);
                WordHandler1.FindAndReplace(wordApp, "<POId>", pl.POId);
                WordHandler1.FindAndReplace(wordApp, "<POCreatedDate>", pl.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<PLDate>", pl.PLDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<vnpt.SiteName>", vnpt.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<vnpt.SiteAddress>", vnpt.SiteAddress);
                WordHandler1.FindAndReplace(wordApp, "<vnpt.SitePhonenumber>", vnpt.SitePhonenumber);
                WordHandler1.FindAndReplace(wordApp, "<vnpt.SiteFaxNumber>", vnpt.SiteFaxNumber);
                WordHandler1.FindAndReplace(wordApp, "<vnpt.SiteRepresentative1>", vnpt.SiteRepresentative1);
                WordHandler1.FindAndReplace(wordApp, "<vnpt.SiteProxy1>", vnpt.SiteProxy1);
                WordHandler1.FindAndReplace(wordApp, "<vnpt.SiteRepresentative2>", vnpt.SiteRepresentative1);
                WordHandler1.FindAndReplace(wordApp, "<vnpt.SiteProxy2>", vnpt.SiteProxy1);
                WordHandler1.FindAndReplace(wordApp, "<vnpt.SiteRepresentative3>", vnpt.SiteRepresentative1);
                WordHandler1.FindAndReplace(wordApp, "<vnpt.SiteProxy3>", vnpt.SiteProxy1);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsDesignation>", pl.ContractGoodsDesignation);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsUnit>", pl.ContractGoodsUnit);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsCode>", pl.ContractGoodsCode);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsOrigin>", pl.ContractGoodsOrigin);
                WordHandler1.FindAndReplace(wordApp, "<PLQuantity>", pl.PLQuantity);
                WordHandler1.FindAndReplace(wordApp, "<PLQuantity1>", Math.Round(pl.PLQuantity * 0.02));
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsUnitPrice>", pl.ContractGoodsUnitPrice);
                WordHandler1.FindAndReplace(wordApp, "<TotalPreVAT>", pl.PLQuantity * pl.ContractGoodsUnitPrice);
                WordHandler1.FindAndReplace(wordApp, "<VAT>", 0.1 * pl.PLQuantity * pl.ContractGoodsUnitPrice);
                WordHandler1.FindAndReplace(wordApp, "<TotalAfterVAT>", pl.PLQuantity * pl.ContractGoodsUnitPrice * 1.1);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsNote>", pl.ContractGoodsNote);

            }
            else
            {
                MessageBox.Show("Error File!");
            }



            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}\{1}\DP{2}", pl.ContractId.Trim().Replace('/', '-'), pl.POName.Replace('/', '-'), pl.DPId.Replace('/', '-'), pl.VNPTId.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }

        // Tạo mẫu 11: Biên bản nghiệm thu kỹ thuật.
        public static void CreateWordDocument_11_NTKTBBNTKT(string ntktId, object filename)
        {
            NTKTObj ntkt = new NTKTObj(ntktId);

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\NTKT{2}\Mẫu 11. Biên bản nghiệm thu kỹ thuật_{3}.docx", ntkt.ContractId.Trim().Replace('/', '-'), ntkt.POName.Replace('/', '-'), ntkt.NTKTPhase, ntkt.NTKTId.Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                WordHandler1.FindAndReplace(wordApp, "<POName>", ntkt.POName);
                WordHandler1.FindAndReplace(wordApp, "<POId>", ntkt.POId);
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", ntkt.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<ContractName>", ntkt.ContractName);
                WordHandler1.FindAndReplace(wordApp, "<ContractShoppingPlan>", ntkt.ContractShoppingPlan);
                WordHandler1.FindAndReplace(wordApp, "<ContractCreatedDate>", ntkt.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<SiteName>", ntkt.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<POCreatedDate>", ntkt.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<POConfirmId>", ntkt.POConfirmId);
                WordHandler1.FindAndReplace(wordApp, "<POConfirmCreatedDate>", ntkt.POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<NTKTId>", ntkt.NTKTId);
                WordHandler1.FindAndReplace(wordApp, "<NTKTCreatedDate>", ntkt.NTKTCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<TechnicalAcceptanceReportDate>", ntkt.TechnicalAcceptanceReportDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<NTKTCreatedDate>", ntkt.NTKTCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<SiteAddress>", ntkt.SiteAddress);
                WordHandler1.FindAndReplace(wordApp, "<SitePhonenumber>", ntkt.SitePhonenumber);
                WordHandler1.FindAndReplace(wordApp, "<SiteFaxNumber>", ntkt.SiteFaxNumber);
                WordHandler1.FindAndReplace(wordApp, "<SiteRepresentative1>", ntkt.SiteRepresentative1);
                WordHandler1.FindAndReplace(wordApp, "<SitePosition1>", ntkt.SitePosition1);
                WordHandler1.FindAndReplace(wordApp, "<SiteRepresentative2>", ntkt.SiteRepresentative2);
                WordHandler1.FindAndReplace(wordApp, "<SitePosition2>", ntkt.SitePosition2);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsDesignation>", ntkt.ContractGoodsDesignation);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsCode>", ntkt.ContractGoodsCode);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsUnit>", ntkt.ContractGoodsUnit);
                WordHandler1.FindAndReplace(wordApp, "<NTKTQuantity>", ntkt.NTKTQuantity);
                WordHandler1.FindAndReplace(wordApp, "<NTKTQuantity1>", Math.Round(0.02 * ntkt.NTKTQuantity, 0, MidpointRounding.AwayFromZero));
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsManufacture>", ntkt.ContractGoodsManufacture);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsOrigin>", ntkt.ContractGoodsOrigin);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsNote>", ntkt.ContractGoodsNote);

            }
            else
            {
                MessageBox.Show("Error File!");
            }

            /*myWordDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
            MessageBox.Show("File Created!");*/


            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}\NTKT{2}", ntkt.ContractId.Trim().Replace('/', '-'), ntkt.POName.Replace('/', '-'), ntkt.NTKTPhase);
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }

        //Tạo mẫu 10: Chứng nhận bản quyền phần mềm.
        public static void CreateWordDocument_10_NTKTCNBQPM(string ntktId, object filename)
        {
            NTKTObj ntkt = new NTKTObj(ntktId);

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\NTKT{2}\Mẫu 10. Chứng nhận bản quyền phần mềm_{3}.docx", ntkt.ContractId.Trim().Replace('/', '-'), ntkt.POName.Replace('/', '-'), ntkt.NTKTPhase, ntkt.NTKTId.Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", ntkt.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<POName>", ntkt.POName);
                WordHandler1.FindAndReplace(wordApp, "<ContractShoppingPlan>", ntkt.ContractShoppingPlan);
                WordHandler1.FindAndReplace(wordApp, "<NTKTQuantity>", ntkt.NTKTQuantity);
                WordHandler1.FindAndReplace(wordApp, "<NTKTQuantity1>", Math.Round(0.02 * ntkt.NTKTQuantity, 0, MidpointRounding.AwayFromZero));
                WordHandler1.FindAndReplace(wordApp, "<NTKTCreatedDate>", ntkt.NTKTCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<NTKTQuantityTotal>", Math.Round(1.02 * ntkt.NTKTQuantity, 0, MidpointRounding.AwayFromZero));

            }
            else
            {
                MessageBox.Show("Error File!");
            }

            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}\NTKT{2}", ntkt.ContractId.Trim().Replace('/', '-'), ntkt.POName.Replace('/', '-'), ntkt.NTKTPhase);
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }

        //Mẫu 9. Biên bản kiểm tra kỹ thuật.
        public static void CreateWordDocument_09_NTKTBBKTKT(string ntktId, object filename)
        {
            NTKTObj ntkt = new NTKTObj(ntktId);

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\NTKT{2}\Mẫu 9. Biên bản kiểm tra kỹ thuật_{3}.docx", ntkt.ContractId.Trim().Replace('/', '-'), ntkt.POName.Replace('/', '-'), ntkt.NTKTPhase, ntkt.NTKTId.Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                WordHandler1.FindAndReplace(wordApp, "<POName>", ntkt.POName);
                WordHandler1.FindAndReplace(wordApp, "<POId>", ntkt.POId);
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", ntkt.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<ContractName>", ntkt.ContractName);
                WordHandler1.FindAndReplace(wordApp, "<ContractShoppingPlan>", ntkt.ContractShoppingPlan);
                WordHandler1.FindAndReplace(wordApp, "<ContractCreatedDate>", ntkt.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<SiteName>", ntkt.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<POCreatedDate>", ntkt.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<POConfirmId>", ntkt.POConfirmId);
                WordHandler1.FindAndReplace(wordApp, "<POConfirmCreatedDate>", ntkt.POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<NTKTId>", ntkt.NTKTId);
                WordHandler1.FindAndReplace(wordApp, "<NTKTCreatedDate>", ntkt.NTKTCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<TechnicalAcceptanceReportDate>", ntkt.TechnicalAcceptanceReportDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<SiteAddress>", ntkt.SiteAddress);
                WordHandler1.FindAndReplace(wordApp, "<SitePhonenumber>", ntkt.SitePhonenumber);
                WordHandler1.FindAndReplace(wordApp, "<SiteFaxNumber>", ntkt.SiteFaxNumber);
                WordHandler1.FindAndReplace(wordApp, "<SiteRepresentative1>", ntkt.SiteRepresentative1);
                WordHandler1.FindAndReplace(wordApp, "<SitePosition1>", ntkt.SitePosition1);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsDesignation>", ntkt.ContractGoodsDesignation);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsCode>", ntkt.ContractGoodsCode);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsUnit>", ntkt.ContractGoodsUnit);
                WordHandler1.FindAndReplace(wordApp, "<NTKTQuantity>", ntkt.NTKTQuantity);
                WordHandler1.FindAndReplace(wordApp, "<NTKTQuantity1>", Math.Round(0.02 * ntkt.NTKTQuantity, 0, MidpointRounding.AwayFromZero));
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsManufacture>", ntkt.ContractGoodsManufacture);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsOrigin>", ntkt.ContractGoodsOrigin);
                WordHandler1.FindAndReplace(wordApp, "<ContractGoodsNote>", ntkt.ContractGoodsNote);
                WordHandler1.FindAndReplace(wordApp, "<ContractConformityCertificateNumber>", ntkt.ContractConformityCertificateNumber);
                WordHandler1.FindAndReplace(wordApp, "<ntkt.KT2%>", Math.Round(ntkt.NTKTQuantity * 1.02 * 0.02, 0, MidpointRounding.AwayFromZero));
                WordHandler1.FindAndReplace(wordApp, "<ntkt.KT0.2%>", Math.Round(ntkt.NTKTQuantity * 1.02 * 0.002, 0, MidpointRounding.AwayFromZero));

            }
            else
            {
                MessageBox.Show("Error File!");
            }

            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}\NTKT{2}", ntkt.ContractId.Trim().Replace('/', '-'), ntkt.POName.Replace('/', '-'), ntkt.NTKTPhase);
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }

        //Mẫu 8: Đề nghị nghiệm thu kỹ thuật.
        public static void CreateWordDocument_08_NTKTRequest(string ntktId, object filename)
        {
            NTKTObj ntkt = new NTKTObj(ntktId);

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\NTKT{2}\Mẫu 8. Đề nghị nghiệm thu kỹ thuật_{3}.docx", ntkt.ContractId.Trim().Replace('/', '-'), ntkt.POName.Replace('/', '-'), ntkt.NTKTPhase, ntkt.NTKTId.Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                WordHandler1.FindAndReplace(wordApp, "<NTKTId>", ntkt.NTKTId);
                WordHandler1.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", ntkt.NTKTCreatedDate.Day, ntkt.NTKTCreatedDate.Month, ntkt.NTKTCreatedDate.Year));
                WordHandler1.FindAndReplace(wordApp, "<NTKTPhase>", ntkt.NTKTPhase);
                WordHandler1.FindAndReplace(wordApp, "<POName>", ntkt.POName);
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", ntkt.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<SiteName>", ntkt.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<ContractShoppingPlan>", ntkt.ContractShoppingPlan);
                WordHandler1.FindAndReplace(wordApp, "<ContractCreatedDate>", ntkt.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<POId>", ntkt.POId);
                WordHandler1.FindAndReplace(wordApp, "<POCreatedDate>", ntkt.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<NTKTTestExpectedDate>", ntkt.NTKTTestExpectedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));

            }
            else
            {
                MessageBox.Show("Error File!");
            }

            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}\NTKT{2}", ntkt.ContractId.Trim().Replace('/', '-'), ntkt.POName.Replace('/', '-'), ntkt.NTKTPhase);
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }

        //Tạo mẫu 6: Văn bản đề nghị tạm ứng đơn hàng
        public static void CreateWordDocument_6_POAdvanceRequest(string poid, object filename)
        {
            POObj po = new POObj(poid);
            /*object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            object path = @"D:\OPMTest\Template\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng.docx";*/

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 6. Văn bản đề nghị tạm ứng đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                WordHandler1.FindAndReplace(wordApp, "<POAdvanceRequestId>", po.POAdvanceRequestId.ToString());
                WordHandler1.FindAndReplace(wordApp, "<POAdvanceGuaranteePercentage>", po.POAdvanceGuaranteePercentage.ToString());
                WordHandler1.FindAndReplace(wordApp, "<POName>", po.POName);
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<ContractSiteId>", po.SiteId);
                WordHandler1.FindAndReplace(wordApp, "<ContractName>", po.ContractName);
                WordHandler1.FindAndReplace(wordApp, "<Ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", po.POAdvanceRequestCreatedDate.Day, po.POAdvanceRequestCreatedDate.Month, po.POAdvanceRequestCreatedDate.Year));
                WordHandler1.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                WordHandler1.FindAndReplace(wordApp, "<Ngày tháng năm1>", string.Format("ngày {0} tháng {1} năm {2}", po.ContractCreatedDate.Day, po.ContractCreatedDate.Month, po.ContractCreatedDate.Year));
                WordHandler1.FindAndReplace(wordApp, "<POTotalValue>", string.Format(new CultureInfo("vi-VN"), "{0:#,##}", (po.POTotalValue / 100) * po.POAdvanceGuaranteePercentage));
                WordHandler1.FindAndReplace(wordApp, "<POTotalValueString>", NumberToString((po.POTotalValue / 100) * po.POAdvanceGuaranteePercentage).ToString());


            }
            else
            {
                MessageBox.Show("Error File!");
            }

            /*myWordDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
            MessageBox.Show("File Created!");*/


            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }

        // Mẫu 5: Văn bản mở bảo lãnh tạm ứng đơn hàng.
        public static void CreateWordDocument_5_POAdvanceGuarantee(string poid, object filename)
        {
            POObj po = new POObj(poid);
            /*object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            object path = @"D:\OPMTest\Template\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng.docx";*/

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 5. Văn bản mở bảo lãnh tạm ứng đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                //find and replace
                WordHandler1.FindAndReplace(wordApp, "<POAdvanceGuaranteeCreatedDate>", po.POAdvanceGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<ContractSiteId>", po.SiteId);
                WordHandler1.FindAndReplace(wordApp, "<ContractName>", po.ContractName);
                WordHandler1.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<POName>", po.POName);
                WordHandler1.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<POTotalValue>", string.Format(new CultureInfo("vi-VN"), "{0:#,##}", po.POTotalValue * 1.1));
                WordHandler1.FindAndReplace(wordApp, "<POAdvanceGuaranteePercentage>", po.POAdvanceGuaranteePercentage.ToString());

            }
            else
            {
                MessageBox.Show("Error File!");
            }

            /*myWordDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
            MessageBox.Show("File Created!");*/


            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }

        // Mẫu 39: Công văn xác nhận điều chỉnh đơn hàng.
        public static void CreateWordDocument_4_POPerformanceGuarantee(string poid, object filename)
        {
            POObj po = new POObj(poid);
            /*object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            object path = @"D:\OPMTest\Template\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng.docx";*/

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                //find and replace
                WordHandler1.FindAndReplace(wordApp, "<POGuaranteeDate>", po.POGuaranteeDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<POName>", po.POName);
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<SiteName>", po.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<ContractName>", po.ContractName);
                WordHandler1.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<POTotalValue>", string.Format(new CultureInfo("vi-VN"), "{0:#,##}", po.POTotalValue * 1.1));
                WordHandler1.FindAndReplace(wordApp, "<POGuaranteeRatio>", po.POGuaranteeRatio.ToString());
                WordHandler1.FindAndReplace(wordApp, "<POGuaranteeValidityPeriod>", po.POGuaranteeValidityPeriod.ToString());

            }
            else
            {
                MessageBox.Show("Error File!");
            }

            /*myWordDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
            MessageBox.Show("File Created!");*/


            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }

        // Mẫu 3: Văn bản xác nhận hiệu lực đơn hàng.
        public static void CreateWordDocument_3_POConfirm(string poid, object filename)
        {
            POObj po = new POObj(poid);
            /*object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            object path = @"D:\OPMTest\Template\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng.docx";*/

            object file_name = string.Format(@"D:\OPMTest\{0}\{1}\Mẫu 3. Văn bản xác nhận hiệu lực đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                //find and replace
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                WordHandler1.FindAndReplace(wordApp, "<SiteName>", po.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<ContractName>", po.ContractName);
                WordHandler1.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                WordHandler1.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<POId>", po.POId);
                WordHandler1.FindAndReplace(wordApp, "<POName>", po.POName);
                WordHandler1.FindAndReplace(wordApp, "<Ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", po.POConfirmCreatedDate.Day, po.POConfirmCreatedDate.Month, po.POConfirmCreatedDate.Year));
                WordHandler1.FindAndReplace(wordApp, "<POConfirmId>", po.POConfirmId);
                WordHandler1.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<POPerformDate>", po.POPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //Tạo bảng phụ lục kế hoạch giao hàng dự kiến
                DataTable dataTable = DeliveryPlanObj.DeliveryPlanDataTable(poid);
                int rowCount = dataTable.Rows.Count;
                int columnCount = dataTable.Columns.Count;
                int i;
                Word.Table table = myWordDoc.Tables[3];
                for (i = 0; i < rowCount; i++)
                {
                    table.Rows.Add();
                    table.Cell(i + 2, 1).Range.Text = (i + 1).ToString();
                    table.Cell(i + 2, 2).Range.Text = dataTable.Rows[i].ItemArray[1].ToString();
                    table.Cell(i + 2, 3).Range.Text = dataTable.Rows[i].ItemArray[2].ToString();
                    DateTime temp = (DateTime)dataTable.Rows[i].ItemArray[3];
                    table.Cell(i + 2, 4).Range.Text = temp.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ"));
                }
                //OpmWordHandler.FindAndReplace(wordApp, "12:00:00 SA", "");
                //MessageBox.Show(i.ToString());
                table.Cell(i + 2, 2).Range.Text = "TỔNG CỘNG";
                table.Cell(i + 2, 3).Range.Text = po.POGoodsQuantity.ToString();
            }
            else
            {
                MessageBox.Show("Error File!");
            }

            /*myWordDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
            MessageBox.Show("File Created!");*/


            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }

        // Mẫu 1: Đề nghị mở bảo lãnh thực hiện hợp đồng.
        public static void CreateWordDocument_1_ContractGuarantee(string contractId, object filename)
        {
            ContractObj contract = new ContractObj(contractId);

            object file_name = string.Format(@"D:\OPMTest\{0}\Mẫu 1. Đề nghị mở bảo lãnh thực hiện hợp đồng {0}.docx", contractId.Trim().Replace('/', '-'));

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;


            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                WordHandler1.FindAndReplace(wordApp, "<ContractId>", contract.ContractId.Trim());
                WordHandler1.FindAndReplace(wordApp, "<ContractGuaranteeCreatedDate>", contract.ContractGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<ContractName>", contract.ContractName);
                WordHandler1.FindAndReplace(wordApp, "<ContractSignedDate>", contract.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                WordHandler1.FindAndReplace(wordApp, "<SiteName>", contract.SiteName);
                WordHandler1.FindAndReplace(wordApp, "<POGuaranteeRatio>", contract.POGuaranteeRatio);
                WordHandler1.FindAndReplace(wordApp, "<POGuaranteeValidityPeriod>", contract.POGuaranteeValidityPeriod);

            }
            else
            {
                MessageBox.Show("Error File!");
            }

            /*myWordDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
            MessageBox.Show("File Created!");*/


            try
            {
                string folder = string.Format(@"D:\OPMTest\{0}", contractId.Trim().Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myWordDoc.SaveAs2(ref file_name, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0} thành công!", file_name.ToString()));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", file_name.ToString()) + e.Message + e.StackTrace);
            }
            myWordDoc.Close();
            wordApp.Quit();
        }




        // Hàm chuyển đổi số
        public static string NumberToString(double number)
        {
            return NumberToString(Math.Round(number, 0, MidpointRounding.AwayFromZero).ToString());
        }

        public static string NumberToString(string number)
        {
            string[] dv = { "", "mươi", "trăm", "nghìn", "triệu", "tỉ" };
            string[] cs = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string doc;
            int i, j, k, n, len, found, ddv, rd;

            len = number.Length;
            number += "ss";
            doc = "";
            found = 0;
            ddv = 0;
            rd = 0;

            i = 0;
            while (i < len)
            {
                //So chu so o hang dang duyet
                n = (len - i + 2) % 3 + 1;

                //Kiem tra so 0
                found = 0;
                for (j = 0; j < n; j++)
                {
                    if (number[i + j] != '0')
                    {
                        found = 1;
                        break;
                    }
                }

                //Duyet n chu so
                if (found == 1)
                {
                    rd = 1;
                    for (j = 0; j < n; j++)
                    {
                        ddv = 1;
                        switch (number[i + j])
                        {
                            case '0':
                                if (n - j == 3) doc += cs[0] + " ";
                                if (n - j == 2)
                                {
                                    if (number[i + j + 1] != '0') doc += "lẻ ";
                                    ddv = 0;
                                }
                                break;
                            case '1':
                                if (n - j == 3) doc += cs[1] + " ";
                                if (n - j == 2)
                                {
                                    doc += "mười ";
                                    ddv = 0;
                                }
                                if (n - j == 1)
                                {
                                    if (i + j == 0) k = 0;
                                    else k = i + j - 1;

                                    if (number[k] != '1' && number[k] != '0')
                                        doc += "mốt ";
                                    else
                                        doc += cs[1] + " ";
                                }
                                break;
                            case '5':
                                if (i + j == len - 1)
                                    doc += "lăm ";
                                else
                                    doc += cs[5] + " ";
                                break;
                            default:
                                doc += cs[(int)number[i + j] - 48] + " ";
                                break;
                        }

                        //Doc don vi nho
                        if (ddv == 1)
                        {
                            doc += dv[n - j - 1] + " ";
                        }
                    }
                }


                //Doc don vi lon
                if (len - i - n > 0)
                {
                    if ((len - i - n) % 9 == 0)
                    {
                        if (rd == 1)
                            for (k = 0; k < (len - i - n) / 9; k++)
                                doc += "tỉ ";
                        rd = 0;
                    }
                    else
                        if (found != 0) doc += dv[((len - i - n + 1) % 9) / 3 + 2] + " ";
                }

                i += n;
            }

            if (len == 1)
                if (number[0] == '0' || number[0] == '5') return cs[(int)number[0] - 48];

            return doc;
        }

    }
}
