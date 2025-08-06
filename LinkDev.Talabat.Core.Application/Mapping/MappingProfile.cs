using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Products;
using LinkDev.Talabat.Core.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Application.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>().ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand!.Name))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category!.Name)).ForMember(dest=>dest.PictureUrl,opt=>opt.MapFrom<ProductPictureUrlResolver>());
            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductCategory, CategoryDto>();
               
        }
    }
}
