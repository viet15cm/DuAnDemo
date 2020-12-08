using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.UI;

using WEBAPI.GlobalVariablesWeb;
using WebBanHangAPI.DataContextLayer;
using WebBanHangAPI.Models;
using WebBanHangAPI.Models.MVCModel;
using WebBanHangAPI.Models.MVCModel.mvcJoinModel;

namespace WebBanHangAPI.Controllers.ControllersEmpty
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*", Location = OutputCacheLocation.None)]
        public ActionResult Index()
        {
            IEnumerable<mvcSanPhamMatHang> empList;
            HttpResponseMessage reponse = GlobalVariables.WebApiClient.GetAsync("SanPhams/getJoinSanPhamsMatHangs").Result;

            empList = reponse.Content.ReadAsAsync<IEnumerable<mvcSanPhamMatHang>>().Result;
            return View(empList );
        }

        [HttpGet]
        public ActionResult Add(string id)
        {
            if(id == null)
            {
               
                return View(new mvcSanPham());
            }
            else
            { 
                HttpResponseMessage reponse = GlobalVariables.WebApiClient.GetAsync("SanPhams/getSanPhamsID/" + id).Result;
                

                return View(reponse.Content.ReadAsAsync<mvcSanPham>().Result);
            }

        }

        [HttpPost]
        public ActionResult Add(mvcSanPham sp)
        {
            if (sp.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(sp.ImageUpload.FileName);
                string extension = Path.GetExtension(sp.ImageUpload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                sp.Anh = "~/AppFiles/Images/" + fileName;
                sp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
            }
            var sanpham = new SanPham() { IDSP = sp.IDSP, DonGia = sp.DonGia, Anh = sp.Anh, IDMH = sp.IDMH, TenSP = sp.TenSP, NgayCapNhat = sp.NgayCapNhat };

            HttpResponseMessage reponse = GlobalVariables.WebApiClient.PostAsJsonAsync("SanPhams/PostSanPham", sanpham).Result;
            
            if (reponse.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Thêm Thành Công";
            }
            else
            {
                TempData["ErrorMessage"] = "Thêm Không Thành Công";
            }

            return RedirectToAction("Index");

        }

       

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return View(new mvcSanPham());
            }
            else
            {

                HttpResponseMessage reponse = GlobalVariables.WebApiClient.GetAsync("SanPhams/getSanPhamsID/" + id).Result;
                return View(reponse.Content.ReadAsAsync<mvcSanPham>().Result);

            }

        }
        [HttpPost]
        public ActionResult Edit(mvcSanPham sp)
        {
            if (sp.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(sp.ImageUpload.FileName);
                string extension = Path.GetExtension(sp.ImageUpload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                sp.Anh = "~/AppFiles/Images/" + fileName;
                sp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
            }
            var sanpham = new SanPham() { IDSP = sp.IDSP, DonGia = sp.DonGia, Anh = sp.Anh, IDMH = sp.IDMH, TenSP = sp.TenSP, NgayCapNhat = sp.NgayCapNhat };

            HttpResponseMessage reponse = GlobalVariables.WebApiClient.PutAsJsonAsync("SanPhams/PutSanPham/" + sp.IDSP, sanpham).Result;
            if (reponse.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Sữa Thành Công";
            }
            else
            {
                TempData["ErrorMessage"] = "Sữa Không Thành Công";

            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            HttpResponseMessage reponse = GlobalVariables.WebApiClient.DeleteAsync("SanPhams/Delete/" + id).Result;
            if (reponse.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Xóa Thành Công";
            }
            else
            {
                TempData["ErrorMessage"] = "Xóa Không Thành Công";
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public JsonResult getListAutoCompelete(string key)
        {
            ICollection<mvcMatHang> empList;
            HttpResponseMessage reponse = GlobalVariables.WebApiClient.GetAsync("MatHangs/getMatHangID/" + key).Result;
            empList = reponse.Content.ReadAsAsync<ICollection<mvcMatHang>>().Result;

            
            return Json(new
            {
                list = empList.ToList()
            }, JsonRequestBehavior.AllowGet);
        }

      
    }
}