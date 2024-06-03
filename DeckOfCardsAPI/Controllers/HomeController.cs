using DeckOfCardsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeckOfCardsAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DrawCardsResult()
        {

            DrawCards cards = DrawCardsDAL.GetCards(DrawCardsDAL.GetNewDeck());
            return View(cards);
        }


        [HttpPost]
        public IActionResult DrawCardsResult(string deck)
        {
            DrawCards cards = DrawCardsDAL.GetCards(deck);
            if(cards.remaining <= 0)
            {
                DrawCardsDAL.ShuffleDeck(deck);
            }
            return View(cards);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
