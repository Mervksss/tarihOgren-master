using DAL;
using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        Context db;

        public HomeController()
        {
            db = new Context();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TarihiOlay(string id)
        {
            var tarihiOlaylarId = db.TarihiOlayUlkeler.Where(x => x.UlkeID == db.Ulkeler.Where(y => y.UlkeKod == id).FirstOrDefault().UlkeID).ToList();
            List<TarihiOlay> tarihiOlaylar = new List<TarihiOlay>();
           
            foreach (var item in tarihiOlaylarId)
            {
                tarihiOlaylar.Add(db.TarihiOlaylar.Where(x => x.TarihiOlayID == item.TarihiOlayID).FirstOrDefault());
            }
 
            return View(tarihiOlaylar);
        }

        public ActionResult FavorilereEkle(int id)
        {
            KitaplikTarihiOlay ktp = new KitaplikTarihiOlay()
            {
               KullaniciKitaplikID = 1,        //TODO: Giriş yapan kullanıcı id alınacak.
               TarihiOlayID = id
            };
            db.KitaplikTarihiOlaylar.Add(ktp);
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}