using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniIMDBService.DL.Data.Models;
namespace MiniIMDBService.DL.DBContext
{
    public class NiceMoviesContext: DbContext
    {
        public virtual DbSet<TVShow> TV_Shows { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Cast> Casts { get; set; }
        public NiceMoviesContext(DbContextOptions<NiceMoviesContext> options) : base(options)
        { }



        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Cast>()
                .HasKey(bc => new { bc.tvshow_id, bc.actor_id });
            modelBuilder.Entity<Cast>()
                .HasOne(bc => bc.TVShow)
                .WithMany(b => b.Casts)
                .HasForeignKey(bc => bc.tvshow_id);
            modelBuilder.Entity<Cast>()
                .HasOne(bc => bc.Actor)
                .WithMany(c => c.Casts)
                .HasForeignKey(bc => bc.actor_id);
            modelBuilder.Entity<Cast>()
                .HasOne(bc => bc.Movie)
                .WithMany(b => b.Casts)
                .HasForeignKey(bc => bc.movie_id);
        }
    }
}
