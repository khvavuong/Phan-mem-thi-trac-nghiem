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
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblThongTin.Text = " Khuất Văn Vương - 20216906 - 142297 \n Project cuối kỳ Kỹ thuật lập trình - MI3310 \n Chương trình thi trắc nghiệm";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {

            this.Hide();
            frmMain main = new frmMain();
            main.ShowDialog();
            //this.Close();
        }

        private void lblThongTin_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
