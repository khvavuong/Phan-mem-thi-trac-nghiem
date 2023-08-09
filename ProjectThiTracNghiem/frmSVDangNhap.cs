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
    public partial class frmSVDangNhap : Form
    {
        B_SinhVien objsinhvien = new B_SinhVien();
        public frmSVDangNhap()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain main = new frmMain();
            main.ShowDialog();
           
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            string mssv = txtMSSV.Text;
            long ketQua;
            if (txtTaiKhoanSV.Text == "" || txtMatKhau.Text == "" || txtMSSV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin!");
                txtTaiKhoanSV.SelectAll();
            }
            else if(!(long.TryParse(mssv, out ketQua)))
            {
                MessageBox.Show("Nhập đúng định dạng MSSV");
                txtMSSV.Focus();
            }
            else if(ketQua < 0)
            {
                MessageBox.Show("Nhập đúng định dạng MSSV");
                txtMSSV.Focus();
            }
            else
            {
                DataTable dt = new B_SinhVien().get_tbSinhVien_B(txtMatKhau.Text, txtTaiKhoanSV.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Bạn đã đăng nhập thành công!");
                    if (radTracNghiem.Checked == false && radThi.Checked == false)
                    {
                        MessageBox.Show("Bạn chưa chọn hình thức thi!", "Thông báo");
                    }
                    else
                    {
                        if (radTracNghiem.Checked == true)
                        {
                            frmThiTracNghiem frmLuyenTap = new frmThiTracNghiem();
                            frmLuyenTap.Show();
                            this.Hide();
                        }
                    }   
                }
                else
                    MessageBox.Show("Đăng nhập không thành công!");
            }
        }

        private void frmSVDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmSVDangNhap_Load(object sender, EventArgs e)
        {
            
        }

        private void txtTaiKhoanSV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
