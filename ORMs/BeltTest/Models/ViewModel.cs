using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace BeltTest.Models{
    public class User{
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage="Name is Required!")]
        [MinLength(2)]
        [Display(Name = "Name:")] 
        public string Name { get; set; }

        [Required(ErrorMessage="Email is Required!")]
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

        public List<Activity> CreatedActivities {get;set;}

        public List<Subscription> ActivitiesToGo { get; set; }

    }
    public class Activity{
        [Key]
        public int ActivityId { get; set; }

        [Required]
        [Display(Name = "Title:")]
        public string Title {get; set;}

        [Required]
        [FutureDate]
        [DataType(DataType.Date)]
        [Display(Name = "Date:")]
        public DateTime Date {get; set;}

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Time:")]
        public DateTime Time {get; set;}

        [Required]
        [Range(0,99999999999)]
        [Display(Name = "Duration:")]
        public int Duration {get; set;}

        [Required]
        [Range(1,3, ErrorMessage="You know change code on html will not work, right?")]
        public int DurationType {get; set;}

        [Required]
        [Display(Name = "Description:")]
        public string Description {get; set;}

        public int UserId {get;set;}
        public User Creator {get;set;}
        
        public List<Subscription> GuestsOfActivity { get; set; }

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
    public class LoginUser{
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address:")]
        public string Email {get; set;}
        
        [Required]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class Subscription{
        public int SubscriptionId { get; set; }
        public int UserId { get; set; }
        public int ActivityId { get; set; }
        public User User { get; set; }
        public Activity Activity { get; set; }
    }

    public class ViewWrapper{
        public List<User> Users {get;set;}
        public List<Activity> Activities { get; set; }
        public User User { get; set; }
        public Activity Activity { get; set; }
    }

    public class PastDateAttribute : ValidationAttribute{
        protected override ValidationResult IsValid(object value, ValidationContext validationContext){   
            if(DateTime.Compare((DateTime)value, DateTime.Now)>0){
                return new ValidationResult("The date cannot be in the future!");
            }else{
                return ValidationResult.Success;
            }
        }
    }
    public class FutureDateAttribute : ValidationAttribute{
        protected override ValidationResult IsValid(object value, ValidationContext validationContext){   
            if(DateTime.Compare((DateTime)value, DateTime.Now)<0){
                return new ValidationResult("The date cannot be in the past!");
            }else{
                return ValidationResult.Success;
            }
        }
    }
}