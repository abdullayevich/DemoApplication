using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.Service.Dtos.Products
{
    public class ProductUpdateDto
    {
        [Required, MinLength(2), MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
