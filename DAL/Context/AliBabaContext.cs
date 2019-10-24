using DAL.Migrations;
using Entity.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class AliBabaContext:IdentityDbContext // identity kullandıgımız için bundan miras aldık
    {
        public AliBabaContext() : base("DefCon") // default connection kısaltması
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AliBabaContext, Configuration>("DefCon"));
        }

        public virtual DbSet<AltKategori> AltKategori{ get; set; }
        public virtual DbSet<Color> Color{ get; set; }
        public virtual DbSet<Ilan> Ilan{ get; set; }
        public virtual DbSet<Ilce> Ilce{ get; set; }
        public virtual DbSet<Images> Images{ get; set; }
        public virtual DbSet<Kategori> Kategori{ get; set; }
        public virtual DbSet<KullaniciAdresi> KullaniciAdresi{ get; set; }
        public virtual DbSet<Marka> Marka{ get; set; }
        public virtual DbSet<Mesaj> Mesaj{ get; set; }
        public virtual DbSet<Model> Model{ get; set; }
        public virtual DbSet<Sehir> Sehir{ get; set; }
        public virtual DbSet<Teklif> Teklif{ get; set; }


    }
}
