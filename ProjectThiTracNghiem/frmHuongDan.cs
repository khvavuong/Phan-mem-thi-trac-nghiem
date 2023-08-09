using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectThiTracNghiem
{
    public partial class frmHuongDan : Form
    {
        public frmHuongDan()
        {
            InitializeComponent();
        }

        private void frmHuongDan_Load(object sender, EventArgs e)
        {
            frmMain ve_main = new frmMain();
            ve_main.Show();
        }
    }
}
