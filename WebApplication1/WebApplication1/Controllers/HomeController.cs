using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Linq;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var cars = _context.Cars.ToList();
        return View(cars);
    }

    public IActionResult AddCar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddCar(Car car)
    {
        if (ModelState.IsValid)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(car);
    }

    public IActionResult EditCar(int id)
    {
        var car = _context.Cars.Find(id);
        if (car == null)
        {
            return NotFound();
        }
        return View(car);
    }

    [HttpPost]
    public IActionResult EditCar(Car car)
    {
        if (ModelState.IsValid)
        {
            _context.Cars.Update(car);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(car);
    }

    public IActionResult DeleteCar(int id)
    {
        var car = _context.Cars.Find(id);
        if (car == null)
        {
            return NotFound();
        }
        return View(car);
    }

    [HttpPost, ActionName("DeleteCar")]
    public IActionResult DeleteCarConfirmed(int id)
    {
        var car = _context.Cars.Find(id);
        if (car != null)
        {
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}
