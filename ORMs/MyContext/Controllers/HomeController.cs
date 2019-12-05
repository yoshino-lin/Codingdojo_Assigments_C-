using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyContext.Models;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;

namespace MyContext.Controllers
{
    public class HomeController : Controller
    {
        public class HomeController : Controller
    {
        private MyContext dbContext;
    
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
    
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<User> AllUsers = dbContext.Users.ToList();
            
            return View();
        }
    }
    }
}
