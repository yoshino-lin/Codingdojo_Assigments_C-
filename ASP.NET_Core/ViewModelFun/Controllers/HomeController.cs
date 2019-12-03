using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Person.Models;

namespace ViewModelFun.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public ViewResult Index(){
            string message_display ="Let's get some practice using ViewModels. This project should have 4 routes that each display a different model from our controller. We'll start out with a few simple built-in types (strings and int), and then use a custom class (User) to display a single User and a collection of Users.";
            return View("Index",message_display);
        }
        
        [HttpGet]
        [Route("numbers")]
        public IActionResult Numbers(){
            // to a View that has defined a model as @model string[]
            int[] numbers = new int[]
            {
            1,2,3,10,43,5
            };
            return View("Numbers",numbers);
        }

        [HttpGet]
        [Route("users")]
        public IActionResult Names(){
            User somePerson = new User(){
                FirstName = "Moose",
                LastName = "Phillips",
            };
            User somePerson2 = new User(){
                FirstName = "Sarah",
                LastName = "",
            };
            User somePerson3 = new User(){
                FirstName = "Jerry",
                LastName = "",
            };
            User somePerson4 = new User(){
                FirstName = "Rene",
                LastName = "Ricky",
            };
            User somePerson5 = new User(){
                FirstName = "Barbarah",
                LastName = "",
            };
            
            List<User> names = new List<User>
            {
                somePerson,
                somePerson2,
                somePerson3,
                somePerson4,
                somePerson5
            };
            return View("Users",names);
        }
        [HttpGet]
        [Route("user")]
        public IActionResult Name(){
            User somePerson = new User(){
                FirstName = "Moose",
                LastName = "Phillips",
            };
            return View("User",somePerson);
        }
    }
}
