using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Person.Models;

namespace RazorFun.Controllers     //be sure to use your own project's namespace!
{
    public class MainController : Controller   //remember inheritance??
    {
        [HttpGet]
        [Route("")]
        public ViewResult Projects(){
            return View("Index");
        }
        [HttpPost]
        [Route("result")]
        public IActionResult Submission(Survey yourSurvey){
            return View("Result",yourSurvey);
        }
    }
}
