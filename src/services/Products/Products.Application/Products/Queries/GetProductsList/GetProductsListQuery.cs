using MediatR;
using Products.Domain.Base;
using Products.Domain.Products;

namespace Products.Application.Products.Queries.GetProductsList;

public class GetProductsListQuery:ProductDtos.ProductFilterPageReqDto, IRequest<PaginitionResDto<List<ProductDtos.ProductResDto>>>
{
    
}