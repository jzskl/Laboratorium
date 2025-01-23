namespace WebApp.Models.Movies;

public class ProductionCountry
{
    public int? MovieId { get; set; }

    public int? CountryId { get; set; }

    public virtual Country? Country { get; set; }

    public virtual Movie? Movie { get; set; }
}