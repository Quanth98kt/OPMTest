using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public class DeliveryAddendumObj
    {
        private string Id = "XXXX/ANSV-DO";

        public string id
        {
            get => Id;
            set
            {
                Id = value;
                string query = string.Format("SELECT * FROM dbo.DeliveryAddendum WHERE POId = N'{0}'", value);
                try
                {
                    DataTable table = OPMDBHandler.ExecuteQuery(query);
                    if (table.Rows.Count > 0)
                    {
                        DataRow row = table.Rows[0];
                        POId = row["POId"].ToString();
                        STT = (row["STT"] == null || row["STT"] == DBNull.Value) ? 0 : (int)row["STT"];
                        VNPTId = (row["VNPTId"] == null || row["VNPTId"] == DBNull.Value) ? "X" : row["VNPTId"].ToString();
                        SiteName = (row["SiteName"] == null || row["SiteName"] == DBNull.Value) ? "X" : row["SiteName"].ToString();
                        Mainline = (row["Mainline"] == null || row["Mainline"] == DBNull.Value) ? 0 : (double)row["Mainline"];
                        Sparegoods = (row["Sparegoods"] == null || row["Sparegoods"] == DBNull.Value) ? 0 : (double)row["Sparegoods"];
                        EdDate = (row["EdDate"] == null || row["EdDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["EdDate"];
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Lỗi khi kết nối bảng NTKT trong CSDL " + query + e.Message);
                }
            }
        }
        public double STT { get; set; } = 0;
        public string POId { get; set; } = "X";
        public string VNPTId { get; set; } = "X";
        public string SiteName { get; set; } = "X";
        public double Mainline { get; set; } = 0;
        public double Sparegoods { get; set; } = 0;
        public DateTime EdDate { get; set; } = DateTime.Now;

        public DeliveryAddendumObj(string id, double STT, string POId, string VNPTId, string SiteName, double Mainline, double Sparegoods, DateTime EdDate)
        {
            this.id = id;
            this.STT = STT;
            this.POId = POId;
            this.VNPTId = VNPTId;
            this.SiteName = SiteName;
            this.Mainline = Mainline;
            this.Sparegoods = Sparegoods;
            this.EdDate = EdDate;
        }

        public DeliveryAddendumObj(DataRow row)
        {
            id = row["id"].ToString();
            POId = row["POId"].ToString();
            STT = (row["STT"] == null || row["STT"] == DBNull.Value) ? 0 : (int)row["STT"];
            VNPTId = (row["VNPTId"] == null || row["VNPTId"] == DBNull.Value) ? "X" : row["VNPTId"].ToString();
            SiteName = (row["SiteName"] == null || row["SiteName"] == DBNull.Value) ? "X" : row["SiteName"].ToString();
            Mainline = (row["Mainline"] == null || row["Mainline"] == DBNull.Value) ? 0 : (double)row["Mainline"];
            Sparegoods = (row["Sparegoods"] == null || row["Sparegoods"] == DBNull.Value) ? 0 : (double)row["Sparegoods"];
            EdDate = (row["EdDate"] == null || row["EdDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["EdDate"];
        }
        public DeliveryAddendumObj(string Id) 
        {
            id = Id;
        }
        public DeliveryAddendumObj() { }
        public bool DeliveryAddendumExist()
        {
            string query = string.Format("SELECT * FROM dbo.DeliveryAddendum");
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public bool DeliveryAddendumExist(string id)
        {
            string query = string.Format("SELECT * FROM dbo.DeliveryAddendum WHERE id = N'{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool DeliveryAddendumExist(string POId, string VNPTId)
        {
            string query = string.Format("SELECT * FROM dbo.DeliveryAddendum WHERE POid = N'{0}' and VNPTId = N'{1}'", POId, VNPTId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool DeliveryAddendumByPOId(string POId)
        {
            string query = string.Format("SELECT * FROM dbo.DeliveryAddendum WHERE POId = N'{0}'", POId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static DataTable DeliveryAddendumByPOId_(string POId)
        {
            string query = string.Format("SELECT tb1.*, tb2.SiteName FROM dbo.DeliveryAddendum AS tb1 left join dbo.Site tb2 on tb1.VNPTId = tb2.SiteId Where tb1.POId = N'{0}' Order By tb1.STT", POId);
            return OPMDBHandler.ExecuteQuery(query);
        }
        public static List<DeliveryAddendumObj> DetailListByPOId(string POId)
        {
            List<DeliveryAddendumObj> list = new List<DeliveryAddendumObj>();
            DataTable dataTable = DeliveryAddendumByPOId_(POId);
            foreach (DataRow item in dataTable.Rows)
            {
                DeliveryAddendumObj DeAdd = new DeliveryAddendumObj(item);
                list.Add(DeAdd);
            }
            return list;
        }
        public static bool DeliveryAddendumSTTExist(int STT, string POId)
        {
            string query = string.Format("SELECT * FROM dbo.DeliveryAddendum WHERE STT = '{0}' and POId = N'{1}'", STT, POId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public int DeliveryAddendumInsert()
        {
            string query = string.Format(@"INSERT INTO dbo.DeliveryAddendum(id, STT, POId, VNPTId, Mainline, Sparegoods, EdDate)VALUES(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}')", id, STT, POId, VNPTId, Mainline, Sparegoods, EdDate);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int DeliveryAddendumUpdate(string id)
        {
            string query = string.Format("UPDATE dbo.DeliveryAddendum SET STT = N'{1}', POId = N'{2}', VNPTId = N'{3}', Mainline = N'{4}', Sparegoods= N'{5}', EdDate= N'{6}' WHERE id = N'{0}'", id, STT, POId, VNPTId, Mainline, Sparegoods, EdDate);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public static void DeliveryAddendumDelete(string id)
        {
            string query = string.Format("DELETE FROM dbo.DeliveryAddendum WHERE id = N'{0}'", id);
            OPMDBHandler.ExecuteNonQuery(query);
        }
    }
}
