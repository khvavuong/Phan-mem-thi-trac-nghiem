using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class ChuDe
    {
        public string MaChuDe{get;set;}
        public string TenChuDe{get;set;}
        public string MaAdMin{get;set;}
        public string MaSinhVien{get;set;}

        public ChuDe(){}
        public ChuDe(string machude,string tenchude,string maadmin,string masinhvien)
        {
            MaChuDe = machude;
            TenChuDe =tenchude;
            MaAdMin = maadmin;
            MaSinhVien = masinhvien;

        }
        public ChuDe(string machude, string tenchude)
        {
            MaChuDe = machude;
            TenChuDe = tenchude;
           
        }
    }
}
