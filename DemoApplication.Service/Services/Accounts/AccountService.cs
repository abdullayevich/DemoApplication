using DemoApplication.DataAccess.Interfaces;
using DemoApplication.Service.Common.Security;
using DemoApplication.Service.Dtos.Accounts;
using DemoApplication.Service.Interfaces.Accounts;
using DemoApplication.Service.Interfaces.Common;
using DemoApplication.Service.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using DemoApplication.Domain.Entities;

namespace DemoApplication.Service.Services.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _repository;
        private readonly IAuthService _authService;

        public AccountService(IUnitOfWork unitOfWork, IAuthService authService)
        {
            this._authService = authService;
            this._repository = unitOfWork;
        }
        public async Task<string> LoginAsync(AccountLoginDto accountLoginDto)
        {
            var admin = await _repository.Admins.FirstOrDefault(x => x.UserName == accountLoginDto.UserName);
            if (admin is null)
            {
                var user = await _repository.Users.FirstOrDefault(x => x.UserName == accountLoginDto.UserName);
                if (user is null) throw new NotFoundException(nameof(accountLoginDto.UserName), "No user with this phone number is found!");
                else
                {
                    var hasherResult = PasswordHasher.Verify(accountLoginDto.Password, user.Salt, user.PasswordHash);
                    if (hasherResult)
                    {
                        string token = _authService.GenerateToken(user);
                        return token;
                    }
                    else throw new NotFoundException(nameof(accountLoginDto.Password), "Incorrect password!");
                }
            }
            else
            {
                var hasherResult = PasswordHasher.Verify(accountLoginDto.Password, admin.Salt, admin.PasswordHash);
                if (hasherResult)
                {
                    string token = "";
                    if (admin.UserName != null)
                    {
                        token = _authService.GenerateTokenAdmin(admin);
                        return token;
                    }
                    token = _authService.GenerateTokenAdmin(admin);
                    return token;
                }
                else throw new NotFoundException(nameof(accountLoginDto.Password), "Incorrect password!");
            }
        }

        public async Task<bool> RegisterAsync(AccountRegisterDto accountRegisterDto)
        {
            var userNameCheckUser = await _repository.Users.FirstOrDefault(x => x.UserName == accountRegisterDto.UserName);
            if (userNameCheckUser != null) throw new StatusCodeException(HttpStatusCode.Conflict, "User Name alredy exist");

            var userNameCheckAdmin = await _repository.Admins.FirstOrDefault(x => x.UserName == accountRegisterDto.UserName);
            if (userNameCheckAdmin != null) throw new StatusCodeException(HttpStatusCode.Conflict, "User Name alredy exist");

            if (accountRegisterDto.Role == Domain.Enums.HumanRole.Admin)
            {
                var hashResult = PasswordHasher.Hash(accountRegisterDto.Password);
                var admin = new Admin()
                {
                    PasswordHash = hashResult.Hash,
                    Salt = hashResult.Salt,
                    BirthDate = accountRegisterDto.BirthDate,
                    CreatedAt = DateTime.Now,
                    FullName = accountRegisterDto.FullName,
                    LastUpdatedAt = DateTime.Now,
                    UserName = accountRegisterDto.UserName,
                    Role = accountRegisterDto.Role,
                };
                _repository.Admins.Add(admin);
                var result = await _repository.SaveChangesAsync();
                return result > 0;
            }
            else
            {
                var hashResult = PasswordHasher.Hash(accountRegisterDto.Password);
                var user = new User()
                {
                    PasswordHash = hashResult.Hash,
                    Salt = hashResult.Salt,
                    BirthDate = accountRegisterDto.BirthDate,
                    CreatedAt = DateTime.Now,
                    FullName = accountRegisterDto.FullName,
                    LastUpdatedAt = DateTime.Now,
                    UserName = accountRegisterDto.UserName,
                    Role = accountRegisterDto.Role
                };
                _repository.Users.Add(user);
                var result = await _repository.SaveChangesAsync();
                return result > 0;
            }
        }
    }
}
