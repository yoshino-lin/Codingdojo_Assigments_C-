using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
using Context.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context){dbContext = context;}

        [HttpGet("/products")]
        public IActionResult Index(){
            List<Product> All_product = dbContext.Products
                .Include(product => product.ProductCategories)
                .ThenInclude(sub => sub.Category)
                .ToList();
            ViewBag.Model = All_product;
            return View();
        }
        [HttpGet("/categories")]
        public IActionResult Categories_Index(){
            return View("Categories_Index");
        }
        [HttpPost("/products")]
        public IActionResult Create_Product(Product the_new_product){    
            if(ModelState.IsValid){
                dbContext.Add(the_new_product);
                dbContext.SaveChanges();
                return RedirectToAction();
            }
            else{
                List<Product> All_product = dbContext.Products
                .Include(product => product.ProductCategories)
                .ThenInclude(sub => sub.Category)
                .ToList();
                ViewBag.Model = All_product;
                return View("Index");
            }
        }
    }
}
