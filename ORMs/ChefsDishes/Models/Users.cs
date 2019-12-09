using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ChefsDishes.Models
{
    public class Chef{
        [Key]
        public int ChefId { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name = "First Name:")] 
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Date of Birth:")]
        public DateTime Birthday {get;set;}

        public List<Dish> dishOfChef {get;set;}
    }
    
    public class Dish{
        [Key]
        public int DishId { get; set; }

        [Required]
        [MaxLength(45)]
        [Display(Name = "Name of Dish:")]
        public string DishName { get; set; }

        [Required]
        [Range(0,double.PositiveInfinity)]
        [Display(Name = "# of Calories:")]
        public int Calories { get; set; }

        [Required]
        [Display(Name = "Description:")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Chef:")]
        public int ChefId {get;set;}
        
        public Chef Creator {get;set;}

        [Required]
        [Range(1,6)]
        [Display(Name = "Tastiness:")]
        public int Tastiness { get; set; }

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}