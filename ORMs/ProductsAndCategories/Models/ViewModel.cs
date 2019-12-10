using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ProductsAndCategories.Models
{
    public class Product{
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Required]
        [MinLength(4, ErrorMessage="Description must be 4 characters or longer!")]
        [Display(Name = "Description:")]
        public string Description { get; set; 
        }
        [Required]
        [Display(Name = "Price:")]
        public int Price { get; set; }

        public List<Subscription> ProductCategories {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }

    public class Subscription{
        [Key]
        public int SubscriptionId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
    
    public class Category{
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Subscription> CategoryProducts {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}