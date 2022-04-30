using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TosInMemory.Tests.Models
{
    public partial class TosInMemoryContext : DbContext
    {
        public TosInMemoryContext()
        {
        }

        public TosInMemoryContext(DbContextOptions<TosInMemoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Club> Clubs { get; set; } = null!;
        public virtual DbSet<League> Leagues { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("Data Source=tosthomasinmemory.database.windows.net;Initial Catalog=TosInMemory;Persist Security Info=True;User ID=tosthomasuser;Password=plopAzerty@1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>(entity =>
            {
                entity.ToTable("CLUB");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.League)
                    .WithMany(p => p.Clubs)
                    .HasForeignKey(d => d.LeagueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLUB_LEAGUE");
            });

            modelBuilder.Entity<League>(entity =>
            {
                entity.ToTable("LEAGUE");

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("PLAYER");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PLAYER_CLUB");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
