using Microsoft.EntityFrameworkCore;
using TechnicalTest.iaps.Domain.Entities;

namespace TechnicalTest.iaps.Infrastructure.Context
{
    public class TechnicalTestContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Paper> Papers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PaperVersion> Versions { get; set; }

        public TechnicalTestContext(DbContextOptions<TechnicalTestContext> options)
           : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paper>()
                .HasMany(e => e.Authors)
                .WithMany(e => e.Papers)
                .UsingEntity("PaperAuthor",
                    l => l.HasOne(typeof(Author)).WithMany().HasForeignKey("AuthorId").HasPrincipalKey(nameof(Author.Id)),
                    r => r.HasOne(typeof(Paper)).WithMany().HasForeignKey("PaperId").HasPrincipalKey(nameof(Paper.Id)),
                    j => j.HasKey("AuthorId", "PaperId"));

            modelBuilder.Entity<Paper>()
                .HasMany(e => e.Categories)
                .WithMany(e => e.Papers)
                .UsingEntity("PaperCategory",
                    l => l.HasOne(typeof(Category)).WithMany().HasForeignKey("CategoryId").HasPrincipalKey(nameof(Category.Id)),
                    r => r.HasOne(typeof(Paper)).WithMany().HasForeignKey("PaperId").HasPrincipalKey(nameof(Paper.Id)),
                    j => j.HasKey("CategoryId", "PaperId"));

            modelBuilder.Entity<Paper>()
                .HasMany(e => e.Versions)
                .WithOne(e => e.Paper)
                .HasForeignKey(e => e.PaperId)
                .IsRequired(false);
        }
    }
}
