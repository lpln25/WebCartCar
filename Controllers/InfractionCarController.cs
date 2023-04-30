using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CartCar.App.Context;
using CartCar.App.Models.Entities;

namespace CartCar.App.Controllers
{
    public class InfractionCarController : Controller
    {
        private readonly DatabaseContext _context;

        public InfractionCarController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: InfractionCars
        public async Task<IActionResult> Index()
        {
              return _context.infractionCars != null ? 
                          View(await _context.infractionCars.ToListAsync()) :
                          Problem("Entity set 'DatabaseContext.infractionCars'  is null.");
        }

        // GET: InfractionCars/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.infractionCars == null)
            {
                return NotFound();
            }

            var infractionCar = await _context.infractionCars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (infractionCar == null)
            {
                return NotFound();
            }

            return View(infractionCar);
        }

        // GET: InfractionCars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InfractionCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Infraction,Price1,Price2,Price3")] InfractionCar infractionCar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infractionCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(infractionCar);
        }

        // GET: InfractionCars/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.infractionCars == null)
            {
                return NotFound();
            }

            var infractionCar = await _context.infractionCars.FindAsync(id);
            if (infractionCar == null)
            {
                return NotFound();
            }
            return View(infractionCar);
        }

        // POST: InfractionCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Code,Infraction,Price1,Price2,Price3")] InfractionCar infractionCar)
        {
            if (id != infractionCar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infractionCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfractionCarExists(infractionCar.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(infractionCar);
        }

        // GET: InfractionCars/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.infractionCars == null)
            {
                return NotFound();
            }

            var infractionCar = await _context.infractionCars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (infractionCar == null)
            {
                return NotFound();
            }

            return View(infractionCar);
        }

        // POST: InfractionCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.infractionCars == null)
            {
                return Problem("Entity set 'DatabaseContext.infractionCars'  is null.");
            }
            var infractionCar = await _context.infractionCars.FindAsync(id);
            if (infractionCar != null)
            {
                _context.infractionCars.Remove(infractionCar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfractionCarExists(long id)
        {
          return (_context.infractionCars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
