using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Data_Tier;
using Entities;
namespace Business_Tier
{
    public class B_SinhVien
    {
        D_SinhVien objsinhvien = new D_SinhVien();
        public DataTable get_tbSinhVien_B(string strpass, string strtensinhvien)
        {
            return objsinhvien.get_tbSinhVien(strpass, strtensinhvien).Tables["tbsinhvien"];
        }
    }
}
