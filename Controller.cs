using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Objective;

class Controller
{
    //string connectionString = "Server=(localdb)\\mssqllocaldb;Database=objective;Trusted_Connection=True;";
    //     using (var connect = new SqlConnection(connectionString))
    // {
    //     connect.OpenAsync();
    //     connect.
    // }

    public Apartment[] Get(int? roomCount)
    {
        var apartments = new List<Apartment>();
        apartments.Add(new Apartment
        {
            Room = 1,
            Price = 1000,
            Link = "LocalHost?"
        });
        return apartments.ToArray();
    }

    public Median[] GetMedian(int? roomCount)
    {
        var medians = new List<Median>();
        medians.Add(new Median
        {
            Date = new DateTime(1990, 01, 01),
            Price = 100
        });
        medians.Add(new Median
        {
            Date = new DateTime(1990, 02, 01),
            Price = 200
        });

        medians.Add(new Median
        {
            Date = new DateTime(1990, 03, 01),
            Price = 300
        });

        medians.Add(new Median
        {
            Date = new DateTime(1990, 04, 01),
            Price = 400
        });

        medians.Add(new Median
        {
            Date = new DateTime(1990, 05, 01),
            Price = 500
        });

        medians.Add(new Median
        {
            Date = new DateTime(1990, 06, 01),
            Price = 600
        });

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