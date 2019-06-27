using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapping
{
    public class KitaplikTarihiOlayMapping : EntityTypeConfiguration<KitaplikTarihiOlay>
    {
        public KitaplikTarihiOlayMapping()
        {
            ToTable("KitaplikTarihiOlay");

            HasRequired(x => x.TarihiOlay).WithMany(x => x.KitaplikTarihiOlaylar).HasForeignKey(x => x.TarihiOlayID);
            HasRequired(x => x.Kitaplik).WithMany(x => x.KitaplikTarihiOlaylar).HasForeignKey(x => x.KullaniciKitaplikID);

        }
    }
}
