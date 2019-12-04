using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomPasscodeGenerator.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace RandomPasscodeGenerator.Controllers
{
    public class HomeController : Controller
    {
    
        [HttpGet]
        [Route("")]
        public ViewResult Projects(){
            if(HttpContext.Session.GetInt32("count")==null){
                HttpContext.Session.SetInt32("count", 1);
            }else{
                int? time = HttpContext.Session.GetInt32("count");
                HttpContext.Session.SetInt32("count", (int)time+1);
            }
            
            ViewBag.Count = HttpContext.Session.GetInt32("count");
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            string code = "";
            char[] array_each_letter = new char[]  
            {   
                '0','1','2','3','4','5','6','7','8','9',
                'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
            };
            for (int i = 0; i < 14; i++){
                int idx = rand.Next(0,array_each_letter.Count());
                code += array_each_letter[idx];
            }
            ViewBag.Code = code;
            return View("Index");
        }

        [Route("")]
        public IActionResult Generate(){
            int? time = HttpContext.Session.GetInt32("count");
            HttpContext.Session.SetInt32("count", (int)time+1);
            ViewBag.Count = HttpContext.Session.GetInt32("count");
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            string code = "";
            char[] array_each_letter = new char[]  
            {   
                '0','1','2','3','4','5','6','7','8','9',
                'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
            };
            for (int i = 0; i < 14; i++){
                int idx = rand.Next(0,array_each_letter.Count());
                code += array_each_letter[idx];
            }
            ViewBag.Code = code;
            return View("Index");
        }
    }
}
