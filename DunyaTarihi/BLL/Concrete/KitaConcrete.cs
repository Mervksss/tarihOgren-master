using BLL.Interface;
using DAL;
using DATA;
using DATAA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class KitaConcrete : IKita
    {

        public IRepository<Kita> KitaRepository;
        public IUnitOfWork KitaUnitOfWork;
        private Context _dbContext;

        public KitaConcrete()
        {
            _dbContext = new Context();
            KitaUnitOfWork = new EFUnitOfWork(_dbContext);
            KitaRepository = KitaUnitOfWork.GetRepository<Kita>();
        }


      
    }
}
