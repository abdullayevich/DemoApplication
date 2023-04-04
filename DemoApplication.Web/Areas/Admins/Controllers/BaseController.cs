using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DemoApplication.Web.Areas.Admins.Controllers;
[Area("admins")]
[Authorize(Roles = "Admin")]
public class BaseController : Controller
{
}
