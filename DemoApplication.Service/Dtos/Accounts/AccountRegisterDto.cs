using DemoApplication.Domain.Enums;
using DemoApplication.Service.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.Service.Dtos.Accounts
{
    public class AccountRegisterDto
    {
        [Required, MinLength(2), MaxLength(30)]
        public string FullName { get; set; } = string.Empty;
        
        [Required]
        public DateTime BirthDate { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string UserName { get; set; } = string.Empty;

        [Required, StrongPassword]
        public string Password { get; set; } = string.Empty;

        public HumanRole Role { get; set; } = HumanRole.User;
    }
}
