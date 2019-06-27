﻿using DAL;
using DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
     public class TarihiOlayConcrete: ITarihiOlay
    {
        public IRepository<TarihiOlay> tarihiOlayRepository;
        public IUnitOfWork tarihiOlayUnitOfWork;
        private Context _dbContext;


        public TarihiOlayConcrete()
        {
            _dbContext = new Context();
            tarihiOlayUnitOfWork = new EFUnitOfWork(_dbContext);
            tarihiOlayRepository = tarihiOlayUnitOfWork.GetRepository<TarihiOlay>();
        }

        //Deneme
        public TarihiOlay GetByKategori(int katID)
        {
            return tarihiOlayRepository.GetAll().FirstOrDefault(x => x.Kategori.KategoriID == katID);
        }


        public List<TarihiOlay> GetByDurum(int durum)
        {
            throw new NotImplementedException();
        }

        public List<TarihiOlay> GetByEkleyenKisi(int userID)
        {
            throw new NotImplementedException();
        }

        public TarihiOlay GetByOlayID(int olayID)
        {
            foreach (var item in tarihiOlayRepository.GetAll())
            {
                if (item.TarihiOlayID == olayID)
                    return (item);
            }
            return null;

            
            
        }

        public List<TarihiOlay> GetByUlkeKod(string ulkeKod)
        {
            throw new NotImplementedException();
        }
    }
}
