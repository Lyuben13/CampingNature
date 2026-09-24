using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Intro.Data;

namespace MVC.Intro.Controllers
{
    public class CampingController : Controller
    {
        private readonly AppDbContext _context;

        public CampingController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tents = _context.CampingTents
                .AsNoTracking()
                .AsEnumerable()
                .OrderBy(t => t.Price)
                .ToList();

            return View(tents);
        }
    }
}