using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;
using Entities;
namespace Data_Tier
{
    public class D_CauHoi:General_data
    {
        public DataSet getCauHoi_Theo_MaChuDe(string strChuDe)
        {
            OleDbCommand cmd = new OleDbCommand("select * from tbcauhoi where maCauHoi=@maCauHoi",cnn);

            cmd.Parameters.Add("@maChuDe", OleDbType.BSTR).Value = strChuDe;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "tbcauhoi");
            return ds;

        }
        public DataSet getCauHoi_Theo_MaCauHoi(string strCauHoi)
        {
            OleDbCommand cmd = new OleDbCommand("select *from tbcauhoi where maCauHoi='"+strCauHoi+"'",cnn);
            //cmd.Parameters.Add("@maCauHoi", OleDbType.BSTR).Value = strCauHoi;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "tbcauhoi");
            return ds;
        }
        public DataView ShowCauHoi_TheoMaChuDe(String machude)
        {
            OleDbCommand cmd = new OleDbCommand("select from tbcauhoi where maChuDe=@maChuDe", cnn);
            cmd.Parameters.Add("@maChuDe", OleDbType.BSTR).Value = machude;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet("tbcauhoi");
            da.Fill(ds, "tbcauhoi");
            DataView dv = new DataView(ds.Tables["tbcauhoi"]);
            return dv;
        }
        public bool Check_MaCauHoi(String macauhoi)
        {
            MoKetNoi();
            OleDbCommand cmd = new OleDbCommand("select *  from tbcauhoi where maCauHoi='"+macauhoi+"'", cnn);
           // cmd.Parameters.Add("@maCauHoi", OleDbType.BSTR).Value = macauhoi;
            OleDbDataReader dr = cmd.ExecuteReader();
          
           bool n = dr.Read();
            DongKetNoi();
            return n;
        }
        //String macauhoi,String machude,String noidung,String dapana,String dapanb,String dapanc,String dapand ,String dapandung
        public int Add_CauHoi(CauHoi CH)
        {
            string SQL = " ";
            bool kt = Check_MaCauHoi(CH.MaCauhoi);
            if (kt == true)
            {
                return 0;
            }
            else
            {
                SQL = "insert into tbcauhoi values('" + CH.MaCauhoi + "','" + CH.MaChuDe + "','" + CH.NoiDung + "','" + CH.DapAnA + "','" + CH.DapAnB + "','" + CH.DapAnC + "','" + CH.DapAnD + "','" + CH.DapAnDung + "')";
            }

            MoKetNoi();
            OleDbCommand cmd = new OleDbCommand(SQL, cnn);
            int n = cmd.ExecuteNonQuery();
            DongKetNoi();
            return n;
        }
        public int Update_CauHoi(CauHoi CH)
        {
            string SQL = " ";
            bool kt = Check_MaCauHoi(CH.MaCauhoi);
            if (kt == true)
            {
                SQL = "update tbcauhoi set machude='" + CH.MaChuDe + "',noidung='" + CH.NoiDung + "',dapana='" + CH.DapAnA + "',dapanb='" + CH.DapAnB + "',dapanc='" + CH.DapAnC + "',dapand='" + CH.DapAnD + "',dapandung='" + CH.DapAnDung + "' where macauhoi='" + CH.MaCauhoi + "'";
            }
            else
            {
                return 0;
            }

            MoKetNoi();
            OleDbCommand cmd = new OleDbCommand(SQL, cnn);
            int n = cmd.ExecuteNonQuery();
            DongKetNoi();
            return n;
        }
        public int Xoa_CauHoi(CauHoi CH)
        {
            try
            {
	            MoKetNoi();
	            OleDbCommand cmd = new OleDbCommand("delete from tbcauhoi where maCauHoi='"+CH.MaCauhoi+"'", cnn);
	           
	            int n = cmd.ExecuteNonQuery();
	            DongKetNoi();
	            return n;
                }
            catch (Exception )
            {
                return -1;
            }
        }
    }
}
