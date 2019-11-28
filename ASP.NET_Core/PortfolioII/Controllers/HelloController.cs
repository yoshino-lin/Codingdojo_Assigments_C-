using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace PortfolioII.Controllers     //be sure to use your own project's namespace!
{
    public class HelloController : Controller   //remember inheritance??
    {
        [HttpGet]
        [Route("")]
        public ViewResult Index()
        {
            // will attempt to serve 
                // Views/Hello/Index.cshtml
            // or if that file isn't there:
                // Views/Shared/Index.cshtml
            return View();
        }
        [HttpGet]
        [Route("info")]
        public ViewResult Info()
        {
            // Same logic for serving a view applies
            // if we provide the the exact view name
            return View("Info");
        }
        // You may also serve the same view twice from additional actions
        [HttpGet("elsewhere")]
        public ViewResult Elsewhere()
        {
            return View("Index");
        }
    }
}
