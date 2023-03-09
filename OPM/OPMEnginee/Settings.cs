using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OPM.OPMEnginee
{
    public class Settings
    {
        public int id { get; set; } = 0;
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "Email@anssv.vn";
        public double Phone { get; set; } = 0;
        public string UserName { get; set; } = "";
        public string PassWord { get; set; } = "";
        public int CheckAdmin { get; set; } = 0;

        public Settings(int id, string FullName, string Email, double Phone, string UserName, string PassWord, int CheckAdmin)
        {
            this.id = id;
            this.FullName = FullName;
            this.Email = Email;
            this.Phone = Phone;
            this.UserName = UserName;
            this.PassWord = PassWord;
            this.CheckAdmin = CheckAdmin;
        }

        public Settings(DataRow row)
        {
            id = (row["id"] == null || row["id"] == DBNull.Value) ? 0 : (int)row["id"];
            FullName = (row["FullName"] == null || row["FullName"] == DBNull.Value) ? "Trần Văn X" : row["FullName"].ToString();
            Email = (row["Email"] == null || row["Email"] == DBNull.Value) ? "Email@ansv.vn" : row["Email"].ToString();
            Phone = (row["Phone"] == null || row["Phone"] == DBNull.Value) ? 0 : (double)row["Phone"];
            UserName = (row["UserName"] == null || row["UserName"] == DBNull.Value) ? "X" : row["UserName"].ToString();
            PassWord = (row["PassWord"] == null || row["PassWord"] == DBNull.Value) ? "X" : row["PassWord"].ToString();
            CheckAdmin = (row["CheckAdmin"] == null || row["CheckAdmin"] == DBNull.Value) ? 0 : (int)row["CheckAdmin"];
        }

        public Settings() { }
        public bool UserExist()
        {
            string query = string.Format("SELECT * FROM dbo.Users");
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool UserExists()
        {
            string query = string.Format("SELECT * FROM dbo.Users");
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public int UserInsert()
        {
            string query = string.Format(@"INSERT INTO dbo.Users(FullName, Email, Phone, UserName, PassWord, CheckAdmin)VALUES(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')", FullName, Email, Phone, UserName, PassWord, CheckAdmin);
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public static DataTable User()
        {
            string query = string.Format("SELECT * FROM dbo.Users");
            return OPMDBHandler.ExecuteQuery(query);
        }
        public static List<Settings> Users()
        {
            List<Settings> list = new List<Settings>();
            DataTable dataTable = User();
            foreach (DataRow items in dataTable.Rows)
            {
                Settings item = new Settings(items);
                list.Add(item);
            }
            return list;
        }
        //Login
        public static bool Login(string userName, string passWord)
        {
            string query = string.Format("SELECT * FROM dbo.Users where userName = N'{0}' and passWord = N'{1}'", userName, passWord);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
    }
}
