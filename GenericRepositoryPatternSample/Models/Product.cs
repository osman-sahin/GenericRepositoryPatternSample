using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GenericRepositoryPatternSample.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
