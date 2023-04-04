using DemoApplication.Domain.Entities;
using DemoApplication.Service.Interfaces.Products;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Web.Areas.Admins.Controllers;

[Route("adminProductAudits")]
public class ProductAuditsController : BaseController
{
    private readonly IProductService _service;

    public ProductAuditsController(IProductService service)
    {
        this._service = service;
    }
    public async Task<ViewResult> Index()
    {
        var productAudits = await _service.GetAllAuditAsync();
        return View("Index", productAudits);
    }
}
