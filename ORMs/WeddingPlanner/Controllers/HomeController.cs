using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller{
        private MyContext dbContext;
        public HomeController(MyContext context){dbContext = context;}


        [HttpGet("")]
        public IActionResult Index(){
            if(HttpContext.Session.GetString("UserId")==null){
                return View();
            }else{
                return RedirectToAction("Success");
            }
        }

        [HttpGet("Dashboard")]
        public IActionResult Registration(OnlineChecker Data_get){
            User the_user = Data_get.User;
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
                    return RedirectToAction("Success");
                }
            }else{
                return View("Index");
            }
        }

        [HttpPost("Dashboard")]
        public IActionResult LoginCheck(OnlineChecker Data_get){
            LoginUser userSubmission = Data_get.LoginUser;
            if(ModelState.IsValid){
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
                if(userInDb == null){
                    ModelState.AddModelError("Email", "Invalid Email");
                    return View("Index");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                if(result == 0){
                    ModelState.AddModelError("Password", "Password Incorrect!");
                    return View("Index");
                }else{
                    HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                    return RedirectToAction("Success");
                }
            }else{
                return View("Index");
            }
        }

        [HttpPost("logout")]
        public IActionResult LogOut(LoginUser userSubmission){
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}
