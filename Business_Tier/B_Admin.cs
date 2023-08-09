using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Data_Tier;
using Entities;
namespace Business_Tier
{
    public class B_Admin
    {
        D_Admin objadmin = new D_Admin();

        public DataTable get_tbAdmin(string strpass, string strtendangnhap)
        {
            return objadmin.get_tbAdmin(strpass, strtendangnhap).Tables["tbadmin"];
        }
        public void CapNhat_Admin(DataTable tbTable)
        {
            objadmin.CapNhatDuLieu(tbTable, "tbadmin");
        }
    }
}
