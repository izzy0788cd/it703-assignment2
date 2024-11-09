using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelWebApp.Models;

namespace HotelWebApp.Controllers
{
    public class TravelAgenciesController : Controller
    {
        private readonly HotelDbContext _context;

        public TravelAgenciesController(HotelDbContext context)
        {
            _context = context;
        }

        // GET: TravelAgencies
        public async Task<IActionResult> Index()
        {
            return View(await _context.TravelAgencies.ToListAsync());
        }

        // GET: TravelAgencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelAgency = await _context.TravelAgencies
                .FirstOrDefaultAsync(m => m.AgencyId == id);
            if (travelAgency == null)
            {
                return NotFound();
            }

            return View(travelAgency);
        }

        // GET: TravelAgencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TravelAgencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgencyId,AgencyName,Address,Country,Phone,Email")] TravelAgency travelAgency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(travelAgency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(travelAgency);
        }

        // GET: TravelAgencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelAgency = await _context.TravelAgencies.FindAsync(id);
            if (travelAgency == null)
            {
                return NotFound();
            }
            return View(travelAgency);
        }

        // POST: TravelAgencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AgencyId,AgencyName,Address,Country,Phone,Email")] TravelAgency travelAgency)
        {
            if (id != travelAgency.AgencyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travelAgency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelAgencyExists(travelAgency.AgencyId))
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
            return View(travelAgency);
        }

        // GET: TravelAgencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelAgency = await _context.TravelAgencies
                .FirstOrDefaultAsync(m => m.AgencyId == id);
            if (travelAgency == null)
            {
                return NotFound();
            }

            return View(travelAgency);
        }

        // POST: TravelAgencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var travelAgency = await _context.TravelAgencies.FindAsync(id);
            if (travelAgency != null)
            {
                _context.TravelAgencies.Remove(travelAgency);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelAgencyExists(int id)
        {
            return _context.TravelAgencies.Any(e => e.AgencyId == id);
        }
    }
}
