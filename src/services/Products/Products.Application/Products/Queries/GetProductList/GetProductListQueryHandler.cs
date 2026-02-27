using AutoMapper;
using MediatR;
using Products.Domain;
using Products.Domain.Products;

namespace Products.Application.Products.Queries.GetProductList;

public class GetProductListQueryHandler:IRequestHandler<GetProductListQuery,List<ProductDtos.ProductResDto>>
{
    private readonly IReadUnitOfWork _readUnitOfWork;
    private readonly IMapper _mapper;

    public GetProductListQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
    {
        _readUnitOfWork = readUnitOfWork;
        _mapper = mapper;
    }

    public async Task<List<ProductDtos.ProductResDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        var productList = await _readUnitOfWork.ProductReadRepository.GetAllAsync();
        return _mapper.Map<List<ProductDtos.ProductResDto>>(productList);
    }
}