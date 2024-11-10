using HotelWebApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HotelWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly HotelDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountController(HotelDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        // GET: Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        // POST: Register
        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationDto model)
        {
            if (ModelState.IsValid)
            {
                // Check if username already exists
                var existingUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserName == model.UserName);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Username already exists.");
                    return View(model);
                }

                // Hash password (you can use a stronger hashing algorithm like bcrypt or PBKDF2 here)
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

                // Create new user
                var user = new User
                {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Phone =     model.Phone,
                RoleId = model.RoleId,
                Password = passwordHash,
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Automatically sign in the user after registration
                await SignInUser(user);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
        public IActionResult Login()
        {
            return View(); // This should return the Login view
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == model.Email);

                if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                {
                    // Sign in the user
                    await SignInUser(user);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login attempt.");
            }

            return View(model);
        }

        // Log the user out
        public async Task<IActionResult> Logout()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private async Task SignInUser(User user)
        {
            var claims = new List<Claim>
        {
            
            new Claim(ClaimTypes.Email, user.Email),
        };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
