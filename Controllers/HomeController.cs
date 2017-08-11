using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace quotingdojo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("quotes")]
        public IActionResult SaveQuotes(string Name, string Quote)
        {
            String q = $"INSERT INTO quotes(name, quote) VALUES('{Name}', '{Quote}')";
            DbConnector.Query(q);

            return RedirectToAction("Quotes");
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            List<Dictionary<string, object>> Quotes = DbConnector.Query("SELECT * FROM quotes ORDER BY datetime DESC");
            ViewBag.quotes = Quotes;

            return View();
        }
    }
}
