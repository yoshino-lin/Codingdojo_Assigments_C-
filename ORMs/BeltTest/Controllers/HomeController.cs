using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeltTest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BeltTest.Controllers
{
    public class HomeController : Controller{
        private MyContext dbContext;
        public HomeController(MyContext context){dbContext = context;}

        [HttpGet("")]
        public IActionResult LoginChecker(){
            if(HttpContext.Session.GetInt32("UserId")==null){
                return RedirectToAction("Index");
            }else{
                return RedirectToAction("MainMenu");
            }
        }

        [HttpGet("signin")]
        public IActionResult Index(){
            if(HttpContext.Session.GetInt32("UserId")==null){
                return View("Index");
            }else{
                return RedirectToAction("MainMenu");
            }
        }

        [HttpGet("home")]
        public IActionResult MainMenu(){
            if(HttpContext.Session.GetInt32("UserId")==null){
                return RedirectToAction("Index");
            }else{
                ViewWrapper ViewWrapper = new ViewWrapper();
                //所有活动
                ViewWrapper.Activities = dbContext.Activities
                    .OrderBy(prod => prod.Date)
                    .Include(Activity => Activity.Creator)
                    .Include(Activity => Activity.GuestsOfActivity)
                    .ThenInclude(Activity => Activity.User)
                    .ToList();
                //登录的用户
                ViewWrapper.User = dbContext.Users

                    .FirstOrDefault(user => user.UserId == (int)HttpContext.Session.GetInt32("UserId"));
                return View("MainMenu",ViewWrapper);
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

        [HttpGet("register/home")]
        public IActionResult registerGoBack(){
            if(HttpContext.Session.GetInt32("UserId")==null){
                return RedirectToAction("Index");
            }else{
                return RedirectToAction("MainMenu");
            }
        }

        [HttpGet("login/home")]
        public IActionResult loginGoBack(){
            if(HttpContext.Session.GetInt32("UserId")==null){
                return RedirectToAction("Index");
            }else{
                return RedirectToAction("MainMenu");
            }
        }

        [HttpPost("register/home")]
        public IActionResult Registration(InputChecker Data_get){
            User the_user = Data_get.User;
            if(ModelState.IsValid){
                if(dbContext.Users.Any(u => u.Email == the_user.Email)){
                    ModelState.AddModelError("User.Email", "Email already in use!");
                    return View("Index");
                }else{
                    if(Regex.IsMatch(the_user.Password, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$")){
                        PasswordHasher<User> Hasher = new PasswordHasher<User>();
                        the_user.Password = Hasher.HashPassword(the_user, the_user.Password);
                        dbContext.Add(the_user);
                        dbContext.SaveChanges();
                        User this_user = dbContext.Users.FirstOrDefault(user => user.Email == the_user.Email);
                        HttpContext.Session.SetInt32("UserId", this_user.UserId);
                        return RedirectToAction("MainMenu");
                    }else{
                        ModelState.AddModelError("User.Password", "Must contain at least 1 number, letter, and a special character!");
                        return View("Index");
                    }
                    
                }
            }else{
                return View("Index");
            }
        }

        [HttpPost("login/home")]
        public IActionResult LoginCheck(InputChecker Data_get){
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

        [HttpPost("new/home")]
        public IActionResult CreateNewActivity(InputChecker Data_get){
            if(ModelState.IsValid){
                Data_get.Activity.UserId = (int)HttpContext.Session.GetInt32("UserId");
                dbContext.Add(Data_get.Activity);
                dbContext.SaveChanges();
                return RedirectToAction("MainMenu");
            }else{
                return View("New");
            }
        }

        [HttpGet("activity/{ActivityId}")]
        public IActionResult DisplayActivity(int ActivityId){
            if(HttpContext.Session.GetInt32("UserId")!=null){
                ViewWrapper ViewWrapper = new ViewWrapper();
                ViewWrapper.Activity = dbContext.Activities
                    .Include(Activity => Activity.Creator)
                    .Include(Activity => Activity.GuestsOfActivity)
                    .ThenInclude(sub => sub.User)
                    .FirstOrDefault(Activity => Activity.ActivityId == ActivityId);
                ViewWrapper.User = dbContext.Users
                    .Include(Activity => Activity.ActivitiesToGo)
                    .FirstOrDefault(user => user.UserId == (int)HttpContext.Session.GetInt32("UserId"));
                ViewWrapper.Activities = dbContext.Activities
                    .OrderBy(prod => prod.Date)
                    .Include(Activity => Activity.Creator)
                    .Include(Activity => Activity.GuestsOfActivity)
                    .ToList();
                return View("Display",ViewWrapper);
            }else{
                return View("Index");
            }
        }

        [HttpGet("rsvp/{ActivityId}")]
        public IActionResult RSVP(int ActivityId){
            if(HttpContext.Session.GetInt32("UserId")!=null){
                if(dbContext.Activities.Any(u => u.ActivityId == ActivityId)){
                    Subscription IsSubscription = dbContext.Subscriptions
                        .Where(u => u.ActivityId == ActivityId)
                        .FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
                    if(IsSubscription == null){
                        Subscription newSubscription = new Subscription();
                        newSubscription.UserId = (int)HttpContext.Session.GetInt32("UserId");
                        newSubscription.ActivityId = ActivityId;
                        dbContext.Add(newSubscription);
                        dbContext.SaveChanges();
                    }
                }
                return RedirectToAction("MainMenu");
            }else{
                return View("Index");
            }
        }

        [HttpGet("unrsvp/{ActivityId}")]
        public IActionResult UNRSVP(int ActivityId){
            if(HttpContext.Session.GetInt32("UserId")!=null){
                Subscription the_newSubscription = dbContext.Subscriptions
                    .Where(u => u.ActivityId == ActivityId)
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
        
        [HttpGet("delete/{ActivityId}")]
        public IActionResult DeleteActivity(int ActivityId){
            if(HttpContext.Session.GetInt32("UserId")!=null){
                ViewWrapper ViewWrapper = new ViewWrapper();
                ViewWrapper.Activity = dbContext.Activities
                    .Include(Activity => Activity.Creator)
                    .FirstOrDefault(Activity => Activity.ActivityId == ActivityId);
                if(ViewWrapper.Activity != null){
                    if(ViewWrapper.Activity.Creator.UserId == HttpContext.Session.GetInt32("UserId")){
                        dbContext.Remove(ViewWrapper.Activity);
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
