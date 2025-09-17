using System.Text.Json;

namespace DailySpark.FinalProject.Models
{
    // Creating a model to identify a quote to be displayed
    public class Quotes
    {
        // The following properties are to get or set the values with in our "datafile/database"
        public string Id { get; set; }
        public string Quote { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public int[] Ratings { get; set; } // To get/set the ratings of a quote presented.

        // this method overrides the default ToString() method for the Quote Class
        public override string ToString() => JsonSerializer.Serialize<Quotes>(this);
    }
}
