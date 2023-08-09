using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Data_Tier;
using Entities;
namespace Business_Tier
{
   public class B_ChuDe
    {
        //khởi tạo đối tượng
       D_ChuDe objChuDe = new D_ChuDe();
       General_data objgd = new General_data();
       public DataTable getall_chude()
       {
           return objgd.getAllTable("tbchude").Tables["tbchude"];

       }
       public void CapNhat_tbchude(DataTable tbTable)
       {
           objChuDe.CapNhatDuLieu(tbTable, "tbchude");
       }
      public DataTable getrow_tbchude(string strmachude)
      {
          return objChuDe.getrow_tbchude(strmachude).Tables["tbchude"];
      }
      public DataTable get_tbchude()
      {
          return objChuDe.getAllTable("tbchude").Tables["tbchude"];

      }
      public int xoa_chude_B(ChuDe machude)
      {
          return objChuDe.XoaChuDe(machude);
      }
       public int sua_chude_B(ChuDe CH)
       {
           return objChuDe.SuaChuDe(CH);
       }
    }
}
