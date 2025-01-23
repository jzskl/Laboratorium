using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.GravityBookStore;

public class BookEntity
{
    [Column("book_id")]
    public int BookId { get; set; }
    
    public string? Title { get; set; }
    
    public string? ISBN13 { get; set; }
    
    [Column("language_id")]
    public int? LanguageId { get; set; }
    
    [Column("num_pages")]
    public int? NumPages { get; set; }
    
    [Column("publication_date")]
    public DateOnly? PublicationDate { get; set; }
    
    [Column("publisher_id")]
    public int? PublisherId { get; set; }
    
    public LanguageEntity? Language { get; set; }
    
    public PublisherEntity? Publisher { get; set; }

    public ISet<AuthorEntity> Authors { get; set; }
}