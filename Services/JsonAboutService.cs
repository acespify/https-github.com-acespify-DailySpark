using DailySpark.FinalProject.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DailySpark.FinalProject.Services
{
    public class JsonAboutService
    {
        public JsonAboutService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName =>
            Path.Combine(WebHostEnvironment.WebRootPath, "data", "about.json");

        public IEnumerable<About> GetAbout()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<About[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}
