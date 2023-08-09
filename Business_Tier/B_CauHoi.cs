using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Data_Tier;
using Entities;
namespace Business_Tier
{
    public class B_CauHoi
    {
        D_CauHoi objCauHoi = new D_CauHoi();
        General_data objgd = new General_data();

        public DataTable gettbcauhoi_Theo_maCauHoi(string strmacauhoi)
        {
            return objCauHoi.getCauHoi_Theo_MaCauHoi(strmacauhoi).Tables["tbcauhoi"];

        }
        public DataTable gettbcauhoi_Theo_machude(string strmachude)
        {
            return objCauHoi.getCauHoi_Theo_MaChuDe(strmachude).Tables["tbcauhoi"];
        }
        public void CapNhat_tbcauhoi(DataTable tbTable)
        {
            objCauHoi.CapNhatDuLieu(tbTable, "tbcauhoi");
        }
        public int Add_CauHoi_B(CauHoi CH)
        {
            return objCauHoi.Add_CauHoi(CH);
        }
        public int update_CauHoi_B(CauHoi CH)
        {
            return objCauHoi.Update_CauHoi(CH);
        }
        public DataTable getAll_cauhoi()
        {
            return objgd.getAllTable("tbcauhoi").Tables[0];
        }
        public int xoa_cauhoi(CauHoi CH)
        {

            return objCauHoi.Xoa_CauHoi(CH);
        }
        //public int Check_MaCauHoi_B(CauHoi ch)
        //{

        //    return objCauHoi.Check_MaCauHoi(ch.MaCauhoi);
        //}
    }
}
