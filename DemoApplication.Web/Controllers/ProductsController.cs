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

    [HttpGet("create")]
    public ViewResult Create()
    {
        return View("ProductCreate");
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromForm] ProductCreateDto createDto)
    {
        if (ModelState.IsValid)
        {
            var res = await _service.CreateAsync(createDto);
            if (res)
            {
                return RedirectToAction("Index", "products", new { area = "" });
            }
            else return Create();
        }
        else return Create();
    }

    [HttpGet("delete")]
    public async Task<IActionResult> DeleteAsync(int productId)
    {
        var result = await _service.DeleteAsync(productId);
        return RedirectToAction("Index", "product", new { area = "" });
    }
}
