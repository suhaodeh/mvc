﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(12)]
        public string Name { get; set; }

        [Required]
        [MinLength(12)]
        public string Description { get; set; }
        public List<Product>? Products { get; set; }
    }
}
