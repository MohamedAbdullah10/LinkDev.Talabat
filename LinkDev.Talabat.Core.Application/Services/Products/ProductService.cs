using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Products;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Products;
using LinkDev.Talabat.Core.Domain.Contract.Persistence;
using LinkDev.Talabat.Core.Domain.Entities.Products;
using LinkDev.Talabat.Core.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Application.Services.Products
{
    internal class ProductService(IUnitOfWork unitOfWork,IMapper mapper) : IProductService
    {
        public async Task<IEnumerable<BrandDto>> GetBrandsAsync()
        {
           var brands= await unitOfWork.GetRepository<ProductBrand,int>().GetAllAsync();
            var brandtoReturn = mapper.Map<IEnumerable<BrandDto>>(brands);
            return brandtoReturn;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categorys = await unitOfWork.GetRepository<ProductCategory, int>().GetAllAsync();
            var categorytoReturn = mapper.Map<IEnumerable<CategoryDto>>(categorys);
            return categorytoReturn;
        }

        public async Task<ProductToReturnDto?> GetProductByIdAsync(int id)
        {
            var spec = new ProductWithBrandAndCategorySpecifications(id);
            var product= await unitOfWork.GetRepository<Product,int>().GetByIdWithSpecAsync(spec);
            if (product == null) return null;
            var productToReturn = mapper.Map<ProductToReturnDto>(product);
            return productToReturn;
        }

        public async Task<IEnumerable<ProductToReturnDto>> GetProductsAsync()
        {
            var spec = new ProductWithBrandAndCategorySpecifications();

            var products = await unitOfWork.GetRepository<Product, int>().GetAllWithSpecAsync(spec);
            var productsToReturn = mapper.Map<IEnumerable<ProductToReturnDto>>(products);
            return productsToReturn;
        }
    }
}
