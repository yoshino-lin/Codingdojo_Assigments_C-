using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using MyProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
{
    private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            // Get all Users
            List<User> AllUsers = dbContext.Users.ToList();

            // Get Users with the LastName "Jefferson"
            List<User> Jeffersons = dbContext.Users.Where(u => u.LastName == "Jefferson");
            // Get the 5 most recently added Users
            List<User> MostRecent = dbContext.Users
                .OrderByDescending(u => u.CreatedAt)
                .Take(5)
                .ToList();
            return View();
        }
}
