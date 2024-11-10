﻿using Microsoft.AspNetCore.Mvc;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var users = _userService.GetAllUsersAsync();
            return View(users);
        }

        public IActionResult Details(int id)
        {
            var user = _userService.GetUserByIdAsync(id);
            return View(user);
        }

        public IActionResult Edit(int id)
        {
            var user = _userService.GetUserByIdAsync(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdUserAsync(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}
