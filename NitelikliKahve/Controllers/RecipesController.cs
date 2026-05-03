using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NitelikliKahve.Models;

namespace NitelikliKahve.Controllers;

public class RecipesController : Controller
{
    private readonly ApplicationDbContext _context;

    public RecipesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _context.Recipes
            .Include(r => r.CoffeeBean)
            .Include(r => r.Equipment)
            .ToListAsync();
        return View(items);
    }

    private async Task PopulateSelectLists()
    {
        var beans = await _context.CoffeeBeans
            .OrderBy(b => b.Brand)
            .ToListAsync();
        var equipments = await _context.Equipments
            .OrderBy(e => e.MachineName)
            .ToListAsync();

        ViewBag.CoffeeBeans = new SelectList(beans.Select(b => new { b.Id, Name = b.Brand + " - " + b.Origin }), "Id", "Name");
        ViewBag.Equipments = new SelectList(equipments.Select(e => new { e.Id, Name = e.MachineName }), "Id", "Name");
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var item = await _context.Recipes
            .Include(r => r.CoffeeBean)
            .Include(r => r.Equipment)
            .FirstOrDefaultAsync(r => r.Id == id);
        if (item == null) return NotFound();
        return View(item);
    }

    public async Task<IActionResult> Create()
    {
        await PopulateSelectLists();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Recipe recipe)
    {
        if (ModelState.IsValid)
        {
            _context.Add(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        await PopulateSelectLists();
        return View(recipe);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var item = await _context.Recipes.FindAsync(id);
        if (item == null) return NotFound();
        await PopulateSelectLists();
        return View(item);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Recipe recipe)
    {
        if (id != recipe.Id) return NotFound();
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(recipe);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Recipes.AnyAsync(r => r.Id == recipe.Id))
                    return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        await PopulateSelectLists();
        return View(recipe);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var item = await _context.Recipes
            .Include(r => r.CoffeeBean)
            .Include(r => r.Equipment)
            .FirstOrDefaultAsync(r => r.Id == id);
        if (item == null) return NotFound();
        return View(item);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await _context.Recipes.FindAsync(id);
        if (item != null)
        {
            _context.Recipes.Remove(item);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
