using DemoApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.Service.Interfaces.Common
{
    public interface IAuthService
    {
        public string GenerateToken(User user);
        public string GenerateTokenAdmin(Admin admin);
    }
}
