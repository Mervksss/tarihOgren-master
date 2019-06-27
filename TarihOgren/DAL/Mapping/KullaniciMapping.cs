using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapping
{
    public class KullaniciMapping: EntityTypeConfiguration<Kullanici>
    {
        public KullaniciMapping()
        {
            ToTable("Kullanici");
            HasKey(x => x.KullaniciID);

            HasRequired(x => x.Kitaplik).WithRequiredPrincipal(x => x.Kullanici);

            // Bu bire bir ilişkiyi kontrol etmek gerek. Pek emin değilim bu koddan.

            Property(x => x.Ad).IsRequired().HasMaxLength(50);
            Property(x => x.Soyad).IsRequired().HasMaxLength(50);
            Property(x => x.KullaniciAdi).IsRequired().HasMaxLength(50);
            Property(x => x.Mail).IsRequired().HasMaxLength(50);
            Property(x => x.Sifre).IsRequired().HasMaxLength(50);





        }
    }
}
