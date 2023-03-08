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
    public partial class NotificationInfo : Form
    {
        public NotificationInfo()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            //Bảo lãnh thực hiện HĐ
            MailSending.GuaranteeDeadline_Notification();
            DataTable table = MailSending.GuaranteeDeadline_Notification();
            DataRow row = table.NewRow();

            foreach (DataRow dataRow in table.Rows)
            {
                PictureBox pb = new PictureBox();
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Image = new Bitmap(Application.StartupPath + "\\Resources\\notification_mail_30px.png");
                pb.Width = 30;
                pb.Height = 90;

                Label lb = new Label();
                lb.Text = string.Format("[Hợp đồng]: {0} \n                    Ngày hết hạn bảo lãnh hợp đồng: {1} \n                    Còn lại: {2} ngày {3} giờ", dataRow[0], DateTime.Parse(dataRow[1].ToString()).ToString("dd/MM/yyyy"), (DateTime.Parse(dataRow[1].ToString()) - DateTime.Now).ToString("dd"), (DateTime.Parse(dataRow[1].ToString()) - DateTime.Now).ToString("hh"));
                lb.Font = new Font(lb.Font.FontFamily, 13);
                lb.Width = flPn.Width - pb.Width - 30;
                lb.Height = 90;
                lb.BackColor = Color.White;

                Random rand = new Random();
                lb.Location = new Point(rand.Next(0, flPn.Size.Width), rand.Next(0, flPn.Size.Height));

                flPn.Controls.Add(pb);
                flPn.Controls.Add(lb);
            }

            //Xác nhận đơn hàng – cảnh báo hạn xác nhận PO
            MailSending.POConfirmRequestDeadline_Notification();
            DataTable table4 = MailSending.POConfirmRequestDeadline_Notification();
            DataRow row4 = table4.NewRow();

            foreach (DataRow dataRow in table4.Rows)
            {
                PictureBox pb = new PictureBox();
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Image = new Bitmap(Application.StartupPath + "\\Resources\\notification_mail_30px.png");
                pb.Width = 30;
                pb.Height = 90;

                Label lb = new Label();
                lb.Text = string.Format("[Hợp đồng]: {0} _ PO: {1} \n                    Ngày xác nhận PO: {2} \n                    Còn lại: {3} ngày {4} giờ", dataRow[0], dataRow[1], DateTime.Parse(dataRow[2].ToString()).ToString("dd/MM/yyyy"), (DateTime.Parse(dataRow[2].ToString()) - DateTime.Now).ToString("dd"), (DateTime.Parse(dataRow[2].ToString()) - DateTime.Now).ToString("hh"));
                lb.Font = new Font(lb.Font.FontFamily, 13);
                lb.Width = flPn.Width - pb.Width - 30;
                lb.Height = 90;
                lb.BackColor = Color.White;

                Random rand = new Random();
                lb.Location = new Point(rand.Next(0, flPn.Size.Width), rand.Next(0, flPn.Size.Height));

                flPn.Controls.Add(pb);
                flPn.Controls.Add(lb);
            }

            //Bảo lãnh thực hiện PO - cảnh bảo hạn BL
            MailSending.POGuaranteeDate_Notification();
            DataTable table1 = MailSending.POGuaranteeDate_Notification();
            DataRow row1 = table1.NewRow();

            foreach (DataRow dataRow in table1.Rows)
            {
                PictureBox pb = new PictureBox();
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Image = new Bitmap(Application.StartupPath + "\\Resources\\notification_mail_30px.png");
                pb.Width = 30;
                pb.Height = 90;

                Label lb = new Label();
                lb.Text = string.Format("[Hợp đồng]: {0} _ PO: {1} \n                    Ngày hết hạn bảo lãnh PO: {2} \n                    Còn lại: {3} ngày {4} giờ", dataRow[0], dataRow[1], DateTime.Parse(dataRow[2].ToString()).ToString("dd/MM/yyyy"), (DateTime.Parse(dataRow[2].ToString()) - DateTime.Now).ToString("dd"), (DateTime.Parse(dataRow[2].ToString()) - DateTime.Now).ToString("hh"));
                lb.Font = new Font(lb.Font.FontFamily, 13);
                lb.Width = flPn.Width - pb.Width - 30;
                lb.Height = 90;
                lb.BackColor = Color.White;

                Random rand = new Random();
                lb.Location = new Point(rand.Next(0, flPn.Size.Width), rand.Next(0, flPn.Size.Height));

                flPn.Controls.Add(pb);
                flPn.Controls.Add(lb);
            }

            //Bảo lãnh tạm ứng PO - cảnh bảo hạn BL
            MailSending.POAdvanceGuaranteeCreatedDate_Notification();
            DataTable table2 = MailSending.POAdvanceGuaranteeCreatedDate_Notification();
            DataRow row2 = table2.NewRow();

            foreach (DataRow dataRow in table2.Rows)
            {
                PictureBox pb = new PictureBox();
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Image = new Bitmap(Application.StartupPath + "\\Resources\\notification_mail_30px.png");
                pb.Width = 30;
                pb.Height = 90;

                Label lb = new Label();
                lb.Text = string.Format("[Hợp đồng]: {0} _ PO: {1} \n                    Ngày bảo lãnh tạm ứng PO: {2} \n                    Còn lại: {3} ngày {4} giờ", dataRow[0], dataRow[1], DateTime.Parse(dataRow[2].ToString()).ToString("dd/MM/yyyy"), (DateTime.Parse(dataRow[2].ToString()) - DateTime.Now).ToString("dd"), (DateTime.Parse(dataRow[2].ToString()) - DateTime.Now).ToString("hh"));
                lb.Font = new Font(lb.Font.FontFamily, 13);
                lb.Width = flPn.Width - pb.Width - 30;
                lb.Height = 90;
                lb.BackColor = Color.White;

                Random rand = new Random();
                lb.Location = new Point(rand.Next(0, flPn.Size.Width), rand.Next(0, flPn.Size.Height));

                flPn.Controls.Add(pb);
                flPn.Controls.Add(lb);
            }

            //Bảo lãnh bảo hành PO - cảnh bảo hạn BL
            MailSending.POOfferToGuaranteePOWarrantyDate_Notification();
            DataTable table3 = MailSending.POOfferToGuaranteePOWarrantyDate_Notification();
            DataRow row3 = table3.NewRow();

            foreach (DataRow dataRow in table3.Rows)
            {
                PictureBox pb = new PictureBox();
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Image = new Bitmap(Application.StartupPath + "\\Resources\\notification_mail_30px.png");
                pb.Width = 30;
                pb.Height = 90;

                Label lb = new Label();
                lb.Text = string.Format("[Hợp đồng]: {0} _ PO: {1} \n                    Ngày đề nghị mở bảo lãnh bảo hành PO: {2} \n                    Còn lại: {3} ngày {4} giờ", dataRow[0], dataRow[1], DateTime.Parse(dataRow[2].ToString()).ToString("dd/MM/yyyy"), (DateTime.Parse(dataRow[2].ToString()) - DateTime.Now).ToString("dd"), (DateTime.Parse(dataRow[2].ToString()) - DateTime.Now).ToString("hh"));
                lb.Font = new Font(lb.Font.FontFamily, 13);
                lb.Width = flPn.Width - pb.Width - 30;
                lb.Height = 90;
                lb.BackColor = Color.White;

                Random rand = new Random();
                lb.Location = new Point(rand.Next(0, flPn.Size.Width), rand.Next(0, flPn.Size.Height));

                flPn.Controls.Add(pb);
                flPn.Controls.Add(lb);
            }
        }
    }
}
