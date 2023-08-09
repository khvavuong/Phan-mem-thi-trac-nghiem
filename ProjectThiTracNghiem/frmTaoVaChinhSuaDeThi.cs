using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;

using Business_Tier;
using Entities;

namespace ProjectThiTracNghiem
{
    public partial class frmTaoVaChinhSuaDeThi : Form
    {
        List<int> listChuDe = new List<int>();
        private List<CauHoi> arrCauHoi = new List<CauHoi>();

        B_Admin objadmin = new B_Admin();
        B_ChuDe objchude = new B_ChuDe();
        B_CauHoi objcauhoi = new B_CauHoi();

        DataTable tbcauhoi;
        DataTable tbchude;
        public int dapan_duocchon = 0;

        BindingSource bs = new BindingSource();
        public frmTaoVaChinhSuaDeThi()
        {
            InitializeComponent();
        }
        int cauHienTai = 0;
        int flag = 0;


        private string path = "";
        private bool isSaved = false;
        private bool isOpen = false;
        private bool isNew = false;
        private bool isEditing = true;

        string dapAnA;
        string dapAnB;
        string dapAnC;
        string dapAnD;

       private int dapAnDung=0;
       private int cautraloi = 0;
        private string noiDung;

        //
        //private int cauhientai=0;
        

        bool DaNapCombobox = false;
        //soạn câu hỏi
        private void Luu_DapAnDung()
        {
            //CauHoi cauhoi=new CauHoi()
            //var dsCauHoi=from objcauhoi in 
        }



        //ok
        private void btnThemChuDe_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTheLoai frmThemChuDe = new frmTheLoai();
            frmThemChuDe.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblGio.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
        }

        private void frmTaoVaChinhSuaDeThi_Load(object sender, EventArgs e)
        {
            lblNgay.Text ="Hôm nay, " + DateTime.Now.Day.ToString() + " - " + DateTime.Now.Month.ToString() + " - " + DateTime.Now.Year.ToString();

            DataTable dtchude = new B_ChuDe().getall_chude();
            cboChonChuDe.DataSource = dtchude;
            cboChonChuDe.DisplayMember = "tenChuDe";
            cboChonChuDe.ValueMember = "maChuDe";
            DaNapCombobox = true;

            DataTable dt_ch = new B_CauHoi().getAll_cauhoi();
            listCauHoi.DataSource = dt_ch;
            listCauHoi.DisplayMember = "maCauHoi";
            listCauHoi.ValueMember = "maCauHoi";
        }

        private void tooltlblTaoMoi_Click(object sender, EventArgs e)
        {
            //if ((isNew ))
            //{
            //}
        }
//ok
        private void tooltlblMoDe_Click(object sender, EventArgs e)
        {
            OpenFileDialog MoDe = new OpenFileDialog();
            MoDe.Filter = "XML file(*.xml)|*.xml|All file(*.*)|*.*";
            if (MoDe.ShowDialog() == DialogResult.Cancel)
                return;
            this.btnCauTruoc.Visible = true;
            this.btnCauSau.Visible = true;

           
            grbCauHoi.ResetText();
            isSaved = true;
            isOpen = true;
            grbCauHoi.Visible = true;
            btnThemCauHoi.Enabled = true;
            listCauHoi.Items.Clear();

            path = MoDe.FileName;
           // ReadFromXmlDocument
            //if ()
            //{
            //}
        }


        private void tooltLuu_Click(object sender, EventArgs e)

        {
            LuuCauHoi();
        }

