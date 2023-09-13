using Microsoft.EntityFrameworkCore;

namespace Objective;

class Controller
{
    public Apartment[] Get(int? roomCount)
    {
        var apartments = new List<Apartment>();

        return apartments.ToArray();
    }

    public Median[] GetMedian(int? roomCount)
    {
        var medians = new List<Median>();
        return medians.ToArray();
    }
}

public class Apartment
{
    public int Room { get; set; }
    public string Link { get; set; } = "";
    public decimal Price { get; set; }
}

public class Median
{
    public decimal Price { get; set; }
    public DateTime Date { get; set; }
}