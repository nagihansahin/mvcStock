using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcStock.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace mvcStock.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index(int sayfa = 1)
        {
            //var deger = db.MusteriTbl.ToList();
            var deger = db.MusteriTbl.ToList().ToPagedList(sayfa, 4);
            return View(deger);
        }
        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriEkle(MusteriTbl m1)
        {
            if (!ModelState.IsValid)
            {
                return View("MusteriEkle");
            }
            db.MusteriTbl.Add(m1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var musteri = db.MusteriTbl.Find(id);
            db.MusteriTbl.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Güncellemek için müşteri getirme işlemimizi yapalım
        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.MusteriTbl.Find(id);
            return View("MusteriGetir", musteri);
        }
        //Güncelleme kısmı
        public ActionResult MusteriGuncelle(MusteriTbl m1)
        {
            var mstr = db.MusteriTbl.Find(m1.musteriID);
            mstr.musteriAd = m1.musteriAd;
            mstr.musteriSoyad = m1.musteriSoyad;
            db.SaveChangesAsync();
            return RedirectToAction("Index");//RidayrekToAkşın
        }
    }
}