using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entities
{
    public class Kitaplik
    {
        public int KullaniciKitaplikID { get; set; }

        public virtual Kullanici Kullanici { get; set; }
        public virtual ICollection<KitaplikTarihiOlay> KitaplikTarihiOlaylar { get; set; }


    }
}
