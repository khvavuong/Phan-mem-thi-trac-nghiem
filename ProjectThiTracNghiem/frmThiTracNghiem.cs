using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.Xml.Linq;

using Business_Tier;
using Entities;
using System.Data.SqlClient;

namespace ProjectThiTracNghiem
{
    public partial class frmThiTracNghiem : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=DESKTOP-KN8R2E4;Initial Catalog=DiemThiTracNghiem;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private List<CauHoi> arrCauHoi = new List<CauHoi>();
        B_CauHoi objcauhoi = new B_CauHoi();
        
        CauHoi cautracnghiem = new CauHoi();
        BindingSource bs = new BindingSource();
        public frmThiTracNghiem()
        {
            InitializeComponent();
        }
        int cauHienTai = 0;

        int flag = 0;

        int tongThoiGianThi;

        private DateTime thoiGianThi;
        int soCauDung = 0;//tính số câu đúng
        float diemThi = 0;//tính điểm thi
        private void frmThiThu_Load(object sender, EventArgs e)
        {
            //enable các button xem, bắt đầu, câu tiếp,câu trước và kết thúc
            btnXemDapAn.Enabled = false;
            btnBatDau.Enabled = false;
            btnCauTiep.Enabled = false;
            btnCauTruoc.Enabled = false;
            btnKetThuc.Enabled = false;
            Bat_TatRadiobutton(false);
            timer1.Stop();
        }

