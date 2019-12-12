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
            if(HttpContext.Session.GetInt32("UserId")==null){
                return View("Index");
            }else{
                return RedirectToAction("MainMenu");
            }
        }

        [HttpGet("Dashboard")]
        public IActionResult MainMenu(){
            if(HttpContext.Session.GetInt32("UserId")==null){
                return RedirectToAction("Index");
            }else{
                List<Wedding> AllWedding = dbContext.Weddings
                    .Include(wedding => wedding.Creator)
                    .Include(wedding => wedding.GuestsOfWedding)
                    .ToList();
                User this_user = dbContext.Users
                    .Include(wedding => wedding.WeddingsToGo)
                    .FirstOrDefault(user => user.UserId == (int)HttpContext.Session.GetInt32("UserId"));
                HttpContext.Session.SetInt32("UserId", this_user.UserId);
                ViewBag.Models = AllWedding;
                ViewBag.ThisUser = this_user;
                return View("MainMenu");
            }
        }

        [HttpGet("new")]
        public IActionResult New(){
            if(HttpContext.Session.GetInt32("UserId")==null){
                return RedirectToAction("Index");
            }else{
                return View("New");
            }
        }

        [HttpPost("register/Dashboard")]
        public IActionResult Registration(OnlineChecker Data_get){
            User the_user = Data_get.User;
            if(ModelState.IsValid){
                if(dbContext.Users.Any(u => u.Email == the_user.Email)){
                    ModelState.AddModelError("User.Email", "Email already in use!");
                    return View("Index");
                }else{
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    the_user.Password = Hasher.HashPassword(the_user, the_user.Password);
                    dbContext.Add(the_user);
                    dbContext.SaveChanges();
                    User this_user = dbContext.Users.FirstOrDefault(user => user.Email == the_user.Email);
                    HttpContext.Session.SetInt32("UserId", this_user.UserId);
                    return RedirectToAction("MainMenu");
                }
            }else{
                return View("Index");
            }
        }

        [HttpPost("login/Dashboard")]
        public IActionResult LoginCheck(OnlineChecker Data_get){
            LoginUser userSubmission = Data_get.LoginUser;
            if(ModelState.IsValid){
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
                if(userInDb == null){
                    ModelState.AddModelError("LoginUser.Email", "Invalid Email");
                    return View("Index");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                if(result == 0){
                    ModelState.AddModelError("LoginUser.Password", "Password Incorrect!");
                    return View("Index");
                }else{
                    HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                    return RedirectToAction("MainMenu");
                }
            }else{
                return View("Index");
            }
        }

        [HttpPost("new/Dashboard")]
        public IActionResult CreateNewWedding(OnlineChecker Data_get){
            Wedding the_wedding = Data_get.Wedding;
            if(ModelState.IsValid){
                the_wedding.UserId = (int)HttpContext.Session.GetInt32("UserId");
                dbContext.Add(the_wedding);
                dbContext.SaveChanges();
                return RedirectToAction("MainMenu");
            }else{
                return View("New");
            }
        }

        [HttpGet("display/{weddingId}")]
        public IActionResult DisplayeWedding(int weddingId){
            if(HttpContext.Session.GetInt32("UserId")!=null){
                Wedding this_wedding = dbContext.Weddings
                    .Include(wedding => wedding.Creator)
                    .Include(wedding => wedding.GuestsOfWedding)
                    .ThenInclude(sub => sub.User)
                    .FirstOrDefault(wedding => wedding.WeddingId == weddingId);
                return View("Display",this_wedding);
            }else{
                return View("Index");
            }
        }

        [HttpGet("rsvp/{weddingId}")]
        public IActionResult RSVP(int weddingId){
            if(HttpContext.Session.GetInt32("UserId")!=null){
                if(dbContext.Weddings.Any(u => u.WeddingId == weddingId)){
                    Subscription IsSubscription = dbContext.Subscriptions
                        .Where(u => u.WeddingId == weddingId)
                        .FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
                    if(IsSubscription == null){
                        Subscription newSubscription = new Subscription();
                        newSubscription.UserId = (int)HttpContext.Session.GetInt32("UserId");
                        newSubscription.WeddingId = weddingId;
                        dbContext.Add(newSubscription);
                        dbContext.SaveChanges();
                    }
                }
                return RedirectToAction("MainMenu");
            }else{
                return View("Index");
            }
        }

        [HttpGet("unrsvp/{weddingId}")]
        public IActionResult UNRSVP(int weddingId){
            if(HttpContext.Session.GetInt32("UserId")!=null){
                Subscription the_newSubscription = dbContext.Subscriptions
                    .Where(u => u.WeddingId == weddingId)
                    .FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
                if(the_newSubscription != null){
                    dbContext.Remove(the_newSubscription);
                    dbContext.SaveChanges();
                }
                return RedirectToAction("MainMenu");
            }else{
                return View("Index");
            }
        }
        
        [HttpGet("delete/{weddingId}")]
        public IActionResult DeleteWedding(int weddingId){
            if(HttpContext.Session.GetInt32("UserId")!=null){
                Wedding this_wedding = dbContext.Weddings
                    .Include(wedding => wedding.Creator)
                    .FirstOrDefault(wedding => wedding.WeddingId == weddingId);
                if(this_wedding != null){
                    if(this_wedding.Creator.UserId == HttpContext.Session.GetInt32("UserId")){
                        dbContext.Remove(this_wedding);
                        dbContext.SaveChanges();
                    }
                }
                return RedirectToAction("MainMenu");
            }else{
                return View("Index");
            }
        }

        [HttpGet("logout")]
        public IActionResult LogOut(LoginUser userSubmission){
            if(HttpContext.Session.GetInt32("UserId")!=null){
                HttpContext.Session.Clear();
            }
            return RedirectToAction("Index");
        }
    }
}
