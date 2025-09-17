using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DailySpark.FinalProject.Models;
using DailySpark.FinalProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace IS370_YoungFinalProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonQuoteService QuoteService; // this will get our service to add to the page
        public IEnumerable<Quotes> Quotes { get; private set; }      // Lets get the list of our Quotes

        public IndexModel(ILogger<IndexModel> logger,
            JsonQuoteService quoteService)
        {
            _logger = logger;
            QuoteService = quoteService;
        }

        public void OnGet()
        {
            Quotes = QuoteService.GetQuote();
        }
    }
}
