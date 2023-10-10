using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarCenter.Data;
using CarCenter.Models;

namespace CarCenter.Controllers
{
    public class BillsController : Controller
    {
        private readonly CarCenterContext _context;

        public BillsController(CarCenterContext context)
        {
            _context = context;
        }

        // GET: Bills
        public async Task<IActionResult> Index()
        {
            var carCenterContext = _context.Bill.Include(b => b.Buyer).Include(b => b.Car).Include(b => b.Seller);
            return View(await carCenterContext.ToListAsync());
        }

        // GET: Bills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bill == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill
                .Include(b => b.Buyer)
                .Include(b => b.Car)
                .Include(b => b.Seller)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // GET: Bills/Create
        public IActionResult Create()
        {
            ViewData["BuyerId"] = new SelectList(_context.Client, "Id", "Id");
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Id");
            ViewData["SellerId"] = new SelectList(_context.Seller, "Id", "Id");
            return View();
        }

        // POST: Bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,EmissionDate,Warranty,SalePrice,BuyerId,SellerId,CarId")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuyerId"] = new SelectList(_context.Client, "Id", "Id", bill.BuyerId);
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Id", bill.CarId);
            ViewData["SellerId"] = new SelectList(_context.Seller, "Id", "Id", bill.SellerId);
            return View(bill);
        }

        // GET: Bills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bill == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }
            ViewData["BuyerId"] = new SelectList(_context.Client, "Id", "Id", bill.BuyerId);
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Id", bill.CarId);
            ViewData["SellerId"] = new SelectList(_context.Seller, "Id", "Id", bill.SellerId);
            return View(bill);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,EmissionDate,Warranty,SalePrice,BuyerId,SellerId,CarId")] Bill bill)
        {
            if (id != bill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillExists(bill.Id))
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
            ViewData["BuyerId"] = new SelectList(_context.Client, "Id", "Id", bill.BuyerId);
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Id", bill.CarId);
            ViewData["SellerId"] = new SelectList(_context.Seller, "Id", "Id", bill.SellerId);
            return View(bill);
        }

        // GET: Bills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bill == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill
                .Include(b => b.Buyer)
                .Include(b => b.Car)
                .Include(b => b.Seller)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bill == null)
            {
                return Problem("Entity set 'CarCenterContext.Bill'  is null.");
            }
            var bill = await _context.Bill.FindAsync(id);
            if (bill != null)
            {
                _context.Bill.Remove(bill);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillExists(int id)
        {
          return (_context.Bill?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
