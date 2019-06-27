using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapping
{
    public class KullaniciTipleriMapping : EntityTypeConfiguration<KullaniciTipleri>
    {
        public KullaniciTipleriMapping()
        {
            ToTable("KullaniciTipleri");

            HasRequired(x => x.Kullanici).WithMany(x => x.KullaniciTiplerii).HasForeignKey(x => x.KullaniciID);
            HasRequired(x => x.KullaniciTip).WithMany(x => x.KullanicilarTipleri).HasForeignKey(x => x.TipID);
        }
    }
}
