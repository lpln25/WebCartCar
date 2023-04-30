using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CartCar.App.Context;
using CartCar.App.Models.Entities;
using CartCar.App.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CartCar.App.Controllers
{
    public class CartcarController : Controller
    {
        private readonly DatabaseContext _context;

        public CartcarController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Cartcar
        public async Task<IActionResult> Index()
        {
            return _context.cartcars != null ?
                        View(await _context.cartcars.ToListAsync()) :
                        Problem("Entity set 'DatabaseContext.cartcars'  is null.");
        }

        // GET: Cartcar/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.cartcars == null)
            {
                return NotFound();
            }

            var cartcar = await _context.cartcars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartcar == null)
            {
                return NotFound();
            }

            return View(cartcar);
        }

        // GET: Cartcar/Create
        public IActionResult Create()
        {
            var model = new Cartcar();
            return View(model);
        }

        // POST: Cartcar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OwnerName,NationalCode,Fathername,VIN,ModelCar,SystemCar,Tip,Color,DateCreated,FuelType,Copacity,EngineNumber,ChassisNumber,SerialNumber,Part1,Part2,Part3,Part4")] Cartcar cartcar)
        {
            if (ModelState.IsValid)
            {
                if (IranNationalCode.validator(cartcar.NationalCode))
                {
                    _context.Add(cartcar);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(nameof(cartcar.NationalCode), "کد ملی صحیح وارد نمایید");
                }
            }
            return View(cartcar);
        }

        // GET: Cartcar/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.cartcars == null)
            {
                return NotFound();
            }

            var cartcar = await _context.cartcars.FindAsync(id);
            if (cartcar == null)
            {
                return NotFound();
            }
            return View(cartcar);
        }

        // POST: Cartcar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,OwnerName,NationalCode,Fathername,VIN,ModelCar,SystemCar,Tip,Color,DateCreated,FuelType,Copacity,EngineNumber,ChassisNumber,SerialNumber,Part1,Part2,Part3,Part4")] Cartcar cartcar)
        {
            if (id != cartcar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartcar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartcarExists(cartcar.Id))
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
            return View(cartcar);
        }

        // GET: Cartcar/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.cartcars == null)
            {
                return NotFound();
            }

            var cartcar = await _context.cartcars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartcar == null)
            {
                return NotFound();
            }

            return View(cartcar);
        }

        // POST: Cartcar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.cartcars == null)
            {
                return Problem("Entity set 'DatabaseContext.cartcars'  is null.");
            }
            var cartcar = await _context.cartcars.FindAsync(id);
            if (cartcar != null)
            {
                _context.cartcars.Remove(cartcar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartcarExists(long id)
        {
            return (_context.cartcars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
