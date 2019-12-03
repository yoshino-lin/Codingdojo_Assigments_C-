using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RazorFun.Controllers     //be sure to use your own project's namespace!
{
    public class MainController : Controller   //remember inheritance??
    {
        [HttpGet]
        [Route("")]
        public ViewResult Projects(){
            return View("Index");
        }
    }
}
