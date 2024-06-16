using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;
using System.Threading.Tasks;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class CarDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var carDetails = await _context.CarDetails.Include(cd => cd.Car).ToListAsync();
            return View(carDetails);
        }

        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Make");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PartName,PartNumber,Price,Description,CarId")] CarDetail carDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Make", carDetail.CarId);
            return View(carDetail);
        }
    }
}
