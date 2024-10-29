using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public enum Category
{
    [Display(Name = "Rodzina", Order = 1)]
    Family = 1,
    [Display(Name = "Znajomi", Order = 3)]
    Friend = 2,
    [Display(Name = "Kontakt zawodowy", Order = 2)]
    Business = 3
}