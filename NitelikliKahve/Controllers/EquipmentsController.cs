using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NitelikliKahve.Models;

namespace NitelikliKahve.Controllers;

public class EquipmentsController : Controller
{
    private readonly ApplicationDbContext _context;

    public EquipmentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _context.Equipments.ToListAsync();
        return View(items);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Equipment equipment)
    {
        if (ModelState.IsValid)
        {
            _context.Add(equipment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(equipment);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var item = await _context.Equipments.FirstOrDefaultAsync(e => e.Id == id);
        if (item == null) return NotFound();
        return View(item);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var item = await _context.Equipments.FindAsync(id);
        if (item == null) return NotFound();
        return View(item);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Equipment equipment)
    {
        if (id != equipment.Id) return NotFound();
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(equipment);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Equipments.AnyAsync(e => e.Id == equipment.Id))
                    return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(equipment);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var item = await _context.Equipments.FirstOrDefaultAsync(e => e.Id == id);
        if (item == null) return NotFound();
        return View(item);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await _context.Equipments.FindAsync(id);
        if (item != null)
        {
            _context.Equipments.Remove(item);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
