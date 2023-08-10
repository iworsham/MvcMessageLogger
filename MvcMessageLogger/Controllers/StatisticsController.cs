using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMessageLogger.DataAccess;

namespace MvcMessageLogger.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly MvcMessageLoggerContext _context;

        public StatisticsController(MvcMessageLoggerContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var users = _context.Users
                .Include(u => u.Messages);
            List<string> words = new List<string>();
            {
                words.Add("hi");
                words.Add("hi");
                words.Add("hi");
                words.Add("hi");
                words.Add("hi");
                words.Add("hi");
                words.Add("hi");
                words.Add("hi");
                words.Add("Unicorns");
                words.Add("hey");
                words.Add("hello");


            }
            var mostCommonWords = words.GroupBy(w => w)
                .Select(w => new { KeyField = w.Key, Count = w.Count() })
                .OrderByDescending(w => w.Count);
  
            return View(users);
        }
      
    }
}
