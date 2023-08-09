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
    public partial class frmThiThu : Form
    {
        private List<CauHoi> arrCauHoi = new List<CauHoi>();

        CauHoi cautracnghiem = new CauHoi();
        B_CauHoi cauHoi = new B_CauHoi();
        DataTable tbcauhoi;
        public frmThiThu()
        {
            InitializeComponent();
        }
        int cauHienTai = 0;
        int flag = 0;
        bool flaga = false;
        bool flagb = false;
        bool flagc = false;
        bool flagd = false;
        int tongThoiGianThi;

        int soCauDung = 0;//tính số câu đúng
        float diemThi = 0;//tính điểm thi
        private DateTime thoiGianThi;
        private TimeSpan thoigianhet;
        private Timer thoigian;
        private bool hetgio = false;

        //

        #region ________xử lý___________
        //ok
        private void Bat_TatRadiobutton(bool p)
        {
            radA.Enabled = p;
            radB.Enabled = p;
            radC.Enabled = p;
            radD.Enabled = p;
        }
        //ok
        private void MoTrangThai_Radiobutton(int radio)
        {
            if (radio == 1)

                radA.Checked = true;
            else if (radio == 2)
                radB.Checked = true;
            else if (radio == 3)
                radC.Checked = true;
            else if (radio == 4)
                radD.Checked = true;
            else
            {
                radA.Checked = false;
                radB.Checked = false;
                radC.Checked = false;
                radD.Checked = false;
            }

        }
        //kiểm tra kết quả
        private void KiemTraKetQua()
        {
            for (int i = 0; i < arrCauHoi.Count; i++)
            {
                soCauDung++;
                diemThi = diemThi + (float)10 / arrCauHoi.Count;

            }
            lblCauDung.Text = soCauDung.ToString() + "/" + arrCauHoi.Count.ToString();
            lblDiem.Text = diemThi.ToString();
            if (diemThi < 5)
            {
                lblDanhGia.Text = "Không đạt yêu cầu !";

            }
            else if (diemThi >= 5 && diemThi <= 7)
            {
                lblDanhGia.Text = "Đạt yêu cầu .Tốt";
            }
            else if (diemThi > 7 && diemThi <= 10)
            {
                lblDanhGia.Text = "Đạt yêu cầu .Khá";
            }
        }
        //kiểm tra câu trả lời
        private int KiemTra_TraLoi()
        {
            if (radA.Checked == true || radB.Checked == true || radC.Checked == true || radD.Checked == true)
                return 1;
            return 0;

        }
        //luu xong
        private void Luu_CauTraLoi()
        {
            if (KiemTra_TraLoi() == 1)
            {
                if (radA.Checked == true)
                    arrCauHoi[cauHienTai].CauTraLoi = 1;
                if (radB.Checked == true)
                    arrCauHoi[cauHienTai].CauTraLoi = 2;
                if (radC.Checked == true)
                    arrCauHoi[cauHienTai].CauTraLoi = 3;
                if (radD.Checked == true)
                    arrCauHoi[cauHienTai].CauTraLoi = 4;

            }
            else
                arrCauHoi[cauHienTai].CauTraLoi = 0;
        }
        //tô xong màu những câu đúng
        private void DoiMauCauDung(int cauHienTai)
        {
            int temp = arrCauHoi[cauHienTai].DapAnDung;
            if (temp == 1)
            {
                flaga = true;
                flagb = false;
                flagc = false;
                flagd = false;
            }
            if (temp == 2)
            {
                flaga = false;
                flagb = true;
                flagc = false;
                flagd = false;
            }
            if (temp == 3)
            {
                flaga = false;
                flagb = false;
                flagc = true;
                flagd = false;
            }

            if (temp == 4)
            {
                flaga = false;
                flagb = false;
                flagc = false;
                flagd = true;
            }
            lblDapAnA.BackColor = flaga ? Color.Red : Color.White;
            lblDapAnB.BackColor = flaga ? Color.Red : Color.White;
            lblDapAnC.BackColor = flaga ? Color.Red : Color.White;
            lblDapAnD.BackColor = flaga ? Color.Red : Color.White;
        }
        private void LoadDe()
        {

        }
        //load de thi nua!!!
        //đề thi phải cho load tự động lên khi thi thật
        #endregion
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan dt = new TimeSpan(0, 0, 1);
            //thoiGianThi = thoiGianThi.Subtract(dt);
            lblThoiGianconLai.Text = thoiGianThi.Minute.ToString() + ":" + thoiGianThi.Second.ToString();
            if (thoiGianThi.Minute == 0 && thoiGianThi.Second == 0)
            {
                ThoiGianThi.Enabled = false;
                DialogResult dl = MessageBox.Show("Thời gian làm bài đã hết.Mời bạn xem kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                {
                    if (dl == DialogResult.OK)
                        KiemTraKetQua();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frmve_main = new frmMain();
            frmve_main.ShowDialog();
        }

        private void frmThiTracNghiem_Load(object sender, EventArgs e)
        {
            NapCauHoi();
            DataTable dtcauhoi = new B_CauHoi().getAll_cauhoi();

        }

        private void NapCauHoi()
        {
            tbcauhoi = cauHoi.getAll_cauhoi();
           DataView dv = new DataView(tbcauhoi);
            
            foreach(DataRow dr in tbcauhoi.Rows)
            {
                //arrCauHoi.Add(dr["macauhoi"].ToString());
                //NapCauHoi(dr["macauhoi"].ToString());
            }


        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {

            DialogResult dl = MessageBox.Show("Thời gian làm bài bắt đầu đếm ngược.Điểm tối đa là 10 điểm.\n\rĐề thi có" + " " + arrCauHoi.Count.ToString() + " " + "câu hỏi" + " Chúc bạn thi tốt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            {
                if (dl == DialogResult.OK)
                {
                   
                    ThoiGianThi.Start();
                    btnBatDau.Enabled = false;
                    btnKetThuc.Enabled = true;
                    btnCauTiep.Enabled = true;
                    btnCauTruoc.Enabled = true;
                    Bat_TatRadiobutton(true);
                    lblCauHoi.Text = "1. " + arrCauHoi[0].NoiDung;
                    lblDapAnA.Text = arrCauHoi[0].DapAnA;
                    lblDapAnB.Text = arrCauHoi[0].DapAnB;
                    lblDapAnC.Text = arrCauHoi[0].DapAnC;
                    lblDapAnD.Text = arrCauHoi[0].DapAnD;
                }
            }
        }

       
        private void btnCauTiep_Click(object sender, EventArgs e)
        {
            if (cauHienTai <= arrCauHoi.Count - 2)
            {
                cauHienTai = cauHienTai + 1;
               MoTrangThai_Radiobutton(arrCauHoi[cauHienTai].CauTraLoi);
                if (flag == 1)
                {
                    DoiMauCauDung(cauHienTai);
                    lblCauHoi.Text = (cauHienTai + 1).ToString() + "." + arrCauHoi[cauHienTai].NoiDung;
                    lblDapAnA.Text = arrCauHoi[cauHienTai].DapAnA;
                    lblDapAnB.Text = arrCauHoi[cauHienTai].DapAnB;
                    lblDapAnC.Text = arrCauHoi[cauHienTai].DapAnC;
                    lblDapAnD.Text = arrCauHoi[cauHienTai].DapAnD;

                }
            }
        }

        private void btnCauTruoc_Click(object sender, EventArgs e)
        {
            if (cauHienTai <= arrCauHoi.Count - 1)
            {
                cauHienTai = cauHienTai - 1;
                if (cauHienTai >= 0)
                {
                    MoTrangThai_Radiobutton(arrCauHoi[cauHienTai].CauTraLoi);
                    if (flag == 1)
                        DoiMauCauDung(cauHienTai);
                    lblCauHoi.Text = (cauHienTai + 1).ToString() + "." + arrCauHoi[cauHienTai].NoiDung;
                    lblDapAnA.Text = arrCauHoi[cauHienTai].DapAnA;
                    lblDapAnB.Text = arrCauHoi[cauHienTai].DapAnB;
                    lblDapAnC.Text = arrCauHoi[cauHienTai].DapAnC;
                    lblDapAnD.Text = arrCauHoi[cauHienTai].DapAnD;
                }
                else
                {
                    cauHienTai = 0;
                }
            }
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            ThoiGianThi.Stop();
            KiemTraKetQua();
            btnBatDau.Enabled = false;
            Bat_TatRadiobutton(false);
        }

        private void radA_CheckedChanged(object sender, EventArgs e)
        {
            Luu_CauTraLoi();
        }

        private void radB_CheckedChanged(object sender, EventArgs e)
        {
            Luu_CauTraLoi();
        }

        private void radC_CheckedChanged(object sender, EventArgs e)
        {
            Luu_CauTraLoi();
        }

        private void radD_CheckedChanged(object sender, EventArgs e)
        {
            Luu_CauTraLoi();
        }
    }
}
