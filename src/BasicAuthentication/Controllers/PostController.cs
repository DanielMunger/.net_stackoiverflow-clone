using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BasicAuthentication.Models;
using BasicAuthentication.ViewModels;
using System.Diagnostics;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicAuthentication.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly UserManager<ApplicationUser> _userManager;

        public PostController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Create()
        {
            if(User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        public IActionResult Create(Post post)
        {
            post.Date = DateTime.Now;
            post.Votes = 0;
            post.User = db.Users.FirstOrDefault(u => u.Id == _userManager.GetUserId(HttpContext.User));
            db.Posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index", "Account");
        }
    }
}
