using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarCenter.Data;
using CarCenter.Models;
using CarCenter.Models.ViewModels;
using NuGet.Protocol.Plugins;

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
            //ViewData["Buyer"] = new SelectList(_context.Client, "Name", "Name");
            //ViewData["Car"] = new SelectList(_context.Car, "Model", "Model");
            //ViewData["Seller"] = new SelectList(_context.Seller, "Name", "Name");
            //return View();

            var viewModel = new BillFormViewModel();

            viewModel.Clients = _context.Client.ToList();
            viewModel.Sellers = _context.Seller.ToList();
            viewModel.Cars = _context.Car.ToList();

            return View(viewModel);
        }

        // POST: Bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Bill bill)
        {
            if (bill == null)
            {
                return NotFound();
            }

            _context.Add(bill);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Bills/Edit/5

        public IActionResult Edit(int id)
        {
            var bill = _context.Bill.FirstOrDefault(s => s.Id == id);

            // Verificar se foi encontrado um objeto vendedor com o id passado na url
            if (bill == null)
            {
                return NotFound();
            }

            // Cria uma lista de departamentos
            List<Client> clients = _context.Client.ToList();
            List<Seller> sellers = _context.Seller.ToList();
            List<Car> cars = _context.Car.ToList();

            // Cria uma instância do View Model
            BillFormViewModel viewModel = new BillFormViewModel();

            viewModel.Clients = clients;
            viewModel.Sellers = sellers;
            viewModel.Cars = cars;
            viewModel.Bill = bill;

            return View(viewModel);
        }
        

        // POST: Bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Bill bill)
        {
            // Verifica se foi passado um objeto 
            if (bill == null)
            {
                return NotFound();
            }

            _context.Update(bill);
            _context.SaveChanges();
            return RedirectToAction("Index");
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
