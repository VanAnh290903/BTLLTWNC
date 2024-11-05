using Btl_web_nc.Models;
using Btl_web_nc.RepositoryInterfaces;
using Btl_web_nc.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Btl_web_nc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserRepositories _userRepository;

        public AdminController(IUserRepositories userRepository)
        {
            _userRepository = userRepository;
        }
        
        public IActionResult Admin()
        {
            var users = _userRepository.GetAllUsers();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    username = model.Username,
                    phoneNumber = model.PhoneNumber,
                    password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                };

                _userRepository.AddUser(user);
                return RedirectToAction(nameof(Admin));
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var user = _userRepository.MaGetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new EditUserViewModel
            {
                Username = user.username,
                PhoneNumber = user.phoneNumber
          
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditUserViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var user = _userRepository.MaGetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }

                user.username = model.Username;
                user.phoneNumber = model.PhoneNumber;
              
                _userRepository.UpdateUser(user);
                return RedirectToAction(nameof(Admin));
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var user = _userRepository.MaGetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _userRepository.DeleteUser(id);
            return RedirectToAction(nameof(Admin));
        }
    }
}
