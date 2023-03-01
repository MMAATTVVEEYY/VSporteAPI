using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSporteAPI.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace VSporteAPI.Data
{
    public class VSporteAPIDbContext:DbContext
    {
        public VSporteAPIDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<PlayerClub> PlayerClubs { get; set;}
        public DbSet<MatchEvent> MatchEvents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerClub>()
                .HasKey(c => new { c.PlayerId, c.ClubId });

           /* modelBuilder.Entity<Club>()
                        .HasMany(c => c.PlayerClubs).WithMany()
                        .HasForeignKey(c => c.ClubId);

            modelBuilder.Entity<Media>()
                .HasMany(c => c.ContractMedias)
                .WithRequired()
                .HasForeignKey(c => c.MediaId);*/
            
        }


    }
}
