using System;

namespace TheWall.Models{
    public class User{
        [Key]
        public int UserId { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name = "First Name:")] 
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
        [Display(Name = "Password:")]
        public string Password {get;set;}

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password:")]
        public string Confirm {get;set;}

        public List<Message> UserMessages {get;set;}
        public List<Comment> UserComments {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
    public class Message{
        [Key]
        public int MessageId { get; set; }

        [Required]
        public string Message_TEXT {get; set;}

        public int UserId {get;set;}
        public User Creator {get;set;}
        
        
        public List<Comment> MessageComments { get; set; }

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
    public class Comment{
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string Comment_TEXT {get; set;}

        public int UserId {get;set;}
        public User Creator {get;set;}

        public int MessageId {get;set;}
        public Message SignTo {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}