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
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index(int sayfa = 1)
        {
            //var degerler = db.TblUrunler.ToList();
            var degerler = db.TblUrunler.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            //return View();
            //----------------------------
            List<SelectListItem> degerler = (from i in db.KategoriTbl.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriAd,
                                                 Value = i.kategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;//diger tarafa dgr ye tasıyoruz.
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(TblUrunler u1)
        {
            var ktg = db.KategoriTbl.Where(i => i.kategoriID == u1.KategoriTbl.kategoriID).FirstOrDefault();
            u1.KategoriTbl = ktg;
            db.TblUrunler.Add(u1);
            db.SaveChanges();
            //return View();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urun = db.TblUrunler.Find(id);
            db.TblUrunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TblUrunler.Find(id);
            List<SelectListItem> degerler = (from i in db.KategoriTbl.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriAd,
                                                 Value = i.kategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;//diger tarafa dgr ye tasıyoruz.
            return View("UrunGetir", urun);
        }
        public ActionResult UrunGuncelle(TblUrunler p1)
        {
            var urun = db.TblUrunler.Find(p1.UrunID);
            urun.UrunAd = p1.UrunAd;
            //urun.UrunKategori = p1.UrunKategori;
            var ktgr = db.KategoriTbl.Where(i => i.kategoriID == p1.KategoriTbl.kategoriID).FirstOrDefault();
            urun.UrunKategori = ktgr.kategoriID;
            urun.UrunFiyat = p1.UrunFiyat;
            urun.UrunMarka = p1.UrunMarka;
            urun.UrunStok = p1.UrunStok;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}