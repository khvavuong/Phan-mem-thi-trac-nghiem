using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;
using Entities;

namespace Data_Tier
{
    public class D_ChuDe:General_data
    {

        public DataSet getAll_chude()
        {
            OleDbCommand cmd = new OleDbCommand("select * from tbchude ", cnn);
            
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "tbchude");
            return ds;
        }
        public DataSet getrow_tbchude(string strmachude)
        {
            OleDbCommand cmd=new OleDbCommand("select * from tbchude where maChuDe='"+strmachude+"'",cnn);
            //cmd.Parameters.Add("@maChuDe", OleDbType.BSTR).Value = strmachude;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, strmachude);
            return ds;
        }
        public int XoaChuDe(ChuDe chude)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("delete from tbchude where maChuDe='"+chude.MaChuDe+"'", cnn);
            //cmd.Parameters.Add("@maChuDe", OleDbType.BSTR).Value = ch;
            int n = cmd.ExecuteNonQuery();
            cnn.Close();
            return n;
        }
        public int SuaChuDe(ChuDe chude)
        {
            bool kt = KiemTra_MaChuDe(chude.MaChuDe);
            string SQL = "";
            cnn.Open();
            if (kt==true)
            {
                SQL="update tbchude set tenchude='"+chude.TenChuDe+"' where machude='"+chude.MaChuDe+"'";  
            }
            else
            {
                return 0;
            }
            OleDbCommand cmd = new OleDbCommand(SQL, cnn);
            int n = cmd.ExecuteNonQuery();
            cnn.Close();
            return n;
        }

        public bool KiemTra_MaChuDe(string macd)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from tbchude where maChuDe=@maChuDe", cnn);
            cmd.Parameters.Add("@maChuDe", OleDbType.BSTR).Value = macd;
            OleDbDataReader dr = cmd.ExecuteReader();
            bool n = dr.Read();
            dr.Close();
            cnn.Close();
            return n;
        }
    }
}
