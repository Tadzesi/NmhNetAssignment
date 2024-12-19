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
            // Author configuration
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name).IsRequired();
                entity.HasIndex(a => a.Name).IsUnique();

                entity.HasOne(a => a.Image)
                       .WithOne()
                       .HasForeignKey<Image>(i => i.Id);
            });

            // Article configuration
            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.HasIndex(a => a.Title);

                entity.HasMany(a => a.Authors) // Many-To-Many relationship
                      .WithMany(); // Configure the join table automatically

                entity.HasOne(a => a.Site)
                      .WithMany()
                      .HasForeignKey(a => a.SiteId) // Specify foreign key property
                      .IsRequired(false);
            });

            // Site configuration
            modelBuilder.Entity<Site>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.CreatedAt).IsRequired();
            });

            // Image configuration
            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(i => i.Description).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
