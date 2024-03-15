using System;
using Microsoft.EntityFrameworkCore;
namespace IP_DateLayer
{
    public class ToyShopAPIDBContext : DbContext
    {
        public ToyShopAPIDBContext()
        {
        }

        public ToyShopAPIDBContext(DbContextOptions<ToyShopAPIDBContext> options)
       : base(options)
        {
        }

        //public DbSet<class> dbsetname { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<DBset>(entity =>
        //    {
        //        entity.ToTable("table");
        //    }
        //}
    }
}

