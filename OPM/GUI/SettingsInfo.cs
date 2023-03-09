using OPM.OPMEnginee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class SettingsInfo : Form
    {
        public SettingsInfo()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            LoadTodtg();
            AddNTKTBinding();
        }

        private void LoadTodtg()
        {
            List<Settings> Users = Settings.Users();
            Settings User = new Settings();
            if (!Settings.UserExists())
            {
                //NTKTDetails.Insert(0, NTKTDetail);
            }

            dgvUsers.DataSource = Users;
            dgvUsers.Columns["id"].Visible = false;
            dgvUsers.Columns["UserName"].Visible = false;
            dgvUsers.Columns["PassWord"].Visible = false;
            dgvUsers.Columns["CheckAdmin"].Visible = false;
            dgvUsers.Columns["FullName"].HeaderText = @"Họ và tên";
            dgvUsers.Columns["FullName"].Width = 170;
            dgvUsers.Columns["Email"].Width = 200;
            dgvUsers.Columns["Phone"].HeaderText = @"Số điện thoại";
            dgvUsers.Columns["Phone"].Width = 150;
        }
        void AddNTKTBinding()
        {
            tbFullName.DataBindings.Clear();
            tbFullName.DataBindings.Add(new Binding("Text", dgvUsers.DataSource, "FullName"));
            tbEmail.DataBindings.Clear();
            tbEmail.DataBindings.Add(new Binding("Text", dgvUsers.DataSource, "Email"));
            tbPhone.DataBindings.Clear();
            tbPhone.DataBindings.Add(new Binding("Text", dgvUsers.DataSource, "Phone"));
            tbUserName.DataBindings.Clear();
            tbUserName.DataBindings.Add(new Binding("Text", dgvUsers.DataSource, "UserName"));
            cbCheckAdmin.DataBindings.Clear();
            cbCheckAdmin.DataBindings.Add(new Binding("Checked", dgvUsers.DataSource, "CheckAdmin"));

        }
    }
}
