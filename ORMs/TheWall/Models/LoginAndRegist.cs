using Microsoft.EntityFrameworkCore;

namespace TheWall.Models{
    public class InputChecker{
        public User User {get;set;}
        public Message Message {get;set;}
        public Comment Comment {get;set;}
    }
}
