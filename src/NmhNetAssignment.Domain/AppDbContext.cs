using Microsoft.EntityFrameworkCore;
using NmhNetAssignment.Domain.Entities;

namespace NmhNetAssignment.Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Author Configuration
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.HasIndex(a => a.Name).IsUnique();
                entity.HasOne(a => a.Image)
                      .WithOne()
                      .HasForeignKey<Author>(a => a.Id);
            });

            // Article Configuration
            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.HasIndex(a => a.Title);
                entity.HasMany(a => a.Authors)
                      .WithMany()
                      .UsingEntity(j => j.ToTable("ArticleAuthors"));

                entity.HasOne(a => a.Site)
                      .WithMany()
                      .HasForeignKey(a => a.Id);
            });

            // Site Configuration
            modelBuilder.Entity<Site>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.CreatedAt).IsRequired();
            });

            // Image Configuration
            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(i => i.Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
