using System.ComponentModel.DataAnnotations;
using System;
namespace ValidatingFormSubmission.Models
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {   
            if(DateTime.Compare((DateTime)value, DateTime.Now)>0){
                return new ValidationResult("Your Birthday cannot be in the future!");
            }else{
                return ValidationResult.Success;
            }
        }
    }
    public class User
    {   
        [Required]
        [MinLength(4)]
        [Display(Name = "First Name:")] 
        public string FirstName { get; set; }

        [Required]
        [MinLength(4)]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Required]
        [Range(0,double.PositiveInfinity)]
        [Display(Name = "Age:")]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address:")]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]
        [FutureDate]
        public DateTime Birthday { get; set; }
    }
}