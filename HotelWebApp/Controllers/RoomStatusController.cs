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
    public class RoomStatusController : Controller
    {
        private readonly HotelDbContext _context;

        public RoomStatusController(HotelDbContext context)
        {
            _context = context;
        }

        // GET: RoomStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomStatuses.ToListAsync());
        }

        // GET: RoomStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomStatus = await _context.RoomStatuses
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (roomStatus == null)
            {
                return NotFound();
            }

            return View(roomStatus);
        }

        // GET: RoomStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusId,StatusName")] RoomStatus roomStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomStatus);
        }

        // GET: RoomStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomStatus = await _context.RoomStatuses.FindAsync(id);
            if (roomStatus == null)
            {
                return NotFound();
            }
            return View(roomStatus);
        }

        // POST: RoomStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatusId,StatusName")] RoomStatus roomStatus)
        {
            if (id != roomStatus.StatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomStatusExists(roomStatus.StatusId))
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
            return View(roomStatus);
        }

        // GET: RoomStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomStatus = await _context.RoomStatuses
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (roomStatus == null)
            {
                return NotFound();
            }

            return View(roomStatus);
        }

        // POST: RoomStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomStatus = await _context.RoomStatuses.FindAsync(id);
            if (roomStatus != null)
            {
                _context.RoomStatuses.Remove(roomStatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomStatusExists(int id)
        {
            return _context.RoomStatuses.Any(e => e.StatusId == id);
        }
    }
}
