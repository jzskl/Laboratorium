using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.GravityBookStore;

public class PublisherEntity
{
    [Column("publisher_id")]
    public int PublisherId { get; set; }
    
    [Column("publisher_name")]
    public string? PublisherName { get; set; }
    
    public ISet<BookEntity> Books { get; set; }
}