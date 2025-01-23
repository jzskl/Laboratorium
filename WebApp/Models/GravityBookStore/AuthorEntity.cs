using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.GravityBookStore;

public class AuthorEntity
{
    [Column("author_id")]
    public int AuthorId { get; set; }
    
    [Column("author_name")]
    [Display(Name = "Nazwisko")]
    public string AuthorName { get; set; }
    
    [Display(Name = "Lista książek")]
    public ISet<BookEntity> Books { get; set; }
}