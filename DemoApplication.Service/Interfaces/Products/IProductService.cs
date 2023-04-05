using DemoApplication.Service.Dtos.Products;
using DemoApplication.Service.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.Service.Interfaces.Products
{
    public interface IProductService
    {
        public Task<bool> CreateAsync(ProductCreateDto createDto);
        public Task<bool> UpdateAsync(int id, ProductUpdateDto updateDto);
        public Task<bool> DeleteAsync(int id);
        public Task<ProductViewModel> GetAsync(int id);
        public Task<List<ProductViewModel>> GetAllAsync();
        public Task<List<ProductAuditViewModel>> GetAllAuditAsync();
        public Task<List<ProductAuditViewModel>> GetByAuditAsync(string startDate, string endDate);
    }
}
