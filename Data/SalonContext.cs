using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InaBeauty.Models
{
    public class SalonContext : DbContext
    {
        public SalonContext (DbContextOptions<SalonContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clienti { get; set; }
        public DbSet<Programare> Programari { get; set; }
        public DbSet<Serviciu> Servicii { get; set; }
        public DbSet<Membru> Membrii { get; set; }
        public DbSet<AlocareServiciu> AlocariServicii { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Serviciu>().ToTable("Serviciu");
            modelBuilder.Entity<Programare>().ToTable("Programare");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Membru>().ToTable("Membru");
            modelBuilder.Entity<AlocareServiciu>().ToTable("AlocareServiciu");

            modelBuilder.Entity<AlocareServiciu>()
                .HasKey(s => new { s.ServiciuID, s.MembruID });
        }
    }
}
