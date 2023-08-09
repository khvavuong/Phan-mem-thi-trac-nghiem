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
    public partial class frmTheLoai : Form
    {
        B_ChuDe objchude = new B_ChuDe();
        DataTable tbchude;
        public static string strMaChuDe_Chon = "";
        public DataView dv;
        BindingSource bs = new BindingSource();

        public frmTheLoai()
        {
            InitializeComponent();
            tbchude = objchude.get_tbchude();
        }

        private void frmTheLoai_Load(object sender, EventArgs e)
        {
           // btnXoa.Enabled = false;
           dv = new DataView(tbchude);
            Load_ChuDe(dv);
            txtMaChuDe.ReadOnly = true;
            
           
            
        }
        //ok
        private void Load_ChuDe(DataView dv)
        {
            lvwTenChuDe.Items.Clear();
            foreach (DataRowView dr in dv)
            {
                ListViewItem li = lvwTenChuDe.Items.Add(dr["maChuDe"].ToString());
              // li.SubItems.Add(dr["maChuDe"].ToString());
                li.SubItems.Add(dr["tenChuDe"].ToString());
                //lvwTenChuDe.Items.Add(li);
            }
        }
        //ok
        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmTaoVaChinhSuaDeThi frmtaode = new frmTaoVaChinhSuaDeThi();
            frmtaode.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaChuDe.ReadOnly = false;
            txtNoiDungChuDe.Clear();
            txtMaChuDe.Clear();
            txtMaChuDe.Focus();
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //DataView dv = new DataView(tbchude);
           // int vitri;
            if (lvwTenChuDe.SelectedItems.Count > 0)
            {
                ChuDe ch = new ChuDe(txtMaChuDe.Text,txtNoiDungChuDe.Text);

                if (objchude.xoa_chude_B(ch)==1)
                {
                    MessageBox.Show("Xóa thành công");
                    capnhatlistlistview();
                    txtMaChuDe.Clear();
                    txtNoiDungChuDe.Clear();

                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
            else
                MessageBox.Show("Bạn chưa chọn chủ đề cần xóa!");

        }

        private void capnhatlistlistview()
        {
            lvwTenChuDe.Items.Clear();
            tbchude = objchude.get_tbchude();
            foreach (DataRow dr in tbchude.Rows)
            {
                ListViewItem li = lvwTenChuDe.Items.Add(dr["maChuDe"].ToString());
                li.SubItems.Add(dr["tenChuDe"].ToString());

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
            if (lvwTenChuDe.SelectedItems.Count > 0)
            {

                ChuDe cd_sua = new ChuDe(txtMaChuDe.Text,txtNoiDungChuDe.Text);
                if (objchude.sua_chude_B(cd_sua) == 1)
                {
                    MessageBox.Show("Sửa thành công");
                    capnhatlistlistview();
                    txtMaChuDe.Clear();
                    txtNoiDungChuDe.Clear();

                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng muốn sửa");
            }
        }

        private void txtMaChuDe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)&&!Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Mã chủ đề chỉ được nhập số");
            }
        }

        private void lvwTenChuDe_Click(object sender, EventArgs e)
        {
            //strMaChuDe_Chon = lvwTenChuDe.SelectedItems[0].ToString();

            //tbchude = objchude.getrow_tbchude(strMaChuDe_Chon);
            //txtMaChuDe.Text = tbchude.Rows[0]["maChuDe"].ToString();
            //txtNoiDungChuDe.Text = tbchude.Rows[1]["TenChuDe"].ToString();

            
        }

        private void lvwTenChuDe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwTenChuDe.SelectedItems.Count>0)
            {
                ListViewItem li = lvwTenChuDe.SelectedItems[0];
                txtMaChuDe.Text = li.Text;
                txtNoiDungChuDe.Text = li.SubItems[1].Text;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            if (txtNoiDungChuDe.Text == "" || txtMaChuDe.Text == "")
            {
                DialogResult dl = MessageBox.Show("Vui lòng nhập nội dung chủ đề", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                txtMaChuDe.Focus();

            }
            else
            {
                DataRow row = tbchude.NewRow();

                row[0] = txtMaChuDe.Text;
                row[1] = txtNoiDungChuDe.Text;
                tbchude.Rows.Add(row);
                objchude.CapNhat_tbchude(tbchude);
                Load_ChuDe(dv);
                txtNoiDungChuDe.ResetText();
                MessageBox.Show("Thêm thành công!");
                txtMaChuDe.Clear();
                txtNoiDungChuDe.Clear();


            }
        }
    }
}
