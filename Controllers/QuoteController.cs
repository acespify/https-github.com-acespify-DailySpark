using DailySpark.FinalProject.Models;
using DailySpark.FinalProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace DailySpark.FinalProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        public QuoteController(JsonQuoteService quoteService)
        {
            this.QuoteService = quoteService;
        }

        public JsonQuoteService QuoteService { get; }

        [HttpGet]
        public IEnumerable<Quotes> Get()
        {
            return QuoteService.GetQuote();
        }
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get(
            [FromQuery]string QuoteId,
            [FromQuery] int Rating)
        {
            QuoteService.AddRating(QuoteId, Rating);
            return Ok();
        }
    }
}
