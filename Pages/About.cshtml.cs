using DailySpark.FinalProject.Models;
using DailySpark.FinalProject.Services;
using IS370_YoungFinalProject.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace DailySpark.FinalProject.Pages
{
    public class AboutModel : PageModel
    {
        private readonly ILogger<AboutModel> _logger;
        public JsonAboutService AboutService;

        public IEnumerable<About>AboutDiscription { get; private set; }

        public AboutModel(ILogger<AboutModel> logger,
            JsonAboutService aboutService)
        {
            _logger = logger;
            AboutService = aboutService;
        }
        public void OnGet()
        {
            AboutDiscription = AboutService.GetAbout();
        }
    }
}
