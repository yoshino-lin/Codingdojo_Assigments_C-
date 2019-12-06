using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginAndRegistration.Models;
using Context.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LoginAndRegistration.Controllers
{
    public class HomeController : Controller{
        private MyContext dbContext;
        public HomeController(MyContext context){dbContext = context;}

        [HttpGet("")]
        public IActionResult Index(){
            if(HttpContext.Session.GetString("UserId")==null){
                return View();
            }else{
                return View("Success");
            }
        }

        [HttpPost("")]
        public IActionResult Registration(User the_user){
            if(ModelState.IsValid){
                if(dbContext.Users.Any(u => u.Email == the_user.Email)){
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                }else{
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    the_user.Password = Hasher.HashPassword(the_user, the_user.Password);
                    dbContext.Add(the_user);
                    dbContext.SaveChanges();
                    User this_user = dbContext.Users.FirstOrDefault(user => user.Email == the_user.Email);
                    HttpContext.Session.SetInt32("UserId", this_user.UserId);
                    return View("Success");
                }
            }else{
                return View("Index");
            }
        }
        [HttpGet("login")]
        public IActionResult login(){
            if(HttpContext.Session.GetString("UserId")==null){
                return View("Login");
            }else{
                return View("Success");
            }
        }

        [HttpPost("success")]
        public IActionResult LoginCheck(LoginUser userSubmission){
            if(ModelState.IsValid){
                // If inital ModelState is valid, query for a user with provided email
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
                // If no user exists with provided email
                if(userInDb == null){
                    // Add an error to ModelState and return to View!
                    ModelState.AddModelError("Email", "Invalid Email");
                    return View("Login");
                }
                
                // Initialize hasher object
                var hasher = new PasswordHasher<LoginUser>();
                
                // verify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                
                // result can be compared to 0 for failure
                if(result == 0){
                    ModelState.AddModelError("Password", "Password Incorrect!");
                    return View("Login");
                }else{
                    HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                    return View("Success");
                }
            }else{
                return View("Login");
            }
            
        }
        [HttpPost("logout")]
        public IActionResult LogOut(LoginUser userSubmission){
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}
