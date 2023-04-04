using DemoApplication.Service.Dtos.Products;
using DemoApplication.Service.Interfaces.Products;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Web.Areas.Admins.Controllers;

[Route("adminProducts")]
public class ProductsController : BaseController
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
        return View("Create");
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromForm] ProductCreateDto createDto)
    {
        if (ModelState.IsValid)
        {
            var res = await _service.CreateAsync(createDto);
            if (res)
            {
                return RedirectToAction("Index", "Products", new { area = "Admins" });
            }
            else return Create();
        }
        else return Create();
    }

    [HttpGet("delete")]
    public async Task<IActionResult> DeleteAsync(int productId)
    {
        var result = await _service.DeleteAsync(productId);
        return RedirectToAction("Index", "Products", new { area = "Admins" });
    }

    [HttpGet("update")]
    public async Task<IActionResult> UpdateAsync(int productId)
    {
        var product = await _service.GetAsync(productId);
        ViewBag.productId = productId;
        var productUpdate = new ProductUpdateDto()
        {
            Price = product.Price,
            Title = product.Title,
            Quantity = product.Quantity
        };
        return View("Update", productUpdate);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(int productId,  ProductUpdateDto updateDto)
    {
        var res = await _service.UpdateAsync(productId, updateDto);
        if (res)
        {
            return RedirectToAction("Index", "Products", new { area = "Admins" });
        }
        else return await UpdateAsync(productId);
    }
}
