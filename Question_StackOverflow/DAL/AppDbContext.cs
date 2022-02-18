using System;
using Microsoft.EntityFrameworkCore;
using Question_StackOverflow.Models;

namespace Question_StackOverflow.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<MainEntity> MainEntities { get; set; }
    
        public DbSet<Foo> Foos { get; set; }

        public DbSet<Bar> Bars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bar>()
                .HasMany(sc => sc.ChildrenBars)
                .WithOne(sc=>sc.ParentBar)
                .HasForeignKey(sc=>sc.ParentBarId);
        }
    }
}
