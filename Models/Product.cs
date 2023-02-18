﻿using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace ShoppingCart.Models
{
    public class Product
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Please enter a value")]

        public string Name { get; set; }
        public string Slug{ get; set; }

        [Required, MinLength(4, ErrorMessage = "Minimum length is 2")]


        public string Description { get; set; }
        public decimal Price { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public string Image { get; set; }

    }
}
