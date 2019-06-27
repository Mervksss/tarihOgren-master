using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapping
{
    public class TarihiOlayMapping: EntityTypeConfiguration<TarihiOlay>
    {
        public TarihiOlayMapping()
        {
            ToTable("TarihiOlaylar");

            HasKey(x => x.TarihiOlayID);

            HasRequired(x => x.Kategori).WithMany(x => x.TarihiOlaylar).HasForeignKey(x => x.KategoriID);


            Property(x => x.Baslik).IsRequired().HasMaxLength(50);
            Property(x => x.Icerik).IsRequired().HasColumnType("nvarchar(MAX)");
            Property(x => x.BaslangicTarihi).IsRequired().HasColumnType("datetime2");
            Property(x => x.BitisTarihi).IsOptional().HasColumnType("datetime2"); // devam eden bir olay olabilir diye bitistarihini optional yaptim. tatışılabilir tabi..
        }
    }
}
