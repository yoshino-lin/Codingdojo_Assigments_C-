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
            List<Category> All_category = dbContext.Categories
                .Include(category => category.CategoryProducts)
                .ThenInclude(sub => sub.Product)
                .ToList();
            ViewBag.Model = All_category;
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
        [HttpGet("/products/{productId}")]
        public IActionResult ProductEdit(int productId){
            Product the_product = dbContext.Products
                .Include(product => product.ProductCategories)
                .ThenInclude(sub => sub.Category)
                .FirstOrDefault(product => product.ProductId == productId);
            List<Category> All_Categories = dbContext.Categories.ToList();
            ViewBag.All_Categories = All_Categories;
            ViewBag.the_product = the_product;
            return View("EditProduct");
        }
        [HttpPost("/products/{productId}")]
        public IActionResult Add_Category_to_Product(int productId,Subscription newrelation){
            newrelation.ProductId=productId;
            dbContext.Add(newrelation);
            dbContext.SaveChanges();

            Product the_product = dbContext.Products
                .Include(product => product.ProductCategories)
                .ThenInclude(sub => sub.Category)
                .FirstOrDefault(product => product.ProductId == productId);
            List<Category> All_Categories = dbContext.Categories.ToList();
            ViewBag.All_Categories = All_Categories;
            ViewBag.the_product = the_product;
            return View("EditProduct");
        }

        [HttpPost("/categories")]
        public IActionResult Create_Category(Category the_new_category){
            if(ModelState.IsValid){
                dbContext.Add(the_new_category);
                dbContext.SaveChanges();
                return RedirectToAction("Categories_Index");
            }
            else{
                List<Category> All_category = dbContext.Categories
                .Include(category => category.CategoryProducts)
                .ThenInclude(sub => sub.Product)
                .ToList();
                ViewBag.Model = All_category;
                return View("Categories_Index");
            }
        }
        [HttpGet("/category/{categoryId}")]
        public IActionResult CategoryEdit(int categoryId){
            Category the_category = dbContext.Categories
                .Include(category => category.CategoryProducts)
                .ThenInclude(sub => sub.Product)
                .FirstOrDefault(category => category.CategoryId == categoryId);

            List<Product> All_product = dbContext.Products.ToList();
            ViewBag.New = All_product;
            return View("EditCategory",the_category);
        }
        
    }
}
