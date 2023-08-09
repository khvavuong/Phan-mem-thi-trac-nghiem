using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;
using Entities;

namespace Data_Tier
{
    public class D_SinhVien :General_data
    {
        public DataSet get_tbSinhVien(string strpass, string strtensinhvien)
        {
            OleDbCommand cmd = new OleDbCommand("select * from tbsinhvien where matKhau=@matKhau and tensinhvien=@tensinhvien ", cnn);
            cmd.Parameters.Add("@matKhau", OleDbType.BSTR).Value = strpass;
            cmd.Parameters.Add("@tensinhvien", OleDbType.BSTR).Value = strtensinhvien;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "tbsinhvien");
            return ds;
        }
    }
}
