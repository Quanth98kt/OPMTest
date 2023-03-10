using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public class ContractObj : SiteObj
    {
        private string contractId = "XXX-"+ DateTime.Now.ToString("yyyy")+"/CUVT-ANSV/DTRR-KHMS";
        public string ContractId
        {
            get => contractId;
            set
            {
                contractId = value;
                try
                {
                    string query = string.Format("SELECT * FROM dbo.Contract WHERE ContractId = '{0}'", value);
                    DataTable table = OPMDBHandler.ExecuteQuery(query);
                    if (table.Rows.Count > 0)
                    {
                        DataRow row = table.Rows[0];
                        ContractCreatedDate = (row["ContractSignedDate"] == null || row["ContractSignedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ContractSignedDate"];
                        ContractName = (row["ContractName"] == null || row["ContractName"] == DBNull.Value) ? "" : row["ContractName"].ToString();
                        ContractShoppingPlan = (row["ContractShoppingPlan"] == null || row["ContractShoppingPlan"] == DBNull.Value) ? "" : row["ContractShoppingPlan"].ToString();
                        ContractType = (row["ContractType"] == null || row["ContractType"] == DBNull.Value) ? "" : row["ContractType"].ToString();
                        SiteId = (row["SiteId"] == null || row["SiteId"] == DBNull.Value) ? "" : row["SiteId"].ToString();
                        ContractValidityDate = (row["ContractValidityDate"] == null || row["ContractValidityDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ContractValidityDate"];
                        ContractDeadline = (row["ContractDeadline"] == null || row["ContractDeadline"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ContractDeadline"];
                        ContractGoodsDesignation = (row["ContractGoodsDesignation"] == null || row["ContractGoodsDesignation"] == DBNull.Value) ? "" : row["ContractGoodsDesignation"].ToString();
                        ContractGoodsCode = (row["ContractGoodsCode"] == null || row["ContractGoodsCode"] == DBNull.Value) ? "" : row["ContractGoodsCode"].ToString();
                        ContractGoodsManufacture = (row["ContractGoodsManufacture"] == null || row["ContractGoodsManufacture"] == DBNull.Value) ? "" : row["ContractGoodsManufacture"].ToString();
                        ContractGoodsOrigin = (row["ContractGoodsOrigin"] == null || row["ContractGoodsOrigin"] == DBNull.Value) ? "" : row["ContractGoodsOrigin"].ToString();
                        ContractGoodsDesignation1 = (row["ContractGoodsDesignation1"] == null || row["ContractGoodsDesignation1"] == DBNull.Value) ? "" : row["ContractGoodsDesignation1"].ToString();
                        ContractGoodsCode1 = (row["ContractGoodsCode1"] == null || row["ContractGoodsCode1"] == DBNull.Value) ? "" : row["ContractGoodsCode1"].ToString();
                        ContractGoodsCode2 = (row["ContractGoodsCode2"] == null || row["ContractGoodsCode2"] == DBNull.Value) ? "" : row["ContractGoodsCode2"].ToString();
                        ContractGoodsSpecies = (row["ContractGoodsSpecies"] == null || row["ContractGoodsSpecies"] == DBNull.Value) ? "" : row["ContractGoodsSpecies"].ToString();
                        ContractGoodsNote = (row["ContractGoodsNote"] == null || row["ContractGoodsNote"] == DBNull.Value) ? "" : row["ContractGoodsNote"].ToString();
                        ContractGoodsUnit = (row["ContractGoodsUnit"] == null || row["ContractGoodsUnit"] == DBNull.Value) ? "" : row["ContractGoodsUnit"].ToString();
                        ContractGoodsUnitPrice = (row["ContractGoodsUnitPrice"] == null || row["ContractGoodsUnitPrice"] == DBNull.Value) ? 0 : (double)row["ContractGoodsUnitPrice"];
                        ContractGoodsQuantity = (row["ContractGoodsQuantity"] == null || row["ContractGoodsQuantity"] == DBNull.Value) ? 0 : (double)row["ContractGoodsQuantity"];
                        ContractGoodsLicenseName = (row["ContractGoodsLicenseName"] == null || row["ContractGoodsLicenseName"] == DBNull.Value) ? "" : row["ContractGoodsLicenseName"].ToString();
                        ContractGoodsLicenseUnitPrice = (row["ContractGoodsLicenseUnitPrice"] == null || row["ContractGoodsLicenseUnitPrice"] == DBNull.Value) ? 0 : (double)row["ContractGoodsLicenseUnitPrice"];
                        ContractGuaranteeCreatedDate = (row["ContractGuaranteeCreatedDate"] == null || row["ContractGuaranteeCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ContractGuaranteeCreatedDate"];
                        POGuaranteeRatio = (row["POGuaranteeRatio"] == null || row["POGuaranteeRatio"] == DBNull.Value) ? 0 : (int)row["POGuaranteeRatio"];
                        POGuaranteeValidityPeriod = (row["POGuaranteeValidityPeriod"] == null || row["POGuaranteeValidityPeriod"] == DBNull.Value) ? 0 : (int)row["POGuaranteeValidityPeriod"];
                        ContractGuaranteeDeadline = (row["ContractGuaranteeDeadline"] == null || row["ContractGuaranteeDeadline"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ContractGuaranteeDeadline"];
                        ContractAccoutingCode = (row["AccoutingCode"] == null || row["AccoutingCode"] == DBNull.Value) ? "" : row["AccoutingCode"].ToString();
                        ContractReportOfConpletedVolumeDate = (row["ContractReportOfConpletedVolumeDate"] == null || row["ContractReportOfConpletedVolumeDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ContractReportOfConpletedVolumeDate"];
                        ContractLiquidationRecordsDate = (row["ContractLiquidationRecordsDate"] == null || row["ContractLiquidationRecordsDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ContractLiquidationRecordsDate"];
                        ContractTotalAmountPaid = (row["ContractTotalAmountPaid"] == null || row["ContractTotalAmountPaid"] == DBNull.Value) ? 0 : (double)row["ContractTotalAmountPaid"];
                        ContractConformityCertificateNumber = (row["ContractConformityCertificateNumber"] == null || row["ContractConformityCertificateNumber"] == DBNull.Value) ? "" : row["ContractConformityCertificateNumber"].ToString();
                        check_ContractGuaranteeDeadline = (row["check_ContractGuaranteeDeadline"] == null || row["check_ContractGuaranteeDeadline"] == DBNull.Value) ? 0 : (int)row["check_ContractGuaranteeDeadline"];

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Lỗi khi kết nối bảng Contract trong CSDL " + e.Message);
                }
            }
        }
        public DateTime ContractCreatedDate { get; set; } = DateTime.Now.Date;
        public string ContractName { get; set; } = @"Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)";
        public string ContractShoppingPlan { get; set; } = @"Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020";
        public string ContractType { get; set; } = @"Theo đơn giá cố định";
        public DateTime ContractValidityDate { get; set; } = DateTime.Now.Date.AddDays(2);
        public int ContractPeriod => (ContractDeadline - ContractValidityDate).Days;
        public DateTime ContractDeadline { get; set; } = DateTime.Now.Date.AddDays(2);
        public double ContractValue => ContractGoodsUnitPrice * ContractGoodsQuantity;
        public string ContractGoodsDesignation { get; set; } = "Thiết bị đầu cuối ONT loại (4FE/GE+Wifi dualband+2POTS) tương thích hệ thống GPON cùng đầy đủ license và phụ kiện kèm theo (không bao gồm dây nhảy quang, bản quyền Multicast)";
        public string ContractGoodsCode { get; set; } = "iGate GW240-H";
        public string ContractGoodsManufacture { get; set; } = @"VNPT/Technology";
        public string ContractGoodsOrigin { get; set; } = "Việt Nam";
        public string ContractGoodsDesignation1 { get; set; } = "FINAL_PRODUCT, GW020_BOB";
        public string ContractGoodsCode1 { get; set; } = "HY5N2T5N000024NP";
        public string ContractGoodsCode2 { get; set; } = "2FE/GE+WIFI singleband";
        public string ContractGoodsSpecies { get; set; } = "Thiết bị đầu cuối ONT";
        public string ContractGoodsNote { get; set; } = @"Phụ kiện kèm theo mỗi bộ ONT: 01 Dây cáp mạng UTP dài 1,0 mét với giắc kết nối RJ-45 tại hai đầu; 01 Bộ chuyển đổi điện AC/DC dải rộng với chiều dài dây tối thiểu là 1,5 mét; 01 Tài liệu hướng dẫn sử dụng bằng tiếng Việt.";
        public string ContractGoodsUnit { get; set; } = "Bộ";
        public double ContractGoodsUnitPrice { get; set; } = 0;
        public double ContractGoodsQuantity { get; set; } = 0;
        public double ContractSpareGoodsQuantity => Math.Round(ContractGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero);
        public string ContractGoodsLicenseName { get; set; } = "Bản quyền quản lý ONT FTTH (bản quyền / ONT)";
        public double ContractGoodsLicenseUnitPrice { get; set; } = 0;
        public DateTime ContractGuaranteeCreatedDate { get; set; } = DateTime.Now.Date;
        public int POGuaranteeRatio { get; set; } = 5;
        public int POGuaranteeValidityPeriod { get; set; } = 5;
        public int ContractGuaranteeValidityPeriod { get => (ContractGuaranteeDeadline - ContractGuaranteeCreatedDate).Days; }
        public DateTime ContractGuaranteeDeadline { get; set; } = DateTime.Now.Date.AddDays(2);
        public string ContractAccoutingCode { get; set; } = "C01007";
        public DateTime ContractReportOfConpletedVolumeDate { get; set; } = DateTime.Now.Date;
        public DateTime ContractLiquidationRecordsDate { get; set; } = DateTime.Now.Date;
        public double ContractTotalAmountPaid { get; set; } = 0;
        public int check_ContractGuaranteeDeadline { get; set; } = 0;
        public string ContractConformityCertificateNumber { get; set; } = "";
        private SiteObj siteA;

        public SiteObj GetSiteA()
        {
            return siteA;
        }

        public void SetSiteA(SiteObj value)
        {
            siteA = value;
            this.SiteId = value.SiteId;
            this.SiteName = value.SiteName;
            this.SiteProvince = value.SiteProvince;
            this.SiteType = value.SiteType;
            this.SiteHeadquater = value.SiteHeadquater;
            this.SiteAddress = value.SiteAddress;
            this.SitePhonenumber = value.SitePhonenumber;
            this.SiteFaxNumber = value.SiteFaxNumber;
            this.SiteTaxCode = value.SiteTaxCode;
            this.SiteBankAccount = value.SiteBankAccount;
            this.SiteNameOfBank = value.SiteNameOfBank;
            this.SiteRepresentative1 = value.SiteRepresentative1;
            this.SitePosition1 = value.SitePosition1;
            this.SiteProxy1 = value.SiteProxy1;
            this.SiteRepresentative2 = value.SiteRepresentative2;
            this.SitePosition2 = value.SitePosition2;
            this.SiteProxy2 = value.SiteProxy2;
            this.SiteRepresentative3 = value.SiteRepresentative3;
            this.SitePosition3 = value.SitePosition3;
            this.SiteProxy3 = value.SiteProxy3;
        }

        public ContractObj() { }
        public ContractObj(string contractId)
        {
            ContractId = contractId;
            try
            {
                string query = string.Format("SELECT * FROM dbo.Contract WHERE ContractId = '{0}'", contractId);
                DataTable table = OPMDBHandler.ExecuteQuery(query);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    ContractCreatedDate = (row["ContractSignedDate"] == null || row["ContractSignedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ContractSignedDate"];
                    ContractName = (row["ContractName"] == null || row["ContractName"] == DBNull.Value) ? "" : row["ContractName"].ToString();
                    ContractShoppingPlan = (row["ContractShoppingPlan"] == null || row["ContractShoppingPlan"] == DBNull.Value) ? "" : row["ContractShoppingPlan"].ToString();
                    ContractType = (row["ContractType"] == null || row["ContractType"] == DBNull.Value) ? "" : row["ContractType"].ToString();
                    SiteId = (row["SiteId"] == null || row["SiteId"] == DBNull.Value) ? "" : row["SiteId"].ToString();
                    ContractValidityDate = (row["ContractValidityDate"] == null || row["ContractValidityDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ContractValidityDate"];
                    ContractDeadline = (row["ContractDeadline"] == null || row["ContractDeadline"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ContractDeadline"];
                    ContractGoodsDesignation = (row["ContractGoodsDesignation"] == null || row["ContractGoodsDesignation"] == DBNull.Value) ? "" : row["ContractGoodsDesignation"].ToString();
                    ContractGoodsCode = (row["ContractGoodsCode"] == null || row["ContractGoodsCode"] == DBNull.Value) ? "" : row["ContractGoodsCode"].ToString();
                    ContractGoodsManufacture = (row["ContractGoodsManufacture"] == null || row["ContractGoodsManufacture"] == DBNull.Value) ? "" : row["ContractGoodsManufacture"].ToString();
                    ContractGoodsOrigin = (row["ContractGoodsOrigin"] == null || row["ContractGoodsOrigin"] == DBNull.Value) ? "" : row["ContractGoodsOrigin"].ToString();
                    ContractGoodsDesignation1 = (row["ContractGoodsDesignation1"] == null || row["ContractGoodsDesignation1"] == DBNull.Value) ? "" : row["ContractGoodsDesignation1"].ToString();
                    ContractGoodsCode1 = (row["ContractGoodsCode1"] == null || row["ContractGoodsCode1"] == DBNull.Value) ? "" : row["ContractGoodsCode1"].ToString();
                    ContractGoodsCode2 = (row["ContractGoodsCode2"] == null || row["ContractGoodsCode2"] == DBNull.Value) ? "" : row["ContractGoodsCode2"].ToString();
                    ContractGoodsSpecies = (row["ContractGoodsSpecies"] == null || row["ContractGoodsSpecies"] == DBNull.Value) ? "" : row["ContractGoodsSpecies"].ToString();
                    ContractGoodsNote = (row["ContractGoodsNote"] == null || row["ContractGoodsNote"] == DBNull.Value) ? "" : row["ContractGoodsNote"].ToString();
                    ContractGoodsUnit = (row["ContractGoodsUnit"] == null || row["ContractGoodsUnit"] == DBNull.Value) ? "" : row["ContractGoodsUnit"].ToString();
                    ContractGoodsUnitPrice = (row["ContractGoodsUnitPrice"] == null || row["ContractGoodsUnitPrice"] == DBNull.Value) ? 0 : (double)row["ContractGoodsUnitPrice"];
                    ContractGoodsQuantity = (row["ContractGoodsQuantity"] == null || row["ContractGoodsQuantity"] == DBNull.Value) ? 0 : (double)row["ContractGoodsQuantity"];
                    ContractGoodsLicenseName = (row["ContractGoodsLicenseName"] == null || row["ContractGoodsLicenseName"] == DBNull.Value) ? "" : row["ContractGoodsLicenseName"].ToString();
                    ContractGoodsLicenseUnitPrice = (row["ContractGoodsLicenseUnitPrice"] == null || row["ContractGoodsLicenseUnitPrice"] == DBNull.Value) ? 0 : (double)row["ContractGoodsLicenseUnitPrice"];
                    ContractGuaranteeCreatedDate = (row["ContractGuaranteeCreatedDate"] == null || row["ContractGuaranteeCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ContractGuaranteeCreatedDate"];
                    POGuaranteeRatio = (row["POGuaranteeRatio"] == null || row["POGuaranteeRatio"] == DBNull.Value) ? 0 : (int)row["POGuaranteeRatio"];
                    POGuaranteeValidityPeriod = (row["POGuaranteeValidityPeriod"] == null || row["POGuaranteeValidityPeriod"] == DBNull.Value) ? 0 : (int)row["POGuaranteeValidityPeriod"];
                    ContractGuaranteeDeadline = (row["ContractGuaranteeDeadline"] == null || row["ContractGuaranteeDeadline"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ContractGuaranteeDeadline"];
                    ContractAccoutingCode = (row["AccoutingCode"] == null || row["AccoutingCode"] == DBNull.Value) ? "" : row["AccoutingCode"].ToString();
                    ContractReportOfConpletedVolumeDate = (row["ContractReportOfConpletedVolumeDate"] == null || row["ContractReportOfConpletedVolumeDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ContractReportOfConpletedVolumeDate"];
                    ContractLiquidationRecordsDate = (row["ContractLiquidationRecordsDate"] == null || row["ContractLiquidationRecordsDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ContractLiquidationRecordsDate"];
                    ContractTotalAmountPaid = (row["ContractTotalAmountPaid"] == null || row["ContractTotalAmountPaid"] == DBNull.Value) ? 0 : (double)row["ContractTotalAmountPaid"];
                    ContractConformityCertificateNumber = (row["ContractConformityCertificateNumber"] == null || row["ContractConformityCertificateNumber"] == DBNull.Value) ? "" : row["ContractConformityCertificateNumber"].ToString();
                    check_ContractGuaranteeDeadline = (row["check_ContractGuaranteeDeadline"] == null || row["check_ContractGuaranteeDeadline"] == DBNull.Value) ? 0 : (int)row["check_ContractGuaranteeDeadline"];
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi khi kết nối bảng Contract trong CSDL " + e.Message);
            }
        }
        public bool ContractExist()
        {
            string query = string.Format("SELECT * FROM dbo.Contract WHERE ContractId = '{0}'", ContractId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool ContractExist(string contractId)
        {
            string query = string.Format("SELECT * FROM dbo.Contract WHERE ContractId = '{0}'", contractId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public int ContractInsert(string id)
        {
            if (ContractExist(id)) return 0;
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.Contract(ContractId,ContractSignedDate,ContractName,ContractShoppingPlan,ContractType,SiteId,ContractValidityDate,ContractDeadline,ContractGoodsDesignation,ContractGoodsCode,ContractGoodsManufacture,ContractGoodsOrigin,ContractGoodsDesignation1,ContractGoodsCode1,ContractGoodsCode2,ContractGoodsSpecies,ContractGoodsNote,ContractGoodsUnit,ContractGoodsUnitPrice,ContractGoodsQuantity,ContractGoodsLicenseName,ContractGoodsLicenseUnitPrice,ContractGuaranteeCreatedDate,POGuaranteeRatio,POGuaranteeValidityPeriod,ContractGuaranteeDeadline,AccoutingCode,ContractReportOfConpletedVolumeDate,ContractLiquidationRecordsDate,ContractTotalAmountPaid,ContractConformityCertificateNumber,check_ContractGuaranteeDeadline)VALUES('{0}','{1}',N'{2}',N'{3}',N'{4}','{5}','{6}','{7}',N'{8}','{9}',N'{10}',N'{11}','{12}','{13}','{14}',N'{15}',N'{16}',N'{17}',{18},{19},N'{20}',{21},'{22}',{23},{24},'{25}','{26}','{27}','{28}',{29},'{30}','{31}')", id, ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), ContractName, ContractShoppingPlan, ContractType, SiteId, ContractValidityDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), ContractDeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), ContractGoodsDesignation, ContractGoodsCode, ContractGoodsManufacture, ContractGoodsOrigin, ContractGoodsDesignation1, ContractGoodsCode1, ContractGoodsCode2, ContractGoodsSpecies, ContractGoodsNote, ContractGoodsUnit, ContractGoodsUnitPrice, ContractGoodsQuantity, ContractGoodsLicenseName, ContractGoodsLicenseUnitPrice, ContractGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POGuaranteeRatio, POGuaranteeValidityPeriod, ContractGuaranteeDeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), ContractAccoutingCode, ContractReportOfConpletedVolumeDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), ContractLiquidationRecordsDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), ContractTotalAmountPaid, ContractConformityCertificateNumber, check_ContractGuaranteeDeadline);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int ContractUpdate(string newId, string oldID)
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.Contract SET ContractId = '{31}', ContractSignedDate ='{1}', ContractName = N'{2}', ContractShoppingPlan = N'{3}', ContractType = N'{4}', SiteId = '{5}', ContractValidityDate = '{6}', ContractDeadline = '{7}', ContractGoodsDesignation = N'{8}', ContractGoodsCode = '{9}', ContractGoodsManufacture = N'{10}', ContractGoodsOrigin = N'{11}', ContractGoodsDesignation1 = '{12}', ContractGoodsCode1 = '{13}', ContractGoodsCode2 = '{14}', ContractGoodsSpecies = N'{15}', ContractGoodsNote = N'{16}', ContractGoodsUnit = N'{17}', ContractGoodsUnitPrice = {18}, ContractGoodsQuantity = {19}, ContractGoodsLicenseName = N'{20}', ContractGoodsLicenseUnitPrice = {21}, ContractGuaranteeCreatedDate = '{22}', POGuaranteeRatio = {23}, POGuaranteeValidityPeriod = {24}, ContractGuaranteeDeadline = '{25}', AccoutingCode = '{26}',ContractReportOfConpletedVolumeDate = '{27}',ContractLiquidationRecordsDate = '{28}',ContractTotalAmountPaid = {29},ContractConformityCertificateNumber = '{30}' WHERE ContractId = '{0}'", oldID, ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), ContractName, ContractShoppingPlan, ContractType, SiteId, ContractValidityDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), ContractDeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), ContractGoodsDesignation, ContractGoodsCode, ContractGoodsManufacture, ContractGoodsOrigin, ContractGoodsDesignation1, ContractGoodsCode1, ContractGoodsCode2, ContractGoodsSpecies, ContractGoodsNote, ContractGoodsUnit, ContractGoodsUnitPrice, ContractGoodsQuantity, ContractGoodsLicenseName, ContractGoodsLicenseUnitPrice, ContractGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POGuaranteeRatio, POGuaranteeValidityPeriod, ContractGuaranteeDeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), ContractAccoutingCode, ContractReportOfConpletedVolumeDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), ContractLiquidationRecordsDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), ContractTotalAmountPaid, ContractConformityCertificateNumber, newId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public static int ContractDelete(string contractId)
        {
            string query = string.Format("DELETE FROM dbo.Contract WHERE ContractId = '{0}'", contractId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
    }
}
