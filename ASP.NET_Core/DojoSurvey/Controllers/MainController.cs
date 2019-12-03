using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IActionResult Method(string name, string location, string language, string comment){
            ViewBag.Example = new List<string>
            {
                name,
                location,
                language,
                comment
            };
            return View("Result");
        }
    }
}
