using AutoMapper;
using MediatR;
using Products.Domain;
using Products.Domain.Base;
using Products.Domain.Products;

namespace Products.Application.Products.Queries.GetProductsList;

public class GetProductsListQueryHandler:IRequestHandler<GetProductsListQuery,PaginitionResDto<List<ProductDtos.ProductResDto>>>
{
    private readonly IReadUnitOfWork _readUnitOfWork;
    private readonly IMapper _mapper;

    public GetProductsListQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
    {
        _readUnitOfWork = readUnitOfWork;
        _mapper = mapper;
    }

    public async Task<PaginitionResDto<List<ProductDtos.ProductResDto>>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
    {
        // var productList = await _readUnitOfWork.ProductReadRepository.GetAllAsync();
        // return _mapper.Map<List<ProductDtos.ProductResDto>>(productList);
        var productList = await _readUnitOfWork.ProductReadRepository.GetByFilterPagedAsync(request);
        PaginitionResDto<List<ProductDtos.ProductResDto>> result = new PaginitionResDto<List<ProductDtos.ProductResDto>>
        {
            Data = _mapper.Map<List<ProductDtos.ProductResDto>>(productList.Item1),
            TotalCount = productList.Item2,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize
        };
        return result;
    }
}