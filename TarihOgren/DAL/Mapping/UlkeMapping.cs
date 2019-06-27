using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapping
{
    public class UlkeMapping: EntityTypeConfiguration<Ulke>
    {
        public UlkeMapping()
        {
            ToTable("Ulkeler");

            HasKey(x => x.UlkeID);

            HasRequired(x => x.Kita).WithMany(x => x.Ulkeler).HasForeignKey(x => x.KitaID);

            Property(x => x.UlkeAd).IsRequired().HasMaxLength(50);
            
        }
    }
}
