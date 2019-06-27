using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entities
{
    public class KitaplikTarihiOlay
    {
        public int ID { get; set; }
        public int TarihiOlayID { get; set; }
        public int KullaniciKitaplikID { get; set; }

        public virtual TarihiOlay TarihiOlay { get; set; }
        public virtual Kitaplik Kitaplik { get; set; }
    }
}
