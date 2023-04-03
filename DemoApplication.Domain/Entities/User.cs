using DemoApplication.Domain.Common;
using DemoApplication.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.Domain.Entities;
public class User : Auditable
{
    public string FullName { get; set; } = string.Empty; 
    public DateTime BirthDate { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public HumanRole Role { get; set; } = HumanRole.User;
}
