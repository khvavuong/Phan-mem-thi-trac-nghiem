using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class SinhVien
    {
        public string MaSinhVien{get;set;}
        public string TenSinhVien{get;set;}
        public string MatKhau{get;set;}
        public string DiaChi{get;set;}
        public string NgaySinh { get; set; }

        public SinhVien(){ }
        public SinhVien(string masinhvien,string tensinhvien,string matkhau,string diachi,string ngaysinh)
        {
            MaSinhVien = masinhvien;
            TenSinhVien = tensinhvien;
            MatKhau = matkhau;
            DiaChi = diachi;
            NgaySinh = ngaysinh;
        }
    }
}
