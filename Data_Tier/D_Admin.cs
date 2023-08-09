using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;
using Entities;
namespace Data_Tier
{
    public class D_Admin:General_data
    {
       public DataSet get_tbAdmin(string strpass, string strtendangnhap)
        {
            OleDbCommand cmd = new OleDbCommand("select * from tbadmin where matKhau=@matKhau and tenDangNhap=@tenDangNhap ", cnn);
           cmd.Parameters.Add("@matKhau", OleDbType.BSTR).Value = strpass;
           cmd.Parameters.Add("@tenDangNhap", OleDbType.BSTR).Value = strtendangnhap;
           OleDbDataAdapter da = new OleDbDataAdapter(cmd);
           DataSet ds = new DataSet();
           da.Fill(ds, "tbadmin");
           return ds;
       }
    }
}
