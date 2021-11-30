using Microsoft.AspNetCore.Mvc;
using MovieReviewApp.Models;
using MovieReviewApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReviewApp.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(User u)
        {
            var result = _userService.SignIn(u);
            if (result)
            {
                return View("UserHome");
            }
            else
            {
                return View("IncorrectPassword");
            }
            
        }

        public ActionResult SignUp(User u)
        {
            var result = _userService.AddUser(u);
            if (result)
            {
                return View("SignUpSuccessful");
            }
            else
            {
                return View("IncorrectPassword");
            }
        }
    }
}
