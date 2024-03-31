using EcoCars_Project.Domain.Entities;
using EcoCars_Project.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoCars_Project.Persistance.Contexts
{
    public class EcoCarsDbContext:DbContext
    {
        public EcoCarsDbContext(DbContextOptions options):base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>()
                .HasOne<Brand>(b => b.Brand)
                .WithMany(a => a.Models)
                .HasForeignKey(b => b.BrandId);

            //GeneralType-GeneralInfo relation
            modelBuilder.Entity<GeneralInfo>()
                .HasOne<GeneralType>(b => b.GeneralType)
                .WithMany(a => a.GeneralInfo)
                .HasForeignKey(b => b.TypeId);

            //TB_ADS-TB_ADSIMAGES relation
            //modelBuilder.Entity<TB_AdsImages>()
            //    .HasOne<TB_Ads>(b => b.TB_Ads)
            //    .WithMany(a => a.TB_AdsImages)
            //    .HasForeignKey(x => x.Ads_Id);
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<GeneralType> GeneralTypes { get; set; }
        public DbSet<GeneralInfo> GeneralInfos { get; set; }
        public DbSet<TB_Ads> TB_Ads { get; set; }
        public DbSet<TB_AdsImages> TB_AdsImages { get; set; }
        public DbSet<RatingData> RatingDatas { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker : Entityler üzerinden yapılan değişiklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.

            var datas = ChangeTracker
                 .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
