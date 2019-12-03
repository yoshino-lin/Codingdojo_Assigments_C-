using Microsoft.AspNetCore.Mvc;
using ValidatingFormSubmission.Models;

namespace ValidatingFormSubmission.Controllers
{
    public class HomeController : Controller
    {   
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("result")]
        public IActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {   
                return View("Result");
            }
            else
            {
                return View("Index");
            }
        }
    }
}
