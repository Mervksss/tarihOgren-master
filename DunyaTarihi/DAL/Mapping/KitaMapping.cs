using DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapping
{
    public class KitaMapping : EntityTypeConfiguration<Kita>
    {
        public KitaMapping()
        {
            ToTable("Kitalar");

            HasKey(x => x.KitaID);

            Property(x => x.KitaAd).IsRequired().HasMaxLength(20);


        }
    }
}
