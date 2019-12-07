using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsDishes.Models
{
    public class Chef{
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name = "First Name:")] 
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        [Display(Name = "Date of Birth:")]
        public DateTime Birthday {get;set;}
    }
    public class Dish{
        // No other fields!
        [Required]
        
        [Display(Name = "Email:")]
        public string Email {get; set;}
        
        [Required]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}