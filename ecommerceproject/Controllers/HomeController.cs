using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ecommerceproject.Models;
using ecommerceproject.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using ecommerceproject.Data;
using Microsoft.EntityFrameworkCore;
using AspNetCore;

namespace ecommerceproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Our()
        {
            return View();
        }
        public IActionResult Payment()
        {
            return View();
        }

        public IActionResult Paymentapp()
        {
            return View();
        }
        public IActionResult SendMessage()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Search()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel searchModel)
        {



            IQueryable<Malzeme> malzemes = _context.Malzeme.AsQueryable();

            if (!String.IsNullOrWhiteSpace(searchModel.SearchText))
            {
                if (searchModel.SearchInDescription)
                {
                    malzemes = malzemes.Where(b => b.Title.Contains(searchModel.SearchText) || b.Description.Contains(searchModel.SearchText));
                }
                else
                {
                    malzemes = malzemes.Where(b => b.Title.Contains(searchModel.SearchText));
                }
            }

            if (searchModel.CategoryId.HasValue)
            {
                malzemes = malzemes.Where(b => b.CategoryId == searchModel.CategoryId.Value);
            }

            if (searchModel.MinPrice.HasValue)
            {
                malzemes = malzemes.Where(b => b.Price >= searchModel.MinPrice.Value);
            }

            if (searchModel.MaxPrice.HasValue)
            {
                malzemes = malzemes.Where(b => b.Price <= searchModel.MaxPrice.Value);
            }

            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", searchModel.CategoryId);
            searchModel.Results = await malzemes.ToListAsync();
            return View(searchModel);
        }
    }
}
