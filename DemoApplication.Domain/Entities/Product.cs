using DemoApplication.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.Domain.Entities;

public class Product : Auditable
{
    public string Title { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public double Price { get; set; }
}
