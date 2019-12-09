using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;
using Context.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChefsDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context){dbContext = context;}

        [HttpGet("")]
        public IActionResult Index(){
            List<Chef> AllChefs = dbContext.Chef
                .Include(user => user.dishOfChef)
                .ToList();
            return View(AllChefs);
        }

        [HttpGet("new")]
        public IActionResult New(){
            return View("New");
        }

        [HttpGet("dishes/new")]
        public IActionResult NewDish(){
            ViewBag.AllChefs = dbContext.Chef.ToList();
            return View("NewDish");
        }

        [HttpPost("")]
        public IActionResult ChefCreator(Chef yourSurvey){
            if(ModelState.IsValid){
                dbContext.Add(yourSurvey);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }else{
                return View("New");
            }
        }
        
        [HttpGet("dishes")]
        public IActionResult Index_dishes(){
            List<Dish> ChefDishes = dbContext.Dish
                // populates each Message with its related User object (Creator)
                .Include(dish => dish.Creator)
                .ToList();
            return View("Dishes",ChefDishes);
        }

        [HttpPost("dishes")]
        public IActionResult Submission(Dish yourSurvey){
            if(ModelState.IsValid){
                dbContext.Add(yourSurvey);
                dbContext.SaveChanges();
                return Index_dishes();
            }else{
                List<Chef> AllChefs = dbContext.Chef.ToList();
                return View("NewDish",AllChefs);
            }
        }
        
    }
}
