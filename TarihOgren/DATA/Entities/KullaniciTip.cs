using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entities
{
    public class KullaniciTip
    {
        public int TipID { get; set; }
        public string TipAd { get; set; }


        public virtual ICollection<KullaniciTipleri> KullanicilarTipleri { get; set; }

        
    }
}
