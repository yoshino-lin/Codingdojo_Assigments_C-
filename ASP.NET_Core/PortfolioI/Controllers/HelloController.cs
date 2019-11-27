using Microsoft.AspNetCore.Mvc;
namespace PortfolioI.Controllers     //be sure to use your own project's namespace!
{
    public class HelloController : Controller   //remember inheritance??
    {
        //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("")]     //associated route string (exclude the leading /)
        public string Index()
        {
            return "This is my Index!";
        }
        [HttpGet]
        [Route("projects")]
        public string ind2()
        {
            return "These are my projects";
        }
        [HttpGet]
        [Route("contact")]
        public string UserInfo()
        {
            return "This is my Contact";
        }
    }
}
