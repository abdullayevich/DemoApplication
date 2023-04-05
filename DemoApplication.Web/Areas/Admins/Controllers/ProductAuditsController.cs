using DemoApplication.Domain.Entities;
using DemoApplication.Service.Dtos.Products;
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
        var result = new ProductGetByDateDto()
        {
            ProductAudits = productAudits,
            StartDate = DateTime.Now.ToString("yyyy-MM-dd"),
            EndDate = DateTime.Now.ToString("yyyy-MM-dd")
        };
        return View("Index", result);
    }

    [HttpPost("GetAllByDate")]
    public async Task<ViewResult> GetAllByDateAsync(ProductGetByDateDto productGet)
    {
        if (ModelState.IsValid)
        {
            var res = await _service.GetByAuditAsync(productGet.StartDate, productGet.EndDate);
            var result = new ProductGetByDateDto()
            {
                StartDate = productGet.StartDate,
                EndDate = productGet.EndDate,
                ProductAudits = res
            };
            return View("Index", result);
        }
        else return View("Index");
    }

    [HttpGet("productAudits-by-date")]
    public async Task<IActionResult> GetByDateAsync(string from, string to)
    {
        return Ok(await _service.GetByAuditAsync(from, to));
    }
}
