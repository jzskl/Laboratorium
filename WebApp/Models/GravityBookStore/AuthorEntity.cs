using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.GravityBookStore;

public class AuthorEntity
{
    [Column("author_id")]
    public int AuthorId { get; set; }
    
    [Column("author_name")]
    public string AuthorName { get; set; }
    
    public ISet<BookEntity> Books { get; set; }
}