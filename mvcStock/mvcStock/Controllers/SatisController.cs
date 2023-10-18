using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcStock.Models.Entity;

namespace mvcStock.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SatisEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SatisEkle(SatisTbl s1)
        {
            db.SatisTbl.Add(s1);
            db.SaveChanges();
            return View("Index");
        }
    }
}