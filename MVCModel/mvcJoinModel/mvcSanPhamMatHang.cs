using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangAPI.Models.MVCModel.mvcJoinModel
{
    public class mvcSanPhamMatHang
    {
        public string IDSP { get; set; }

        public string TenSP { get; set; }


        public decimal DonGia { get; set; }

        public string Anh { get; set; }

        public DateTime NgayCapNhat { get; set; }
        public decimal GiaBan { get; set; }
        
        public string TenMH { get; set; }
    }
}