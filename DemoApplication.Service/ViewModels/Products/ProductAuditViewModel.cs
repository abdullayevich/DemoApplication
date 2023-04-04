using DemoApplication.Domain.Entities;
using DemoApplication.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.Service.ViewModels.Products
{
    public class ProductAuditViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set;} = string.Empty;
        public ProductStatus Status { get; set; }
        public string OldTitle { get; set; } = string.Empty;
        public string NewTitle { get; set; } = string.Empty;
        public int OldQuantity { get; set; }
        public int NewQuantity { get; set; }
        public double OldPrice { get; set; }
        public double NewPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
