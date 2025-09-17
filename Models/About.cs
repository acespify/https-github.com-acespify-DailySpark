using System.Text.Json;

namespace DailySpark.FinalProject.Models
{
    public class About
    {
        public string Description { get; set; }

        // Override the ToString() method
        public override string ToString() => JsonSerializer.Serialize<About>(this);
        
    }
}
