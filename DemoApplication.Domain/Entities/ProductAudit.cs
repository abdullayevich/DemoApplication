using DemoApplication.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.Domain.Entities;

public class ProductAudit : Auditable
{
    public string FullName { get; set; } = string.Empty;
    public string OldTitle { get; set; } = string.Empty;
    public string NewTitle { get; set; } = string.Empty;
    public int OldQuantity { get; set; }
    public int NewQuantity { get; set; }
    public double OldPrice { get; set; }
    public double NewPrice { get; set; }
}
