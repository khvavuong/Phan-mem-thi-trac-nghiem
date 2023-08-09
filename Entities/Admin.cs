using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Admin
    {
        public string TenDangNhap{get;set;}
        public string Password{get;set;}
        public string MaAdMin{get;set;}

        public Admin(){}
        public Admin(string tendangnhap,string pass,string maadmin)
        {
            TenDangNhap = tendangnhap;
            Password = pass;
            MaAdMin = maadmin;
        }
    }
}
