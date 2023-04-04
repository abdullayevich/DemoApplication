using DemoApplication.Service.Dtos.Accounts;
using DemoApplication.Service.Interfaces.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Web.Areas.Admins.Controllers
{
    [Route("adminAccounts")]
    public class AccountsController : BaseController
    {

        private readonly IAccountService _service;
        public AccountsController(IAccountService accountService)
        {
            this._service = accountService;
        }

        [HttpGet("register")]
        public ViewResult Register()
        {
            return View("../Accounts/Register");
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(AccountRegisterDto accountRegisterDto)
        {
            if (ModelState.IsValid)
            {
                accountRegisterDto.Role = Domain.Enums.HumanRole.Admin;
                bool result = await _service.RegisterAsync(accountRegisterDto);
                if (result)
                {
                    return RedirectToAction("login", "accounts", new { area = "" });
                }
                else
                {
                    return Register();
                }
            }
            else return Register();
        }
    }
}
