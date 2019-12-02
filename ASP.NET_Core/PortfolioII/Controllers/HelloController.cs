using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace PortfolioII.Controllers     //be sure to use your own project's namespace!
{
    public class HelloController : Controller   //remember inheritance??
    {
        [HttpGet]
        [Route("")]
        public ViewResult Index(){
            return View("Index");
        }
        
        [HttpGet]
        [Route("projects")]
        public ViewResult Projects(){
            string[] img_list = {
                "http://www.weipet.cn/common/images/pic/a43.jpg",
                "http://www.xungou66.com/wp-content/uploads/2019/23/374.jpg",
                "https://as.chdev.tw/web/article/b/0/4/b1814323-0790-4b70-a3b1-6cbc87d37d1f/A0951614.jpg"
            };
            return View("Projects",img_list);
            
        }
        [HttpGet]
        [Route("contact")]
        public ViewResult Contact(){
            return View("Contact");
        }

        // You may also serve the same view twice from additional actions
        [HttpGet("elsewhere")]
        public JsonResult Elsewhere(){
            var AnonObject = new {
                FirstName = "Raz",
                LastName = "Aquato",
                Age = 10
            };
            return Json(AnonObject);
        }
    }
}
