using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Services;
using Infrastructure.Repositories;

namespace OnlineShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public AccountController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrate(User model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var existingUser = await _userRepository.GetByEmailAsync(model.Email);

            if (existingUser != null)
            {
                ModelState.AddModelError("", "This account already exist!");
                return View("Registration");

            }


            await _userService.RegisterUserAsync(model);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var existingUser = await _userRepository.GetByEmailAsync(model.Email);

            if (existingUser != null && model.Password != existingUser.Password)
            {
                TempData["ErrorMessage"] = "Wrong password or email!";
                return RedirectToAction("Index", "Home");
            }


            await _userService.RegisterUserAsync(model);

            return RedirectToAction("MainPage", "Main");
        }
    }
}
