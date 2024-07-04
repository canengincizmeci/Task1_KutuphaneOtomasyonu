using ktp_Otamasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace ktp_Otamasyon.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            db_context model = new db_context();
            var liste = model.Kitaplar.Where(p => p.aktiflik == true).OrderByDescending(p => p.kategoriID).Select(p => new Kitap
            {
                id = p.id,
                aktiflik = p.aktiflik,
                kategoriID = p.kategoriID,
                kitapAd = p.kitapAd,
                sayfaSayisi = p.sayfaSayisi,
                yazar = p.yazar,
                kategori_ad = p.Kategoriler.kategoriAd
            }).ToList();
            return View(liste);
        }
        public ActionResult Sil(int kitap_id)
        {
            db_context model = new db_context();
            model.Kitaplar.Find(kitap_id).aktiflik = false;
            model.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            db_context model = new db_context();
            List<SelectListItem> ktg = (from i in model.Kategoriler.ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.kategoriAd,
                                            Value = i.id.ToString()
                                        }).ToList();
            ViewBag.Ktg = ktg;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle(string kitap_ad, string sayfa_sayisi, string yazar, int id)
        {
            db_context model = new db_context();
            model.Kitaplar.Add(new Kitaplar
            {
                aktiflik = true,
                kategoriID = id,
                kitapAd = kitap_ad,
                sayfaSayisi = sayfa_sayisi,
                yazar = yazar
            });
            model.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Kategoriler()
        {
            db_context model = new db_context();
            var ktg = model.Kategoriler.Where(p => p.aktiflik == true).OrderByDescending(p => p.id).Select(p => new Kategori
            {
                id = p.id,
                kategoriAd = p.kategoriAd
            }).ToList();
            return View(ktg);

        }
        public ActionResult KategoriSil(int kategori_id)
        {
            db_context model = new db_context();
            model.Kategoriler.Find(kategori_id).aktiflik = false;
            model.SaveChanges();
            return RedirectToAction("Kategoriler", "Home");
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KategoriEkle(string kategori_ad)
        {
            db_context model = new db_context();
            model.Kategoriler.Add(new Kategoriler
            {
                aktiflik = true,
                kategoriAd = kategori_ad
            });
            model.SaveChanges();
            return RedirectToAction("Kategoriler", "Home");
        }
    }
}