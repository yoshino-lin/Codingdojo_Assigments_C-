using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using YourNamespace.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller{
        private MyContext dbContext;
    
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
    
        [HttpGet("")]
        public IActionResult Index()
        {
            List<User> AllUsers = dbContext.Users.ToList();
            return View(AllUsers);
        }

        [HttpGet("new")]
        public IActionResult AddDish()
        {
            List<User> AllUsers = dbContext.Users.ToList();
            return View("New");
        }

        [HttpGet("{UserId}")]
        public IActionResult DisplayDish(int UserId)
        {
            User the_dish = dbContext.Users.FirstOrDefault(user => user.UserId == UserId);
            return View("Display",the_dish);
        }

        [HttpPost("delete/{UserId}")]
        public IActionResult DeleteDish(int UserId)
        {
            User RetrievedUser = dbContext.Users.SingleOrDefault(user => user.UserId == UserId);
            dbContext.Users.Remove(RetrievedUser);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost("edit/{UserId}")]
        public IActionResult EditDish(int UserId)
        {
            User the_dish = dbContext.Users.FirstOrDefault(user => user.UserId == UserId);
            return View("Edit",the_dish);
        }

        [HttpPost("update/{UserId}")]
        public IActionResult UpdateUser(int UserId,User yourSurvey)
        {
            User RetrievedUser = dbContext.Users.FirstOrDefault(user => user.UserId == UserId);
            RetrievedUser.Name = yourSurvey.Name;
            RetrievedUser.DishName = yourSurvey.DishName;
            RetrievedUser.Calories = yourSurvey.Calories;
            RetrievedUser.Tastiness = yourSurvey.Tastiness;
            RetrievedUser.Description = yourSurvey.Description;
            RetrievedUser.UpdatedAt = DateTime.Now;
            dbContext.SaveChanges();
            User the_dish = dbContext.Users.FirstOrDefault(user => user.UserId == UserId);
            return View("Display",the_dish);
        }

        public IActionResult Submission(User yourSurvey){
            if(ModelState.IsValid){
                dbContext.Add(yourSurvey);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }else{
                return View("New");
            }
        }
    }
}
