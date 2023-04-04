using DemoApplication.Service.Dtos.Products;
using DemoApplication.Service.Interfaces.Products;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Web.Controllers;

[Route("products")]
public class ProductsController : Controller
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        this._service = service;
    }
    public async Task<ViewResult> Index()
    {
        var products = await _service.GetAllAsync();
        return View("Index", products);
    }
}
