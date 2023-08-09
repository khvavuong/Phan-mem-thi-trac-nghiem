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
    public partial class frmAdminDangNhap : Form
    {
               
        public frmAdminDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(txtTenDN.Text==""||txtMatKhau.Text=="")
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin đăng nhập");
                txtTenDN.SelectAll();
            }            
            else
            {
                DataTable dt = new B_Admin().get_tbAdmin(txtMatKhau.Text, txtTenDN.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Bạn đã đăng nhập thành công!");
                    frmTaoVaChinhSuaDeThi frmTaoDe = new frmTaoVaChinhSuaDeThi();
                    frmTaoDe.ShowDialog();
                }
                else
                    MessageBox.Show("Đăng nhập không thành công!");
            }
        
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            this.Hide();
            main.ShowDialog();
        }

        private void frmAdminDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmAdminDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
