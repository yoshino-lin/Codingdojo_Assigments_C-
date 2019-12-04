using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoSurvey_withValidation.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DojoSurvey_withValidation.Controllers
{
    public class HomeController : Controller{
        [HttpGet]
        [Route("")]
        public ViewResult Projects(){
            return View("Index");
        }
        [HttpPost("result")]
        public IActionResult Submission(User yourSurvey){
            if(ModelState.IsValid)
            {   
                return View("Result",yourSurvey);
            }
            else
            {
                return View("Index");
            }
        }
    }
}
