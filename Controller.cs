using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Objective;

class Controller
{
    private string connectionString =
        "Persist Security Info=False;User ID=*bjective;Password=objective;Initial Catalog=Objective;Server=192.168.0.100";

    public Apartment[] Get(int? roomCount)
    {
        var apartments = new List<Apartment>();
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(@"SELECT  room, link,
                (select top 1 price from price_history where id_apartment = apartment.id order by change_date desc) price
            FROM apartment", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                apartments.Add(new Apartment
                {
                    Room = reader.GetInt32(0),
                    Link = reader.GetString(1),
                    Price = reader.GetInt32(2),
                });
            }
        }

        return apartments.ToArray();
    }

    public int[] GetFilterValues()
    {
        var values = new List<int>();
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT distinct room FROM apartment order by 1", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                values.Add(reader.GetInt32(0));
            }
        }

        return values.ToArray();
    }

    public Median[] GetMedian(int? roomCount)
    {
        var medians = new List<Median>();
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(@"SELECT distinct date, PERCENTILE_CONT(0.5) 
        WITHIN GROUP (ORDER BY price) 
        OVER (PARTITION BY date)
        AS Median_UnitPrice
FROM (SELECT price, CONCAT ( YEAR(change_date),'-',MONTH(change_date))   date  FROM  price_history) AS history",
                connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                medians.Add(new Median
                {
                    Date = reader.GetString(0),
                    Price = reader.GetInt32(1),
                   
                });
            }
        }

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
    public string Date { get; set; }
}