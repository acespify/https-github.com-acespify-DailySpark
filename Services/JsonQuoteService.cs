using DailySpark.FinalProject.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace DailySpark.FinalProject.Services
{
    public class JsonQuoteService
    {
        // The constructor for the class, this will be used to perform dependency injection
        // I'll use the IWebHostEnvironment interface to be available for the class.
        public JsonQuoteService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        // Creating a property to allow the application to become aware of its surroundings,
        // all we will need is to get the information.
        public IWebHostEnvironment WebHostEnvironment { get; }

        // This property is used to retrieve the file that stores the data
        // Retrieves it from the web root folder to the data folder, 
        private string JsonFileName =>
            Path.Combine(WebHostEnvironment.WebRootPath, "data", "quotes.json");

        public IEnumerable<Quotes> GetQuote()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Quotes[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                   PropertyNameCaseInsensitive = true
                });
        }
        
        // I would like people to rate the quote they have received.
        public void AddRating(string quoteId, int rating)
        {
            var quote = GetQuote();

            var query = quote.First(x => x.Id == quoteId);

            if (query.Ratings == null)
            {
                query.Ratings = new int[] { rating };
            }
            else
            {
                var ratings = query.Ratings.ToList();
                ratings.Add(rating);
                query.Ratings = ratings.ToArray();
            }

            using var outputStream = File.OpenWrite(JsonFileName);

            JsonSerializer.Serialize<IEnumerable<Quotes>>(
                new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    SkipValidation = true,
                    Indented = true
                }),
                quote
            );
        }
    }
}
