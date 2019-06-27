using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entities
{
    public class KullaniciTipleri
    {
        public int ID { get; set; }
        public int TipID { get; set; }
        public int KullaniciID { get; set; }



        public virtual Kullanici Kullanici { get; set; }
        public virtual KullaniciTip KullaniciTip { get; set; }



    }
}
