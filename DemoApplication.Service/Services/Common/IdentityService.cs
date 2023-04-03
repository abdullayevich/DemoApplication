using DemoApplication.Service.Interfaces.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.Service.Services.Common
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _accessor;
        public IdentityService(IHttpContextAccessor accessor)
        {
            this._accessor = accessor;
        }
        public int? Id
        {
            get
            {
                var res = _accessor.HttpContext.User.FindFirst("Id");
                return res is not null ? int.Parse(res.Value) : null;
            }
        }
    }
}