        private void LuuCauHoi() // Lưu đề thi dưới dạng file .xml
        {
            CauHoi ch = new CauHoi();
            SaveFileDialog luu = new SaveFileDialog();
            luu.Filter = " XML file(*.xml)|*.xml|All file(*.*)|*.*";
            if (luu.ShowDialog() == DialogResult.OK)
            {                XmlDocument doc = new XmlDocument();
                XmlElement root = doc.CreateElement("DeThi");
                doc.AppendChild(root);
                XmlElement noodCau = doc.CreateElement("CauHoi");
                root.AppendChild(noodCau);

                XmlElement nodeNoiDung = doc.CreateElement("NoiDung");
                noodCau.AppendChild(nodeNoiDung);
                nodeNoiDung.InnerText = ch.NoiDung;

                XmlElement nodeDapAnA = doc.CreateElement("DapAnA");
                noodCau.AppendChild(nodeDapAnA);
                nodeDapAnA.InnerText = ch.DapAnA;

                XmlElement nodeDapAnB = doc.CreateElement("DapAnB");
                noodCau.AppendChild(nodeDapAnB);
                nodeDapAnB.InnerText = ch.DapAnB;

                XmlElement nodeDapAnC = doc.CreateElement("DapAnC");
                noodCau.AppendChild(nodeDapAnC);
                nodeDapAnC.InnerText = ch.DapAnC;

                XmlElement nodeDapAnD = doc.CreateElement("DapAnD");
                noodCau.AppendChild(nodeDapAnD);
                nodeDapAnD.InnerText = ch.DapAnD;

                XmlElement nodeDapAnDung = doc.CreateElement("DapAnDung");
                noodCau.AppendChild(nodeDapAnDung);
                nodeDapAnDung.InnerText = ch.DapAnDung.ToString();

                doc.Save(luu.Filter);
            }
        }

        private void tooltlblLuuTai_Click(object sender, EventArgs e)
        {
            LuuCauHoi();
        }

         private void tooltlblXoaCauHoi_Click(object sender, EventArgs e)
        {
            txtNoiDungCauHoi.Clear();
            txtDapAnA.Clear();
            txtDapAnB.Clear();
            txtDapAnC.Clear();
            txtDapAnD.Clear();
            radA.Checked = false;
            radB.Checked = false;
            radC.Checked = false;
            radC.Checked = false;
        }

        private void tooltlblXoaDapAn_Click(object sender, EventArgs e)
        {
            radA.Checked = false;
            radB.Checked = false;
            radC.Checked = false;
            radC.Checked = false;
        }

        private void btnChonChuDe_Click(object sender, EventArgs e)
        {
            frmTheLoai frmchude = new frmTheLoai();
            frmchude.ShowDialog();
            
            XoaTruongDuLieu();
        }

      
        //
        private void LoadDuLieu_ChuDe(DataView dv)
        {

            dv = new DataView(tbchude);

            cboChonChuDe.Items.Clear();
            foreach (DataRowView dr in tbchude.Rows)
            {
                ListViewItem li = new ListViewItem();
                li.Text = cboChonChuDe.SelectedValue.ToString();
                cboChonChuDe.Items.Add(dr["tenChuDe"].ToString());
            }
        }

        private void btnThemCauHoi_Click(object sender, EventArgs e)
        {
            txtMaCauHoi.Clear();
            txtNoiDungCauHoi.Clear();
            txtDapAnA.Clear();
            txtDapAnB.Clear();
            txtDapAnC.Clear();
            txtDapAnD.Clear();
            txtMaCauHoi.Focus();
            
        }

