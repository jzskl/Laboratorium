namespace WebApp.Models;

public class BirthModel
{
    public string? Name { get; set; }
    public DateTime? Date { get; set; }

    public bool IsValid()
    {
        return Name != null && Date != null && Date < DateTime.Now;
    }

    public int Birth()
    {
        DateTime birth = (DateTime)Date;
        DateTime future = DateTime.Now;
        
        int years = future.Year - birth.Year;
        if (birth.Month == future.Month && future.Day < birth.Day || future.Month < birth.Month)
        {
            years--;
        }

        return years;
    }
}