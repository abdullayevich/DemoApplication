using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApplication.Domain.Entities;

namespace DemoApplication.Service.ViewModels.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public static implicit operator ProductViewModel(Product product)
        {
            return new ProductViewModel()
            {
                Id = product.Id,
                CreateAt = product.CreatedAt,
                Price = product.Price,
                Quantity = product.Quantity,
                Title = product.Title,
                UpdateAt = product.LastUpdatedAt
            };
        }
    }
}
