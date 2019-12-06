using System;
using System.ComponentModel.DataAnnotations;

namespace LoginAndRegistration.Models{
    public class User{
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(45)]
        [Display(Name = "Chef's Name:")] 
        public string Name { get; set; }

        [Required]
        [MaxLength(45)]
        [Display(Name = "Name of Dish:")]
        public string DishName { get; set; }

        [Required]
        [Range(0,double.PositiveInfinity)]
        [Display(Name = "# of Calories:")]
        public int Calories { get; set; }


        [Required]
        [Range(1,6)]
        [Display(Name = "Tastiness:")]
        public int Tastiness { get; set; }

        [Required]
        [Display(Name = "Description:")]
        public string Description { get; set; }

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}