using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CartCar.App.Context;
using CartCar.App.Models.Entities;
using CartCar.App.Models.ViewModels;
using Microsoft.IdentityModel.Tokens;

namespace CartCar.App.Controllers
{
    public class DrivingOffenseController : Controller
    {
        private readonly DatabaseContext _context;

        public DrivingOffenseController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: DrivingOffense
        public async Task<IActionResult> Index()
        {
            return _context.drivingOffenses != null ?
                        View(await _context.drivingOffenses.ToListAsync()) :
                        Problem("Entity set 'DatabaseContext.drivingOffenses'  is null.");
        }

        // GET: DrivingOffense/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.drivingOffenses == null)
            {
                return NotFound();
            }

            var drivingOffenses = await _context.drivingOffenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drivingOffenses == null)
            {
                return NotFound();
            }

            return View(drivingOffenses);
        }

        // GET: DrivingOffense/Create
        public IActionResult Create()
        {
            var model = new DrivingOffenses();
            return View(model);
        }

        // POST: DrivingOffense/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Location,DateDone,Code,Price,Part1,Part2,Part3,Part4")] DrivingOffenses drivingOffenses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drivingOffenses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drivingOffenses);
        }

        // GET: DrivingOffense/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.drivingOffenses == null)
            {
                return NotFound();
            }

            var drivingOffenses = await _context.drivingOffenses.FindAsync(id);
            if (drivingOffenses == null)
            {
                return NotFound();
            }
            return View(drivingOffenses);
        }

        // POST: DrivingOffense/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Location,DateDone,Code,Price,Part1,Part2,Part3,Part4")] DrivingOffenses drivingOffenses)
        {
            if (id != drivingOffenses.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drivingOffenses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrivingOffensesExists(drivingOffenses.Id))
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
            return View(drivingOffenses);
        }

        // GET: DrivingOffense/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.drivingOffenses == null)
            {
                return NotFound();
            }

            var drivingOffenses = await _context.drivingOffenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drivingOffenses == null)
            {
                return NotFound();
            }

            return View(drivingOffenses);
        }

        // POST: DrivingOffense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.drivingOffenses == null)
            {
                return Problem("Entity set 'DatabaseContext.drivingOffenses'  is null.");
            }
            var drivingOffenses = await _context.drivingOffenses.FindAsync(id);
            if (drivingOffenses != null)
            {
                _context.drivingOffenses.Remove(drivingOffenses);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrivingOffensesExists(long id)
        {
            return (_context.drivingOffenses?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult Search()
        {
            var model = new SearchDrivingOffenseVM();
            return View(model);
        }

        [HttpPost]
        public IActionResult Search(SearchDrivingOffenseVM search)
        {
            SearchDrivingOffenseVM resultSearch = new SearchDrivingOffenseVM();
            resultSearch.drivingOffenses = search.drivingOffenses;
            if (search.drivingOffenses.DateDone == null && string.IsNullOrEmpty(search.drivingOffenses.Location))
            {
                resultSearch.ResultSearchDrivingOffenses = _context.drivingOffenses.Where(s =>
                search.drivingOffenses.Part1 == s.Part1
                && search.drivingOffenses.Part2 == s.Part2
                && search.drivingOffenses.Part3 == s.Part3
                && search.drivingOffenses.Part4 == s.Part4
                ).ToList();
            }
            else if (search.drivingOffenses.DateDone == null)
            {
                resultSearch.ResultSearchDrivingOffenses = _context.drivingOffenses.Where(s =>
                s.Location.Contains(search.drivingOffenses.Location)
                && search.drivingOffenses.Part1 == s.Part1
                && search.drivingOffenses.Part2 == s.Part2
                && search.drivingOffenses.Part3 == s.Part3
                && search.drivingOffenses.Part4 == s.Part4
                ).ToList();
            }
            else if (string.IsNullOrEmpty(search.drivingOffenses.Location))
            {
                resultSearch.ResultSearchDrivingOffenses = _context.drivingOffenses.Where(s =>
                s.DateDone == search.drivingOffenses.DateDone
                && search.drivingOffenses.Part1 == s.Part1
                && search.drivingOffenses.Part2 == s.Part2
                && search.drivingOffenses.Part3 == s.Part3
                && search.drivingOffenses.Part4 == s.Part4
                ).ToList();
            }
            else
            {
                resultSearch.ResultSearchDrivingOffenses = _context.drivingOffenses.Where(s =>
                s.Location.Contains(search.drivingOffenses.Location)
                &&s.DateDone == search.drivingOffenses.DateDone
                && search.drivingOffenses.Part1 == s.Part1
                && search.drivingOffenses.Part2 == s.Part2
                && search.drivingOffenses.Part3 == s.Part3
                && search.drivingOffenses.Part4 == s.Part4
                ).ToList();
            }
            return View(resultSearch);
        }
    }
}
