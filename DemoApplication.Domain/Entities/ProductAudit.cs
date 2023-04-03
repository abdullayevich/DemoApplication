using DemoApplication.Domain.Common;
using DemoApplication.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.Domain.Entities;

public class ProductAudit : Auditable
{
    public ProductStatus Status { get; set; }
    public string OldTitle { get; set; } = string.Empty;
    public string NewTitle { get; set; } = string.Empty;
    public int OldQuantity { get; set; }
    public int NewQuantity { get; set; }
    public double OldPrice { get; set; }
    public double NewPrice { get; set; }
    public int AdminId { get; set; }
    public virtual Admin Admin { get; set; } = default!;
}
