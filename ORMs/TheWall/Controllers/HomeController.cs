using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWall.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace TheWall.Controllers{
    public class HomeController : Controller{
        private MyContext dbContext;
        public HomeController(MyContext context){dbContext = context;}

        [HttpGet("login")]
        public IActionResult Index(){
            if(HttpContext.Session.GetInt32("UserId")==null){
                return View("Index");
            }else{
                return RedirectToAction("MainMenu");
            }
        }

        [HttpGet("")]
        public IActionResult MainMenu(){
            if(HttpContext.Session.GetInt32("UserId")==null){
                return RedirectToAction("Index");
            }else{
                User this_user = dbContext.Users.FirstOrDefault(user => user.UserId == HttpContext.Session.GetInt32("UserId"));
                ViewBag.Model_user = this_user;
                List<Message> AllWedding = dbContext.Messages
                    .Include(Message => Message.Creator)
                    .Include(Message => Message.MessageComments)
                    .ThenInclude(MessageComments => MessageComments.Creator)
                    .ToList();
                ViewBag.Model_Messages = AllWedding;
                return View("MainMenu");
            }
        }

        [HttpPost("register")]
        public IActionResult Registration(InputChecker Data_get){
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

        [HttpPost("login")]
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

        [HttpPost("newMessage")]
        public IActionResult CreateMessage(InputChecker Data_get){
            Message userSubmission = Data_get.Message;
            if(ModelState.IsValid){
                userSubmission.UserId = (int)HttpContext.Session.GetInt32("UserId");
                dbContext.Add(userSubmission);
                dbContext.SaveChanges();
                return RedirectToAction("MainMenu");

            }else{
                return View("MainMenu");
            }
        }

        [HttpPost("newComment")]
        public IActionResult CreateComment(InputChecker Data_get){
            Comment userSubmission = Data_get.Comment;
            if(ModelState.IsValid){
                userSubmission.UserId = (int)HttpContext.Session.GetInt32("UserId");
                dbContext.Add(userSubmission);
                dbContext.SaveChanges();
                return RedirectToAction("MainMenu");
            }else{
                return View("MainMenu");
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
