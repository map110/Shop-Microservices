using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Products.Domain;
using Products.Domain.Products;

namespace Products.Application.Products.Commands.Create;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ProductDtos.ProductResDto>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<AddProductCommandHandler> _logger;
    private readonly IPublishEndpoint _publishEndpoint;

    public AddProductCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper,
        ILogger<AddProductCommandHandler> logger, IPublishEndpoint publishEndpoint)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _mapper = mapper;
        _logger = logger;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<ProductDtos.ProductResDto> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var newProduct = _mapper.Map<Product>(request);
        var addedProduct = await _writeUnitOfWork.ProductWriteRepository.AddAsync(newProduct);
        _logger.LogInformation($"product {addedProduct.Id} is successfully added.");

        var addProductEvent = new AddProductEvent
        {
            ProductId = addedProduct.Id,
            ProductTitle = addedProduct.Title
        };
        await _publishEndpoint.Publish(addProductEvent);

        return _mapper.Map<ProductDtos.ProductResDto>(addedProduct);
    }
}