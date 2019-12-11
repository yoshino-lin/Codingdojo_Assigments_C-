using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WeddingPlanner.Models{
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

        public List<Wedding> CreatedWeddings {get;set;}

        public List<Subscription> WeddingsToGo { get; set; }

    }
    public class Wedding{
        [Key]
        public int WeddingId { get; set; }

        [Required]
        [Display(Name = "Wedder One:")]
        public string Wedder1 {get; set;}

        [Required]
        [Display(Name = "Wedder Two:")]
        public string Wedder2 {get; set;}

        [Required]
        [FutureDate]
        [DataType(DataType.Date)]
        [Display(Name = "Date:")]
        public DateTime Date {get; set;}

        [Required]
        [Display(Name = "Wedding Address:")]
        public string Address {get; set;}

        public int UserId {get;set;}
        public User Creator {get;set;}
        
        public List<Subscription> GuestsOfWedding { get; set; }

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
        public int WeddingId { get; set; }
        public User User { get; set; }
        public Wedding Wedding { get; set; }
    }

    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {   
            if(DateTime.Compare((DateTime)value, DateTime.Now)>0){
                return new ValidationResult("The date cannot be in the future!");
            }else{
                return ValidationResult.Success;
            }
        }
    }
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {   
            if(DateTime.Compare((DateTime)value, DateTime.Now)<0){
                return new ValidationResult("The date cannot be in the past!");
            }else{
                return ValidationResult.Success;
            }
        }
    }
}