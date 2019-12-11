using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Models{
    public class OnlineChecker{
        public User User {get;set;}
        public LoginUser LoginUser {get;set;}
        public Wedding Wedding {get;set;}
    }
}
