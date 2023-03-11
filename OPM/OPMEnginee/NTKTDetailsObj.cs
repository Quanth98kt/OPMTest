using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public class NTKTDetailsObj
    {
        public string id { get; set; } = "X";
        public string NTKTId { get; set; } = "X";
        public string VNPTId { get; set; } = "X";
        public string SiteName { get; set; } = "X";
        public double NTKTMainline { get; set; } = 0;
        public double NTKTSparegoods { get; set; } = 0;
        public DateTime NTKTEdDate { get; set; } = DateTime.Now;

        public NTKTDetailsObj( string id, string NTKTId, string VNPTId, string SiteName, double NTKTMainline, double NTKTSparegoods, DateTime NTKTEdDate)
        {
            this.id = id;
            this.NTKTId = NTKTId;
            this.VNPTId = VNPTId;
            this.SiteName = SiteName;
            this.NTKTMainline = NTKTMainline;
            this.NTKTSparegoods = NTKTSparegoods;
            this.NTKTEdDate = NTKTEdDate;
        }

        public NTKTDetailsObj(DataRow row)
        {
            id = (row["id"] == null || row["id"] == DBNull.Value) ? "X" : row["id"].ToString();
            NTKTId = row["NTKTId"].ToString();
            VNPTId = (row["VNPTId"] == null || row["VNPTId"] == DBNull.Value) ? "X" : row["VNPTId"].ToString();
            SiteName = (row["SiteName"] == null || row["SiteName"] == DBNull.Value) ? "X" : row["SiteName"].ToString();
            NTKTMainline = (row["NTKTMainline"] == null || row["NTKTMainline"] == DBNull.Value) ? 0 : (double)row["NTKTMainline"];
            NTKTSparegoods = (row["NTKTSparegoods"] == null || row["NTKTSparegoods"] == DBNull.Value) ? 0 : (double)row["NTKTSparegoods"];
            NTKTEdDate = (row["NTKTEdDate"] == null || row["NTKTEdDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["NTKTEdDate"];
        }

        /*public NTKTDetailsObj(int iD)
        {
            id = iD;
        }*/
        public NTKTDetailsObj() { }
        public bool NTKTDetailsExist()
        {
            string query = string.Format("SELECT * FROM dbo.NTKTDetails WHERE id = N'{0}'");
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool NTKTDetailsExist(string iD,string VNPTId)
        {
            string query = string.Format("SELECT * FROM dbo.NTKTDetails WHERE id = N'{0}' and VNPTId = N'{1}'", iD, VNPTId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool NTKTDetailsByNTKTId(string NTKTId)
        {
            string query = string.Format("SELECT * FROM dbo.NTKTDetails WHERE NTKTId = '{0}'", NTKTId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static DataTable NTKTDetailByNTKTId(string NTKTId)
        {
            string query = string.Format("SELECT tb1.*, tb2.SiteName FROM dbo.NTKTDetails AS tb1 left join dbo.Site tb2 on tb1.VNPTId = tb2.SiteId Where tb1.NTKTId = '{0}' Order By tb1.VNPTId", NTKTId);
            return OPMDBHandler.ExecuteQuery(query);
        }
        public static List<NTKTDetailsObj> NTKTDetailListByNTKTId(string NTKTId)
        {
            List<NTKTDetailsObj> list = new List<NTKTDetailsObj>();
            DataTable dataTable = NTKTDetailByNTKTId(NTKTId);
            foreach (DataRow item in dataTable.Rows)
            {
                NTKTDetailsObj NTKTDt = new NTKTDetailsObj(item);
                list.Add(NTKTDt);
            }
            return list;
        }
        public int NTKTDetailsUpdate(string id)
        {
            string query = string.Format("UPDATE dbo.NTKTDetails SET NTKTId = N'{1}', VNPTId = N'{2}', NTKTMainline = N'{3}', NTKTSparegoods = N'{4}', NTKTEdDate= N'{5}' WHERE id = N'{0}'", id, NTKTId, VNPTId, NTKTMainline, NTKTSparegoods, NTKTEdDate);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int NTKTDetailsInsert(string Id, string VNPTId)
        {
            if (NTKTDetailsObj.NTKTDetailsExist(Id, VNPTId)) return 0;
            string query = string.Format(@"INSERT INTO dbo.NTKTDetails (id,NTKTId, VNPTId, NTKTMainline, NTKTSparegoods, NTKTEdDate)VALUES(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')", Id, NTKTId, VNPTId, NTKTMainline, NTKTSparegoods, NTKTEdDate);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int NTKTDetailsInsert()
        {
            //if (NTKTDetailsObj.NTKTDetailsExist(NTKTDetailId)) return 0;
            string query = string.Format(@"INSERT INTO dbo.NTKTDetails(NTKTId, VNPTId, NTKTMainline, NTKTSparegoods, NTKTEdDate)VALUES(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')", NTKTId, VNPTId, NTKTMainline, NTKTSparegoods, NTKTEdDate);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public static void NTKTDetailDelete(string id)
        {
            string query = string.Format("DELETE FROM dbo.NTKTDetails WHERE id = N'{0}'", id);
            OPMDBHandler.ExecuteNonQuery(query);

        }
        public static DataTable SUM( string VNPTId)
        {
            string query = string.Format("SELECT count(VNPTId) AS SUM_ID, SUM(NTKTMainline) AS SUM_NTKTMainline, SUM(NTKTSparegoods) AS SUM_NTKTSparegoods FROM dbo.NTKTDetails WHERE VNPTId = '{0}'", VNPTId);
            return OPMDBHandler.ExecuteQuery(query);
        }

        public static double SUMID(string NTKTId)
        {
            string query = string.Format(@"SELECT count(VNPTId) as SUM_ID FROM dbo.NTKTDetails WHERE NTKTId = '{0}'", NTKTId);
            var tem1 = OPMDBHandler.ExecuteScalar(query);
            int tem = (tem1 == null || tem1 == DBNull.Value) ? 0 : (int)tem1;
            return tem;
        }

        public static double SUMNTKTMainline(string NTKTId)
        {
            string query = string.Format(@"SELECT SUM(NTKTMainline) AS SUM_NTKTMainline FROM dbo.NTKTDetails WHERE NTKTId = '{0}'", NTKTId);
            var tem1 = OPMDBHandler.ExecuteScalar(query);
            double tem = (tem1 == null || tem1 == DBNull.Value) ? 0 : (double)tem1;
            return tem;
        }

        public static double SUMNTKTSparegoods(string NTKTId)
        {
            string query = string.Format(@"SELECT SUM(NTKTSparegoods) AS SUM_NTKTSparegoods FROM dbo.NTKTDetails WHERE NTKTId = '{0}'", NTKTId);
            var tem1 = OPMDBHandler.ExecuteScalar(query);
            double tem = (tem1 == null || tem1 == DBNull.Value) ? 0 : (double)tem1;
            return tem;
        }
    }
}
