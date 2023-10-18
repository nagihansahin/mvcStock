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
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index( string p)
        {
            //int sayfa = 1,
            //var degerler = db.KategoriTbl.ToList();
            /*var degerler = db.KategoriTbl.ToList().ToPagedList(sayfa, 4);*///1.sayfadan başla 4 tane getir demek
            /////////////////////////arama yapmak
            var degerler2 = from d in db.KategoriTbl select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler2 = degerler2.Where(m => m.kategoriAd.Contains(p));
            }
            return View(degerler2.ToList());
        }
        [HttpGet]
        //sayfa ilk yükleniyorsa
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]//kaydet butonuna bastığımda gerçekleştir
        public ActionResult KategoriEkle(KategoriTbl p1)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriEkle");
            }
            db.KategoriTbl.Add(p1);//parametre 1 deki değerleri kategori tablosuna ekle
            db.SaveChanges();//değişiklikleri kaydet
            //return View();sayfayı bana geri döndür
            return RedirectToAction("Index");//listelenen sayfaya geri gider(Ridayrektoekşın)
        }
        //Buffer metoddan sonra sayfayı tasarla add view
        public ActionResult Sil(int id)
        {
            var kategori = db.KategoriTbl.Find(id);
            db.KategoriTbl.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.KategoriTbl.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult KategoriGuncelle(KategoriTbl p1)
        {
            var ktgr = db.KategoriTbl.Find(p1.kategoriID);
            ktgr.kategoriAd = p1.kategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}