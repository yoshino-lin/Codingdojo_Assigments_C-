using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAccounts.Models;
using Context.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BankAccounts.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context){dbContext = context;}

        [HttpGet("")]
        public IActionResult Index(){
            if(HttpContext.Session.GetString("UserId")==null){
                return View();
            }else{
                return account_info();
            }
        }

        [HttpGet("login")]
        public IActionResult login(){
            if(HttpContext.Session.GetInt32("UserId")==null){
                return View("Login");
            }else{
                return account_info();
            }
        }

        [HttpGet("account")]
        public IActionResult account_info(){
            if(HttpContext.Session.GetInt32("UserId")==null){
                return login();
            }else{
                List<Transaction> TransactionOfThisUser = dbContext.Transactions
                    .Where(transaction => transaction.UserId == (int)HttpContext.Session.GetInt32("UserId"))
                    .ToList();
                ViewBag.Records = TransactionOfThisUser;
                User the_User_name = dbContext.Users.FirstOrDefault(user => user.UserId == HttpContext.Session.GetInt32("UserId"));
                ViewBag.Name = the_User_name.FirstName+" "+the_User_name.LastName;
                decimal Balance = 0;
                foreach(var record in TransactionOfThisUser){
                    Balance += record.Amount;
                }
                ViewBag.Balance = Balance;
                return View("Account");
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
                    return account_info();
                }
            }else{
                return View("Index");
            }
        }

        [HttpPost("login")]
        public IActionResult LoginCheck(LoginUser userSubmission){
            if(ModelState.IsValid){
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
                if(userInDb == null){
                    ModelState.AddModelError("Email", "Invalid Email");
                    return login();
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                if(result == 0){
                    ModelState.AddModelError("Password", "Password Incorrect!");
                    return login();;
                }else{
                    HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                    return account_info();
                }
            }else{
                return login();
            }
        }
        [HttpPost("logout")]
        public IActionResult LogOut(LoginUser userSubmission){
            HttpContext.Session.Clear();
            return login();
        }
        
        [HttpPost("account")]
        public IActionResult makeTransaction(Transaction newRecord){
            if(ModelState.IsValid){
                newRecord.UserId = (int)HttpContext.Session.GetInt32("UserId");
                dbContext.Add(newRecord);
                dbContext.SaveChanges();
            }
            return account_info();
        }
    }
}
