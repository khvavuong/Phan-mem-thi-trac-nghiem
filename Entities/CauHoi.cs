using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class CauHoi
    {
        public string MaCauhoi{get;set;}
        public string MaChuDe{get;set;}
        public string NoiDung{get;set;}
        public string DapAnA{get;set;}
        public string DapAnB { get; set; }
        public string DapAnC { get; set; }
        public string DapAnD{get;set;}
        public int DapAnDung{get;set;}
        public int CauTraLoi { get; set; }

        public CauHoi(){}
        public CauHoi(string macauhoi,string machude,string noidung,string dapan_a,string dapan_b,string dapan_c,string dapan_d,int dapan_dung)
        {
            MaCauhoi = macauhoi;
            MaChuDe = machude;
            NoiDung = noidung;
            DapAnA = dapan_a;
            DapAnB = dapan_b;
            DapAnC = dapan_c;
            DapAnD = dapan_d;
            DapAnDung = dapan_dung;
           
           
        }

    }
}
