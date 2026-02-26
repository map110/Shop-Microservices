using AutoMapper;
using Products.Domain.Products;

namespace Products.Infrastructure.Products;

public class ProductMappingProfile:Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductDtos.ProductReqDto>().ReverseMap();
        CreateMap<Product, ProductDtos.ProductResDto>().ReverseMap();
    }
}