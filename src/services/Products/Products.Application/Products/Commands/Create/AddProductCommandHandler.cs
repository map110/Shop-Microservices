using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Domain;
using Products.Domain.Products;

namespace Products.Application.Products.Commands.Create;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ProductDtos.ProductResDto>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<AddProductCommandHandler> _logger;

    public AddProductCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper,
        ILogger<AddProductCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ProductDtos.ProductResDto> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var newProduct = _mapper.Map<Product>(request);
        var addedProduct = await _writeUnitOfWork.ProductWriteRepository.AddAsync(newProduct);
        _logger.LogInformation($"product {addedProduct.Id} is successfully added.");
        return _mapper.Map<ProductDtos.ProductResDto>(addedProduct);
    }
}