        //bật tắt radbtn
        private void Bat_TatRadiobutton(bool p)
        {
            radA.Enabled=p;
            radB.Enabled=p;
            radC.Enabled=p;
            radD.Enabled=p;
        }


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
                if (arrCauHoi[i].CauTraLoi == arrCauHoi[i].DapAnDung)
                {
                    soCauDung++;
                    diemThi += (float)10 / arrCauHoi.Count;
                }
            }
            lblCauDung.Text = soCauDung.ToString() + "/" + arrCauHoi.Count.ToString();
            lblDiem.Text = diemThi.ToString();
            if (diemThi<5)
            {
                lblDanhGia.Text = "Khong dat";

            }
            else if(diemThi >=5&& diemThi<=7)
            {
                lblDanhGia.Text = "Kha";
            }
            else if(diemThi>7 && diemThi<=10)
            {
                lblDanhGia.Text = "Tot";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dl == DialogResult.OK)
            {
                this.Hide();
                frmMain frmve_main = new frmMain();
                frmve_main.ShowDialog();
            }
        }

        private int KiemTra_TraLoi()
        {
            if (radA.Checked == true || radB.Checked == true 
                || radC.Checked == true || radD.Checked == true)
                return 1;
            return 0;

        }

        //tô xong màu những câu đúng
        private void DoiMauCauDung(int cauHienTai)
        {
            if (arrCauHoi[cauHienTai].DapAnDung == 1)
            {
                lblDapAnA.BackColor = Color.Red;
                lblDapAnB.BackColor = Color.Yellow;
                lblDapAnC.BackColor = Color.Yellow;
                lblDapAnD.BackColor = Color.Yellow;
            }
            else if (arrCauHoi[cauHienTai].DapAnDung == 2)
            {
                lblDapAnA.BackColor = Color.Yellow;
                lblDapAnB.BackColor = Color.Red;
                lblDapAnC.BackColor = Color.Yellow;
                lblDapAnD.BackColor = Color.Yellow;
            }
            else if (arrCauHoi[cauHienTai].DapAnDung == 3)
            {
                lblDapAnA.BackColor = Color.Yellow;
                lblDapAnB.BackColor = Color.Yellow;
                lblDapAnC.BackColor = Color.Red;
                lblDapAnD.BackColor = Color.Yellow;
            }
            else if (arrCauHoi[cauHienTai].DapAnDung == 4)
            {
                lblDapAnA.BackColor = Color.Yellow;
                lblDapAnB.BackColor = Color.Yellow;
                lblDapAnC.BackColor = Color.Yellow;
                lblDapAnD.BackColor = Color.Red;
            }
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

        private void LoadDeThi()
        {
            OpenFileDialog mode = new OpenFileDialog();
         
            mode.Filter = "XML file(*.xml)|*.xml|All file(*.*)|*.*";
            if (mode.ShowDialog()==DialogResult.OK)
            {
                arrCauHoi.Clear();
                string path = mode.FileName;
                txtDuongDan.Text = path;
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlElement root = doc.DocumentElement;
                XmlNodeList rootCauHoi = root.ChildNodes;
                for(int i=0;i<rootCauHoi.Count;i++)
                {
                    CauHoi cautracnghiem = new CauHoi();
                    XmlNode nodeNoiDung = rootCauHoi[i].SelectSingleNode("NoiDung");
                    cautracnghiem.NoiDung = nodeNoiDung.InnerText.ToString();
                    XmlNode nodeDapAnA = rootCauHoi[i].SelectSingleNode("DapAnA");
                    cautracnghiem.DapAnA = nodeDapAnA.InnerText.ToString();
                    XmlNode nodeDapAnB = rootCauHoi[i].SelectSingleNode("DapAnB");
                    cautracnghiem.DapAnB = nodeDapAnB.InnerText.ToString();
                    XmlNode nodeDapAnC = rootCauHoi[i].SelectSingleNode("DapAnC");
                    cautracnghiem.DapAnC = nodeDapAnC.InnerText.ToString();
                    XmlNode nodeDapAnD = rootCauHoi[i].SelectSingleNode("DapAnD");
                    cautracnghiem.DapAnD = nodeDapAnD.InnerText.ToString();
                    XmlNode nodeDapAnDung = rootCauHoi[i].SelectSingleNode("DapAnDung");
                    cautracnghiem.DapAnDung = int.Parse(nodeDapAnDung.InnerText);

                    arrCauHoi.Add(cautracnghiem);
                }
                DialogResult dl=MessageBox.Show("Đề thi được nạp thành công!. Nhấn [Bắt đầu] để làm bài", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dl == DialogResult.OK)
                {
                    btnDuongDan.Enabled = false;
                    btnBatDau.Enabled = true;
                    tongThoiGianThi = arrCauHoi.Count * 600;
                    thoiGianThi = new DateTime(2000, 1, 1, 0, tongThoiGianThi / 60, tongThoiGianThi % 60, 0);
                    lblThoiGianConLai.Text = thoiGianThi.Minute.ToString() + ":" + thoiGianThi.Second.ToString();

                }
            }
            else
            {
                DialogResult dl = MessageBox.Show("Đề thi chưa được nạp. Bạn không thể bắt đầu bài thi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (dl == DialogResult.OK)
                {
                    btnDuongDan.Enabled = true;
                    btnBatDau.Enabled = false;
                }
            }
        }
        private void btnBatDau_Click(object sender, EventArgs e)
        {
            if(txtMSSV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin MSSV");
            }
            else
            {
                DialogResult dl = MessageBox.Show("Thời gian làm bài bắt đầu đếm ngược. Điểm tối đa là 10 điểm.\n\rĐề thi có" + " " + arrCauHoi.Count.ToString() + " " + "câu hỏi" + " Chúc bạn thi tốt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                {
                    if (dl == DialogResult.OK)
                    {
                        timer1.Start();
                        btnBatDau.Enabled = false;
                        btnDuongDan.Enabled = false;
                        btnKetThuc.Enabled = true;
                        btnXemDapAn.Enabled = false;
                        btnMSSV.Enabled = false;
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
        }

        //lưu kết quả thi vào sql
        private void luuKetQua()
        {
            lblCauDung.Text = soCauDung.ToString();
            lblDiem.Text = diemThi.ToString();

            command = connection.CreateCommand();
            command.CommandText = "insert into dbo.tbdiemthi values('" + txtMSSV.Text + "','" + lblCauDung.Text + "','" + lblCauDung.Text + "','" + lblDanhGia.Text + "')"; // truy vấn sql
            command.ExecuteNonQuery(); // báo lỗi
            MessageBox.Show("Đã lưu kết quả điểm thi của sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            KiemTraKetQua();

            //kết nối sql
            connection = new SqlConnection(str);
            connection.Open();

            luuKetQua();

            btnKetThuc.Enabled = false; 
            btnMSSV.Enabled = true;
            btnXemDapAn.Enabled = true;
            btnBatDau.Enabled = false;
            btnDuongDan.Enabled = false;
            Bat_TatRadiobutton(false);
        }
        private void btnCauTiep_Click(object sender, EventArgs e)
        {
            if (cauHienTai <= arrCauHoi.Count - 2)
            {
                flag = 1;
                cauHienTai++;
                MoTrangThai_Radiobutton(arrCauHoi[cauHienTai].CauTraLoi);
                if (flag == 1)
                {
                    lblCauHoi.Text = (cauHienTai + 1).ToString() + "." + arrCauHoi[cauHienTai].NoiDung;
                    lblDapAnA.Text = arrCauHoi[cauHienTai].DapAnA;
                    lblDapAnB.Text = arrCauHoi[cauHienTai].DapAnB;
                    lblDapAnC.Text = arrCauHoi[cauHienTai].DapAnC;
                    lblDapAnD.Text = arrCauHoi[cauHienTai].DapAnD;
                    lblDapAnA.BackColor = Color.Yellow;
                    lblDapAnB.BackColor = Color.Yellow;
                    lblDapAnC.BackColor = Color.Yellow;
                    lblDapAnD.BackColor = Color.Yellow;
                }
            }
            else flag = 0;

        }


        private void btnCauTruoc_Click(object sender, EventArgs e)
        {
            if (cauHienTai <= arrCauHoi.Count - 1)
            {
                flag = 1;
                cauHienTai--;
                if (cauHienTai >= 0)
                {
                    MoTrangThai_Radiobutton(arrCauHoi[cauHienTai].CauTraLoi);
                    if (flag == 1)
                    {
                        lblCauHoi.Text = (cauHienTai + 1).ToString() + "." + arrCauHoi[cauHienTai].NoiDung;
                        lblDapAnA.Text = arrCauHoi[cauHienTai].DapAnA;
                        lblDapAnB.Text = arrCauHoi[cauHienTai].DapAnB;
                        lblDapAnC.Text = arrCauHoi[cauHienTai].DapAnC;
                        lblDapAnD.Text = arrCauHoi[cauHienTai].DapAnD;
                        lblDapAnA.BackColor = Color.Yellow;
                        lblDapAnB.BackColor = Color.Yellow;
                        lblDapAnC.BackColor = Color.Yellow;
                        lblDapAnD.BackColor = Color.Yellow;
                    }
                }
                else
                {
                    cauHienTai = 0;
                }
            }
            else flag = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan dt = new TimeSpan(0, 0, 1);
            thoiGianThi = thoiGianThi.Subtract(dt);
            lblThoiGianConLai.Text = thoiGianThi.Minute.ToString() + " : " + thoiGianThi.Second.ToString();
            if (thoiGianThi.Minute == 0 && thoiGianThi.Second == 0)
            {
                timer1.Enabled = false;
                DialogResult dl = MessageBox.Show("Thời gian làm bài đã hết. Mời bạn xem kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                {
                    if (dl == DialogResult.OK)
                    {
                        KiemTraKetQua();
                        luuKetQua();
                    }

                }
            }
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

        private void btnXemDapAn_Click(object sender, EventArgs e)
        {
            DoiMauCauDung(cauHienTai);
            
        }

        private void btnDuongDan_Click(object sender, EventArgs e)
        {
            LoadDeThi();
            btnKetThuc.Enabled = false;
            Bat_TatRadiobutton(false);
        }

        private void txtDuongDan_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmThiThu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
