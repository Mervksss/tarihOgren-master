using BLL;
using BLL.Concrete;
using DAL;
using DATA;
using DunyaTarihi.Models.DTOs;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DunyaTarihi.Controllers
{
    public class MainController : ApiController
    {

        Context db = new Context();
        TarihiOlayConcrete tarihiOlaylar = new TarihiOlayConcrete();
        UlkeConcrete ulkeler = new UlkeConcrete();
        TarihiOlayUlkeConcrete TarihiOlaylarUlkeler = new TarihiOlayUlkeConcrete();
        KitaplikConcrete kitapliklar = new KitaplikConcrete();
        KitaplikTarihiOlayConcrete kitaplikTarihiOlaylar = new KitaplikTarihiOlayConcrete();

        //[HttpGet]
        //public List<TarihiOlay> GetFromKitaplik()
        //{
        //    string uID = System.Web.HttpContext.Current.User.Identity.GetUserId();
        //    int kitaplikID = kitapliklar.kitaplikRepository.Get(x => x.KullaniciID == uID).KitaplikID;
        //    List<KitaplikTarihiOlay> tarihiOlayIdleri = kitaplikTarihiOlaylar.KitaplikTarihiOlayRepository.GetAll(x => x.KitaplikID == kitaplikID).ToList();
        //    List<TarihiOlay> olaylar = new List<TarihiOlay>();

        //    foreach (var item in tarihiOlayIdleri)
        //    {
        //        if (tarihiOlaylar.tarihiOlayRepository.Get(x => x.TarihiOlayID == item.TarihiOlayID) != null)
        //        {
        //            olaylar.Add(tarihiOlaylar.tarihiOlayRepository.Get(x => x.TarihiOlayID == item.TarihiOlayID));
        //        }
        //    }

        //    return olaylar;
        //}

        [HttpGet]
        public List<BaslikIcerikDTO> GetFromKitaplik()
        {
            string uID = System.Web.HttpContext.Current.User.Identity.GetUserId();
            int kitaplikID = kitapliklar.kitaplikRepository.Get(x => x.KullaniciID == uID).KitaplikID;
            List<KitaplikTarihiOlay> tarihiOlayIdleri = kitaplikTarihiOlaylar.KitaplikTarihiOlayRepository.GetAll(x => x.KitaplikID == kitaplikID).ToList();
            List<BaslikIcerikDTO> olaylar = new List<BaslikIcerikDTO>();

            foreach (var item in tarihiOlayIdleri)
            {
                if (tarihiOlaylar.tarihiOlayRepository.Get(x => x.TarihiOlayID == item.TarihiOlayID) != null)
                {
                    olaylar.Add(new BaslikIcerikDTO()
                    {
                        ID = (tarihiOlaylar.tarihiOlayRepository.Get(x => x.TarihiOlayID == item.TarihiOlayID)).TarihiOlayID,
                        Icerik = (tarihiOlaylar.tarihiOlayRepository.Get(x => x.TarihiOlayID == item.TarihiOlayID)).Icerik,
                        Baslik = (tarihiOlaylar.tarihiOlayRepository.Get(x => x.TarihiOlayID == item.TarihiOlayID)).Baslik
                    });

                }
            }

            return olaylar;
        }


        [HttpGet]
        public List<BaslikIcerikDTO> GetByUlkeKod(string ulkeKod)
        {

            List<BaslikIcerikDTO> olaylar = new List<BaslikIcerikDTO>();
            int ulkeID = ulkeler.GetUlkeID(ulkeKod);

            List<TarihiOlayUlke> OlayIdleri = TarihiOlaylarUlkeler.TarihiOlayUlkeRepository.GetAll(x => x.UlkeID == ulkeID).ToList();

            foreach (var item in OlayIdleri)
            {
                olaylar.Add(new BaslikIcerikDTO()
                {
                    ID = tarihiOlaylar.GetByOlayID(item.TarihiOlayID).TarihiOlayID,
                    Icerik = tarihiOlaylar.GetByOlayID(item.TarihiOlayID).Icerik,
                    Baslik = tarihiOlaylar.GetByOlayID(item.TarihiOlayID).Baslik
                });
            }

            return olaylar;
        }


        [HttpGet]
        public TarihiOlay GetByTarihiOlayID(int id)
        {
            TarihiOlay olay = tarihiOlaylar.GetByOlayID(id);
            return olay;
        }


        [HttpPost]
        public HttpResponseMessage AddToKitaplik(int id)
        {
            Kitaplik kitaplik = new Kitaplik()
            {
                KullaniciID = System.Web.HttpContext.Current.User.Identity.GetUserId()
            };

            if (kitapliklar.kitaplikRepository.Get(x => x.KullaniciID == kitaplik.KullaniciID) == null)
            {
                kitapliklar.kitaplikRepository.Add(kitaplik);
                kitapliklar.kitaplikUnitOfWork.SaveChanges();
            }
            else
            {
                kitaplik.KitaplikID = kitapliklar.kitaplikRepository.Get(x => x.KullaniciID == kitaplik.KullaniciID).KitaplikID;
            }


            KitaplikTarihiOlay kitaplikTarihiOlay = new KitaplikTarihiOlay()
            {
                KitaplikID = kitaplik.KitaplikID,
                TarihiOlayID = id
            };

            if (kitaplikTarihiOlaylar.KitaplikTarihiOlayRepository.Get(x => x.KitaplikID == kitaplik.KitaplikID && x.TarihiOlayID == id) == null)
            {

                kitaplikTarihiOlaylar.KitaplikTarihiOlayRepository.Add(kitaplikTarihiOlay);
                kitaplikTarihiOlaylar.KitaplikTarihiOlayUnitOfWork.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "eklendi");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "zaten ekli");
            }
        }
    }
}
