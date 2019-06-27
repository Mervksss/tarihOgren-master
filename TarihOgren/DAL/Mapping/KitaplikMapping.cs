using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapping
{
    public class KitaplikMapping: EntityTypeConfiguration<Kitaplik>
    {
        public KitaplikMapping()
        {
            ToTable("Kitaplik");

            HasKey(x => x.KullaniciKitaplikID);

            Property(y => y.KullaniciKitaplikID).HasDatabaseGeneratedOption(null); ;



        }
    }
}
