using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entities
{
    public class Kita
    {
        public int KitaID { get; set; }
        public string KitaAd { get; set; }


        public virtual ICollection<Ulke> Ulkeler  { get; set; }

    }
}
