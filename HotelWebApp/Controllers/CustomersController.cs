﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelWebApp.Models;

namespace HotelWebApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly HotelDbContext _context;

        public CustomersController(HotelDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var hotelDbContext = _context.Customers.Include(c => c.Agency).Include(c => c.Company).Include(c => c.CreditCard);
            return View(await hotelDbContext.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Agency)
                .Include(c => c.Company)
                .Include(c => c.CreditCard)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["AgencyId"] = new SelectList(_context.TravelAgencies, "AgencyId", "AgencyId");
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId");
            ViewData["CreditCardId"] = new SelectList(_context.CreditCards, "CreditCardId", "CreditCardId");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,CreditCardId,Email,Phone,Notes,CompanyId,AgencyId,BookingReference")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgencyId"] = new SelectList(_context.TravelAgencies, "AgencyId", "AgencyId", customer.AgencyId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId", customer.CompanyId);
            ViewData["CreditCardId"] = new SelectList(_context.CreditCards, "CreditCardId", "CreditCardId", customer.CreditCardId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["AgencyId"] = new SelectList(_context.TravelAgencies, "AgencyId", "AgencyId", customer.AgencyId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId", customer.CompanyId);
            ViewData["CreditCardId"] = new SelectList(_context.CreditCards, "CreditCardId", "CreditCardId", customer.CreditCardId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName,CreditCardId,Email,Phone,Notes,CompanyId,AgencyId,BookingReference")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            ViewData["AgencyId"] = new SelectList(_context.TravelAgencies, "AgencyId", "AgencyId", customer.AgencyId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId", customer.CompanyId);
            ViewData["CreditCardId"] = new SelectList(_context.CreditCards, "CreditCardId", "CreditCardId", customer.CreditCardId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Agency)
                .Include(c => c.Company)
                .Include(c => c.CreditCard)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
