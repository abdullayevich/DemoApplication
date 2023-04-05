using DemoApplication.DataAccess.Interfaces;
using DemoApplication.Domain.Entities;
using DemoApplication.Domain.Enums;
using DemoApplication.Service.Dtos.Products;
using DemoApplication.Service.Interfaces.Products;
using DemoApplication.Service.ViewModels.Products;
using DemoApplication.Service.Common.Exceptions;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DemoApplication.Service.Interfaces.Common;

namespace DemoApplication.Service.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIdentityService _identityService;

        public ProductService(IUnitOfWork unitOfWork, IIdentityService identityService)
        {
            this._unitOfWork = unitOfWork;
            this._identityService = identityService;
        }

        public async Task<bool> CreateAsync(ProductCreateDto createDto)
        {
            var product = new Product()
            {
                Title = createDto.Title,
                Quantity = createDto.Quantity,
                Price = createDto.Price,
                CreatedAt = DateTime.Now,
                LastUpdatedAt = DateTime.Now
            };
            var res = _unitOfWork.Products.Add(product);
            var productAudit = new ProductAudit()
            {
                CreatedAt = DateTime.Now,
                LastUpdatedAt = DateTime.Now,
                NewPrice = product.Price,
                OldPrice = 0,
                NewQuantity = product.Quantity,
                OldQuantity = 0,
                NewTitle = product.Title,
                OldTitle = string.Empty,
                Status = ProductStatus.Created,
                AdminId = _identityService.Id!.Value,
            };
            _unitOfWork.ProductAudits.Add(productAudit);
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _unitOfWork.Products.FindByIdAsync(id);
            if (product == null) throw new StatusCodeException(HttpStatusCode.NotFound, "Product not found!");
            _unitOfWork.Products.Delete(id);
            var productAudit = new ProductAudit()
            {
                CreatedAt = DateTime.Now,
                LastUpdatedAt = DateTime.Now,
                NewPrice = 0,
                OldPrice = product.Price,
                NewQuantity = 0,
                OldQuantity = product.Quantity,
                NewTitle = string.Empty,
                OldTitle = product.Title,
                Status = ProductStatus.Deleted,
                AdminId = _identityService.Id!.Value,
            };
            _unitOfWork.ProductAudits.Add(productAudit);
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            var result = await _unitOfWork.Products.GetAll().OrderByDescending(x => x.CreatedAt).Select(x => (ProductViewModel)x).ToListAsync();
            return result;
        }

        public Task<List<ProductAuditViewModel>> GetAllAuditAsync()
        {
            var result = (from productAudit in _unitOfWork.ProductAudits.GetAll()
                          join admin in _unitOfWork.Admins.GetAll()
                          on productAudit.AdminId equals admin.Id
                          select new ProductAuditViewModel()
                          {
                              Id = productAudit.Id,
                              FullName = admin.FullName,
                              UserName = admin.UserName,
                              NewTitle = productAudit.NewTitle,
                              OldTitle = productAudit.OldTitle,
                              NewQuantity = productAudit.NewQuantity,
                              OldQuantity = productAudit.OldQuantity,
                              NewPrice = productAudit.NewPrice,
                              OldPrice = productAudit.OldPrice,
                              Status = productAudit.Status,
                              Date = productAudit.CreatedAt
                          }).OrderByDescending(x => x.Date).ToListAsync();
            return result;
        }
        public Task<List<ProductAuditViewModel>> GetByAuditAsync(string startDate, string endDate)
        {
            var result = (from productAudit in _unitOfWork.ProductAudits.GetAll()
                          .Where(x => x.CreatedAt >= DateTime.Parse(startDate) && x.CreatedAt <= DateTime.Parse(endDate))
                          join admin in _unitOfWork.Admins.GetAll()
                          on productAudit.AdminId equals admin.Id
                          select new ProductAuditViewModel()
                          {
                              Id = productAudit.Id,
                              FullName = admin.FullName,
                              UserName = admin.UserName,
                              NewTitle = productAudit.NewTitle,
                              OldTitle = productAudit.OldTitle,
                              NewQuantity = productAudit.NewQuantity,
                              OldQuantity = productAudit.OldQuantity,
                              NewPrice = productAudit.NewPrice,
                              OldPrice = productAudit.OldPrice,
                              Status = productAudit.Status,
                              Date = productAudit.CreatedAt
                          }).OrderByDescending(x => x.Date).ToListAsync();
            return result;
        }

        public async Task<ProductViewModel> GetAsync(int id)
        {
            var product = await _unitOfWork.Products.FindByIdAsync(id);
            if (product is null) throw new StatusCodeException(HttpStatusCode.NotFound, "Product not found!");
            return (ProductViewModel)product;
        }

        public async Task<bool> UpdateAsync(int id, ProductUpdateDto updateDto)
        {
            var product = await _unitOfWork.Products.FindByIdAsync(id);
            if (product is null) throw new StatusCodeException(HttpStatusCode.NotFound, "Product not found!");

            _unitOfWork.Products.TrackingDeteched(product);

            var productAudit = new ProductAudit()
            {
                CreatedAt = DateTime.Now,
                LastUpdatedAt = DateTime.Now,
                NewPrice = updateDto.Price,
                OldPrice = product.Price,
                NewQuantity = updateDto.Quantity,
                OldQuantity = product.Quantity,
                NewTitle = updateDto.Title,
                OldTitle = product.Title,
                Status = ProductStatus.Updated,
                AdminId = _identityService.Id!.Value,
            };

            product.LastUpdatedAt = DateTime.Now;
            product.Price = updateDto.Price;
            product.Quantity = updateDto.Quantity;
            product.Title = updateDto.Title;

            _unitOfWork.Products.Update(id, product);

            _unitOfWork.ProductAudits.Add(productAudit);
            var res = await _unitOfWork.SaveChangesAsync();
            return res > 0;
        }

        public async Task<List<ProductViewModel>> GetAllByDateAsync(string from, string to)
        {
            var res = await _unitOfWork.Products.GetAll()
                      .Where(x => x.CreatedAt >= DateTime.Parse(from) && x.CreatedAt <= DateTime.Parse(to))
                      .OrderByDescending(x => x.CreatedAt).Select(x => (ProductViewModel)x).ToListAsync();
            return res;
        }
    }
}
