using Microsoft.EntityFrameworkCore;

namespace WebApp.Models.GravityBookStore;

public class GravityBookStoreDbContext: DbContext
{
    public DbSet<BookEntity> Books { get; set; }
    
    public GravityBookStoreDbContext()
    {
 
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        optionsBuilder.UseSqlite(configuration.GetConnectionString("GravityBookStore"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AuthorEntity>()
            .ToTable("author");

        modelBuilder.Entity<BookEntity>(e =>
        {
            e.ToTable("book");

            e.HasOne<LanguageEntity>(x => x.Language)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.LanguageId);
            
            e.HasOne<PublisherEntity>(x => x.Publisher)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.PublisherId);

            e.HasMany<AuthorEntity>(x => x.Authors)
                .WithMany(x => x.Books)
                .UsingEntity<Dictionary<string, object>>(
                    "BookAuthor",
                    x => x
                        .HasOne<AuthorEntity>()
                        .WithMany()
                        .HasForeignKey("AuthorId"),
                    x => x
                        .HasOne<BookEntity>()
                        .WithMany()
                        .HasForeignKey("BookId"),
                    x =>
                    {
                        x.ToTable("book_author");
                        x.HasKey("BookId", "AuthorId");
                        x.IndexerProperty<int>("BookId").HasColumnName("book_id");
                        x.IndexerProperty<int>("AuthorId").HasColumnName("author_id");
                    });
        });

        modelBuilder.Entity<LanguageEntity>()
            .ToTable("book_language")
            .HasKey(x => x.LanguageId);
        
        modelBuilder.Entity<PublisherEntity>()
            .ToTable("publisher")
            .HasKey(x => x.PublisherId);
    }
}