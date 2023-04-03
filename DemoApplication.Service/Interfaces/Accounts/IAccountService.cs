using DemoApplication.Service.Dtos.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.Service.Interfaces.Accounts
{
    public interface IAccountService
    {
        public Task<bool> RegisterAsync(AccountRegisterDto accountRegisterDto);
        public Task<string> LoginAsync(AccountLoginDto accountLoginDto);
    }
}
