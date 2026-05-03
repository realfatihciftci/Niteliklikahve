using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NitelikliKahve.Models;

namespace NitelikliKahve.Controllers;

public class CoffeeBeansController : Controller
{
    private readonly ApplicationDbContext _context;

    public CoffeeBeansController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _context.CoffeeBeans.ToListAsync();
        return View(items);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CoffeeBean coffeeBean)
    {
        if (ModelState.IsValid)
        {
            _context.Add(coffeeBean);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(coffeeBean);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var item = await _context.CoffeeBeans.FirstOrDefaultAsync(c => c.Id == id);
        if (item == null) return NotFound();
        return View(item);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var item = await _context.CoffeeBeans.FindAsync(id);
        if (item == null) return NotFound();
        return View(item);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, CoffeeBean coffeeBean)
    {
        if (id != coffeeBean.Id) return NotFound();
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(coffeeBean);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.CoffeeBeans.AnyAsync(e => e.Id == coffeeBean.Id))
                    return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(coffeeBean);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var item = await _context.CoffeeBeans.FirstOrDefaultAsync(c => c.Id == id);
        if (item == null) return NotFound();
        return View(item);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await _context.CoffeeBeans.FindAsync(id);
        if (item != null)
        {
            _context.CoffeeBeans.Remove(item);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
