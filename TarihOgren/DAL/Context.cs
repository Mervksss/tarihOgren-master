using DAL.Mapping;
using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Context : DbContext
    {
        public Context()
        {

            //Database.Connection.ConnectionString = "server = .; database = TarihOgrenDb; uid = sa; pwd = 123";
            //Database.Connection.ConnectionString = "server = .; database = TarihOgrenDb; uid = sa; pwd = 123";
            //Database.Connection.ConnectionString = "server = .; database = TarihOgrenDb; uid = sa; pwd = 123";
            //Database.Connection.ConnectionString = "server = .; database = TarihOgrenDb; uid = sa; pwd = 123";  //--->> Kerim
            Database.Connection.ConnectionString = @"server = DESKTOP-N13DB8I\SQLEXPRESS; database = TarihOgrenDb; Trusted_Connection = True;";


        }

        public DbSet<Kita> Kitalar { get; set; }
        public DbSet<Ulke> Ulkeler { get; set; }
        public DbSet<TarihiOlayUlke> TarihiOlayUlkeler { get; set; }
        public DbSet<TarihiOlay> TarihiOlaylar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kitaplik> Kitapliklar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<KullaniciTipleri> KullaniciTipleriTablo { get; set; }
        public DbSet<KullaniciTip> KullaniciTipleri { get; set; }
        public DbSet<KitaplikTarihiOlay> KitaplikTarihiOlaylar { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new KitaMapping());
            modelBuilder.Configurations.Add(new UlkeMapping());
            modelBuilder.Configurations.Add(new TarihiOlayUlkeMapping());
            modelBuilder.Configurations.Add(new TarihiOlayMapping());
            modelBuilder.Configurations.Add(new KategoriMapping());
            modelBuilder.Configurations.Add(new KitaplikMapping());
            modelBuilder.Configurations.Add(new KullaniciMapping());
            modelBuilder.Configurations.Add(new KullaniciTipleriMapping());
            modelBuilder.Configurations.Add(new KullaniciTipMapping());
            modelBuilder.Configurations.Add(new KitaplikTarihiOlayMapping());



            base.OnModelCreating(modelBuilder);
        }



    }
}
