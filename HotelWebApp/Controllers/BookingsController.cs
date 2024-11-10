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
    public class BookingsController : Controller
    {
        private readonly HotelDbContext _context;

        public BookingsController(HotelDbContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var hotelDbContext = _context.Bookings.Include(b => b.CreditCard).Include(b => b.Customer).Include(b => b.Room);
            return View(await hotelDbContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.CreditCard)
                .Include(b => b.Customer)
                .Include(b => b.Room)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["CreditCardId"] = new SelectList(_context.CreditCards, "CreditCardId", "CreditCardId");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomNumber");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingsDTO booking)
        {
            if (ModelState.IsValid)
            {
                Booking bookings = new Booking
                {
                    CustomerId = booking.CustomerId,
                    RoomId = booking.RoomId,
                    CheckInDate = booking.CheckInDate,
                    CheckOutDate = booking.CheckOutDate,
                    NumberOfGuests = booking.NumberOfGuests,
                    Price = booking.Price,
                    CreditCardId = booking.CreditCardId,
                    DepositMade = booking.DepositMade,
                    DepositMethod = booking.DepositMethod,
                    DepositStatus = booking.DepositStatus,
                    BookingReference = booking.BookingReference,
                };


                _context.Bookings.Add(bookings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreditCardId"] = new SelectList(_context.CreditCards, "CreditCardId", "CreditCardId", booking.CreditCardId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", booking.CustomerId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomNumber", booking.RoomId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["CreditCardId"] = new SelectList(_context.CreditCards, "CreditCardId", "CreditCardId", booking.CreditCardId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", booking.CustomerId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomNumber", booking.RoomId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookingsDTO booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var bookings = await _context.Bookings.FindAsync(id);

                    bookings.CustomerId = booking.CustomerId;
                    bookings.RoomId = booking.RoomId;
                    bookings.CheckInDate = booking.CheckInDate;
                    bookings.CheckOutDate = booking.CheckOutDate;
                    bookings.NumberOfGuests = booking.NumberOfGuests;
                    bookings.Price = booking.Price;
                    bookings.CreditCardId = booking.CreditCardId;
                    bookings.DepositMade = booking.DepositMade;
                    bookings.DepositMethod = booking.DepositMethod;
                    bookings.DepositStatus = booking.DepositStatus;
                    bookings.BookingReference = booking.BookingReference;


                    _context.Bookings.Update(bookings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingId))
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
            ViewData["CreditCardId"] = new SelectList(_context.CreditCards, "CreditCardId", "CreditCardId", booking.CreditCardId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", booking.CustomerId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomNumber", booking.RoomId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.CreditCard)
                .Include(b => b.Customer)
                .Include(b => b.Room)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
