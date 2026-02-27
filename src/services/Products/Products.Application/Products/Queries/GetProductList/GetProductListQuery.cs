using MediatR;
using Products.Domain.Products;

namespace Products.Application.Products.Queries.GetProductList;

public class GetProductListQuery:IRequest<List<ProductDtos.ProductResDto>>
{
    
}