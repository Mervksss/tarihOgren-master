using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapping
{
    public class KullaniciTipMapping : EntityTypeConfiguration<KullaniciTip>
    {
        public KullaniciTipMapping()
        {
            ToTable("KullaniciTipi");

            HasKey(x => x.TipID);

            Property(x => x.TipAd).IsRequired().HasMaxLength(20);
        }
    }
}
