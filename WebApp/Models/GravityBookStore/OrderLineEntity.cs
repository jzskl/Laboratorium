using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.GravityBookStore;

public class OrderLineEntity
{
    [Column("line_id")]
    public int LineId { get; set; }
    
    [Column("order_id")]
    public int? OrderId { get; set; }
    
    [Column("book_id")]
    public int? BookId { get; set; }
    
    public int? Price { get; set; }
    
    public BookEntity? Book { get; set; }
}