using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models.GravityBookStore;

public class BookModel
{
    [HiddenInput]
    public int BookId { get; set; }
    
    [Required(ErrorMessage = "Musisz podać tytuł!")]
    [Display(Name = "Tytuł")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Musisz podać kod ISBN-13!")]
    public string ISBN13 { get; set; }
    
    [Required(ErrorMessage = "Musisz podać ilość stron!")]
    [Display(Name = "Ilość stron")]
    public int NumPages { get; set; }
    
    [Display(Name = "Data publikacji")]
    public DateOnly? PublicationDate { get; set; }
    
    [Display(Name = "Liczba autorów")]
    public int AuthorsCount { get; set; }
    
    [Display(Name = "Ilość sprzedanych egzemplarzy")]
    public int SoldCount { get; set; }
}