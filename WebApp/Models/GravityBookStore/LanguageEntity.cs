using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.GravityBookStore;

public class LanguageEntity
{
    [Column("language_id")]
    public int LanguageId { get; set; }
    
    [Column("language_code")]
    public string? LanguageCode { get; set; }
    
    [Column("language_name")]
    public string? LanguageName { get; set; }
    
    public ISet<BookEntity> Books { get; set; }
}