        private void btnXoaCauHoi_Click(object sender, EventArgs e)
        {
            if (txtNoiDungCauHoi.Text == "" ||
                txtDapAnA.Text == "" ||
                txtDapAnB.Text == "" ||
                txtDapAnC.Text == "" ||
                txtDapAnD.Text == "" )
            {
                DialogResult dl = MessageBox.Show("Vui lòng nhập đầy đủ nội dung câu hỏi và đáp án! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
           else if(radA.Checked==false&&radB.Checked==false&&radC.Checked==false&&radD.Checked==false)
            {
                DialogResult dl = MessageBox.Show("Bạn chưa chọn đáp án đúng cho câu hỏi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;

            }
            else if (cboChonChuDe.SelectedIndex<0)
            {
                DialogResult dl = MessageBox.Show("Vui lòng chọn chủ đề cho câu hỏi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                string macd="";
                CauHoi CH = new CauHoi(txtMaCauHoi.Text,macd,txtNoiDungCauHoi.Text,txtDapAnA.Text,txtDapAnB.Text,txtDapAnC.Text,txtDapAnD.Text,dapAnDung);
                if (objcauhoi.xoa_cauhoi(CH) == 1)
                {
                    MessageBox.Show("Xóa thành công ");
                    XoaTruongDuLieu();
                    txtMaCauHoi.Clear();
                    txtNoiDungCauHoi.Clear();
                    txtDapAnA.Clear();
                    txtDapAnB.Clear();
                    txtDapAnC.Clear();
                    txtDapAnD.Clear();
                    

                }
                else
                    MessageBox.Show("Xóa thất bại!!");

            }
        }
        //ko cần hiển thị lại nội dung câu hỏi trong listview
        private void LoadDuLieu_SoanCauHoi()
        {
            btnThemCauHoi.Enabled = true;

        }

        private void XoaTruongDuLieu()
        {
            btnThemCauHoi.Enabled = true;
            txtMaCauHoi.ResetText();
            txtNoiDungCauHoi.ResetText();
            txtDapAnA.ResetText();
            txtDapAnB.ResetText();
            txtDapAnC.ResetText();
            txtDapAnD.ResetText();
            radA.Checked = false;
            radB.Checked = false;
            radC.Checked = false;
            radD.Checked = false;

            cboChonChuDe.Text = null;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frmve_main = new frmMain();
            frmve_main.ShowDialog();
        }

        private void cboChonChuDe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DaNapCombobox)
            {
                DataView dv = new DataView(tbchude);
                dv.RowFilter = "tenChuDe='" + cboChonChuDe.SelectedValue + "'";
                LoadDuLieu_ChuDe(dv);
            }
        }


        private void btnCauTruoc_Click(object sender, EventArgs e)
        {
            if (cauHienTai <= arrCauHoi.Count - 1)
            {
                cauHienTai = cauHienTai - 1;
                if (cauHienTai >= 0)
                {
                    //MoTrangThai_Radiobutton(arrCauHoi[cauHienTai].CauTraLoi);
                    if (flag == 1)
                        // DoiMauCauDung(cauHienTai);
                    txtMaCauHoi.Text = arrCauHoi[cauHienTai].MaCauhoi;
                    txtNoiDungCauHoi.Text = (cauHienTai + 1).ToString() + "." + arrCauHoi[cauHienTai].NoiDung;
                    txtDapAnA.Text = arrCauHoi[cauHienTai].DapAnA;
                    txtDapAnB.Text = arrCauHoi[cauHienTai].DapAnB;
                    txtDapAnC.Text = arrCauHoi[cauHienTai].DapAnC;
                    txtDapAnD.Text = arrCauHoi[cauHienTai].DapAnD;
                }
                else
                {
                    cauHienTai = 0;
                }
            }
        }

        private void HienThiCauHoi(int p)
        {
            throw new NotImplementedException();
        }

        private void btnCauSau_Click(object sender, EventArgs e)
        {
            if (cauHienTai <= arrCauHoi.Count - 2)
            {
                cauHienTai = cauHienTai + 1;
                //MoTrangThai_Radiobutton(arrCauHoi[cauHienTai].CauTraLoi);
                if (flag == 1)
                {
                    txtMaCauHoi.Text = arrCauHoi[cauHienTai].MaCauhoi;
                    //DoiMauCauDung(cauHienTai);
                    txtNoiDungCauHoi.Text = (cauHienTai + 1).ToString() + "." + arrCauHoi[cauHienTai].NoiDung;
                    txtDapAnA.Text = arrCauHoi[cauHienTai].DapAnA;
                    txtDapAnB.Text = arrCauHoi[cauHienTai].DapAnB;
                    txtDapAnC.Text = arrCauHoi[cauHienTai].DapAnC;
                    txtDapAnD.Text = arrCauHoi[cauHienTai].DapAnD;

                }
            }
        }

        private void btnSuaCauHoi_Click(object sender, EventArgs e)//ok
        {
            CauHoi chfff = new CauHoi(txtMaCauHoi.Text, cboChonChuDe.SelectedValue.ToString(), txtNoiDungCauHoi.Text, txtDapAnA.Text, txtDapAnB.Text, txtDapAnC.Text, txtDapAnD.Text,dapan_duocchon);
            if (objcauhoi.update_CauHoi_B(chfff) == 1)
            {
                MessageBox.Show("Cập nhật thành công!!!!");
                DataTable dt_ch = new B_CauHoi().getAll_cauhoi();
                listCauHoi.DataSource = dt_ch;
                listCauHoi.DisplayMember = "maCauHoi";
                listCauHoi.ValueMember = "maCauHoi";
            }
            else
                MessageBox.Show("Cập nhật thất bại .");

        }

        private void radA_Click(object sender, EventArgs e)//ok
        {
            if (radA.Checked == true)
            {
                dapan_duocchon = 1;
            }
            if (radB.Checked == true)
            {
                dapan_duocchon =2;
            }
            if (radC.Checked == true)
            {
                dapan_duocchon = 3;
            }
            if (radD.Checked == true)
            {
                dapan_duocchon = 4;
            }
        }

       
        private void listCauHoi_SelectedIndexChanged(object sender, EventArgs e)//ok
        {
               
                DataTable dt = new B_CauHoi().gettbcauhoi_Theo_maCauHoi(listCauHoi.SelectedValue.ToString());
                foreach (DataRow dr in dt.Rows)
                {
                    txtMaCauHoi.Text = dr["maCauHoi"].ToString();

                    DataTable dtchude = new B_ChuDe().getrow_tbchude(dr["maChuDe"].ToString());
                    DataTable dt_ch = new B_CauHoi().getAll_cauhoi();
                    listCauHoi.DataSource = dt_ch;
                    listCauHoi.DisplayMember = "maCauHoi";
                    listCauHoi.ValueMember = "maCauHoi";
                    txtNoiDungCauHoi.Text = dr["noiDung"].ToString();
                    txtDapAnA.Text = dr["dapAnA"].ToString();
                    txtDapAnB.Text = dr["dapAnB"].ToString();
                    txtDapAnC.Text = dr["dapAnC"].ToString();
                    txtDapAnD.Text = dr["dapAnD"].ToString();
                }
            
            
        }

        private void btnSoanCauHoi_Click(object sender, EventArgs e)
        {
            if (txtNoiDungCauHoi.Text == "" || txtDapAnA.Text == "" || txtDapAnB.Text == ""
                || txtDapAnC.Text == "" || txtDapAnD.Text == "")
            {
                DialogResult r = MessageBox.Show("Vui lòng nhập đầy đủ nội dung câu hỏi và đáp án! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (radA.Checked == false && radB.Checked == false && radC.Checked == false && radD.Checked == false)
            {
                DialogResult r = MessageBox.Show("Bạn chưa chọn đáp án đúng cho câu hỏi. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cboChonChuDe.SelectedIndex < 0)
            {
                DialogResult r = MessageBox.Show("Vui lòng chọn chủ đề cho câu hỏi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                CauHoi ch = new CauHoi(txtMaCauHoi.Text, cboChonChuDe.SelectedValue.ToString(), txtNoiDungCauHoi.Text, txtDapAnA.Text, txtDapAnB.Text, txtDapAnC.Text, txtDapAnD.Text, dapAnDung);

                if (objcauhoi.Add_CauHoi_B(ch) == 1)
                {
                    MessageBox.Show("Thêm câu hỏi thành công!!");
                    DataTable dt_ch = new B_CauHoi().getAll_cauhoi();
                    listCauHoi.DataSource = dt_ch;
                    listCauHoi.DisplayMember = "maCauHoi";
                    listCauHoi.ValueMember = "maCauHoi";
                }
                else
                    MessageBox.Show("Thêm câu hỏi không thành công!");


            }
        }

        private void cboChonChuDe_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void lblNgay_Click(object sender, EventArgs e)
        {

        }
    }
}
