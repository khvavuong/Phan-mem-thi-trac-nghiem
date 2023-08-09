using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;
using Entities;

namespace Data_Tier
{
    public class General_data
    {
        //kết nối database
        public OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\C#\\Project\\ProjectThiTracNghiem\\CrystalReport_Tutorial\\dbProjectThiTracNghiem.accdb;Persist Security Info=True");

        public void MoKetNoi()
        {
            if (cnn != null && cnn.State == ConnectionState.Closed)
                cnn.Open();
        }
        public void DongKetNoi()
        {
            if (cnn != null && cnn.State == ConnectionState.Open)
                cnn.Close();
        }
        public DataSet getAllTable(string strTableName)
        {
            OleDbCommand cmd = new OleDbCommand("select * from "+strTableName,cnn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds,strTableName);
            return ds;


        }
        public void CapNhatDuLieu(DataTable tbTable, string strTableName)
        {
            try
            {
	            OleDbCommand cmd = new OleDbCommand("select * from " + strTableName + " where 2=7", cnn);
	
	            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
	            DataSet ds = new DataSet();
	            da.Fill(ds, strTableName);
	
	            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
	                        da.Update(tbTable);
            }
            catch (System.Exception err)
            {
                throw new Exception("Lỗi cập nhật " + err);
            }
        }
        public int Check_MaCauHoi(string macauhoi)
        {
            MoKetNoi();
            OleDbCommand cmd = new OleDbCommand("select * from tbcauhoi where macauhoi='"+macauhoi+"'",cnn);
            
            int n = (int)cmd.ExecuteScalar();
            DongKetNoi();
            return n;
        }
    }
}
