using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace OPM.OPMEnginee
{
    class MailSending
    {
        public static DataTable GuaranteeDeadline_MailSendings()
        {
            string query = string.Format("SELECT ContractId, ContractGuaranteeDeadline FROM dbo.Contract WHERE ContractGuaranteeDeadline - 5 <= GETDATE() and ContractGuaranteeDeadline >= GETDATE() and check_ContractGuaranteeDeadline = 0");
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table;
        }

        public static DataTable GuaranteeDeadline_Notification()
        {
            string query = string.Format("SELECT ContractId, ContractGuaranteeDeadline FROM dbo.Contract WHERE ContractGuaranteeDeadline - 5 <= GETDATE() and ContractGuaranteeDeadline >= GETDATE()");
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table;
        }

        public static DataTable POGuaranteeDate_MailSendings()
        {
            string query = string.Format("SELECT ContractId, POId, POGuaranteeDate FROM dbo.PO WHERE POGuaranteeDate - 5 <= GETDATE() and POGuaranteeDate >= GETDATE() and check_POGuaranteeDate = 0");
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table;
        }

        public static DataTable POGuaranteeDate_Notification()
        {
            string query = string.Format("SELECT ContractId, POId, POGuaranteeDate FROM dbo.PO WHERE POGuaranteeDate - 5 <= GETDATE() and POGuaranteeDate >= GETDATE()");
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table;
        }

        public static DataTable POAdvanceGuaranteeCreatedDate_MailSendings()
        {
            string query = string.Format("SELECT ContractId, POId, POAdvanceGuaranteeCreatedDate FROM dbo.PO WHERE POAdvanceGuaranteeCreatedDate - 5 <= GETDATE() and POAdvanceGuaranteeCreatedDate >= GETDATE() and check_POAdvanceGuaranteeCreatedDate = 0");
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table;
        }

        public static DataTable POAdvanceGuaranteeCreatedDate_Notification()
        {
            string query = string.Format("SELECT ContractId, POId, POAdvanceGuaranteeCreatedDate FROM dbo.PO WHERE POAdvanceGuaranteeCreatedDate - 5 <= GETDATE() and POAdvanceGuaranteeCreatedDate >= GETDATE()");
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table;
        }

        public static DataTable POOfferToGuaranteePOWarrantyDate_MailSendings()
        {
            string query = string.Format("SELECT ContractId, POId, POOfferToGuaranteePOWarrantyDate FROM dbo.PO WHERE POOfferToGuaranteePOWarrantyDate - 5 <= GETDATE() and POOfferToGuaranteePOWarrantyDate >= GETDATE() and check_POOfferToGuaranteePOWarrantyDate = 0");
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table;
        }

        public static DataTable POOfferToGuaranteePOWarrantyDate_Notification()
        {
            string query = string.Format("SELECT ContractId, POId, POOfferToGuaranteePOWarrantyDate FROM dbo.PO WHERE POOfferToGuaranteePOWarrantyDate - 5 <= GETDATE() and POOfferToGuaranteePOWarrantyDate >= GETDATE()");
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table;
        }

        public static DataTable POConfirmRequestDeadline_MailSendings()
        {
            string query = string.Format("SELECT ContractId, POId, POConfirmRequestDeadline FROM dbo.PO WHERE POConfirmRequestDeadline - 5 <= GETDATE() and POConfirmRequestDeadline >= GETDATE() and check_POConfirmRequestDeadline = 0");
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table;
        }

        public static DataTable POConfirmRequestDeadline_Notification()
        {
            string query = string.Format("SELECT ContractId, POId, POConfirmRequestDeadline FROM dbo.PO WHERE POConfirmRequestDeadline - 5 <= GETDATE() and POConfirmRequestDeadline >= GETDATE()");
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table;
        }

    }
}
