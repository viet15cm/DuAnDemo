using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHangAPI.Models.MVCModel
{
    public partial class mvcSanPham
    {
        [Required(ErrorMessage ="Không Được Bỏ Trống")]
        [RegularExpression(@"^[A-Za-z0-9_\.]{5}$", ErrorMessage = "Mã là 5 kí tự thường không dấu")]
        public string IDSP { get; set; }
        [Required(ErrorMessage = "Không Được Bỏ Trống")]
        [StringLength(30, ErrorMessage =
            "TenSP should be less than or equal to ten characters.")]
        public string TenSP { get; set; }

        [Required(ErrorMessage = "Không Được Bỏ Trống ")]
        [Range(0, 100000000000, ErrorMessage =
            "Customer DonGia should be in 0 to 100000000000 range.")]
        public decimal DonGia { get; set; }

        

        [Required(ErrorMessage = "Không Được Bỏ Trống")]

        [DisplayFormat( DataFormatString ="{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        
        public DateTime NgayCapNhat {
            set { 
            }
          
            get
            {
                return DateTime.Now;
            }
        }
       

        [Required(ErrorMessage = "Không Được Bỏ Trống")]
        [RegularExpression(@"^[A-Za-z0-9_\.]{5}$", ErrorMessage = "Mã là 5 kí tự thường không dấu")]
        public string IDMH { get; set; }

        public string Anh { get; set; }
        [NotMapped]
        
        public HttpPostedFileBase ImageUpload { get; set; }
        public mvcSanPham()
        {
            Anh = "~/AppFiles/Images/SanPham.png";
        }

      




    }
}