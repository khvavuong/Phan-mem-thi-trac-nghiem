using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Business_Tier;
using Entities;

namespace ProjectThiTracNghiem
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //frmDangNhap frmnhap = new frmDangNhap();
            //frmnhap.ShowDialog();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminDangNhap frmAdmin = new frmAdminDangNhap();
            frmAdmin.ShowDialog();
        }

        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSVDangNhap frmSV = new frmSVDangNhap();
            frmSV.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblNgayGio.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
        }

        private void lblNgayGio_Click(object sender, EventArgs e)
        {

        }

        private void HuongDantoolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHuongDan huongdan = new frmHuongDan();
            huongdan.ShowDialog();
        }

        private void ThongTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbout frnThongTin = new frmAbout();
            frnThongTin.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn muốn thoát chương trình", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                e.Cancel = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
